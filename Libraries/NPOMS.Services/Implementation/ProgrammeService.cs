using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using NPOMS.Domain.Mapping;
using NPOMS.Repository;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Dropdown;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Services.Interfaces;
using NPOMS.Services.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IProgrammeRepository = NPOMS.Repository.Interfaces.Dropdown.IProgrammeRepository;

namespace NPOMS.Services.Implementation
{
    public class ProgrammeService : IProgrammeService
    {
        private IProgrameBankDetailRepository _programeBankDetailRepository;
        private IProgrameContactDetailRepository _programeContactDetailRepository;
        private IUserRepository _userRepository;
        private RepositoryContext _repositoryContext;
        private IProgrameDeliveryRepository _programeDeliveryRepository;
        private INpoProfileRepository _npoProfileRepository;
        private readonly IDistrictCouncilRepository _districtRepository;
        private readonly ILocalMunicipalityRepository _localMunicipalityRepository;
        private IProgrammeRepository _programme;
        private IDepartmentRepository _department;
        private INpoProfileService _npoProfilService;

        public ProgrammeService(
            IProgrameBankDetailRepository programeBankDetailRepository,
            IProgrameContactDetailRepository programeContactDetailRepository,
            IUserRepository userRepository,
            IProgrameDeliveryRepository programeDeliveryRepository,
            INpoProfileRepository npoProfileRepository,
            IDistrictCouncilRepository districtRepository,
            ILocalMunicipalityRepository localMunicipalityRepository,
            IProgrammeRepository programme,
            IDepartmentRepository department,
            RepositoryContext repositoryContext,
            INpoProfileService npoProfilService)
        {
            _programeBankDetailRepository = programeBankDetailRepository;
            _programeContactDetailRepository = programeContactDetailRepository;
            _userRepository = userRepository;
            _repositoryContext = repositoryContext;
            _programeDeliveryRepository = programeDeliveryRepository;
            _npoProfileRepository = npoProfileRepository;
            _districtRepository = districtRepository;
            _localMunicipalityRepository = localMunicipalityRepository;
            _programme = programme;
            _department = department;
            _npoProfilService = npoProfilService;
        }

        public async Task CreateBankDetails(ProgramBankDetails model, string userId, int npoProfileId)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userId);
            //var npoProfile = await _npoProfilService.GetByNpoId(npoProfileId);
            model.CreatedUserId = loggedInUser.Id;
            model.CreatedDateTime = DateTime.Now;
            model.NpoProfileId = npoProfileId;

            bool isDSD = await IsDepartmentAbbreviationDSD(model.ProgramId);

            if (isDSD)
            {
                model.ApprovalStatusId = (int)AccessStatusEnum.Pending;
            }
            else
            {
                model.ApprovalStatusId = (int)AccessStatusEnum.Approved;
            }

            await _programeBankDetailRepository.CreateAsync(model);

            var npoProfile = await _npoProfileRepository.GetByNpoId(npoProfileId);
            
            //if (isDSD)
            //{
            //    npoProfile.AccessStatusId = (int)AccessStatusEnum.Pending;
            //}
            //else
            //{
            //    npoProfile.AccessStatusId = (int)AccessStatusEnum.Approved;
            //}
            //await _npoProfileRepository.UpdateAsync(npoProfile);
        }
        public async Task UpdateBankDetails(ProgramBankDetails model, string userId, int npoProfileId)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userId);

            model.UpdatedUserId = loggedInUser.Id;
            model.UpdatedDateTime = DateTime.Now;
            model.NpoProfileId = npoProfileId;

            bool isDSD = await IsDepartmentAbbreviationDSD(model.ProgramId);

            if (isDSD)
            {
                model.ApprovalStatusId = (int)AccessStatusEnum.Pending;
            }
            else
            {
                model.ApprovalStatusId = (int)AccessStatusEnum.Approved;
            }

            var oldEntity = await _repositoryContext.ProgramBankDetails.FirstOrDefaultAsync(x=> x.Id == model.Id && x.NpoProfileId == npoProfileId);
            await _programeBankDetailRepository.UpdateAsync(oldEntity, model, true, loggedInUser.Id);

            var npoProfile = await _npoProfileRepository.GetById(npoProfileId);

            if (isDSD)
            {
                npoProfile.AccessStatusId = (int)AccessStatusEnum.Pending;
            }
            else
            {
                npoProfile.AccessStatusId = (int)AccessStatusEnum.Approved;
            }
            await _npoProfileRepository.UpdateAsync(npoProfile);
        }

        public async Task CreateContact(ProgramContactInformation model, string userId, int npoProfileId)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userId);

            model.CreatedUserId = loggedInUser.Id;
            model.CreatedDateTime = DateTime.Now;
            model.NpoProfileId = npoProfileId;

            bool isDSD = await IsDepartmentAbbreviationDSD(model.ProgrammeId);

            if (isDSD)
            {
                model.ApprovalStatusId = (int)AccessStatusEnum.Pending;
            }
            else
            {
                model.ApprovalStatusId = (int)AccessStatusEnum.Approved;
            }

            await _programeContactDetailRepository.CreateAsync(model);

            var npoProfile = await _npoProfileRepository.GetById(npoProfileId);

            if (isDSD)
            {
                npoProfile.AccessStatusId = (int)AccessStatusEnum.Pending;
            }
            else
            {
                npoProfile.AccessStatusId = (int)AccessStatusEnum.Approved;
            }

            await _npoProfileRepository.UpdateAsync(npoProfile);
        }

        public async Task UpdateContact(ProgramContactInformation model, string userId, int npoProfileId)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userId);

            model.UpdatedUserId = loggedInUser.Id;
            model.UpdatedDateTime = DateTime.Now;
            model.NpoProfileId = npoProfileId;

            bool isDSD = await IsDepartmentAbbreviationDSD(model.ProgrammeId);

            if (isDSD)
            {
                model.ApprovalStatusId = (int)AccessStatusEnum.Pending;
            }
            else
            {
                model.ApprovalStatusId = (int)AccessStatusEnum.Approved;
            }

            var oldEntity = await this._repositoryContext.ProgramContactInformation.FirstOrDefaultAsync(x => x.Id == model.Id && x.NpoProfileId == npoProfileId);
            await _programeContactDetailRepository.UpdateAsync(oldEntity, model, true, loggedInUser.Id);

            var npoProfile = await _npoProfileRepository.GetById(npoProfileId);
            if (isDSD)
            {
                npoProfile.AccessStatusId = (int)AccessStatusEnum.Pending;
            }
            else
            {
                npoProfile.AccessStatusId = (int)AccessStatusEnum.Approved;
            }

            await _npoProfileRepository.UpdateAsync(npoProfile);
        }
        public async Task CreateDelivery(ProgrammeServiceDeliveryVM programmeServiceDeliveryVM, string userId, int npoProfileId)
        {
            var model = await ProgrammeServiceDeliveryDetails(programmeServiceDeliveryVM);

            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userId);
            model.IsActive = true;
            model.CreatedUserId = loggedInUser.Id;
            model.CreatedDateTime = DateTime.Now;
            model.NpoProfileId = npoProfileId;
            bool isDSD = await IsDepartmentAbbreviationDSD(programmeServiceDeliveryVM.ProgramId);

            if (isDSD)
            {

                model.ApprovalStatusId = (int)AccessStatusEnum.Pending;
            }
            else
            {

                model.ApprovalStatusId = (int)AccessStatusEnum.Approved;
            }
            await _programeDeliveryRepository.CreateAsync(model);

            var npoProfile = await _npoProfileRepository.GetById(npoProfileId);
            if (isDSD)
            {
                npoProfile.AccessStatusId = (int)AccessStatusEnum.Pending;
            }
            else
            {
                npoProfile.AccessStatusId = (int)AccessStatusEnum.Approved;
            }

            await _npoProfileRepository.UpdateAsync(npoProfile);
        }

        public async Task UpdateBankSelection(string userId, int id, bool selection, int npoId)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userId);

            // Fetch the existing entity
            var existingEntity = await _repositoryContext.ProgramBankDetails
                .Where(x => x.NpoProfileId == npoId).ToListAsync();

            if (existingEntity == null)
            {
                throw new Exception("Entity not found");
            }

            foreach (var entity in existingEntity)
            {
                entity.IsSelected = false;
                await _repositoryContext.SaveChangesAsync();
            }

            var existingEntityUpdate = await _repositoryContext.ProgramBankDetails
                .FirstOrDefaultAsync(x => x.Id == id);

            // Set existing entity properties
            existingEntityUpdate.UpdatedUserId = loggedInUser.Id;
            existingEntityUpdate.UpdatedDateTime = DateTime.Now;
            existingEntityUpdate.IsSelected = selection;

            // Save the updated entity to mark old regions and areas as inactive
            await _repositoryContext.SaveChangesAsync();

        }

        public async Task UpdateDeliveryAreaSelection(string userId, int id, bool selection)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userId);

            // Fetch the existing entity
            var existingEntity = await _repositoryContext.ProgrammeServiceDelivery
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existingEntity == null)
            {
                throw new Exception("Entity not found");
            }

            // Set existing entity properties
            existingEntity.UpdatedUserId = loggedInUser.Id;
            existingEntity.UpdatedDateTime = DateTime.Now;
            existingEntity.IsSelected = selection;

            // Save the updated entity to mark old regions and areas as inactive
            await _repositoryContext.SaveChangesAsync();

        }

        public async Task UpdateDelivery(ProgrammeServiceDeliveryVM programmeServiceDeliveryVM, string userId, int npoProfileId)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userId);

            // Fetch the existing entity
            var existingEntity = await _repositoryContext.ProgrammeServiceDelivery
                .Include(psd => psd.Regions)
                .Include(psd => psd.ServiceDeliveryAreas)
                .Include(psd => psd.DistrictCouncil)
                .Include(psd => psd.LocalMunicipality)
                .FirstOrDefaultAsync(psd => psd.Id == programmeServiceDeliveryVM.Id && psd.NpoProfileId == npoProfileId);

            if (existingEntity == null)
            {
                throw new Exception("Entity not found");
            }

            // Set existing entity properties
            existingEntity.UpdatedUserId = loggedInUser.Id;
            existingEntity.UpdatedDateTime = DateTime.Now;
            existingEntity.IsActive = programmeServiceDeliveryVM.IsActive;
            existingEntity.NpoProfileId = npoProfileId;

            bool isDSD = await IsDepartmentAbbreviationDSD(programmeServiceDeliveryVM.ProgramId);

            if (isDSD)
            {
                existingEntity.ApprovalStatusId = (int)AccessStatusEnum.Pending;
            }
            else
            {
                existingEntity.ApprovalStatusId = (int)AccessStatusEnum.Approved;
            }

            // Set existing related entities to inactive if they are not in the new list
            var newRegionIds = programmeServiceDeliveryVM.Regions.Select(r => r.ID).ToList();
            foreach (var region in existingEntity.Regions)
            {
                if (!newRegionIds.Contains(region.RegionId))
                {
                    region.IsActive = false;
                }
            }

            var newSdaIds = programmeServiceDeliveryVM.ServiceDeliveryAreas.Select(sda => sda.ID).ToList();
            foreach (var sda in existingEntity.ServiceDeliveryAreas)
            {
                if (!newSdaIds.Contains(sda.ServiceDeliveryAreaId))
                {
                    sda.IsActive = false;
                }
            }

            // Save the updated entity to mark old regions and areas as inactive
            await _repositoryContext.SaveChangesAsync();

            // Reactivate existing regions or add new ones
            foreach (var newRegion in programmeServiceDeliveryVM.Regions)
            {
                var existingRegion = existingEntity.Regions.FirstOrDefault(r => r.RegionId == newRegion.ID);
                if (existingRegion != null)
                {
                    existingRegion.IsActive = true;
                }
                else
                {
                    existingEntity.Regions.Add(new ProgrammeSDADetail_Region
                    {
                        ProgrameServiceDeliveryId = existingEntity.Id, // Set the foreign key
                        RegionId = newRegion.ID,
                        IsActive = true
                    });
                }
            }

            // Reactivate existing service delivery areas or add new ones
            foreach (var newSda in programmeServiceDeliveryVM.ServiceDeliveryAreas)
            {
                var existingSda = existingEntity.ServiceDeliveryAreas.FirstOrDefault(sda => sda.ServiceDeliveryAreaId == newSda.ID);
                if (existingSda != null)
                {
                    existingSda.IsActive = true;
                }
                else
                {
                    existingEntity.ServiceDeliveryAreas.Add(new ProgrameServiceDeliveryArea
                    {
                        ProgrameServiceDeliveryId = existingEntity.Id, // Set the foreign key
                        ServiceDeliveryAreaId = newSda.ID,
                        IsActive = true
                    });
                }
            }

            // Set the new values for other properties
            existingEntity.ProgramId = programmeServiceDeliveryVM.ProgramId;
            existingEntity.SubProgrammeId = programmeServiceDeliveryVM.SubProgrammeId;
            existingEntity.SubProgrammeTypeId = programmeServiceDeliveryVM.SubProgrammeTypeId;
            existingEntity.DistrictCouncilId = programmeServiceDeliveryVM.DistrictCouncil.Id;
            existingEntity.LocalMunicipalityId = programmeServiceDeliveryVM.LocalMunicipality.ID;

            // Save the updated entity
            try
            {
                await _repositoryContext.SaveChangesAsync();

                var npoProfile = await _npoProfileRepository.GetById(npoProfileId);
                if (isDSD)
                {
                    npoProfile.AccessStatusId = (int)AccessStatusEnum.Pending;
                }
                else
                {
                    npoProfile.AccessStatusId = (int)AccessStatusEnum.Approved;
                }

                await _npoProfileRepository.UpdateAsync(npoProfile);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while saving changes", ex);
            }
        }

        private async Task<ProgrammeServiceDelivery> ProgrammeServiceDeliveryDetails1(ProgrammeServiceDeliveryVM model)
        {
            var programmeServiceDeliveryDetails = new ProgrammeServiceDelivery
            {
                ProgramId = model.ProgramId,
                IsActive = model.IsActive,
                CreatedUserId = model.CreatedUserId,
                CreatedDateTime = model.CreatedDateTime,
                UpdatedUserId = model.UpdatedUserId,
                UpdatedDateTime = model.UpdatedDateTime,
                Id = model.Id
            };

            int districtId = model.DistrictCouncil.Id;
            var district = await _districtRepository.GetById(districtId);
            programmeServiceDeliveryDetails.DistrictCouncil = district;
            programmeServiceDeliveryDetails.LocalMunicipality = await _localMunicipalityRepository.GetById(model.LocalMunicipality.ID);
            programmeServiceDeliveryDetails.DistrictCouncilId = programmeServiceDeliveryDetails.DistrictCouncil?.Id ?? 0;
            programmeServiceDeliveryDetails.LocalMunicipalityId = programmeServiceDeliveryDetails.LocalMunicipality?.Id ?? 0;

            programmeServiceDeliveryDetails.Regions = model.Regions.Select(item => new ProgrammeSDADetail_Region
            {
                RegionId = item.ID,
                IsActive = true
            }).ToList();

            programmeServiceDeliveryDetails.ServiceDeliveryAreas = model.ServiceDeliveryAreas.Select(item => new ProgrameServiceDeliveryArea
            {
                ServiceDeliveryAreaId = item.ID,
                IsActive = true
            }).ToList();

            return programmeServiceDeliveryDetails;
        }
        private async Task<ProgrammeServiceDelivery> ProgrammeServiceDeliveryDetails(ProgrammeServiceDeliveryVM model)
        {
            var programmeServiceDeliveryDetails = new ProgrammeServiceDelivery();

            programmeServiceDeliveryDetails.ProgramId = model.ProgramId;
            programmeServiceDeliveryDetails.SubProgrammeId = model.SubProgrammeId;
            programmeServiceDeliveryDetails.SubProgrammeTypeId = model.SubProgrammeTypeId;
            int districtId = model.DistrictCouncil.Id;
            var district = await _districtRepository.GetById(districtId);

            programmeServiceDeliveryDetails.DistrictCouncil = district;
            programmeServiceDeliveryDetails.LocalMunicipality
                = await _localMunicipalityRepository.GetById(model.LocalMunicipality.ID);

            programmeServiceDeliveryDetails.DistrictCouncilId = programmeServiceDeliveryDetails.DistrictCouncil == null ? 0 : programmeServiceDeliveryDetails.DistrictCouncil.Id;
            programmeServiceDeliveryDetails.DistrictCouncil = null;

            programmeServiceDeliveryDetails.LocalMunicipalityId = programmeServiceDeliveryDetails.LocalMunicipality == null ? 0 : programmeServiceDeliveryDetails.LocalMunicipality.Id;
            programmeServiceDeliveryDetails.LocalMunicipality = null;

            foreach (var item in model.Regions)
            {
                var bidRegion = new ProgrammeSDADetail_Region
                {
                    RegionId = item.ID,
                    IsActive = true

                };

                programmeServiceDeliveryDetails.Regions.Add(bidRegion);
            }

            foreach (var item in model.ServiceDeliveryAreas)
            {
                var bidServiceDeliveryArea = new ProgrameServiceDeliveryArea()
                {
                    ServiceDeliveryAreaId = item.ID,
                    IsActive = true
                };

                programmeServiceDeliveryDetails.ServiceDeliveryAreas.Add(bidServiceDeliveryArea);
            }

            return programmeServiceDeliveryDetails;
        }

        private async Task<bool> IsDepartmentAbbreviationDSD(int programId)
        {
            var prog = await _programme.GetById(programId);
            var depart = await _department.GetDepartmentById(prog.DepartmentId);
            return depart.Abbreviation.ToLower() == "dsd";
        }

        public async Task<IEnumerable<ProgramBankDetails>> GetBankDetailsByIds(int programmeId, int npoProfileId, int subProgramId, int subProgramTypeId)
        {
            var bankDetail = await _programeBankDetailRepository.GetBankDetailsByIds(programmeId,npoProfileId, subProgramId, subProgramTypeId);
            
            return bankDetail;
        }

        public async Task<IEnumerable<ProgrammeServiceDelivery>> GetDeliveryDetailsByIds(int programmeId, int subProgramId, int subProgramTypeId, int npoProfileId)
        {
            var deliveryDetails = await _programeDeliveryRepository.GetDeliveryDetailsByIds(programmeId, npoProfileId, subProgramId, subProgramTypeId);

            return deliveryDetails;
        }

        public async Task<IEnumerable<ProgramContactInformation>> GetContactDetailsByIds(int programmeId, int npoProfileId, int subProgramId, int subProgramTypeId)
        {
            var contactDetails = await _programeContactDetailRepository.GetContactDetailsByIds(programmeId, npoProfileId, subProgramId, subProgramTypeId);

            return contactDetails;
        }

    }
}
