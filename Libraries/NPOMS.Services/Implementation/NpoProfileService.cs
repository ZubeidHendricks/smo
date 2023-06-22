using Microsoft.Extensions.Azure;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using NPOMS.Domain.Mapping;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Repository.Interfaces.Lookup;
using NPOMS.Repository.Interfaces.Mapping;
using NPOMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Services.Implementation
{
	public class NpoProfileService : INpoProfileService
	{
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
        private ISourceOfInformationRepository _sourceOfInformationRepository;
        private IAffiliatedOrganisationInformationRepository _affiliatedOrganisationInformationRepository;

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
            IAffiliatedOrganisationInformationRepository affiliatedOrganisationInformationRepository,
            ISourceOfInformationRepository sourceOfInformationRepository)
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
			_affiliatedOrganisationInformationRepository = affiliatedOrganisationInformationRepository;
			_sourceOfInformationRepository = sourceOfInformationRepository;
        }

		#endregion

		#region Methods

		public async Task<IEnumerable<NpoProfile>> Get(string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
			var npoProfiles = await _npoProfileRepository.GetEntities();

			if (loggedInUser.Roles.Any(x => x.RoleId.Equals((int)RoleEnum.SystemAdmin) || x.RoleId.Equals((int)RoleEnum.Admin)))
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

		public async Task<IEnumerable<ServicesRendered>> GetServicesRenderedByNpoProfileId(int npoProfileId)
		{
			return await _servicesRenderedRepository.GetByNpoProfileId(npoProfileId);
		}

		public async Task Create(ServicesRendered model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _servicesRenderedRepository.CreateAsync(model);
		}

		public async Task Update(ServicesRendered model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _servicesRenderedRepository.UpdateAsync(null, model, false, loggedInUser.Id);
		}

		public async Task<IEnumerable<BankDetail>> GetBankDetailsByNpoProfileId(int npoProfileId)
		{
			return await _bankDetailRepository.GetByNpoProfileId(npoProfileId);
		}

		public async Task Create(BankDetail model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _bankDetailRepository.CreateAsync(model);
		}

		public async Task Update(BankDetail model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _bankDetailRepository.UpdateAsync(null, model, false, loggedInUser.Id);
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

		public async Task Update(List<PreviousYearFinance> model, string userIdentifier, string id)
		{
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            foreach (var m in model)
            {
                if (m.Id == 0)
                {
					m.CreatedUserId = loggedInUser.Id;
					m.CreatedDateTime = DateTime.Now;
                    m.npoProfileId = Convert.ToInt32(id);
                    await _previousYearFinanceRepository.CreateAsync(m);
                }
                else
                {
                    m.UpdatedUserId = loggedInUser.Id;
                    m.UpdatedDateTime = DateTime.Now;
                    await _previousYearFinanceRepository.UpdateAsync(m);
                }
            }
        }

        public async Task<PreviousYearFinance> DeleteById(int id)
        {
            return await _previousYearFinanceRepository.DeleteById(id);
        }

        public async Task<BankDetail> DeleteBankDetailById(int id)
        {
            return await _bankDetailRepository.DeleteBankDetailById(id);
        }

        public async Task Update(List<AffiliatedOrganisationInformation> model, string userIdentifier, string id)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            foreach (var m in model)
            {
                if (m.Id == 0)
                {
                    m.CreatedUserId = loggedInUser.Id;
                    m.CreatedDateTime = DateTime.Now;
                    m.npoProfileId = Convert.ToInt32(id);
                    await _affiliatedOrganisationInformationRepository.CreateAsync(m);
                }
                else
                {
                    m.UpdatedUserId = loggedInUser.Id;
                    m.UpdatedDateTime = DateTime.Now;
                    await _affiliatedOrganisationInformationRepository.UpdateAsync(m);
                }
            }
        }

        public async Task Update(SourceOfInformation model, string userIdentifier, string npoProfileId)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
			var getData = await _sourceOfInformationRepository.GetSourceOfInformationByIdAsync( Convert.ToInt32(npoProfileId));
			//foreach (var m in model)
			//{
				if (getData.Count() <= 1)
                {
                    model.CreatedUserId = loggedInUser.Id;
                    model.CreatedDateTime = DateTime.Now;
                   // model.NpoProfileId = Convert.ToInt32(id);
                    await _sourceOfInformationRepository.CreateAsync(model);
                }
                else
                {
                    model.UpdatedUserId = loggedInUser.Id;
                    model.UpdatedDateTime = DateTime.Now;
                    await _sourceOfInformationRepository.UpdateAsync(model);
                }
			//}
		}

        public async Task<IEnumerable<AffiliatedOrganisationInformation>> GetAffiliatedOrganisationById(int id)
        {
            return await _affiliatedOrganisationInformationRepository.GetAffiliatedOrganisationByIdAsync(id);
        }
        public async Task<IEnumerable<SourceOfInformation>> GetSourceOfInformationById(int id)
        {
            return await _sourceOfInformationRepository.GetSourceOfInformationByIdAsync(id);
        }
        #endregion
    }
}
