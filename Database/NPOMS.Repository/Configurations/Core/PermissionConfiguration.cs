using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NPOMS.Domain.Core;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace NPOMS.Repository.Configurations.Core
{
	public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
	{
		public void Configure(EntityTypeBuilder<Permission> builder)
		{
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new Permission
				{
					Id = 1,
					Name = "Add Users",
					SystemName = "UA.AU",
					CategoryName = "User Administration"
				},
				new Permission
				{
					Id = 2,
					Name = "View List of Users",
					SystemName = "UA.VU",
					CategoryName = "User Administration"
				},
				new Permission
				{
					Id = 3,
					Name = "Edit Users",
					SystemName = "UA.EU",
					CategoryName = "User Administration"
				},
				new Permission
				{
					Id = 4,
					Name = "Add Utilities",
					SystemName = "UM.AU",
					CategoryName = "Utilities Management"
				},
				new Permission
				{
					Id = 5,
					Name = "View List of Utilities",
					SystemName = "UM.VU",
					CategoryName = "Utilities Management"
				},
				new Permission
				{
					Id = 6,
					Name = "Edit Utilities",
					SystemName = "UM.EU",
					CategoryName = "Utilities Management"
				},
				new Permission
				{
					Id = 7,
					Name = "View List of Permissions",
					SystemName = "PM.VP",
					CategoryName = "Permission Management"
				},
				new Permission
				{
					Id = 8,
					Name = "Edit Permissions",
					SystemName = "PM.EP",
					CategoryName = "Permission Management"
				},
				new Permission
				{
					Id = 9,
					Name = "View Admin Menu",
					SystemName = "TN.VAM",
					CategoryName = "Top Navigation"
				},
				new Permission
				{
					Id = 10,
					Name = "View Organisation Profile Menu",
					SystemName = "TN.VPM",
					CategoryName = "Top Navigation"
				},
				new Permission
				{
					Id = 11,
					Name = "Add Organisation Profile",
					SystemName = "NP.ANP",
					CategoryName = "Organisation Profile"
				},
				new Permission
				{
					Id = 12,
					Name = "Edit Organisation Profile",
					SystemName = "NP.ENP",
					CategoryName = "Organisation Profile"
				},
				new Permission
				{
					Id = 13,
					Name = "View List of Organisation Profiles",
					SystemName = "NP.VNP",
					CategoryName = "Organisation Profile"
				},
				new Permission
				{
					Id = 14,
					Name = "Show Organisation Profile Action Buttons",
					SystemName = "NP.SPA",
					CategoryName = "Organisation Profile"
				},
				new Permission
				{
					Id = 15,
					Name = "Show User Administration Action Buttons",
					SystemName = "UA.SUA",
					CategoryName = "User Administration"
				},
				new Permission
				{
					Id = 16,
					Name = "View Apply For Access Menu",
					SystemName = "TN.VAAM",
					CategoryName = "Top Navigation"
				},
				new Permission
				{
					Id = 17,
					Name = "View Access Review Menu",
					SystemName = "TN.VARM",
					CategoryName = "Top Navigation"
				},
				new Permission
				{
					Id = 18,
					Name = "Add User Requests - Apply for access",
					SystemName = "UAM.AUR",
					CategoryName = "User Access Management"
				},
				new Permission
				{
					Id = 19,
					Name = "Edit User Requests - Review access requests",
					SystemName = "UAM.EUR",
					CategoryName = "User Access Management"
				},
				new Permission
				{
					Id = 20,
					Name = "View List of User Requests",
					SystemName = "UAM.VUR",
					CategoryName = "User Access Management"
				},
				new Permission
				{
					Id = 21,
					Name = "View Organisations Menu",
					SystemName = "TN.VNM",
					CategoryName = "Top Navigation"
				},
				new Permission
				{
					Id = 22,
					Name = "Add Organisation",
					SystemName = "NPO.Add",
					CategoryName = "Organisation"
				},
				new Permission
				{
					Id = 23,
					Name = "Edit Organisation",
					SystemName = "NPO.Edit",
					CategoryName = "Organisation"
				},
				new Permission
				{
					Id = 24,
					Name = "View List of Organisations",
					SystemName = "NPO.View",
					CategoryName = "Organisation"
				},
				new Permission
				{
					Id = 25,
					Name = "Show Organisation Action Buttons",
					SystemName = "NPO.SNA",
					CategoryName = "Organisation"
				},
				new Permission
				{
					Id = 26,
					Name = "View Application Period (Programme Selection) Menu",
					SystemName = "TN.VAPM",
					CategoryName = "Top Navigation"
				},
				new Permission
				{
					Id = 27,
					Name = "Add Application Period (Programme Selection)",
					SystemName = "AP.Add",
					CategoryName = "Application Period (Programme Selection)"
				},
				new Permission
				{
					Id = 28,
					Name = "Edit Application Period (Programme Selection)",
					SystemName = "AP.Edit",
					CategoryName = "Application Period (Programme Selection)"
				},
				new Permission
				{
					Id = 29,
					Name = "View List of Application Periods (Programme Selection)",
					SystemName = "AP.View",
					CategoryName = "Application Period (Programme Selection)"
				},
				new Permission
				{
					Id = 30,
					Name = "Show Application Period (Programme Selection) Action Buttons",
					SystemName = "AP.SAPA",
					CategoryName = "Application Period (Programme Selection)"
				},
				new Permission
				{
					Id = 31,
					Name = "View Captured Applications Menu",
					SystemName = "TN.VAppM",
					CategoryName = "Top Navigation"
				},
				new Permission
				{
					Id = 32,
					Name = "Add Application",
					SystemName = "App.Add",
					CategoryName = "Application"
				},
				new Permission
				{
					Id = 33,
					Name = "Edit Application",
					SystemName = "App.Edit",
					CategoryName = "Application"
				},
				new Permission
				{
					Id = 34,
					Name = "View List of Applications",
					SystemName = "App.View",
					CategoryName = "Application"
				},
				new Permission
				{
					Id = 35,
					Name = "Show Application Action Buttons",
					SystemName = "App.SAA",
					CategoryName = "Application"
				},
				new Permission
				{
					Id = 36,
					Name = "View Organisation Approval Menu",
					SystemName = "TN.VNA",
					CategoryName = "Top Navigation"
				},
				new Permission
				{
					Id = 37,
					Name = "Edit Organisation Approval",
					SystemName = "NAM.ENR",
					CategoryName = "Organisation Approval Management"
				},
				new Permission
				{
					Id = 38,
					Name = "View List of Organisations for approval requests",
					SystemName = "NAM.VNR",
					CategoryName = "Organisation Approval Management"
				},
				new Permission
				{
					Id = 39,
					Name = "Review Application",
					SystemName = "App.Review",
					CategoryName = "Application"
				},
				new Permission
				{
					Id = 40,
					Name = "Approve Application",
					SystemName = "App.Approve",
					CategoryName = "Application"
				},
				new Permission
				{
					Id = 41,
					Name = "Upload SLA Document",
					SystemName = "App.Upload",
					CategoryName = "Application"
				},
				new Permission
				{
					Id = 42,
					Name = "View Accepted SLA Application",
					SystemName = "App.VAA",
					CategoryName = "Application"
				},
				new Permission
				{
					Id = 43,
					Name = "Show Utilities Action Buttons",
					SystemName = "UM.SUA",
					CategoryName = "Utilities Management"
				},
				new Permission
				{
					Id = 44,
					Name = "View Dashboard Menu",
					SystemName = "TN.VDM",
					CategoryName = "Top Navigation"
				},
				new Permission
				{
					Id = 45,
					Name = "View PowerBI Dashboard",
					SystemName = "PBI.VD",
					CategoryName = "PowerBI Dashboard"
				},
				new Permission
				{
					Id = 46,
					Name = "View Training Menu",
					SystemName = "TN.VTM",
					CategoryName = "Top Navigation"
				},
				new Permission
				{
					Id = 47,
					Name = "View List of Training Materials",
					SystemName = "TM.VTM",
					CategoryName = "Training Material"
				},
				new Permission
				{
					Id = 48,
					Name = "Add Department Budget",
					SystemName = "Bud.Add",
					CategoryName = "Budgets"
				},
				new Permission
				{
					Id = 49,
					Name = "Edit Department Budget",
					SystemName = "Bud.Edit",
					CategoryName = "Budgets"
				},
				new Permission
				{
					Id = 50,
					Name = "View List of Department Budgets",
					SystemName = "Bud.View",
					CategoryName = "Budgets"
				},
				new Permission
				{
					Id = 51,
					Name = "Add Directorate Budget",
					SystemName = "Bud.ADB",
					CategoryName = "Budgets"
				},
				new Permission
				{
					Id = 52,
					Name = "Edit Directorate Budget",
					SystemName = "Bud.EDB",
					CategoryName = "Budgets"
				},
				new Permission
				{
					Id = 53,
					Name = "View List of Directorate Budgets",
					SystemName = "Bud.VDB",
					CategoryName = "Budgets"
				},
				new Permission
				{
					Id = 54,
					Name = "Add Programme Budget",
					SystemName = "Bud.APB",
					CategoryName = "Budgets"
				},
				new Permission
				{
					Id = 55,
					Name = "Edit Programme Budget",
					SystemName = "Bud.EPB",
					CategoryName = "Budgets"
				},
				new Permission
				{
					Id = 56,
					Name = "View List of Programme Budgets",
					SystemName = "Bud.VPB",
					CategoryName = "Budgets"
				},
				new Permission
				{
					Id = 57,
					Name = "View Security Side Menu",
					SystemName = "SN.Security",
					CategoryName = "Administration - Side Navigation"
				},
				new Permission
				{
					Id = 58,
					Name = "View Users Side Menu",
					SystemName = "SN.Users",
					CategoryName = "Administration - Side Navigation"
				},
				new Permission
				{
					Id = 59,
					Name = "View Permissions Side Menu",
					SystemName = "SN.Permissions",
					CategoryName = "Administration - Side Navigation"
				},
				new Permission
				{
					Id = 60,
					Name = "View Settings Side Menu",
					SystemName = "SN.Settings",
					CategoryName = "Administration - Side Navigation"
				},
				new Permission
				{
					Id = 61,
					Name = "View Utilities Sub Menu",
					SystemName = "SN.Utilities",
					CategoryName = "Administration - Side Navigation"
				},
				new Permission
				{
					Id = 62,
					Name = "View Budgets Sub Menu",
					SystemName = "SN.Budgets",
					CategoryName = "Administration - Side Navigation"
				},
				new Permission
				{
					Id = 63,
					Name = "View Department Budget Sub Menu",
					SystemName = "SN.DeptBudget",
					CategoryName = "Administration - Side Navigation"
				},
				new Permission
				{
					Id = 64,
					Name = "View Directorate Budget Sub Menu",
					SystemName = "SN.DirectorateBudget",
					CategoryName = "Administration - Side Navigation"
				},
				new Permission
				{
					Id = 65,
					Name = "View Programme Budget Sub Menu",
					SystemName = "SN.ProgBudget",
					CategoryName = "Administration - Side Navigation"
				},
				new Permission
				{
					Id = 66,
					Name = "View Funding Menu",
					SystemName = "TN.VFM",
					CategoryName = "Top Navigation"
				},
				new Permission
				{
					Id = 67,
					Name = "Add NPO/Organisation Funding",
					SystemName = "Fund.ANF",
					CategoryName = "Funding"
				},
				new Permission
				{
					Id = 68,
					Name = "Edit NPO/Organisation Funding",
					SystemName = "Fund.ENF",
					CategoryName = "Funding"
				},
				new Permission
				{
					Id = 69,
					Name = "View NPO/Organisation Funding",
					SystemName = "Fund.VNF",
					CategoryName = "Funding"
				},
				new Permission
				{
					Id = 70,
					Name = "Delete NPO/Organisation Funding",
					SystemName = "Fund.DNF",
					CategoryName = "Funding"
				},
				new Permission
				{
					Id = 71,
					Name = "View Payment Schedule",
					SystemName = "Fund.VPS",
					CategoryName = "Funding"
				},
				new Permission
				{
					Id = 72,
					Name = "View Compliance Check",
					SystemName = "Fund.CC",
					CategoryName = "Funding"
				},
				new Permission
				{
					Id = 73,
					Name = "Show NPO/Organisation Funding Action Buttons",
					SystemName = "Fund.SNFA",
					CategoryName = "Funding"
				},
				new Permission
				{
					Id = 74,
					Name = "View Compliant Cycle Sub Menu",
					SystemName = "SN.CompliantCycle",
					CategoryName = "Administration - Side Navigation"
				},
				new Permission
				{
					Id = 75,
					Name = "View Payment Schedule Sub Menu",
					SystemName = "SN.PaymentSchedule",
					CategoryName = "Administration - Side Navigation"
				},
				new Permission
				{
					Id = 76,
					Name = "Add Compliant Cycle",
					SystemName = "CC.Add",
					CategoryName = "Compliant Cycle"
				},
				new Permission
				{
					Id = 77,
					Name = "View Compliant Cycle",
					SystemName = "CC.View",
					CategoryName = "Compliant Cycle"
				},
				new Permission
				{
					Id = 78,
					Name = "Edit Compliant Cycle",
					SystemName = "CC.Edit",
					CategoryName = "Compliant Cycle"
				},
				new Permission
				{
					Id = 79,
					Name = "Delete Compliant Cycle",
					SystemName = "CC.Delete",
					CategoryName = "Compliant Cycle"
				},
				new Permission
				{
					Id = 80,
					Name = "Add Payment Schedule",
					SystemName = "PS.Add",
					CategoryName = "Payment Schedule"
				},
				new Permission
				{
					Id = 81,
					Name = "View Payment Schedule",
					SystemName = "PS.View",
					CategoryName = "Payment Schedule"
				},
				new Permission
				{
					Id = 82,
					Name = "Edit Payment Schedule",
					SystemName = "PS.Edit",
					CategoryName = "Payment Schedule"
				},
				new Permission
				{
					Id = 83,
					Name = "Delete Payment Schedule",
					SystemName = "PS.Delete",
					CategoryName = "Payment Schedule"
				},
				new Permission
				{
					Id = 84,
					Name = "View Workplan Indicator Options",
					SystemName = "Indicators.Options",
					CategoryName = "Workplan Indicators"
				},
				new Permission
				{
					Id = 85,
					Name = "View Manage Indicators Option",
					SystemName = "Indicators.Manage",
					CategoryName = "Workplan Indicators"
				},
				new Permission
				{
					Id = 86,
					Name = "Capture Workplan Target",
					SystemName = "Indicators.CaptureTarget",
					CategoryName = "Workplan Indicators"
				},
				new Permission
				{
					Id = 87,
					Name = "Show Workplan Target Action Buttons",
					SystemName = "Indicators.SWTA",
					CategoryName = "Workplan Indicators"
				},
				new Permission
				{
					Id = 88,
					Name = "Capture Workplan Actual",
					SystemName = "Indicators.CaptureActual",
					CategoryName = "Workplan Indicators"
				},
				new Permission
				{
					Id = 89,
					Name = "Review or Verify Workplan Actual",
					SystemName = "Indicators.ReviewActual",
					CategoryName = "Workplan Indicators"
				},
				new Permission
				{
					Id = 90,
					Name = "Approve Workplan Actual",
					SystemName = "Indicators.ApproveActual",
					CategoryName = "Workplan Indicators"
				},
				new Permission
				{
					Id = 91,
					Name = "View Summary Option",
					SystemName = "Indicators.Summary",
					CategoryName = "Workplan Indicators"
				},
				new Permission
				{
					Id = 92,
					Name = "Export Summary",
					SystemName = "Indicators.ExportSummary",
					CategoryName = "Workplan Indicators"
				},
                new Permission
                {
                    Id = 93,
                    Name = "Pre-evaluate Application",
                    SystemName = "FA.PreEvaluate",
                    CategoryName = "Funding Application"
                },
                new Permission
                {
                    Id = 94,
                    Name = "Evaluate Application",
                    SystemName = "FA.Evaluate",
                    CategoryName = "Funding Application"
                },
                new Permission
                {
                    Id = 95,
                    Name = "Adjudicate Application",
					SystemName = "FA.Adjudicate",
                    CategoryName = "Funding Application"
                },
                new Permission
                {
                    Id = 96,
                    Name = "View Quick Capture",
                    SystemName = "QC.View",
                    CategoryName = "Quick Capture"
                },
                new Permission
                {
                    Id = 97,
                    Name = "Edit Quick Capture",
                    SystemName = "QC.Edit",
                    CategoryName = "Quick Capture"
                },
                new Permission
                {
                    Id = 98,
                    Name = "View Submitted Application",
                    SystemName = "WFA.View",
                    CategoryName = "View Application"
                },
                new Permission
                {
                    Id = 99,
                    Name = "Download Submitted Application",
                    SystemName = "WFA.Download",
                    CategoryName = "Download Application"
                },
                new Permission
                {
                    Id = 100,
                    Name = "Edit Application",
                    SystemName = "WFA.Edit",
                    CategoryName = "Download Application"
                },
                new Permission
                {
                    Id = 101,
                    Name = "Delete Application",
                    SystemName = "WFA.Delete",
                    CategoryName = "Delete Application"
                },
                new Permission
                {
                    Id = 102,
                    Name = "Pre Evaluate",
                    SystemName = "WFA.PreEvaluate",
                    CategoryName = "Pre Evaluate"
                },
                new Permission
                {
                    Id = 104,
                    Name = "Pending PreEvaluation",
                    SystemName = "WFA.PendingPreEvaluation",
                    CategoryName = "Pending PreEvaluation"
                },
                new Permission
                {
                    Id = 105,
                    Name = "Pending Adjudication",
                    SystemName = "WFA.PendingAdjudication",
                    CategoryName = "Pending Adjudication"
                },
                new Permission
                {
                    Id = 106,
                    Name = "Adjudicate",
                    SystemName = "WFA.Adjudicate",
                    CategoryName = "Adjudicate"
                },
                new Permission
                {
                    Id = 107,
                    Name = "Pending Evaluation",
                    SystemName = "WFA.PendingEvaluation",
                    CategoryName = "Pending Evaluation"
                },
                new Permission
                {
                    Id = 108,
                    Name = "Evaluate",
                    SystemName = "WFA.Evaluate",
                    CategoryName = "Evaluate"
                },
                new Permission
                {
                    Id = 109,
                    Name = "Pending Approval",
                    SystemName = "WFA.PendingApproval",
                    CategoryName = "Pending Approval"
                },
                new Permission
                {
                    Id = 110,
                    Name = "Approve",
                    SystemName = "WFA.Approve",
                    CategoryName = "Approve"
                },
				new Permission
				{
					Id = 111,
					Name = "Update Programme Selection on Funding Applications",
					SystemName = "App.UAP",
					CategoryName = "Application"
				},
                new Permission
                {
                    Id = 112,
                    Name = "Add Score card",
                    SystemName = "WFA.AddScorecard",
                    CategoryName = "AddScorecard"
                },
                new Permission
                {
                    Id = 113,
                    Name = "Review Score card",
                    SystemName = "WFA.ReviewScorecard",
                    CategoryName = "ReviewScorecard"
                },
                new Permission
                {
                    Id = 114,
                    Name = "View Score card",
                    SystemName = "WFA.ViewScorecard",
                    CategoryName = "ViewScorecard"
                },
                new Permission
                {
                    Id = 115,
                    Name = "Initiate Score card",
                    SystemName = "WFA.InitiateScorecard",
                    CategoryName = "InitiateScorecard"
                },
                new Permission
                {
                    Id = 116,
                    Name = "Close Score card",
                    SystemName = "WFA.CloseScorecard",
                    CategoryName = "CloseScorecard"
                },
                new Permission
                {
                    Id = 117,
                    Name = "Adjudicate Funded Npo",
                    SystemName = "WFA.AdjudicateFundedNpo",
                    CategoryName = "AdjudicateFundedNpo"
                },
                new Permission
                {
                    Id = 118,
                    Name = "Review Adjudicated FundedNpo",
                    SystemName = "WFA.ReviewAdjudicatedFundedNpo",
                    CategoryName = "ReviewAdjudicatedFundedNpo"
                },
                new Permission
                {
                    Id = 119,
                    Name = "Download Assessment",
                    SystemName = "WFA.DownloadAssessment",
                    CategoryName = "DownloadAssessment"
                },
                new Permission
                {
                    Id = 120,
                    Name = "View Budget Summary Sub Menu",
                    SystemName = "SN.BudgetSummary",
                    CategoryName = "Administration - Side Navigation"
                },
                new Permission
                {
                    Id = 121,
                    Name = "View Budget Summary",
                    SystemName = "Bud.VBS",
                    CategoryName = "Budgets"
                },
                new Permission
                {
                    Id = 122,
                    Name = "Edit capability",
                    SystemName = "Programme.Edit",
                    CategoryName = "Programme"
                }
                ,
                new Permission
                {
                    Id = 123,
                    Name = "Approve Programme",
                    SystemName = "Programme.Approve",
                    CategoryName = "Programme"
                }
                ,
                new Permission
                {
                    Id = 124,
                    Name = "Programme Viewer",
                    SystemName = "Programme.Viewer",
                    CategoryName = "Programme"
                },
                new Permission
                {
                    Id = 125,
                    Name = "Upload Budget",
                    SystemName = "Bud.UB",
                    CategoryName = "Budgets"
                }
            );
		}
	}
}
