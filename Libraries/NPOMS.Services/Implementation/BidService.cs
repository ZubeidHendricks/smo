using AutoMapper;

using NPOMS.Domain.Core;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Dropdown;
using NPOMS.Services.Interfaces;
using NPOMS.Services.Models;
using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using NPOMS.Domain.Dropdown;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using NPOMS.Domain.Mapping;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Repository.Implementation.Entities;
using System.Data;

namespace NPOMS.Services.Implementation
{
	public class BidService : IBidService
	{
		#region Fields

		private readonly IFundingApplicationDetailsRepository _fundingApplicationDetailsRepository;
		private readonly INpoService _npoService;
		private readonly IUserRepository _userRepository;
		private readonly IProjectImplementationRepository _bidImplementationRepository;
		private readonly IFinancialMattersRepository _finalcialMattersRepository;
		private readonly IMonitoringEvaluationRepository _monitoringEvaluationRepository;
		//
		private readonly IFinancialYearRepository _finYearRepository;

		private readonly IPropertyTypeRepository _propertyTypeRepository;
		private readonly IDistrictCouncilRepository _districtRepository;
		private readonly ILocalMunicipalityRepository _localMunicipalityRepository;
		private readonly IPlaceRepository _placeRepository;
		private readonly IRegionRepository _regionRepository;
		private readonly ISubPlaceRepository _subPlaceRepository;
		private readonly IFundAppRegionRepository _bidRegionRepository;
		private readonly IServiceDeliveryAreaRepository _serviceDeliveryAreaRepository;
		private readonly IPropertySubTypeRepository _propertySubTypeRepository;
		private readonly IProjectImplementationSubPlaceRepository _implementationSubPlaceRepository;
		private readonly IMapper _mapper;
		private readonly IFundAppServiceDeliveryAreaRepository _BidServiceDeliveryAreaRepository;
		private readonly IFundAppSDADetailRepository _geographicalDetailsRepositoryRepository;
		private readonly IProjectInformationRepository _projectInformationRepository;
		private readonly IProjectImplementationPlaceRepository _implementationPlaceRepository;
		private readonly IApplicationDetailsRepository _applicationDetailsRepository;
		private readonly IApplicationPeriodService _applicationPeriodService;
        private readonly IProgrameDeliveryService _programeDeliveryService;
        private readonly IBidRepository _bidRepository;
        private readonly IApplicationService _applicationService;


        public BidService(IFundingApplicationDetailsRepository fundingApplicationDetailsRepository, INpoService npoService, IProjectImplementationRepository bidImplementationRepository
			, IFinancialMattersRepository financialMattersRepository, IApplicationDetailsRepository applicationDetailsRepository, IFinancialYearRepository finYearRepository
			, IPropertyTypeRepository propertyTypeRepository, IPropertySubTypeRepository propertySubTypeRepository, IUserRepository userRepository,
			IMapper mapper, IProjectImplementationSubPlaceRepository implementationSubPlaceRepository, IProjectImplementationPlaceRepository implementationPlaceRepository, IDistrictCouncilRepository districtRepository, ILocalMunicipalityRepository localMunicipalityRepository, IPlaceRepository placeRepository,
			IRegionRepository regionRepository, ISubPlaceRepository subPlaceRepository, IApplicationPeriodService applicationPeriodService,
			IFundAppServiceDeliveryAreaRepository bidServiceDeliveryAreaRepository, IProjectInformationRepository projectInformationRepository,
		IServiceDeliveryAreaRepository serviceDeliveryAreaRepository, IFundAppRegionRepository bidRegionRepository, IFundAppSDADetailRepository geographicalDetailsRepositoryRepository, IMonitoringEvaluationRepository monitoringEvaluationRepository, IBidRepository bidRepository,
         IProgrameDeliveryService programeDeliveryService, IApplicationService applicationService)
		{
			_fundingApplicationDetailsRepository = fundingApplicationDetailsRepository;
			_bidRegionRepository = bidRegionRepository;
			_npoService = npoService;
			_applicationDetailsRepository = applicationDetailsRepository;
			_projectInformationRepository = projectInformationRepository;
			_userRepository = userRepository;
			_bidImplementationRepository = bidImplementationRepository;
			_finalcialMattersRepository = financialMattersRepository;
			_finYearRepository = finYearRepository;
			_BidServiceDeliveryAreaRepository = bidServiceDeliveryAreaRepository;
			_propertyTypeRepository = propertyTypeRepository;
			_propertySubTypeRepository = propertySubTypeRepository;
			this._mapper = mapper;
			_districtRepository = districtRepository;
			_localMunicipalityRepository = localMunicipalityRepository;
			_placeRepository = placeRepository;
			_regionRepository = regionRepository;
			_subPlaceRepository = subPlaceRepository;
			_serviceDeliveryAreaRepository = serviceDeliveryAreaRepository;
			_implementationSubPlaceRepository = implementationSubPlaceRepository;
			_implementationPlaceRepository = implementationPlaceRepository;
			_geographicalDetailsRepositoryRepository = geographicalDetailsRepositoryRepository;
			_monitoringEvaluationRepository = monitoringEvaluationRepository;
			_applicationPeriodService = applicationPeriodService;
			_bidRepository = bidRepository;
            _programeDeliveryService = programeDeliveryService;
            _applicationService = applicationService;
        }

		#endregion

		#region Methods




		public IEnumerable<FinYearViewModel> GetFinYears()
		{
			var finYearDTOs = new List<FinYearViewModel> { };

			finYearDTOs.Add(GetFinYearDTO(1));
			finYearDTOs.Add(GetFinYearDTO(2));
			finYearDTOs.Add(GetFinYearDTO(3));

			return finYearDTOs;
		}

		private FinYearViewModel GetFinYearDTO(int years)
		{
			var referentDate = DateTime.Now.AddYears(years);

			var finYear = _finYearRepository.FindAll().FirstOrDefault(fy => fy.StartDate < referentDate &&
				referentDate < fy.EndDate);

			return new FinYearViewModel
			{
				ID = finYear.Id,
				Name = finYear.Name,
				Next = years
			};
		}
		public async Task<FundAppDetailViewModel> Create(string userIdentifier, FundAppDetailViewModel model)
		{

            var npoProfile = await _applicationService.GetApplicationById(model.ApplicationPeriodId);
            // var geoDetails = GetGeoDetails(model.GeographicalDetails);
            var appDetail = await GetAppDetails(model.ApplicationDetails, model.ProgrammeId, npoProfile.NpoId);
			var projectInfo = GetProjectInfoViewModel(model.ProjectInformation);
			var monotoring = GetMonitoringEvaluationViewModel(model.MonitoringEvaluation);
			var bid = new FundingApplicationDetail
			{

				ApplicationPeriodId = model.ApplicationPeriodId,
				ApplicationId = model.ApplicationId,
				MonitoringEvaluation = monotoring,
				ProjectInformation = projectInfo,

				ApplicationDetails = appDetail
			};


			foreach (var financialMatterModel in model.FinancialMatters)
			{
				var financialMatter = _mapper.Map<FinancialMatters>(financialMatterModel);
				bid.FinancialMatters.Add(financialMatter);
			}

			foreach (var imple in model.Implementations)
			{

				var imp = _mapper.Map<ProjectImplementation>(imple);

				foreach (var placeDTO in imple.Places)
				{
					var impPlace = new ProjectImplementationPlace
					{

						ImplementationId = imple.ID,
						IsActive = true,
						PlaceId = placeDTO.Id
					};

					imp.ImplementationPlaces.Add(impPlace);
				}

				foreach (var subPlaceDTO in imple.SubPlaces)
				{
					var impSubPlace = new ProjectImplementationSubPlace
					{
						SubPlace = await _subPlaceRepository.GetById(subPlaceDTO.Id),
						SubPlaceId = subPlaceDTO.Id,
						ImplementationId = imple.ID,
						IsActive = true
					};

					imp.ImplementationSubPlaces.Add(impSubPlace);
				}

				bid.Implementations.Add(imp);

			}


			await _bidRepository.CreateAsync(bid);
			var s = _mapper.Map<FundAppDetailViewModel>(bid);
			return s;
		}
		public IEnumerable<Place> GetPlaces(List<int> sdaIds)
		{
			var filteredPlace = new List<Place>();
			var places = _placeRepository.FindAll();
			foreach (var place in places)
			{
				foreach (var i in sdaIds)
				{
					if (place.ServiceDeliveryAreaId == i)
					{
						filteredPlace.Add(place);
					}
				}
			}
			return filteredPlace;
		}

		public IEnumerable<SubPlace> GetSubplaces(List<int> placeIds)
		{
			var sublaces = _subPlaceRepository.FindAll();
			var filteredSuPlace = new List<SubPlace>();

			foreach (var SbPlace in sublaces)
			{
				foreach (var i in placeIds)
				{
					if (SbPlace.PlaceId == i)
					{
						filteredSuPlace.Add(SbPlace);
					}
				}
			}
			return filteredSuPlace;
		}




		public async Task<FundAppDetailViewModel> GetById(int bidId)
		{
			var bid = await _bidRepository.GetById(bidId);
			bid.ApplicationPeriod = await _applicationPeriodService.GetById(bid.ApplicationPeriodId);
			bid.ApplicationDetails = await _applicationDetailsRepository.GetById(bid.ApplicationDetailId);
			bid.ProjectInformation = await _projectInformationRepository.GetById(bid.ProjectInformationId);
			bid.MonitoringEvaluation = await _monitoringEvaluationRepository.GetById(bid.MonitoringEvaluationId);
			var bidRegions = await _bidRegionRepository.GetBidRegionByGeographicalDetailId(bid.ApplicationDetails.FundAppSDADetail.Id);
			var serviceDeliveryArea = await _BidServiceDeliveryAreaRepository.GetBidServiceDeliveryAreaByGeographicalDetailId(bid.ApplicationDetails.FundAppSDADetail.Id);

			// return active places and subplaces
			foreach (var imple in bid.Implementations)
			{
				var subPlace = await _implementationSubPlaceRepository
			   .GetImplementationSubPlaceByImplementationId(imple.Id);
				var place = await _implementationPlaceRepository
					.GetImplementationPlaceByImplementationId(imple.Id);

				imple.ImplementationSubPlaces = subPlace.ToList();
				imple.ImplementationPlaces = place.ToList();
			}

			bid.ApplicationDetails.FundAppSDADetail.Regions = bidRegions.ToList();
			bid.ApplicationDetails.FundAppSDADetail.ServiceDeliveryAreas = serviceDeliveryArea.ToList();

			return _mapper.Map<FundAppDetailViewModel>(bid);

		}


		public async Task<FundAppDetailViewModel> GetapplicationIDAsync(int bidId)
		{
			var bid = await _bidRepository.GetapplicationIDAsync(bidId);
			// return await FindByCondition(x => x.ApplicationId.Equals(id)).FirstOrDefaultAsync();

			return this._mapper.Map<FundAppDetailViewModel>(bid);
		}

		private async Task<ApplicationDetail> GetAppDetails(ApplicationDetailViewModel model, int programmeId, int npoId)
		{
            var results = await _programeDeliveryService.GetDeliveryDetailsByProgramId(programmeId, npoId);
            // var geographicalDetails = new GeographicalDetails();
            var applicationDetails = new ApplicationDetail();
			var geo = new FundAppSDADetail();
			applicationDetails.FundAppSDADetail = geo;
			applicationDetails.AmountApplyingFor = model.AmountApplyingFor;
            
			var districtCouncil = results.Select(x => x.DistrictCouncil).FirstOrDefault();
            var localMunicipality = results.Select(x => x.LocalMunicipality).FirstOrDefault();
            var regions = results.Select(x => x.Regions).FirstOrDefault();
			var serviceDeliveryAreas = results.Select(x => x.ServiceDeliveryAreas).FirstOrDefault();


            int districtId = districtCouncil.Id; //  model.FundAppSDADetail.DistrictCouncil.Id;
			var district = await _districtRepository.GetById(districtId);

			applicationDetails.FundAppSDADetail.DistrictCouncil = district;

			applicationDetails.FundAppSDADetail.LocalMunicipality
                = await _localMunicipalityRepository.GetById(localMunicipality.ID);

			applicationDetails.FundAppSDADetail.DistrictCouncilId = applicationDetails.FundAppSDADetail.DistrictCouncil == null ? 0 : applicationDetails.FundAppSDADetail.DistrictCouncil.Id;
			applicationDetails.FundAppSDADetail.DistrictCouncil = null;

			applicationDetails.FundAppSDADetail.LocalMunicipalityId = applicationDetails.FundAppSDADetail.LocalMunicipality == null ? 0 : applicationDetails.FundAppSDADetail.LocalMunicipality.Id;
			applicationDetails.FundAppSDADetail.LocalMunicipality = null;

			foreach (var item in regions)
			{
				var bidRegion = new FundAppSDADetail_Region
				{
					//  Region = await _regionRepository.GetById(item.ID),
					RegionId = item.ID,
					IsActive = true

				};

				applicationDetails.FundAppSDADetail.Regions.Add(bidRegion);
			}

			foreach (var item in serviceDeliveryAreas)
			{
				var bidServiceDeliveryArea = new FundAppServiceDeliveryArea()
				{
					// ServiceDeliveryArea = await _serviceDeliveryAreaRepository.GetById(item.ID),
					ServiceDeliveryAreaId = item.ID,
					IsActive = true
				};

				applicationDetails.FundAppSDADetail.ServiceDeliveryAreas.Add(bidServiceDeliveryArea);
			}

			return applicationDetails;
		}

		private ProjectInformation GetProjectInfoViewModel(ProjectInformationViewModel viewModel)
		{
			if (viewModel == null) return null;
			else
			{
				var projectInformationViewModel = new ProjectInformation();
				//projectInformationViewModel.InitiatedQuestion = viewModel.InitiatedQuestion;
				//projectInformationViewModel.considerQuestion = viewModel.considerQuestion;
				projectInformationViewModel.purposeQuestion = viewModel.purposeQuestion;

				return projectInformationViewModel;
			}
		}

		private MonitoringEvaluation GetMonitoringEvaluationViewModel(MonitoringEvaluationViewModel viewModel)
		{
			if (viewModel == null) return null;


			else
			{
				var monitoring = new MonitoringEvaluation();
				monitoring.MonEvalDescription = viewModel.MonEvalDescription;


				return monitoring;
			}
		}

		private async Task UpdateDistrictLocalMunicipal(FundAppSDADetailViewModel model, FundAppSDADetail existingRegionsAndSdas)
		{
			var mapping = await _geographicalDetailsRepositoryRepository.GetById(existingRegionsAndSdas.Id);
			mapping.DistrictCouncilId = model.DistrictCouncil.Id;
			mapping.LocalMunicipalityId = model.LocalMunicipality.ID;
			mapping.DistrictCouncil = null;
			mapping.LocalMunicipality = null;

			await _geographicalDetailsRepositoryRepository.UpdateAsync1(mapping);
		}



		private async Task UpdateGeoDetails(FundAppSDADetailViewModel model, FundAppSDADetail existingRegionsAndSdas)
		{
			// Create new mappings
			foreach (var region in model.Regions)
			{
				var mapping = await _bidRegionRepository.GetById(region.ID, model.Id);

				if (mapping == null)
				{
					existingRegionsAndSdas.Regions.Add(new FundAppSDADetail_Region
					{
						FundAppSDADetailId = existingRegionsAndSdas.Id,
						IsActive = true,
						RegionId = region.ID,
					});

				}
			}

			// Update is active state
			var newIds = model.Regions.Select(x => x.ID);

			foreach (var mapping in existingRegionsAndSdas.Regions)
			{
				mapping.IsActive = newIds.Contains(mapping.RegionId) ? true : false;
				await _bidRegionRepository.UpdateAsync(mapping);

			}


			// service delivery area
			foreach (var item in model.ServiceDeliveryAreas)
			{
				var mapping = await _BidServiceDeliveryAreaRepository.GetById(item.ID, model.Id);

				if (mapping == null)

					existingRegionsAndSdas.ServiceDeliveryAreas.Add(new FundAppServiceDeliveryArea
					{
						FundAppSDADetailId = model.Id,
						IsActive = true,
						ServiceDeliveryAreaId = item.ID,
					});

			}

			// Update is active state
			var Ids = model.ServiceDeliveryAreas.Select(x => x.ID);

			foreach (var mapping in existingRegionsAndSdas.ServiceDeliveryAreas)
			{
				mapping.IsActive = Ids.Contains(mapping.ServiceDeliveryAreaId) ? true : false;
				await _BidServiceDeliveryAreaRepository.UpdateAsync(mapping);

			}

		}
		private void ProjectInformationUpdate(FundAppDetailViewModel model, FundingApplicationDetail bid)
		{

			if (model.ProjectInformationId == null)
			{
				bid.ProjectInformation = _mapper.Map<ProjectInformation>(model.ProjectInformation);
			}

			else
			{
				_mapper.Map(model.ProjectInformation, bid.ProjectInformation);
			}
		}

		private void MonitoringEvalutionUpdate(FundAppDetailViewModel model, FundingApplicationDetail bid)
		{
			if (model.MonitoringEvaluationId == null)
			{
				bid.MonitoringEvaluation = _mapper.Map<MonitoringEvaluation>(model.MonitoringEvaluation);
			}

			else
			{
				_mapper.Map(model.MonitoringEvaluation, bid.MonitoringEvaluation);
			}
		}

		public async Task<FundAppDetailViewModel> UpdateSDA(string userIdentifier, int bidId, FundAppDetailViewModel model)
		{

			var user = _userRepository.GetByUserName(userIdentifier).Result;
			var bid = await _bidRepository.GetById(bidId);
			bid.ProjectInformation = await _projectInformationRepository.GetById(bid.ProjectInformationId);
			bid.MonitoringEvaluation = await _monitoringEvaluationRepository.GetById(bid.MonitoringEvaluationId);

			if (bid == null)
				throw new ArgumentNullException(nameof(FundingApplicationDetail));
			if (model.ApplicationDetails.FundAppSDADetail != null)
			{
				var bidRegions = await _bidRegionRepository.GetAllBidRegionByGeographicalDetailId(model.ApplicationDetails.FundAppSDADetail.Id);
				var bidSDAs = await _BidServiceDeliveryAreaRepository.GetAllBidSdasByGeographicalDetailId(model.ApplicationDetails.FundAppSDADetail.Id);


				var existingBidRegionsAndSdas = await _geographicalDetailsRepositoryRepository.GetById(model.ApplicationDetails.FundAppSDADetail.Id);
				existingBidRegionsAndSdas.Regions = bidRegions.ToList();
				existingBidRegionsAndSdas.ServiceDeliveryAreas = bidSDAs.ToList();
				if (model.ApplicationDetails.FundAppSDADetail.DistrictCouncil != null)
				{
					await UpdateDistrictLocalMunicipal(model.ApplicationDetails.FundAppSDADetail, existingBidRegionsAndSdas);
				}

				await UpdateGeoDetails(model.ApplicationDetails.FundAppSDADetail, existingBidRegionsAndSdas);
			}
			ProjectInformationUpdate(model, bid);
			MonitoringEvalutionUpdate(model, bid);
			//bid.ApplicationDetails.FundAppSDADetail = existingBidRegionsAndSdas;
			//bid.ApplicationDetails.FundAppSDADetailId = model.ApplicationDetails.FundAppSDADetailId;

			bid.ApplicationDetails.AmountApplyingFor = model.ApplicationDetails.AmountApplyingFor;


			foreach (var imple in model.Implementations)
			{

				var subPlace = await _implementationSubPlaceRepository.GetAllImplementationSubPlaceByImplementationId(imple.ID);
				var place = await _implementationPlaceRepository.GetAllImplementationPlaceByImplementationId(imple.ID);

				if (imple.ID == 0)
				{

					var imp = _mapper.Map<ProjectImplementation>(imple);

					foreach (var placeDTO in imple.Places)
					{
						var impPlace = new ProjectImplementationPlace
						{

							ImplementationId = imple.ID,
							IsActive = true,
							PlaceId = placeDTO.Id
						};

						imp.ImplementationPlaces.Add(impPlace);
					}

					foreach (var subPlaceDTO in imple.SubPlaces)
					{
						var impSubPlace = new ProjectImplementationSubPlace
						{
							SubPlace = null,
							SubPlaceId = subPlaceDTO.Id,
							ImplementationId = imple.ID,
							IsActive = true
						};

						imp.ImplementationSubPlaces.Add(impSubPlace);
					}

					bid.Implementations.Add(imp);

				}
				else
				{

					var implementation = bid.Implementations.FirstOrDefault(p => p.Id == imple.ID);
					_mapper.Map(imple, implementation);

					implementation.ImplementationSubPlaces = subPlace.ToList();

					implementation.ImplementationPlaces = place.ToList();

					// Create new mappings
					foreach (var plac in imple.Places)
					{
						if (plac != null)
						{

							var mapping = await _implementationPlaceRepository.GetById(plac.Id, imple.ID);
							if (mapping == null)
								implementation.ImplementationPlaces.Add(new ProjectImplementationPlace
								{
									Place = null,
									PlaceId = plac.Id,
									ImplementationId = imple.ID,
								});
						}
					}

					// Update is active state
					var newIds = imple.Places.Select(x => x.Id);

					foreach (var mapping in implementation.ImplementationPlaces)
					{
						mapping.Place = null;

						mapping.IsActive = newIds.Contains(mapping.PlaceId) ? true : false;
					}

					// sub place mapping
					foreach (var sub in imple.SubPlaces)
					{

						var map = await _implementationSubPlaceRepository.GetById(sub.Id, imple.ID);
						if (map == null)
							implementation.ImplementationSubPlaces.Add(new ProjectImplementationSubPlace
							{

								SubPlaceId = sub.Id,
								ImplementationId = imple.ID,
								IsActive = true,
								SubPlace = null

							});
					}

					// Update is active state
					var frontEndIds = imple.SubPlaces.Select(x => x.Id);

					foreach (var mapping in implementation.ImplementationSubPlaces)
					{
						mapping.SubPlace = null;
						mapping.IsActive = frontEndIds.Contains(mapping.SubPlaceId) ? true : false;

					}


				}
			}

			foreach (var f in bid.FinancialMatters)
			{
				if (!model.FinancialMatters.Where(p => p.Id == f.Id).Any())
				{
					throw new ArgumentNullException(nameof(f));
				}
			}

			foreach (var fn in model.FinancialMatters)
			{
				if (fn.Id == 0)
				{

					var financial = _mapper.Map<FinancialMatters>(fn);


					bid.FinancialMatters.Add(financial);
				}
				else
				{
					var financial = bid.FinancialMatters.FirstOrDefault(p => p.Id == fn.Id);

					_mapper.Map(fn, financial);

				}
			}

			await _bidRepository.UpdateAsync(bid);


			return _mapper.Map<FundAppDetailViewModel>(bid);
		}

		public async Task<FundAppDetailViewModel> Update(string userIdentifier, int bidId, FundAppDetailViewModel model)
		{

			var user = _userRepository.GetByUserName(userIdentifier).Result;
			var bid = await _bidRepository.GetById(bidId);
			bid.ProjectInformation = await _projectInformationRepository.GetById(bid.ProjectInformationId);
			bid.MonitoringEvaluation = await _monitoringEvaluationRepository.GetById(bid.MonitoringEvaluationId);

			if (bid == null)
				throw new ArgumentNullException(nameof(FundingApplicationDetail));
			if (model.ApplicationDetails.FundAppSDADetail != null)
			{
				var bidRegions = await _bidRegionRepository.GetAllBidRegionByGeographicalDetailId(model.ApplicationDetails.FundAppSDADetail.Id);
				var bidSDAs = await _BidServiceDeliveryAreaRepository.GetAllBidSdasByGeographicalDetailId(model.ApplicationDetails.FundAppSDADetail.Id);


				var existingBidRegionsAndSdas = await _geographicalDetailsRepositoryRepository.GetById(model.ApplicationDetails.FundAppSDADetail.Id);
				existingBidRegionsAndSdas.Regions = bidRegions.ToList();
				existingBidRegionsAndSdas.ServiceDeliveryAreas = bidSDAs.ToList();
				if (model.ApplicationDetails.FundAppSDADetail.DistrictCouncil != null)
				{
					await UpdateDistrictLocalMunicipal(model.ApplicationDetails.FundAppSDADetail, existingBidRegionsAndSdas);
				}

				await UpdateGeoDetails(model.ApplicationDetails.FundAppSDADetail, existingBidRegionsAndSdas);
			}
			ProjectInformationUpdate(model, bid);
			MonitoringEvalutionUpdate(model, bid);
			//bid.ApplicationDetails.FundAppSDADetail = existingBidRegionsAndSdas;
			//bid.ApplicationDetails.FundAppSDADetailId = model.ApplicationDetails.FundAppSDADetailId;

			bid.ApplicationDetails.AmountApplyingFor = model.ApplicationDetails.AmountApplyingFor;


			foreach (var imple in model.Implementations)
			{

				var subPlace = await _implementationSubPlaceRepository.GetAllImplementationSubPlaceByImplementationId(imple.ID);
				var place = await _implementationPlaceRepository.GetAllImplementationPlaceByImplementationId(imple.ID);

				if (imple.ID == 0)
				{

					var imp = _mapper.Map<ProjectImplementation>(imple);

					foreach (var placeDTO in imple.Places)
					{
						var impPlace = new ProjectImplementationPlace
						{

							ImplementationId = imple.ID,
							IsActive = true,
							PlaceId = placeDTO.Id
						};

						imp.ImplementationPlaces.Add(impPlace);
					}

					foreach (var subPlaceDTO in imple.SubPlaces)
					{
						var impSubPlace = new ProjectImplementationSubPlace
						{
							SubPlace = null,
							SubPlaceId = subPlaceDTO.Id,
							ImplementationId = imple.ID,
							IsActive = true
						};

						imp.ImplementationSubPlaces.Add(impSubPlace);
					}

					bid.Implementations.Add(imp);

				}
				else
				{

					var implementation = bid.Implementations.FirstOrDefault(p => p.Id == imple.ID);
					_mapper.Map(imple, implementation);

					implementation.ImplementationSubPlaces = subPlace.ToList();

					implementation.ImplementationPlaces = place.ToList();

					// Create new mappings
					foreach (var plac in imple.Places)
					{
						if (plac != null)
						{

							var mapping = await _implementationPlaceRepository.GetById(plac.Id, imple.ID);
							if (mapping == null)
								implementation.ImplementationPlaces.Add(new ProjectImplementationPlace
								{
									Place = null,
									PlaceId = plac.Id,
									ImplementationId = imple.ID,
								});
						}
					}

					// Update is active state
					var newIds = imple.Places.Select(x => x.Id);

					foreach (var mapping in implementation.ImplementationPlaces)
					{
						mapping.Place = null;

						mapping.IsActive = newIds.Contains(mapping.PlaceId) ? true : false;
					}

					// sub place mapping
					foreach (var sub in imple.SubPlaces)
					{

						var map = await _implementationSubPlaceRepository.GetById(sub.Id, imple.ID);
						if (map == null)
							implementation.ImplementationSubPlaces.Add(new ProjectImplementationSubPlace
							{

								SubPlaceId = sub.Id,
								ImplementationId = imple.ID,
								IsActive = true,
								SubPlace = null

							});
					}

					// Update is active state
					var frontEndIds = imple.SubPlaces.Select(x => x.Id);

					foreach (var mapping in implementation.ImplementationSubPlaces)
					{
						mapping.SubPlace = null;
						mapping.IsActive = frontEndIds.Contains(mapping.SubPlaceId) ? true : false;

					}


				}
			}

			foreach (var f in bid.FinancialMatters)
			{
				if (!model.FinancialMatters.Where(p => p.Id == f.Id).Any())
				{
					throw new ArgumentNullException(nameof(f));
				}
			}

			foreach (var fn in model.FinancialMatters)
			{
				if (fn.Id == 0)
				{

					var financial = _mapper.Map<FinancialMatters>(fn);


					bid.FinancialMatters.Add(financial);
				}
				else
				{
					var financial = bid.FinancialMatters.FirstOrDefault(p => p.Id == fn.Id);

					_mapper.Map(fn, financial);

				}
			}

			await _bidRepository.UpdateAsync(bid);


			return _mapper.Map<FundAppDetailViewModel>(bid);
		}

		public void UpdateIncome(FinancialMatters model)
		{
			//var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			//model.SignOffUserId = loggedInUser.Id;
			//model.SignOffDateTime = DateTime.Now;

			_finalcialMattersRepository.UpdateAsync(model);
		}





		#endregion


	}
}
