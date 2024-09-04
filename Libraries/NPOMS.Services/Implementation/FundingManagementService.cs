using NPOMS.Domain.Enumerations;
using NPOMS.Domain.FundingManagement;
using NPOMS.Repository.Extensions;
using NPOMS.Repository.Interfaces.Budget;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Dropdown;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Repository.Interfaces.FundingManagement;
using NPOMS.Services.Interfaces;
using NPOMS.Services.Models.FundingManagement;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private IProgrammeBudgetRepository _programmeBudgetRepository;
        private ICompliantCycleRuleRepository _compliantCycleRuleRepository;
        private ICompliantCycleRepository _compliantCycleRepository;
        private Repository.Interfaces.Entities.IPaymentScheduleRepository _paymentScheduleRepository;
        private IFrequencyRepository _frequencyRepository;
        private Repository.Interfaces.FundingManagement.IPaymentScheduleRepository _fundingPaymentScheduleRepository;
        private IDropdownService _dropdownService;
        private IProgrameBankDetailRepository _programeBankDetailRepository;

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
            IServiceDeliveryAreaRepository serviceDeliveryAreaRepository,
            IProgrammeBudgetRepository programmeBudgetRepository,
            ICompliantCycleRuleRepository compliantCycleRuleRepository,
            ICompliantCycleRepository compliantCycleRepository,
            Repository.Interfaces.Entities.IPaymentScheduleRepository paymentScheduleRepository,
            IFrequencyRepository frequencyRepository,
            Repository.Interfaces.FundingManagement.IPaymentScheduleRepository fundingPaymentScheduleRepository,
            IDropdownService dropdownService,
            IProgrameBankDetailRepository programeBankDetailRepository
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
            _programmeBudgetRepository = programmeBudgetRepository;
            _compliantCycleRuleRepository = compliantCycleRuleRepository;
            _compliantCycleRepository = compliantCycleRepository;
            _paymentScheduleRepository = paymentScheduleRepository;
            _frequencyRepository = frequencyRepository;
            _fundingPaymentScheduleRepository = fundingPaymentScheduleRepository;
            _dropdownService = dropdownService;
            _programeBankDetailRepository = programeBankDetailRepository;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<NpoViewModel>> GetNposForFunding(string userIdentifier)
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
                        var programmeBudget = await _programmeBudgetRepository.GetByIds(detail.Programme.DepartmentId, $"{funding.FinancialYear.Year}/{funding.FinancialYear.Year + 1}", detail.ProgrammeId, detail.SubProgrammeId, detail.SubProgrammeTypeId);

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
                                AmountAwarded = detail.AmountAwarded ?? 0,
                                ProgrammeBudget = programmeBudget != null ? programmeBudget.OriginalBudgetAmount : Convert.ToDecimal(0)
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
            await _fundingPaymentScheduleRepository.CreateAsync(new() { FundingCaptureId = fundingCapture.Id, IsActive = true, CreatedUserId = loggedInUser.Id, CreatedDateTime = DateTime.Now });
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
            fundingCapture.FinancialYear = null;

            await _fundingCaptureRepository.UpdateAsync(fundingCapture);
        }

        public async Task<NpoViewModel> GetById(int id)
        {
            var fundingDetail = await _fundingDetailRepository.GetByFundingCaptureId(id);
            var sda = await _sdaRepository.GetByFundingCaptureId(id);
            var paymentSchedule = await _fundingPaymentScheduleRepository.GetByFundingCaptureId(id);
            var bankDetail = await _bankDetailRepository.GetByFundingCaptureId(id);
            var document = await _documentRepository.GetByFundingCaptureId(id);

            var fundingCapture = await _fundingCaptureRepository.GetById(id);
            var npo = await _npoRepository.GetById(fundingCapture.NpoId);
            var npoProfile = await _npoProfileRepository.GetByNpoId(fundingCapture.NpoId);

            var programmeBudget = await _programmeBudgetRepository.GetByIds(fundingDetail.Programme.DepartmentId, $"{fundingDetail.FinancialYear.Year}/{fundingDetail.FinancialYear.Year + 1}", fundingDetail.ProgrammeId, fundingDetail.SubProgrammeId, fundingDetail.SubProgrammeTypeId);
            var approvedBy = await _userRepository.GetUserByIdAsync(Convert.ToInt32(fundingCapture.ApproverUserId));
            var status = await _dropdownService.GetStatusById(fundingCapture.StatusId);

            var programmeBankDetail = await _programeBankDetailRepository.GetById(Convert.ToInt32(bankDetail.ProgramBankDetailsId));
            var bank = programmeBankDetail != null ? await _dropdownService.GetBankById(programmeBankDetail.BankId) : null;
            var branch = programmeBankDetail != null ? await _dropdownService.GetBranchById(programmeBankDetail.BranchId) : null;
            var accountType = programmeBankDetail != null ? await _dropdownService.GetAccountTypeById(programmeBankDetail.AccountTypeId) : null;

            var serviceDeliveryArea = await _dropdownService.GetServiceDeliveryAreaById(Convert.ToInt32(sda.ServiceDeliveryAreaId));

            var funding = new FundingCaptureViewModel
            {
                Id = id,
                StatusId = fundingCapture.StatusId,
                StatusName = status.Name,
                IsActive = fundingCapture.IsActive,
                FinancialYearId = fundingCapture.FinancialYearId,
                ApproverUserName = approvedBy != null ? $"{approvedBy.FullName} ({approvedBy.Email})" : string.Empty,
                ApprovedDate = Convert.ToDateTime(fundingCapture.ApprovedDateTime).ToString("yyyy-MM-dd HH:mm:ss") ?? string.Empty,
                ApproverComment = fundingCapture.ApproverComment ?? string.Empty,
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
                    IsActive = fundingDetail.IsActive,
                    ProgrammeBudget = programmeBudget != null ? programmeBudget.OriginalBudgetAmount : Convert.ToDecimal(0)
                },
                SDAViewModel = new()
                {
                    Id = sda.Id,
                    FundingCaptureId = sda.FundingCaptureId,
                    ServiceDeliveryAreaId = sda.ServiceDeliveryAreaId ?? null,
                    ServiceDeliveryAreaName = serviceDeliveryArea != null ? serviceDeliveryArea.Name : string.Empty,
                    PlaceId = sda.PlaceId ?? null,
                    PlaceName = sda.Place != null ? sda.Place.Name : string.Empty,
                    IsActive = sda.IsActive
                },
                PaymentScheduleViewModel = new()
                {
                    Id = id,
                    FundingCaptureId = paymentSchedule.FundingCaptureId,
                    AllocatedAmountTotal = paymentSchedule.AllocatedAmountTotal ?? 0,
                    ApprovedAmountTotal = paymentSchedule.ApprovedAmountTotal ?? 0,
                    PaidAmountTotal = paymentSchedule.PaidAmountTotal ?? 0,
                    AllocatedAmountBalance = paymentSchedule.AllocatedAmountBalance ?? 0,
                    ApprovedAmountBalance = paymentSchedule.ApprovedAmountBalance ?? 0,
                    PaidAmountBalance = paymentSchedule.PaidAmountBalance ?? 0,
                    IsActive = paymentSchedule.IsActive
                },
                BankDetailViewModel = new()
                {
                    Id = bankDetail.Id,
                    FundingCaptureId = bankDetail.FundingCaptureId,
                    ProgramBankDetailsId = bankDetail.ProgramBankDetailsId ?? null,
                    BankName = bank != null ? bank.Name : string.Empty,
                    BranchName = branch != null ? branch.Name : string.Empty,
                    AccountTypeName = accountType != null ? accountType.Name : string.Empty,
                    AccountNumber = programmeBankDetail != null ? programmeBankDetail.AccountNumber : string.Empty,
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

            foreach (var paymentScheduleItem in paymentSchedule.PaymentScheduleItems)
            {
                funding.PaymentScheduleViewModel.PaymentScheduleItemViewModels.Add(new()
                {
                    Id = paymentScheduleItem.Id,
                    PaymentScheduleId = paymentScheduleItem.PaymentScheduleId,
                    CompliantCycleId = paymentScheduleItem.CompliantCycleId ?? null,
                    CycleNumber = paymentScheduleItem.CycleNumber ?? null,
                    PaymentDate = paymentScheduleItem.PaymentDate ?? string.Empty,
                    PaymentStatus = paymentScheduleItem.PaymentStatus ?? string.Empty,
                    AllocatedAmount = paymentScheduleItem.AllocatedAmount ?? 0,
                    ApprovedAmount = paymentScheduleItem.ApprovedAmount ?? 0,
                    PaidAmount = paymentScheduleItem.PaidAmount ?? 0,
                    IsActive = paymentScheduleItem.IsActive
                });
            }

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

            fundingDetail.CalculationType = null;
            fundingDetail.FinancialYear = null;
            fundingDetail.Frequency = null;
            fundingDetail.FundingType = null;
            fundingDetail.Programme = null;
            fundingDetail.SubProgramme = null;
            fundingDetail.SubProgrammeType = null;

            await _fundingDetailRepository.UpdateAsync(fundingDetail);
        }

        public async Task UpdateSDA(SDAViewModel model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
            var sda = await _sdaRepository.GetByFundingCaptureId(model.FundingCaptureId);

            sda.ServiceDeliveryAreaId = model.ServiceDeliveryAreaId;
            sda.PlaceId = model.PlaceId;
            sda.Place = null;
            sda.UpdatedUserId = loggedInUser.Id;
            sda.UpdatedDateTime = DateTime.Now;

            await _sdaRepository.UpdateAsync(sda);
        }

        public async Task<PaymentScheduleViewModel> GeneratePaymentSchedule(int fundingCaptureId, int frequencyId, string startDate, double amountAwarded)
        {
            var fundingCapture = await _fundingCaptureRepository.GetById(fundingCaptureId);
            var fundingDetail = await _fundingDetailRepository.GetByFundingCaptureId(fundingCaptureId);
            var paymentSchedule = await _fundingPaymentScheduleRepository.GetByFundingCaptureId(fundingCaptureId);

            if ((FrequencyEnum)frequencyId != FrequencyEnum.Adhoc)
            {
                var frequency = await _frequencyRepository.GetById(frequencyId);
                var intervals = 12 / Convert.ToInt32(frequency.FrequencyNumber);

                var paymentScheduleItems = new List<PaymentScheduleItemViewModel>();

                var compliantCycleRules = await _compliantCycleRuleRepository.GetEntities(false);
                var compliantCycles = await _compliantCycleRepository.GetCompliantCyclesByIds(fundingDetail.Programme.DepartmentId, Convert.ToInt32(fundingCapture.FinancialYearId));
                var departmentPaymentSchedules = await _paymentScheduleRepository.GetPaymentSchedulesByIds(fundingDetail.Programme.DepartmentId, Convert.ToInt32(fundingCapture.FinancialYearId));
                var paymentSchedules = departmentPaymentSchedules.OrderBy(x => x.StartDate).Where(x => x.StartDate > Convert.ToDateTime(startDate) && x.StartDate.Date >= DateTime.Now.Date);

                // Get months between funding detail start date and financial year end date
                var financialYearMonths = MonthsBetween(Convert.ToDateTime(startDate), fundingDetail.FinancialYear.EndDate).ToArray();

                var monthStartDates = new List<DateTime>();
                for (int i = 0; i < financialYearMonths.Count(); i += intervals)
                {
                    monthStartDates.Add(financialYearMonths[i]);
                }

                var applicableSchedules = new List<Domain.Entities.PaymentSchedule>();
                foreach (var monthStartDate in monthStartDates)
                {
                    var applicableSchedule = paymentSchedules.FirstOrDefault(x => x.StartDate >= monthStartDate);

                    if (applicableSchedule != null)
                    {
                        if (!applicableSchedules.Contains(applicableSchedule))
                            applicableSchedules.Add(applicableSchedule);
                        else
                            applicableSchedules.Add(paymentSchedules.ToList()[1]);

                        applicableSchedule = applicableSchedules.Last();

                        var amount = monthStartDate == monthStartDates.Last() ? amountAwarded - paymentScheduleItems.Sum(item => item.AllocatedAmount) : Convert.ToDouble(Math.Floor((decimal)amountAwarded / monthStartDates.Count()));
                        var compliantCycle = compliantCycles.FirstOrDefault(x => x.Id.Equals(applicableSchedule.CompliantCycleId));

                        var paymentScheduleItem = new PaymentScheduleItemViewModel()
                        {
                            PaymentScheduleId = paymentSchedule.Id,
                            CompliantCycleId = compliantCycle.Id,
                            CycleNumber = compliantCycleRules.FirstOrDefault(x => x.Id.Equals(compliantCycle.CompliantCycleRuleId)).CycleNumber,
                            PaymentDate = applicableSchedule.PaymentDate.ToString("yyyy-MM-dd"),
                            PaymentStatus = string.Empty,
                            AllocatedAmount = amount,
                            ApprovedAmount = 0,
                            PaidAmount = 0,
                            IsActive = true
                        };
                        paymentScheduleItems.Add(paymentScheduleItem);
                    }
                }

                var model = new PaymentScheduleViewModel()
                {
                    Id = paymentSchedule.Id,
                    FundingCaptureId = fundingCaptureId,
                    AllocatedAmountTotal = paymentScheduleItems.Sum(item => item.AllocatedAmount),
                    ApprovedAmountTotal = paymentScheduleItems.Sum(item => item.ApprovedAmount),
                    PaidAmountTotal = paymentScheduleItems.Sum(item => item.PaidAmount),
                    AllocatedAmountBalance = amountAwarded - paymentScheduleItems.Sum(item => item.AllocatedAmount),
                    ApprovedAmountBalance = amountAwarded - paymentScheduleItems.Sum(item => item.ApprovedAmount),
                    PaidAmountBalance = amountAwarded - paymentScheduleItems.Sum(item => item.PaidAmount),
                    IsActive = true,
                    PaymentScheduleItemViewModels = paymentScheduleItems
                };

                return model;
            }

            return new();
        }

        private static IEnumerable<DateTime> MonthsBetween(DateTime startDate, DateTime endDate)
        {
            return Enumerable.Range(0, (endDate.Year - startDate.Year) * 12 + (endDate.Month - startDate.Month + 1))
                             .Select(m => new DateTime(startDate.Year, startDate.Month, 1).AddMonths(m));
        }

        public async Task UpdatePaymentSchedules(PaymentScheduleViewModel model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
            var paymentSchedule = await _fundingPaymentScheduleRepository.GetByFundingCaptureId(model.FundingCaptureId);

            foreach (var paymentScheduleItem in model.PaymentScheduleItemViewModels)
            {
                paymentSchedule.PaymentScheduleItems.Add(new()
                {
                    PaymentScheduleId = paymentScheduleItem.PaymentScheduleId,
                    CompliantCycleId = paymentScheduleItem.CompliantCycleId,
                    CycleNumber = paymentScheduleItem.CycleNumber,
                    PaymentDate = paymentScheduleItem.PaymentDate,
                    PaymentStatus = paymentScheduleItem.PaymentStatus,
                    AllocatedAmount = paymentScheduleItem.AllocatedAmount,
                    ApprovedAmount = paymentScheduleItem.ApprovedAmount,
                    PaidAmount = paymentScheduleItem.PaidAmount,
                    IsActive = paymentScheduleItem.IsActive,
                    CreatedUserId = loggedInUser.Id,
                    CreatedDateTime = DateTime.Now
                });
            }

            paymentSchedule.AllocatedAmountTotal = model.AllocatedAmountTotal;
            paymentSchedule.ApprovedAmountTotal = model.ApprovedAmountTotal;
            paymentSchedule.PaidAmountTotal = model.PaidAmountTotal;
            paymentSchedule.AllocatedAmountBalance = model.AllocatedAmountBalance;
            paymentSchedule.ApprovedAmountBalance = model.ApprovedAmountBalance;
            paymentSchedule.PaidAmountBalance = model.PaidAmountBalance;
            paymentSchedule.UpdatedUserId = loggedInUser.Id;
            paymentSchedule.UpdatedDateTime = DateTime.Now;

            await _fundingPaymentScheduleRepository.UpdateAsync(paymentSchedule);
        }

        public async Task UpdateBankDetail(BankDetailViewModel model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
            var bankDetail = await _bankDetailRepository.GetByFundingCaptureId(model.FundingCaptureId);

            bankDetail.ProgramBankDetailsId = model.ProgramBankDetailsId;
            bankDetail.ProgramBankDetails = null;
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

        public async Task UpdateApproverDetail(FundingCaptureViewModel model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
            var fundingCapture = await _fundingCaptureRepository.GetById(model.Id);

            fundingCapture.StatusId = model.StatusId;
            fundingCapture.ApproverUserId = loggedInUser.Id;
            fundingCapture.ApprovedDateTime = DateTime.Now;
            fundingCapture.ApproverComment = model.ApproverComment;
            fundingCapture.FinancialYear = null;

            await _fundingCaptureRepository.UpdateAsync(fundingCapture);
        }

        #endregion
    }
}
