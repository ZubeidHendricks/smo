using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Dropdown;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Repository.Interfaces.Mapping;
using NPOMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Services.Implementation
{
	public class NpoService : INpoService
	{

		#region Fields

		private INpoRepository _npoRepository;
		private IUserRepository _userRepository;
		private IOrganisationTypeRepository _organisationTypeRepository;
		private IContactInformationRepository _contactInformationRepository;
		private IUserNpoRepository _userNpoRepository;
		private IRegistrationStatusRepository _registrationStatusRepository;

		#endregion

		#region Constructorrs

		public NpoService(
			INpoRepository npoRepository,
			IUserRepository userRepository,
			IOrganisationTypeRepository organisationTypeRepository,
			IContactInformationRepository contactInformationRepository,
			IUserNpoRepository userNpoRepository,
			IRegistrationStatusRepository registrationStatusRepository)
		{
			_npoRepository = npoRepository;
			_userRepository = userRepository;
			_organisationTypeRepository = organisationTypeRepository;
			_contactInformationRepository = contactInformationRepository;
			_userNpoRepository = userNpoRepository;
			_registrationStatusRepository = registrationStatusRepository;
		}

        #endregion

        #region Methods

        public async Task<IEnumerable<Npo>> Get(string userIdentifier, AccessStatusEnum accessStatus)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
            var npos = await _npoRepository.GetEntities();

            if (Enum.IsDefined(typeof(AccessStatusEnum), accessStatus))
            {
                int accessStatusId = (int)accessStatus;

                if (accessStatusId != 0)
                    npos = npos.Where(x => x.ApprovalStatusId == accessStatusId);
            }

            if (loggedInUser.Roles.Any(x => x.RoleId.Equals((int)RoleEnum.SystemAdmin) || x.RoleId.Equals((int)RoleEnum.Admin)))
            {
                return npos;
            }
            else
            {
                var mappings = await _userNpoRepository.GetApprovedEntities(loggedInUser.Id);
                var NpoIds = mappings.Select(x => x.NpoId);
                var results = npos.Where(x => NpoIds.Contains(x.Id));

                return results;
            }
        }

        public async Task<IEnumerable<Npo>> GetQuickCaptures(string userIdentifier, AccessStatusEnum accessStatus)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
			var npos = await _npoRepository.GetQuickCapturers();

			if (Enum.IsDefined(typeof(AccessStatusEnum), accessStatus))
			{
				int accessStatusId = (int)accessStatus;

				if (accessStatusId != 0)
					npos = npos.Where(x => x.ApprovalStatusId == accessStatusId);
			}

			if (loggedInUser.Roles.Any(x => x.RoleId.Equals((int)RoleEnum.SystemAdmin) || x.RoleId.Equals((int)RoleEnum.Admin)))
			{
				return npos;
			}
			else
			{
				var mappings = await _userNpoRepository.GetApprovedEntities(loggedInUser.Id);
				var NpoIds = mappings.Select(x => x.NpoId);
				var results = npos.Where(x => NpoIds.Contains(x.Id));

				return results;
			}
		}

		public async Task<Npo> GetById(int id)
		{
			var result = await _npoRepository.GetById(id);
			result.OrganisationType = await _organisationTypeRepository.GetById(result.OrganisationTypeId);

			result.RegistrationStatus = result.RegistrationStatusId != null ? await _registrationStatusRepository.GetById(Convert.ToInt32(result.RegistrationStatusId)) : null;

			var contactInformation = await _contactInformationRepository.GetByNpoId(result.Id);
			result.ContactInformation = contactInformation.ToList();

			return result;
		}

		public async Task<IEnumerable<Npo>> Search(string name)
		{
			return await _npoRepository.SearchByName(name);
		}

		public async Task<IEnumerable<Npo>> SearchApprovedNpo(string name)
		{
			return await _npoRepository.SearchApprovedNpoByName(name);
		}

		public async Task<Npo> GetByNameAndOrgTypeId(string name, int organisationTypeId, string CCode)
		{
			return await _npoRepository.GetByNameAndOrgTypeId(name, organisationTypeId, CCode);
		}

		public async Task Create(Npo npo, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			npo.CreatedUserId = loggedInUser.Id;
			npo.CreatedDateTime = DateTime.Now;

			await _npoRepository.CreateEntity(npo);
		}

		public async Task Update(Npo npo, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			npo.UpdatedUserId = loggedInUser.Id;
			npo.UpdatedDateTime = DateTime.Now;

			await UpdateMappings(npo, loggedInUser.Id);
			await _npoRepository.UpdateEntity(npo, loggedInUser.Id);
		}

		private async Task UpdateMappings(Npo model, int currentUserId)
		{
			if (model.ContactInformation != null)
			{
				var contactDetails = await _contactInformationRepository.GetByNpoId(model.Id);

				if (contactDetails.Count() > 0)
				{
					var existingIds = contactDetails.Select(x => x.Id);
					var newIds = model.ContactInformation.Select(x => x.Id);

					foreach (var id in existingIds)
					{
						if (!newIds.Contains(id))
							await _contactInformationRepository.DeleteEntity(id, model, currentUserId);
					}
				}
			}
		}

		public async Task UpdateNpoStatus(Npo npo, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			npo.ApprovalStatus = null;
			npo.UpdatedUserId = loggedInUser.Id;
			npo.UpdatedDateTime = DateTime.Now;
			npo.ApprovalUserId = loggedInUser.Id;
			npo.ApprovalDateTime = DateTime.Now;

			await _npoRepository.UpdateEntity(npo, loggedInUser.Id);
		}

		#endregion
	}
}
