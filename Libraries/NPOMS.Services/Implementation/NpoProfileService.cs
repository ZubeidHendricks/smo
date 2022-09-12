using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
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

		#endregion

		#region Constructorrs

		public NpoProfileService(
			INpoProfileRepository npoProfileRepository,
			IUserRepository userRepository,
			INpoRepository npoRepository,
			IUserNpoRepository userNpoRepository,
			INpoProfileFacilityListRepository npoProfileFacilityListRepository,
			IFacilityListRepository facilityListRepository,
			IServicesRenderedRepository servicesRenderedRepository
			)
		{
			_npoProfileRepository = npoProfileRepository;
			_userRepository = userRepository;
			_npoRepository = npoRepository;
			_userNpoRepository = userNpoRepository;
			_npoProfileFacilityListRepository = npoProfileFacilityListRepository;
			_facilityListRepository = facilityListRepository;
			_servicesRenderedRepository = servicesRenderedRepository;
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

			var mappings = await _npoProfileFacilityListRepository.GetByNpoProfileId(result.Id);
			result.NpoProfileFacilityLists = mappings.ToList();

			var servicesRendered = await _servicesRenderedRepository.GetByNpoProfileId(result.Id);
			result.ServicesRendered = servicesRendered.ToList();

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

			await GetMappedObjects(profile);
			ClearObjects(profile);
			await UpdateMappings(profile);

			profile.UpdatedUserId = loggedInUser.Id;
			profile.UpdatedDateTime = DateTime.Now;

			await _npoProfileRepository.UpdateEntity(profile);
		}

		private static void ClearObjects(NpoProfile model)
		{
			foreach (var item in model.NpoProfileFacilityLists)
			{
				item.FacilityList = null;
			}
		}

		private async Task GetMappedObjects(NpoProfile model)
		{
			foreach (var item in model.NpoProfileFacilityLists)
			{
				var facility = await _facilityListRepository.GetByProperties(item.FacilityList);

				if (facility != null)
				{
					item.FacilityListId = facility.Id;
					item.IsActive = true;
				}
			}

			foreach (var item in model.ServicesRendered)
			{
				var service = await _servicesRenderedRepository.GetByProperties(item);

				if (service != null)
				{
					item.Id = service.Id;
					item.NpoProfileId = service.NpoProfileId;
					item.IsActive = true;
				}
			}
		}

		private async Task UpdateMappings(NpoProfile model)
		{
			if (model.NpoProfileFacilityLists != null)
			{
				var mappings = await _npoProfileFacilityListRepository.GetByNpoProfileId(model.Id);

				if (mappings.Count() > 0)
				{
					var existingIds = mappings.Select(x => x.Id);
					var newIds = model.NpoProfileFacilityLists.Select(x => x.Id);

					foreach (var id in existingIds)
					{
						if (!newIds.Contains(id))
							await _npoProfileFacilityListRepository.DeleteEntity(id);
					}
				}
			}

			if (model.ServicesRendered != null)
			{
				var mappings = await _servicesRenderedRepository.GetByNpoProfileId(model.Id);

				if (mappings.Count() > 0)
				{
					var existingIds = mappings.Select(x => x.Id);
					var newIds = model.ServicesRendered.Select(x => x.Id);

					foreach (var id in existingIds)
					{
						if (!newIds.Contains(id))
							await _servicesRenderedRepository.DeleteEntity(id);
					}
				}
			}
		}

		public async Task<NpoProfile> GetByNpoId(int NpoId)
		{
			var result = await _npoProfileRepository.GetByNpoId(NpoId);

			var mappings = await _npoProfileFacilityListRepository.GetByNpoProfileId(result.Id);
			result.NpoProfileFacilityLists = mappings.ToList();

			var servicesRendered = await _servicesRenderedRepository.GetByNpoProfileId(result.Id);
			result.ServicesRendered = servicesRendered.ToList();

			return result;
		}

		#endregion
	}
}
