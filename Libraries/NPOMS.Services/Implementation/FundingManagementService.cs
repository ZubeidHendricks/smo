using NPOMS.Domain.FundingManagement;
using NPOMS.Repository.Extensions;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Dropdown;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Repository.Interfaces.FundingManagement;
using NPOMS.Services.Interfaces;
using NPOMS.Services.Models.FundingManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace NPOMS.Services.Implementation
{
    public class FundingManagementService : IFundingManagementService
    {
        #region Fields

        private INpoRepository _npoRepository;
        private INpoProfileRepository _npoProfileRepository;
        private IFundingCaptureRepository _fundingCaptureRepository;
        private IFundingDetailRepository _fundingDetailRepository;
        private IUserRepository _userRepository;
        private ISDARepository _sdaRepository;
        private Repository.Interfaces.FundingManagement.IBankDetailRepository _bankDetailRepository;
        private IDocumentRepository _documentRepository;
        private IServiceDeliveryAreaRepository _serviceDeliveryAreaRepository;

        #endregion

        #region Constructors

        public FundingManagementService(
            INpoRepository npoRepository,
            INpoProfileRepository npoProfileRepository,
            IFundingCaptureRepository fundingCaptureRepository,
            IFundingDetailRepository fundingDetailRepository,
            IUserRepository userRepository,
            ISDARepository sdaRepository,
            Repository.Interfaces.FundingManagement.IBankDetailRepository bankDetailRepository,
            IDocumentRepository documentRepository,
            IServiceDeliveryAreaRepository serviceDeliveryAreaRepository
            )
        {
            _npoRepository = npoRepository;
            _npoProfileRepository = npoProfileRepository;
            _fundingCaptureRepository = fundingCaptureRepository;
            _fundingDetailRepository = fundingDetailRepository;
            _userRepository = userRepository;
            _sdaRepository = sdaRepository;
            _bankDetailRepository = bankDetailRepository;
            _documentRepository = documentRepository;
            _serviceDeliveryAreaRepository = serviceDeliveryAreaRepository;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<NpoViewModel>> GetNposForFunding()
        {
            List<NpoViewModel> viewModel = new();
            var profiles = await _npoProfileRepository.GetEntitiesForFundingCapture();
            var fundingCaptures = await _fundingCaptureRepository.GetAll();
            var fundingDetails = await _fundingDetailRepository.GetAll();

            foreach (var profile in profiles)
            {
                var npoViewModel = new NpoViewModel
                {
                    Id = profile.Npo.Id,
                    RefNo = profile.Npo.RefNo,
                    Name = profile.Npo.Name,
                    CCode = profile.Npo.CCode,
                    IsActive = profile.Npo.IsActive,
                    NpoProfileId = profile.Id
                };

                if (profile.Npo.FundingCaptures.Count > 0)
                {
                    var fundings = fundingCaptures.Where(x => x.NpoId.Equals(profile.NpoId) && x.IsActive).ToList();

                    foreach (var funding in fundings)
                    {
                        var detail = fundingDetails.Where(x => x.FundingCaptureId.Equals(funding.Id) && x.IsActive).FirstOrDefault();
                        var sda = await _sdaRepository.GetByFundingCaptureId(funding.Id);
                        var serviceDeliveryArea = await _serviceDeliveryAreaRepository.GetEntities(true);

                        var fundingCaptureViewModel = new FundingCaptureViewModel
                        {
                            Id = funding.Id,
                            RefNo = funding.RefNo,
                            NpoId = funding.NpoId,
                            FinancialYearId = funding.FinancialYearId,
                            FinancialYearName = funding.FinancialYear.Name,
                            StatusId = funding.StatusId,
                            StatusName = funding.Status.Name,
                            IsActive = funding.IsActive,
                            FundingDetailViewModel = new()
                            {
                                Id = detail.Id,
                                FundingCaptureId = detail.FundingCaptureId,
                                ProgrammeId = detail.ProgrammeId,
                                ProgrammeName = detail.Programme.Name,
                                SubProgrammeTypeId = detail.SubProgrammeTypeId,
                                SubProgrammeTypeName = detail.SubProgrammeType.Name,
                                FrequencyId = detail.FrequencyId ?? null,
                                FrequencyName = detail.Frequency != null ? detail.Frequency.Name : string.Empty,
                                AmountAwarded = detail.AmountAwarded ?? 0
                            },
                            SDAViewModel = new()
                            {
                                Id = sda.Id,
                                ServiceDeliveryAreaName = sda.ServiceDeliveryAreaId != null ? serviceDeliveryArea.FirstOrDefault(x => x.Id.Equals(sda.ServiceDeliveryAreaId)).Name : string.Empty
                            }
                        };

                        npoViewModel.FundingCaptureViewModels.Add(fundingCaptureViewModel);
                    }
                }

                viewModel.Add(npoViewModel);
            }

            return viewModel;
        }

        public async Task<bool> CanCaptureFunding(int financialYearId, int programmeId, int subProgrammeId, int subProgrammeTypeId)
        {
            var fundingDetail = await _fundingDetailRepository.GetByIds(financialYearId, programmeId, subProgrammeId, subProgrammeTypeId);
            return fundingDetail != null ? false : true;
        }

        public async Task<FundingCaptureViewModel> CreateFundingCapture(FundingCaptureViewModel model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            var fundingCapture = new FundingCapture
            {
                RefNo = StringExtensions.GenerateNewCode("FUND"),
                NpoId = model.NpoId,
                FinancialYearId = model.FinancialYearId,
                StatusId = model.StatusId,
                IsActive = model.IsActive,
                CreatedUserId = loggedInUser.Id,
                CreatedDateTime = DateTime.Now
            };
            await _fundingCaptureRepository.CreateAsync(fundingCapture);

            var fundingDetail = new FundingDetail
            {
                FundingCaptureId = fundingCapture.Id,
                FinancialYearId = model.FundingDetailViewModel.FinancialYearId,
                FundingTypeId = model.FundingDetailViewModel.FundingTypeId,
                AllowVariableFunding = model.FundingDetailViewModel.AllowVariableFunding,
                AllowClaims = model.FundingDetailViewModel.AllowClaims,
                ProgrammeId = model.FundingDetailViewModel.ProgrammeId,
                SubProgrammeId = model.FundingDetailViewModel.SubProgrammeId,
                SubProgrammeTypeId = model.FundingDetailViewModel.SubProgrammeTypeId,
                CalculationTypeId = model.FundingDetailViewModel.CalculationTypeId,
                IsActive = model.FundingDetailViewModel.IsActive,
                CreatedUserId = loggedInUser.Id,
                CreatedDateTime = DateTime.Now
            };
            await _fundingDetailRepository.CreateAsync(fundingDetail);

            await _sdaRepository.CreateAsync(new() { FundingCaptureId = fundingCapture.Id, IsActive = true, CreatedUserId = loggedInUser.Id, CreatedDateTime = DateTime.Now });
            await _bankDetailRepository.CreateAsync(new() { FundingCaptureId = fundingCapture.Id, IsActive = true, CreatedUserId = loggedInUser.Id, CreatedDateTime = DateTime.Now });
            await _documentRepository.CreateAsync(new() { FundingCaptureId = fundingCapture.Id, IsActive = true, CreatedUserId = loggedInUser.Id, CreatedDateTime = DateTime.Now });

            model.Id = fundingCapture.Id;
            return model;
        }

        public async Task UpdateFundingCapture(FundingCaptureViewModel model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
            var fundingCapture = await _fundingCaptureRepository.GetById(model.Id);

            fundingCapture.StatusId = model.StatusId;
            fundingCapture.IsActive = model.IsActive;
            fundingCapture.UpdatedUserId = loggedInUser.Id;
            fundingCapture.UpdatedDateTime = DateTime.Now;

            await _fundingCaptureRepository.UpdateAsync(fundingCapture);
        }

        public async Task<NpoViewModel> GetById(int id)
        {
            var fundingDetail = await _fundingDetailRepository.GetByFundingCaptureId(id);
            var sda = await _sdaRepository.GetByFundingCaptureId(id);
            var bankDetail = await _bankDetailRepository.GetByFundingCaptureId(id);
            var document = await _documentRepository.GetByFundingCaptureId(id);

            var fundingCapture = await _fundingCaptureRepository.GetById(id);
            var npo = await _npoRepository.GetById(fundingCapture.NpoId);
            var npoProfile = await _npoProfileRepository.GetByNpoId(fundingCapture.NpoId);

            var funding = new FundingCaptureViewModel
            {
                Id = id,
                StatusId = fundingCapture.StatusId,
                IsActive = fundingCapture.IsActive,
                FundingDetailViewModel = new()
                {
                    Id = fundingDetail.Id,
                    FundingCaptureId = fundingDetail.FundingCaptureId,
                    FinancialYearId = fundingDetail.FinancialYearId,
                    FinancialYearName = fundingDetail.FinancialYear.Name,
                    FinancialYearStartDate = fundingDetail.FinancialYear.StartDate,
                    FinancialYearEndDate = fundingDetail.FinancialYear.EndDate,
                    StartDate = fundingDetail.StartDate ?? string.Empty,
                    FundingTypeId = fundingDetail.FundingTypeId,
                    FundingTypeName = fundingDetail.FundingType.Name,
                    FrequencyId = fundingDetail.FrequencyId ?? null,
                    FrequencyName = fundingDetail.Frequency != null ? fundingDetail.Frequency.Name : string.Empty,
                    AllowVariableFunding = fundingDetail.AllowVariableFunding,
                    AllowClaims = fundingDetail.AllowClaims,
                    ProgrammeId = fundingDetail.ProgrammeId,
                    ProgrammeName = fundingDetail.Programme.Name,
                    SubProgrammeId = fundingDetail.SubProgrammeId,
                    SubProgrammeName = fundingDetail.SubProgramme.Name,
                    SubProgrammeTypeId = fundingDetail.SubProgrammeTypeId,
                    SubProgrammeTypeName = fundingDetail.SubProgrammeType.Name,
                    AmountAwarded = fundingDetail.AmountAwarded ?? 0,
                    CalculationTypeId = fundingDetail.CalculationTypeId,
                    CalculationTypeName = fundingDetail.CalculationType.Name,
                    IsActive = fundingDetail.IsActive
                },
                SDAViewModel = new()
                {
                    Id = sda.Id,
                    FundingCaptureId = sda.FundingCaptureId,
                    ServiceDeliveryAreaId = sda.ServiceDeliveryAreaId ?? null,
                    PlaceId = sda.PlaceId ?? null,
                    PlaceName = sda.Place != null ? sda.Place.Name : string.Empty,
                    IsActive = sda.IsActive,
                },
                BankDetailViewModel = new()
                {
                    Id = bankDetail.Id,
                    FundingCaptureId = bankDetail.FundingCaptureId,
                    ProgramBankDetailsId = bankDetail.ProgramBankDetailsId ?? null,
                    IsActive = bankDetail.IsActive
                },
                DocumentViewModel = new()
                {
                    Id = document.Id,
                    FundingCaptureId = document.FundingCaptureId,
                    TPALink = document.TPALink ?? string.Empty,
                    IsActive = document.IsActive
                }
            };

            var details = new NpoViewModel
            {
                Id = npo.Id,
                Name = npo.Name,
                CCode = npo.CCode,
                NpoProfileId = npoProfile.Id,
                IsActive = npo.IsActive
            };
            details.FundingCaptureViewModels.Add(funding);

            return details;
        }

        public async Task UpdateFundingDetail(FundingDetailViewModel model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
            var fundingDetail = await _fundingDetailRepository.GetByFundingCaptureId(model.FundingCaptureId);

            fundingDetail.StartDate = model.StartDate;
            fundingDetail.FrequencyId = model.FrequencyId;
            fundingDetail.AllowVariableFunding = model.AllowVariableFunding;
            fundingDetail.AllowClaims = model.AllowClaims;
            fundingDetail.AmountAwarded = model.AmountAwarded;
            fundingDetail.UpdatedUserId = loggedInUser.Id;
            fundingDetail.UpdatedDateTime = DateTime.Now;

            await _fundingDetailRepository.UpdateAsync(fundingDetail);
        }

        public async Task UpdateSDA(SDAViewModel model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
            var sda = await _sdaRepository.GetByFundingCaptureId(model.FundingCaptureId);

            sda.ServiceDeliveryAreaId = model.ServiceDeliveryAreaId;
            sda.PlaceId = model.PlaceId;
            sda.UpdatedUserId = loggedInUser.Id;
            sda.UpdatedDateTime = DateTime.Now;

            await _sdaRepository.UpdateAsync(sda);
        }

        public async Task UpdateBankDetail(BankDetailViewModel model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
            var bankDetail = await _bankDetailRepository.GetByFundingCaptureId(model.FundingCaptureId);

            bankDetail.ProgramBankDetailsId = model.ProgramBankDetailsId;
            bankDetail.UpdatedUserId = loggedInUser.Id;
            bankDetail.UpdatedDateTime = DateTime.Now;

            await _bankDetailRepository.UpdateAsync(bankDetail);
        }

        public async Task UpdateDocument(DocumentViewModel model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
            var document = await _documentRepository.GetByFundingCaptureId(model.FundingCaptureId);

            document.TPALink = model.TPALink;
            document.UpdatedUserId = loggedInUser.Id;
            document.UpdatedDateTime = DateTime.Now;

            await _documentRepository.UpdateAsync(document);
        }

        #endregion
    }
}
