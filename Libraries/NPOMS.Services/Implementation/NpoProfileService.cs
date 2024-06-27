using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using NPOMS.Domain.Mapping;
using NPOMS.Repository.Implementation.Entities;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Repository.Interfaces.Lookup;
using NPOMS.Repository.Interfaces.Mapping;
using NPOMS.Services.Interfaces;
using NPOMS.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Services.Implementation
{
	public class NpoProfileService : INpoProfileService
	{
		public const string Auditor = "Auditor";
		public const string Affiliation = "Affiliation";

		#region Fields

		private INpoProfileRepository _npoProfileRepository;
		private IUserRepository _userRepository;
		private INpoRepository _npoRepository;
		private IUserNpoRepository _userNpoRepository;
		private INpoProfileFacilityListRepository _npoProfileFacilityListRepository;
		private IFacilityListRepository _facilityListRepository;
		private IServicesRenderedRepository _servicesRenderedRepository;
		private IBankDetailRepository _bankDetailRepository;
		private IPreviousYearFinanceRepository _previousYearFinanceRepository;
		private IFinancialMattersIncomeRepository _financialMattersIncomeRepository;
		private IFinancialMattersExpenditureRepository _financialMattersExpenditureRepository;
		private IFinancialMattersOthersRepository _financialMattersOthersRepository;
		private ISourceOfInformationRepository _sourceOfInformationRepository;
		private IAffiliatedOrganisationInformationRepository _affiliatedOrganisationInformationRepository;
		private IAuditorOrAffiliationRepository _auditorOrAffiliationRepository;
		private IStaffMemberProfileRepository _staffMemberProfileRepository;
		private IProjectImplementationRepository _projectImplementationRepository;
		private readonly IMapper _mapper;
        private IProgrameBankDetailRepository _programeBankDetailRepository;
        private IProgrameContactDetailRepository _programeContactDetailRepository;
        private IProgrameDeliveryRepository _programeDeliveryService;
        private IApplicationRepository _applicationRepository;

        #endregion

        #region Constructorrs

        public NpoProfileService(
			INpoProfileRepository npoProfileRepository,
			IUserRepository userRepository,
			INpoRepository npoRepository,
			IUserNpoRepository userNpoRepository,
			INpoProfileFacilityListRepository npoProfileFacilityListRepository,
			IFacilityListRepository facilityListRepository,
			IServicesRenderedRepository servicesRenderedRepository,
			IBankDetailRepository bankDetailRepository,
			IPreviousYearFinanceRepository previousYearFinanceRepository,
			IFinancialMattersIncomeRepository financialMattersIncomeRepository,
			IFinancialMattersExpenditureRepository financialMattersExpenditureRepository,
			IFinancialMattersOthersRepository financialMattersOthersRepository,
			IAuditorOrAffiliationRepository auditorOrAffiliationRepository,
			IStaffMemberProfileRepository staffMemberProfileRepository,
			IAffiliatedOrganisationInformationRepository affiliatedOrganisationInformationRepository,
			ISourceOfInformationRepository sourceOfInformationRepository,
			IProjectImplementationRepository projectImplementationRepository,
            IProgrameBankDetailRepository programeBankDetailRepository,
            IProgrameContactDetailRepository programeContactDetailRepository,
            IProgrameDeliveryRepository programeDeliveryService,
            IApplicationRepository applicationRepository,
            IMapper mapper)
		{
			_npoProfileRepository = npoProfileRepository;
			_userRepository = userRepository;
			_npoRepository = npoRepository;
			_userNpoRepository = userNpoRepository;
			_npoProfileFacilityListRepository = npoProfileFacilityListRepository;
			_facilityListRepository = facilityListRepository;
			_servicesRenderedRepository = servicesRenderedRepository;
			_bankDetailRepository = bankDetailRepository;
			_previousYearFinanceRepository = previousYearFinanceRepository;
			_financialMattersIncomeRepository = financialMattersIncomeRepository;
			_financialMattersExpenditureRepository = financialMattersExpenditureRepository;
			_financialMattersOthersRepository = financialMattersOthersRepository;
			_auditorOrAffiliationRepository = auditorOrAffiliationRepository;
			_staffMemberProfileRepository = staffMemberProfileRepository;
			_affiliatedOrganisationInformationRepository = affiliatedOrganisationInformationRepository;
			_sourceOfInformationRepository = sourceOfInformationRepository;
			_projectImplementationRepository = projectImplementationRepository;
			_programeBankDetailRepository = programeBankDetailRepository;
            _programeContactDetailRepository = programeContactDetailRepository;
            _programeDeliveryService = programeDeliveryService;
            _applicationRepository = applicationRepository;

            this._mapper = mapper;
		}

		#endregion

		#region Methods

		public async Task<IEnumerable<NpoProfile>> Get(string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
			var npoProfiles = await _npoProfileRepository.GetEntities();

			if (loggedInUser.Roles.Any(x => x.IsActive && (x.RoleId.Equals((int)RoleEnum.SystemAdmin) || x.RoleId.Equals((int)RoleEnum.Admin) || x.RoleId.Equals((int)RoleEnum.ViewOnly))))
			{
				return npoProfiles;
			}
			else
			{
				// Get assigned profiles
				var mappings = await _userNpoRepository.GetApprovedEntities(loggedInUser.Id);
				var NpoIds = mappings.Select(x => x.NpoId);
				var assignedNpoProfiles = npoProfiles.Where(x => NpoIds.Contains(x.NpoId));
				return assignedNpoProfiles;
			}
		}

		public async Task<NpoProfile> GetById(int id)
		{
			var result = await _npoProfileRepository.GetById(id);
			return result;
		}

		public async Task Create(NpoProfile profile, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			profile.CreatedUserId = loggedInUser.Id;
			profile.CreatedDateTime = DateTime.Now;

			await _npoProfileRepository.CreateEntity(profile);
		}

		public async Task Update(NpoProfile profile, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			profile.UpdatedUserId = loggedInUser.Id;
			profile.UpdatedDateTime = DateTime.Now;

			await _npoProfileRepository.UpdateEntity(profile, loggedInUser.Id);
		}

		public async Task<NpoProfile> GetByNpoId(int NpoId)
		{
			var result = await _npoProfileRepository.GetByNpoId(NpoId);
			return result;
		}

		public async Task<IEnumerable<NpoProfileFacilityList>> GetFacilitiesByNpoProfileId(int npoProfileId)
		{
			return await _npoProfileFacilityListRepository.GetByNpoProfileId(npoProfileId);
		}

		public async Task Create(NpoProfileFacilityList model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
			var mapping = await _npoProfileFacilityListRepository.GetByModel(model);

			if (mapping == null)
			{
				await _npoProfileFacilityListRepository.CreateAsync(model);
			}
			else
			{
				mapping.IsActive = true;
				await _npoProfileFacilityListRepository.UpdateAsync(null, mapping, false, loggedInUser.Id);
			}
		}

		public async Task Update(NpoProfileFacilityList model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
			await _npoProfileFacilityListRepository.UpdateAsync(null, model, false, loggedInUser.Id);
		}

		public async Task<IEnumerable<ServicesRenderedVM>> GetServicesRenderedByNpoProfileId(int npoProfileId)
		{
            var servicesRenderedList = await _servicesRenderedRepository.GetByNpoProfileId(npoProfileId);
            var servicesRenderedVM = MapToViewModelList(servicesRenderedList.ToList());

            return servicesRenderedVM;
        }
        public List<ServicesRenderedVM> MapToViewModelList(List<ServicesRendered> entities)
        {
            return entities.Select(entity => new ServicesRenderedVM
            {
                NpoProfileId = entity.NpoProfileId,
                ProgrammeId = entity.ProgrammeId,
                SubProgrammeId = entity.SubProgrammeId,
                SubProgrammeTypeId = entity.SubProgrammeTypeId,
                IsActive = entity.IsActive,
                CreatedUserId = entity.CreatedUserId,
                CreatedDateTime = entity.CreatedDateTime,
                UpdatedUserId = entity.UpdatedUserId,
                UpdatedDateTime = entity.UpdatedDateTime,
                SubProgramme = entity.ServiceSubProgramme.Select(sp => new SubProgrammeVM
                {
                    Id = sp.SubProgramme.Id,
                    Name = sp.SubProgramme.Name,
                    Description = sp.SubProgramme.Description,
                    ProgrammeId = sp.SubProgramme.ProgrammeId,
                    IsActive = sp.SubProgramme.IsActive,
                    CreatedUserId = sp.SubProgramme.CreatedUserId,
                    CreatedDateTime = sp.SubProgramme.CreatedDateTime,
                    UpdatedUserId = sp.SubProgramme.UpdatedUserId,
                    UpdatedDateTime = sp.SubProgramme.UpdatedDateTime,
                    SubProgrammeType = sp.ServiceProgrammeTypes.Select(spt => new SubProgrammeTypeVM
                    {
                        Id = spt.SubProgrammeType.Id,
                        Name = spt.SubProgrammeType.Name,
                        Description = spt.SubProgrammeType.Description,
                        IsActive = spt.SubProgrammeType.IsActive,
                        CreatedUserId = spt.SubProgrammeType.CreatedUserId,
                        CreatedDateTime = spt.SubProgrammeType.CreatedDateTime,
                        UpdatedUserId = spt.SubProgrammeType.UpdatedUserId,
                        UpdatedDateTime = spt.SubProgrammeType.UpdatedDateTime
                    }).ToList()
                }).ToList()
            }).ToList();
        }

        //public List<ServicesRenderedVM> MapToViewModelList(List<ServicesRendered> entities)
        //{
        //    return entities.Select(entity => new ServicesRenderedVM
        //    {
        //        NpoProfileId = entity.NpoProfileId,
        //        ProgrammeId = entity.ProgrammeId,
        //        SubProgrammeId = entity.SubProgrammeId,
        //        SubProgrammeTypeId = entity.SubProgrammeTypeId,
        //        IsActive = entity.IsActive,
        //        CreatedUserId = entity.CreatedUserId,
        //        CreatedDateTime = entity.CreatedDateTime,
        //        UpdatedUserId = entity.UpdatedUserId,
        //        UpdatedDateTime = entity.UpdatedDateTime,
        //        SubProgramme = entity.ServiceSubProgramme.Select(sp => new SubProgrammeVM
        //        {
        //            Id = sp.SubProgramme.Id,
        //            Name = sp.SubProgramme.Name,
        //            Description = sp.SubProgramme.Description,
        //            ProgrammeId = sp.SubProgramme.ProgrammeId,
        //            IsActive = sp.SubProgramme.IsActive,
        //            CreatedUserId = sp.SubProgramme.CreatedUserId,
        //            CreatedDateTime = sp.SubProgramme.CreatedDateTime,
        //            UpdatedUserId = sp.SubProgramme.UpdatedUserId,
        //            UpdatedDateTime = sp.SubProgramme.UpdatedDateTime
        //        }).ToList(),
        //        SubProgrammeType = entity.SubProgrammeType.Select(spt => new SubProgrammeType
        //        {
        //            Id = spt.SubProgrammeType.Id,
        //            Name = spt.SubProgrammeType.Name,
        //            Description = spt.SubProgrammeType.Description,
        //            SubProgrammeId = spt.SubProgrammeType.SubProgrammeId,
        //            IsActive = spt.SubProgrammeType.IsActive,
        //            CreatedUserId = spt.SubProgrammeType.CreatedUserId,
        //            CreatedDateTime = spt.SubProgrammeType.CreatedDateTime,
        //            UpdatedUserId = spt.SubProgrammeType.UpdatedUserId,
        //            UpdatedDateTime = spt.SubProgrammeType.UpdatedDateTime
        //        }).ToList()
        //    }).ToList();
        //}

        //      public async Task Create(ServicesRenderedVM model, string userIdentifier)
        //{
        //	var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

        //	model.CreatedUserId = loggedInUser.Id;
        //	model.CreatedDateTime = DateTime.Now;
        //          model.IsActive =true;

        //          var entity = new ServicesRendered
        //          {
        //              NpoProfileId = model.NpoProfileId,
        //              ProgrammeId = model.ProgrammeId,
        //              SubProgrammeId = model.SubProgrammeId,
        //              SubProgrammeTypeId = model.SubProgrammeTypeId,
        //              ServiceSubProgramme = MapServiceSubProgrammes(model.SubProgramme),
        //              SubProgrammeType = MapServiceProgrammeTypes(model.SubProgrammeType)
        //          };
        //          await _servicesRenderedRepository.CreateAsync(entity);
        //}

        public async Task Create(ServicesRenderedVM model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.CreatedUserId = loggedInUser.Id;
            model.CreatedDateTime = DateTime.Now;
            model.IsActive = true;

            var entity = new ServicesRendered
            {
                NpoProfileId = model.NpoProfileId,
                ProgrammeId = model.ProgrammeId,
                SubProgrammeId = model.SubProgrammeId,
                SubProgrammeTypeId = model.SubProgrammeTypeId,
                ServiceSubProgramme = MapServiceSubProgrammes(model.SubProgramme)
            };
            await _servicesRenderedRepository.CreateAsync(entity);
        }

        private List<ServiceSubProgramme> MapServiceSubProgrammes(List<SubProgrammeVM> selectedSubProgrammes)
        {
            return selectedSubProgrammes.Select(sp => new ServiceSubProgramme
            {
                SubProgrammeId = sp.Id,
                IsActive = true,
                ServiceProgrammeTypes = sp.SubProgrammeType.Select(spt => new ServiceProgrammeType
                {
                    SubProgrammeTypeId = spt.Id,
                    IsActive = true
                }).ToList()
            }).ToList();
        }


        public async Task Update(ServicesRenderedVM model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			var existingEntity = await _servicesRenderedRepository.GetById(model.Id);

            if (existingEntity == null)
            {
                throw new ApplicationException($"ServicesRendered with id {model.Id} not found.");
            }

            existingEntity.NpoProfileId = model.NpoProfileId;
            existingEntity.ProgrammeId = model.ProgrammeId;
            existingEntity.SubProgrammeId = model.SubProgrammeId;
            existingEntity.SubProgrammeTypeId = model.SubProgrammeTypeId;

            //existingEntity.ServiceSubProgramme.Clear();
            //var updatedServiceSubProgrammes = MapServiceSubProgrammes(model.SelectedServiceSubProgrammes);
            //foreach (var serviceSubProgramme in updatedServiceSubProgrammes)
            //{
            //    existingEntity.ServiceSubProgramme.Add(serviceSubProgramme);
            //}

            //existingEntity.SubProgrammeType.Clear();
            //var updatedSubProgrammeTypes = MapServiceProgrammeTypes(model.SelectedServiceSubProgrammeTypes);
            //foreach (var subProgrammeType in updatedSubProgrammeTypes)
            //{
            //    existingEntity.SubProgrammeType.Add(subProgrammeType);
            //}

            existingEntity.IsActive = model.IsActive;
            existingEntity.UpdatedUserId = loggedInUser.Id;
            existingEntity.UpdatedDateTime = DateTime.Now;

            await _servicesRenderedRepository.UpdateAsync(existingEntity);
        }



        //public async Task Update(ServicesRenderedVM model, string userIdentifier)
        //{
        //	var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

        //	model.UpdatedUserId = loggedInUser.Id;
        //	model.UpdatedDateTime = DateTime.Now;

        //	await _servicesRenderedRepository.UpdateAsync(null, model, false, loggedInUser.Id);
        //}


        private List<ServiceSubProgramme> MapServiceSubProgrammes(List<SubProgramme> selectedSubProgrammes)
        {
            return selectedSubProgrammes.Select(sp => new ServiceSubProgramme
            {
                SubProgrammeId = sp.Id,
                IsActive = true,
            }).ToList();
        }

        private List<ServiceProgrammeType> MapServiceProgrammeTypes(List<SubProgrammeType> selectedSubProgrammeTypes)
        {
            return selectedSubProgrammeTypes.Select(spt => new ServiceProgrammeType
            {
                SubProgrammeTypeId = spt.Id,
                IsActive = true,
            }).ToList();
        }
        public async Task<IEnumerable<BankDetail>> GetBankDetailsByNpoProfileId(int npoProfileId)
		{
			return await _bankDetailRepository.GetByNpoProfileId(npoProfileId);
		}


		public async Task<IEnumerable<ProjectImplementation>> GetProjImplByNpoProfileId(int npoProfileId)
		{
			return await _projectImplementationRepository.GetAllByNpoProfileId(npoProfileId);
		}

		public async Task<IEnumerable<ProjectImplementation>> GetProjImplByAppDetailId(int appDetailId)
		{
			var imple = await _projectImplementationRepository.GetAllByAppDetailId(appDetailId);
			return (IEnumerable<ProjectImplementation>)_mapper.Map<ProjectImplementation>(imple);
		}


		public async Task Create(BankDetail model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.IsActive = true;
			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _bankDetailRepository.CreateAsync(model);
		}

		public async Task Update(BankDetail model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _bankDetailRepository.UpdateAsync(model);
		}


		public async Task Update(ProjectImplementation model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			//model.UpdatedUserId = loggedInUser.Id;
			//model.UpdatedDateTime = DateTime.Now;

			await _projectImplementationRepository.UpdateAsync(null, model, false, loggedInUser.Id);
		}

		public async Task<IEnumerable<FinancialMattersIncome>> GetIncomeByNpoProfileIdAsync(int id)
		{
			return await _financialMattersIncomeRepository.GetByNpoProfileIdAsync(id);
		}

		public async Task<IEnumerable<FinancialMattersExpenditure>> GetExpenditureByNpoProfileIdAsync(int id)
		{
			return await _financialMattersExpenditureRepository.GetByNpoProfileIdAsync(id);
		}

		public async Task<IEnumerable<FinancialMattersOthers>> GetOthersByNpoProfileIdAsync(int id)
		{
			return await _financialMattersOthersRepository.GetByNpoProfileIdAsync(id);
		}

		public async Task<IEnumerable<PreviousYearFinance>> GetByNpoProfileIdAsync(int id)
		{
			return await _previousYearFinanceRepository.GetByNpoProfileIdAsync(id);
		}

		public async Task Create(PreviousYearFinance model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;
			await _previousYearFinanceRepository.CreateAsync(model);
		}

		public async Task Update(PreviousYearFinance model, string userIdentifier, string id)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _previousYearFinanceRepository.UpdateAsync(model);
		}

		public async Task UpdateIncome(FinancialMattersIncome model, string userIdentifier, string id)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _financialMattersIncomeRepository.UpdateAsync(model);
		}

		public async Task UpdateExpenditure(FinancialMattersExpenditure model, string userIdentifier, string id)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _financialMattersExpenditureRepository.UpdateAsync(model);
		}

		public async Task UpdateOthers(FinancialMattersOthers model, string userIdentifier, string id)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _financialMattersOthersRepository.UpdateAsync(model);
		}

		public async Task CreatePreviousYearFinance(int fundingApplicationId, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			var model = new PreviousYearFinance
			{
				npoProfileId = fundingApplicationId,
				IsActive = true,
				CreatedUserId = loggedInUser.Id,
				CreatedDateTime = DateTime.Now,
			};

			await _previousYearFinanceRepository.CreateAsync(model);
		}

		public async Task DeleteById(int id, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			var model = await _previousYearFinanceRepository.GetById(id);
			model.IsActive = false;
			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _previousYearFinanceRepository.UpdateAsync(model);
		}

		public async Task DeleteIncomeById(int id, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			var model = await _financialMattersIncomeRepository.GetById(id);
			model.IsActive = false;
			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _financialMattersIncomeRepository.UpdateAsync(model);
		}

		public async Task DeleteExpenditureById(int id, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			var model = await _financialMattersExpenditureRepository.GetById(id);
			model.IsActive = false;
			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _financialMattersExpenditureRepository.UpdateAsync(model);
		}

		public async Task DeleteOthersById(int id, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			var model = await _financialMattersOthersRepository.GetById(id);
			model.IsActive = false;
			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _financialMattersOthersRepository.UpdateAsync(model);
		}

		public async Task CreateFinancialMattersIncome(int fundingApplicationId, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			var model = new FinancialMattersIncome
			{
				npoProfileId = fundingApplicationId,
				AmountOneI = 0,
				AmountTwoI = 0,
				AmountThreeI = 0,
				TotalFundingAmountI = 0,
				IsActive = true,
				CreatedUserId = loggedInUser.Id,
				CreatedDateTime = DateTime.Now,
			};

			await _financialMattersIncomeRepository.CreateAsync(model);
		}

		public async Task CreateFinancialMattersExpenditure(int fundingApplicationId, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			var model = new FinancialMattersExpenditure
			{
				npoProfileId = fundingApplicationId,
				AmountOneE = 0,
				AmountTwoE = 0,
				AmountThreeE = 0,
				TotalFundingAmountE = 0,
				IsActive = true,
				CreatedUserId = loggedInUser.Id,
				CreatedDateTime = DateTime.Now,
			};

			await _financialMattersExpenditureRepository.CreateAsync(model);
		}

		public async Task CreateFinancialMattersOther(int fundingApplicationId, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			var model = new FinancialMattersOthers
			{
				npoProfileId = fundingApplicationId,
				AmountOneO = 0,
				AmountTwoO = 0,
				AmountThreeO = 0,
				TotalFundingAmountO = 0,
				IsActive = true,
				CreatedUserId = loggedInUser.Id,
				CreatedDateTime = DateTime.Now,
			};

			await _financialMattersOthersRepository.CreateAsync(model);
		}

		public async Task DeleteBankDetailById(int id, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			var model = await _bankDetailRepository.GetById(id);
			model.IsActive = false;
			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _bankDetailRepository.UpdateAsync(model);
		}


		public async Task<ProjectImplementation> DeleteProjectImplementationById(int id)
		{
			return await _projectImplementationRepository.DeleteById(id);
		}

		public async Task<IEnumerable<AuditorOrAffiliation>> GetAuditorOrAffiliations(int entityId)
		{
			return await _auditorOrAffiliationRepository.GetByEntityId(entityId);
		}

		public async Task CreateAuditorOrAffiliation(AuditorOrAffiliation model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _auditorOrAffiliationRepository.CreateAsync(model);
		}

		public async Task Update(AffiliatedOrganisationInformation model, string userIdentifier, string id)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			if (model.Id == 0)
			{
				model.CreatedUserId = loggedInUser.Id;
				model.CreatedDateTime = DateTime.Now;
				model.npoProfileId = Convert.ToInt32(id);
				await _affiliatedOrganisationInformationRepository.CreateAsync(model);
			}
			else
			{
				model.UpdatedUserId = loggedInUser.Id;
				model.UpdatedDateTime = DateTime.Now;
				await _affiliatedOrganisationInformationRepository.UpdateAsync(model);
			}
		}

		public async Task Update(SourceOfInformation model, string userIdentifier, string npoProfileId)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
			var getData = await _sourceOfInformationRepository.GetSourceOfInformationByIdAsync(Convert.ToInt32(npoProfileId));

			if (getData.Count() == 0)
			{
				model.CreatedUserId = loggedInUser.Id;
				model.CreatedDateTime = DateTime.Now;
				await _sourceOfInformationRepository.CreateAsync(model);
			}
		}

		public async Task<IEnumerable<AffiliatedOrganisationInformation>> GetAffiliatedOrganisationById(int id)
		{
			return await _affiliatedOrganisationInformationRepository.GetAffiliatedOrganisationByIdAsync(id);
		}
		public async Task<IEnumerable<SourceOfInformation>> GetSourceOfInformationById(int id)
		{
			return await _sourceOfInformationRepository.GetSourceOfInformationByIdAsync(id);
		}

		public async Task UpdateAuditorOrAffiliation(AuditorOrAffiliation model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _auditorOrAffiliationRepository.UpdateEntity(model, loggedInUser.Id);
		}

		public async Task<IEnumerable<StaffMemberProfile>> GetStaffMemberProfiles(int npoProfileId)
		{
			return await _staffMemberProfileRepository.GetByNpoProfileId(npoProfileId);
		}

		public async Task CreateStaffMemberProfile(StaffMemberProfile model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _staffMemberProfileRepository.CreateAsync(model);
		}

		public async Task UpdateStaffMemberProfile(StaffMemberProfile model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _staffMemberProfileRepository.UpdateEntity(model, loggedInUser.Id);
		}

        //     public async Task ApproveNpoProfile(int npoProfileId, string userIdentifier)
        //     {
        //         var model = await _npoProfileRepository.GetById(npoProfileId);

        //         var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

        //         model.UpdatedUserId = loggedInUser.Id;
        //         model.UpdatedDateTime = DateTime.Now;
        //model.AccessStatusId = (int)(AccessStatusEnum.Approved);
        //await _npoProfileRepository.UpdateAsync(model);

        //         // get service renderd -
        //         // get programId
        //         // pull active Banking details and update status
        //         // pull active Contact information and update status 
        //         // pull active Delivery information and update status 
        //     }

        public async Task ApproveNpoProfile(int npoProfileId, string userIdentifier)
        {
            // Fetch the NPO profile by ID
            var model = await _npoProfileRepository.GetById(npoProfileId);
            if (model == null)
            {
                throw new Exception("NPO profile not found");
            }

            // Get the logged-in user details
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
            if (loggedInUser == null)
            {
                throw new Exception("User not found");
            }

            // Update NPO profile details
            model.UpdatedUserId = loggedInUser.Id;
            model.UpdatedDateTime = DateTime.Now;
            model.AccessStatusId = (int)AccessStatusEnum.Approved;
            await _npoProfileRepository.UpdateAsync(model);

            // Assuming that you have a method to fetch the service rendered and the program ID
            var servicesRendered = await GetServiceRenderedByNpoProfileId(npoProfileId);
            if (!servicesRendered.Any())
            {
                throw new Exception("No services rendered found for the given NPO profile");
            }

            foreach (var serviceRendered in servicesRendered)
            {
                var programId = serviceRendered.ProgrammeId;

                var activeBankingDetails = await _programeBankDetailRepository.GetBankDetailsByProgramId(programId);
                foreach (var bankingDetail in activeBankingDetails)
                {
                    bankingDetail.ApprovalStatusId = (int)AccessStatusEnum.Approved;
					bankingDetail.ApprovalStatus = null;
                    await _programeBankDetailRepository.UpdateAsync(bankingDetail);
                }

                var activeContactInfo = await _programeContactDetailRepository.GetContactDetailsByProgramId(programId);
                foreach (var contact in activeContactInfo)
                {
                    contact.ApprovalStatusId = (int)AccessStatusEnum.Approved;
					contact.ApprovalStatus = null;
                    await _programeContactDetailRepository.UpdateAsync(contact);
                }

                var activeDeliveryInfo = await _programeDeliveryService.GetDeliveryDetailsByProgramId(programId);
                foreach (var delivery in activeDeliveryInfo)
                {
                    delivery.ApprovalStatusId = (int)AccessStatusEnum.Approved;
					delivery.ApprovalStatus = null;
                    await _programeDeliveryService.UpdateAsync(delivery);
                }
            }
        }
        public async Task RejectNpoProfile(int npoProfileId, string userIdentifier)
        {
            // Fetch the NPO profile by ID
            var model = await _npoProfileRepository.GetById(npoProfileId);
            if (model == null)
            {
                throw new Exception("NPO profile not found");
            }

            // Get the logged-in user details
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
            if (loggedInUser == null)
            {
                throw new Exception("User not found");
            }

            // Update NPO profile details
            model.UpdatedUserId = loggedInUser.Id;
            model.UpdatedDateTime = DateTime.Now;
            model.AccessStatusId = (int)AccessStatusEnum.Rejected;
            await _npoProfileRepository.UpdateAsync(model);

            // Fetch the services rendered for the given NPO profile
            var servicesRendered = await GetServiceRenderedByNpoProfileId(npoProfileId);
            if (!servicesRendered.Any())
            {
                throw new Exception("No services rendered found for the given NPO profile");
            }

            foreach (var serviceRendered in servicesRendered)
            {
                var programId = serviceRendered.ProgrammeId;

                // Fetch and update active banking details if pending
                var activeBankingDetails = await _programeBankDetailRepository.GetBankDetailsByProgramId(programId);
                foreach (var bankingDetail in activeBankingDetails)
                {
                    if (bankingDetail.ApprovalStatusId == (int)AccessStatusEnum.Pending)
                    {
                        bankingDetail.ApprovalStatusId = (int)AccessStatusEnum.Rejected;
                        await _programeBankDetailRepository.UpdateAsync(bankingDetail);
                    }
                }

                // Fetch and update active contact information if pending
                var activeContactInfo = await _programeContactDetailRepository.GetContactDetailsByProgramId(programId);
                foreach (var contact in activeContactInfo)
                {
                    if (contact.ApprovalStatusId == (int)AccessStatusEnum.Pending)
                    {
                        contact.ApprovalStatusId = (int)AccessStatusEnum.Rejected;
                        await _programeContactDetailRepository.UpdateAsync(contact);
                    }
                }

                // Fetch and update active delivery information if pending
                var activeDeliveryInfo = await _programeDeliveryService.GetDeliveryDetailsByProgramId(programId);
                foreach (var delivery in activeDeliveryInfo)
                {
                    if (delivery.ApprovalStatusId == (int)AccessStatusEnum.Pending)
                    {
                        delivery.ApprovalStatusId = (int)AccessStatusEnum.Rejected;
                        await _programeDeliveryService.UpdateAsync(delivery);
                    }
                }
            }
        }

        //public async Task RejectNpoProfile(int npoProfileId, string userIdentifier)
        //{
        //    // Fetch the NPO profile by ID
        //    var model = await _npoProfileRepository.GetById(npoProfileId);
        //    if (model == null)
        //    {
        //        throw new Exception("NPO profile not found");
        //    }

        //    // Get the logged-in user details
        //    var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
        //    if (loggedInUser == null)
        //    {
        //        throw new Exception("User not found");
        //    }

        //    // Update NPO profile details
        //    model.UpdatedUserId = loggedInUser.Id;
        //    model.UpdatedDateTime = DateTime.Now;
        //    model.AccessStatusId = (int)AccessStatusEnum.Rejected;
        //    await _npoProfileRepository.UpdateAsync(model);

        //    // Assuming that you have a method to fetch the service rendered and the program ID
        //    var servicesRendered = await GetServiceRenderedByNpoProfileId(npoProfileId);
        //    if (!servicesRendered.Any())
        //    {
        //        throw new Exception("No services rendered found for the given NPO profile");
        //    }

        //    foreach (var serviceRendered in servicesRendered)
        //    {
        //        var programId = serviceRendered.ProgrammeId;

        //        var activeBankingDetails = await _programeBankDetailRepository.GetBankDetailsByProgramId(programId);
        //        foreach (var bankingDetail in activeBankingDetails)
        //        {
        //            bankingDetail.ApprovalStatusId = (int)AccessStatusEnum.Rejected;
        //            await _programeBankDetailRepository.UpdateAsync(bankingDetail);
        //        }

        //        var activeContactInfo = await _programeContactDetailRepository.GetContactDetailsByProgramId(programId);
        //        foreach (var contact in activeContactInfo)
        //        {
        //            contact.ApprovalStatusId = (int)AccessStatusEnum.Rejected;
        //            await _programeContactDetailRepository.UpdateAsync(contact);
        //        }

        //        var activeDeliveryInfo = await _programeDeliveryService.GetDeliveryDetailsByProgramId(programId);
        //        foreach (var delivery in activeDeliveryInfo)
        //        {
        //            delivery.ApprovalStatusId = (int)AccessStatusEnum.Rejected;
        //            await _programeDeliveryService.UpdateAsync(delivery);
        //        }
        //    }
        //}


        //public async Task RejectNpoProfile(int npoProfileId, string userIdentifier)
        //{
        //    var model = await _npoProfileRepository.GetById(npoProfileId);

        //    var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

        //    model.UpdatedUserId = loggedInUser.Id;
        //    model.UpdatedDateTime = DateTime.Now;
        //    model.AccessStatusId = (int)(AccessStatusEnum.Rejected);
        //    await _npoProfileRepository.UpdateAsync(model);
        //}

        public async Task SubmitProfileNpoProfile(int npoProfileId, string userIdentifier)
        {
            var model = await _npoProfileRepository.GetById(npoProfileId);

            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.UpdatedUserId = loggedInUser.Id;
            model.UpdatedDateTime = DateTime.Now;
            model.AccessStatusId = (int)(AccessStatusEnum.Pending);
            await _npoProfileRepository.UpdateAsync(model);
        }

        private async Task<IEnumerable<ServicesRendered>> GetServiceRenderedByNpoProfileId(int npoProfileId)
        {
            var results = await _servicesRenderedRepository.GetByNpoProfileId(npoProfileId);
            return results;
        }


        #endregion
    }
}
