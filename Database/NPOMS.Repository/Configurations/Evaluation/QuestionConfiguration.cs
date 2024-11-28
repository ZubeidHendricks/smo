using NPOMS.Domain.Evaluation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NPOMS.Repository.Configurations.Evaluation
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.Property("IsActive").HasDefaultValueSql("1");
            builder.Property("CreatedUserId").HasDefaultValueSql("1");
            builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

            builder.HasData(
                // Pre-evaluation
                new Question
                {
                    Id = 1,
                    QuestionSectionId = 1,
                    ResponseTypeId = 1,
                    Name = "% Own Funding Contribution to Funding Requested",
                    SortOrder = 1
                },
                new Question
                {
                    Id = 2,
                    QuestionSectionId = 1,
                    ResponseTypeId = 1,
                    Name = "The organisation applying for support must be formally registered or incorporated. Company registration documents or documents of incorporation (NPO/NPC registration certificate, partnership agreements, sole proprietor tax certificate etc.) clearly identifying the director(s) of the company or organisation must be submitted. CFP 4.1",
                    SortOrder = 2
                },
                new Question
                {
                    Id = 3,
                    QuestionSectionId = 1,
                    ResponseTypeId = 1,
                    Name = "The organisation applying for support must be operational (still trading) and must have been in operation for a minimum of three financial years. Management accounts for the two months preceding the application closing date must be submitted. CFP 4.2",
                    SortOrder = 3
                },
                new Question
                {
                    Id = 4,
                    QuestionSectionId = 1,
                    ResponseTypeId = 1,
                    Name = "Signed annual financial statements for the three most recent financial years (the annual financial statements for the latest financial year must be audited and must be submitted. CFP 4.2",
                    SortOrder = 4
                },
                new Question
                {
                    Id = 5,
                    QuestionSectionId = 1,
                    ResponseTypeId = 1,
                    Name = "A tax compliant status (TCS) letter with a valid (not expired) tax pin must be submitted. The tax pin must be valid for a period of 60 days after the closing date for applications. CFP 4.3",
                    SortOrder = 5
                },
                new Question
                {
                    Id = 6,
                    QuestionSectionId = 1,
                    ResponseTypeId = 1,
                    Name = "The organisation must have obtained an unqualified audit opinion during its latest financial period. Signed audited annual financial statements (AFS) for the latest financial year must be submitted. It is important that the AFS are signed off. CFP 4.4",
                    SortOrder = 6
                },
                new Question
                {
                    Id = 7,
                    QuestionSectionId = 1,
                    ResponseTypeId = 1,
                    Name = "A valid BBBEE certificate / affidavit for the applicant organisation. CFP 4.5",
                    SortOrder = 7
                },
                new Question
                {
                    Id = 8,
                    QuestionSectionId = 1,
                    ResponseTypeId = 1,
                    Name = "The value of funding requested from the Department must not be less than R500 000, 00 and the maximum value of funding requested must not exceed R2 million. CFP 4.6",
                    SortOrder = 8
                },
                new Question
                {
                    Id = 9,
                    QuestionSectionId = 1,
                    ResponseTypeId = 1,
                    Name = "The organisation must demonstrate an own funding (including third party funding if any) contribution of 50% or more of the requested amount. CFP 4.7",
                    SortOrder = 9
                },
                new Question
                {
                    Id = 10,
                    QuestionSectionId = 1,
                    ResponseTypeId = 1,
                    Name = "A signed letter by the Chief Executive Officer (CEO) / Chief Financial Officer (CFO) or similar executive authority confirming the value of own funding committed must be submitted. CFP 4.7",
                    SortOrder = 10
                },
                new Question
                {
                    Id = 11,
                    QuestionSectionId = 1,
                    ResponseTypeId = 1,
                    Name = "The identity document of the signatory to the agreement must be provided. CFP 4.8",
                    SortOrder = 11
                },

                // Evaluation
                new Question
                {
                    Id = 12,
                    QuestionSectionId = 2,
                    ResponseTypeId = 2,
                    Name = "The proposed intervention(s) qualifies in terms of what the Booster Fund aims to achieve i.e., enhancing and/or expanding interventions that supports SMMEs.",
                    SortOrder = 1
                },
                new Question
                {
                    Id = 13,
                    QuestionSectionId = 2,
                    ResponseTypeId = 2,
                    Name = "The project implementation plan demonstrates that the project has commenced or will commence within two months of signing the agreement with the Department.",
                    SortOrder = 2
                },
                new Question
                {
                    Id = 14,
                    QuestionSectionId = 2,
                    ResponseTypeId = 2,
                    Name = "The utilisation of the funds is in line with what the SMME Booster Fund aims to achieve i.e.; interventions that provide direct support to SMMEs.",
                    SortOrder = 3
                },
                new Question
                {
                    Id = 15,
                    QuestionSectionId = 2,
                    ResponseTypeId = 2,
                    Name = "The spatial and designated group impact of the proposed intervention is in line with what the SMME Booster Fund sets out to achieve i.e., beneficiaries are township/rural based and are women, youth or persons living with a disability.",
                    SortOrder = 4
                },

                new Question
                {
                    Id = 16,
                    QuestionSectionId = 3,
                    ResponseTypeId = 2,
                    Name = "The organisation requesting support for the qualifying intervention has adequate and relevant experience.",
                    SortOrder = 1
                },
                new Question
                {
                    Id = 17,
                    QuestionSectionId = 3,
                    ResponseTypeId = 2,
                    Name = "The organisation has in the proposal, demonstrated success either relating to the intervention they are seeking assistance for or relevant work done by the organisation.",
                    SortOrder = 2
                },

                new Question
                {
                    Id = 18,
                    QuestionSectionId = 4,
                    ResponseTypeId = 2,
                    Name = "The co-funding / own contribution is of a substantial nature.",
                    SortOrder = 1
                },

                new Question
                {
                    Id = 19,
                    QuestionSectionId = 5,
                    ResponseTypeId = 2,
                    Name = "The impact of the proposed intervention supports the primary objective of the SMME Booster Fund i.e., the propensity of job creation and/or job retention.",
                    SortOrder = 1
                },
                new Question
                {
                    Id = 20,
                    QuestionSectionId = 5,
                    ResponseTypeId = 2,
                    Name = "The average cost of creating the projected number of jobs is tolerable.",
                    SortOrder = 2
                },
                new Question
                {
                    Id = 21,
                    QuestionSectionId = 5,
                    ResponseTypeId = 2,
                    Name = "The average cost of supporting an individual SMME is tolerable",
                    SortOrder = 3
                },

                new Question
                {
                    Id = 22,
                    QuestionSectionId = 6,
                    ResponseTypeId = 2,
                    Name = "The organisation in the proposal has demonstrated an intention to implement a monitoring and evaluation framework in line with what the Department requires.",
                    SortOrder = 1
                },

                new Question
                {
                    Id = 23,
                    QuestionSectionId = 7,
                    ResponseTypeId = 2,
                    Name = "The AFS submitted by the organisation indicates that the 	organisation is in a good financial position",
                    SortOrder = 1
                },

                // Adjudication
                new Question
                {
                    Id = 24,
                    QuestionSectionId = 8,
                    ResponseTypeId = 2,
                    Name = "Risk: The level of risk associated with the organisation and the implementation of the project is tolerable",
                    SortOrder = 1
                },
                new Question
                {
                    Id = 25,
                    QuestionSectionId = 8,
                    ResponseTypeId = 2,
                    Name = "Impact: The impact of the intervention in terms of the following areas:",
                    SortOrder = 2
                },
                new Question
                {
                    Id = 26,
                    QuestionSectionId = 8,
                    ResponseTypeId = 2,
                    Name = "The proposal has a propensity to create or sustain employment",
                    SortOrder = 3
                },
                new Question
                {
                    Id = 27,
                    QuestionSectionId = 8,
                    ResponseTypeId = 2,
                    Name = "DEDAT funding will contribute to the development of SMMEs or enhance the ecosystem",
                    SortOrder = 4
                },

                //Assessment & Evaluation
                new Question
                {
                    Id = 100,
                    QuestionSectionId = 30,
                    ResponseTypeId = 12,
                    Name = "NPO Registration/Public Benefit Org (Section 21) of the Companies Act or Trust",
                    SortOrder = 100,
                    IsActive = true,
                    CreatedUserId = 1
                
                },
                new Question
                {
                    Id = 101,
                    QuestionSectionId = 30,
                    ResponseTypeId = 13,
                    Name = "If the NPO is required to be legally registered in terms of any specific related legislation  e.g. Children's Act, Older Persons Act, etc. that requires registration then rate the NPO.",
                    SortOrder = 101,
                    IsActive = true,
                    CreatedUserId = 1
                },
                new Question
                {
                    Id = 102,
                    QuestionSectionId = 30,
                    ResponseTypeId = 18,
                    Name = "Analysis of Finding",
                    SortOrder = 200,
                    IsActive = true,
                    CreatedUserId = 1
                },
                new Question
                {
                    Id = 103,
                    QuestionSectionId = 30,
                    ResponseTypeId = 10,
                    Name = "Approval",
                    SortOrder = 400,
                    IsActive = true,
                    CreatedUserId = 1
                },
                new Question
                {
                    Id = 104,
                    QuestionSectionId = 30,
                    ResponseTypeId = 18,
                    Name = "Final comment",
                    SortOrder = 500,
                    IsActive = true,
                    CreatedUserId = 1
                },

                new Question
                {
                    Id = 106,
                    QuestionSectionId = 31,
                    ResponseTypeId = 14,
                    Name = "Audited or certified financial statement for previous FY submitted",
                    SortOrder = 100,
                    IsActive = true,
                    CreatedUserId = 1
                },
                new Question
                {
                    Id = 107,
                    QuestionSectionId = 31,
                    ResponseTypeId = 18,
                    Name = "Analysis of Finding",
                    SortOrder = 200,
                    IsActive = true,
                    CreatedUserId = 1
                }, new Question
                {
                    Id = 108,
                    QuestionSectionId = 31,
                    ResponseTypeId = 11,
                    Name = "Approval",
                    SortOrder = 400,
                    IsActive = true,
                    CreatedUserId = 1
                }, new Question
                {
                    Id = 109,
                    QuestionSectionId = 31,
                    ResponseTypeId = 18,
                    Name = "Final comment",
                    SortOrder = 500,
                    IsActive = true,
                    CreatedUserId = 1
                },


                new Question
                {
                    Id = 110,
                    QuestionSectionId = 32,
                    ResponseTypeId = 15,
                    Name = "Monitoring report (select option from the dropdown list)",
                    SortOrder = 100,
                    IsActive = true,
                    CreatedUserId = 1
                },
                new Question
                {
                    Id = 111,
                    QuestionSectionId = 32,
                    ResponseTypeId = 16,
                    Name = "Quarterly Progress Report: Current Financial year - ",
                    SortOrder = 101,
                    IsActive = true,
                    CreatedUserId = 1
                },
                new Question
                {
                    Id = 112,
                    QuestionSectionId = 32,
                    ResponseTypeId = 17,
                    Name = "Quaterly Progress Report from the current or previous financial year. This question maybe answered as \"Not Applicable\"",
                    SortOrder = 102,
                    IsActive = true,
                    CreatedUserId = 1
                },
                new Question
                {
                    Id = 113,
                    QuestionSectionId = 32,
                    ResponseTypeId = 18,
                    Name = "Analysis of Finding",
                    SortOrder = 200,
                    IsActive = true,
                    CreatedUserId = 1
                },
                new Question
                {
                    Id = 114,
                    QuestionSectionId = 32,
                    ResponseTypeId = 11,
                    Name = "Approval",
                    SortOrder = 400,
                    IsActive = true,
                    CreatedUserId = 1
                },
                new Question
                {
                    Id = 115,
                    QuestionSectionId = 32,
                    ResponseTypeId = 18,
                    Name = "Final comment",
                    SortOrder = 500,
                    IsActive = true,
                    CreatedUserId = 1
                },
                new Question
                {
                    Id = 116,
                    QuestionSectionId = 30,
                    ResponseTypeId = 18,
                    Name = "Overall Rating on Analysis of findings (1 - 3)",
                    SortOrder = 300,
                    IsActive = true,
                    CreatedUserId = 1
                },
                 new Question
                 {
                     Id = 117,
                     QuestionSectionId = 31,
                     ResponseTypeId = 18,
                     Name = "Overall Rating on Analysis of findings (1 - 5)",
                     SortOrder = 300,
                     IsActive = true,
                     CreatedUserId = 1
                 },
                  new Question
                  {
                      Id = 118,
                      QuestionSectionId = 32,
                      ResponseTypeId = 18,
                      Name = "Overall Rating on Analysis of findings (1 - 5)",
                      SortOrder = 300,
                      IsActive = true,
                      CreatedUserId = 1
                  },
                  new Question
                  {
                      Id = 119,
                      QuestionSectionId = 33,
                      ResponseTypeId = 11,
                      Name = "Legislative Compliance",
                      SortOrder = 100,
                      IsActive = true,
                      CreatedUserId = 1,
                      CreatedDateTime= DateTime.UtcNow
                  },
                new Question
                {
                    Id = 120,
                    QuestionSectionId = 33,
                    ResponseTypeId = 11,
                    Name = "PFMA Compliance",
                    SortOrder = 101,
                    IsActive = true,
                    CreatedUserId = 1,
                    CreatedDateTime = DateTime.UtcNow
                },
                new Question
                {
                    Id = 121,
                    QuestionSectionId = 33,
                    ResponseTypeId = 11,
                    Name = "Analysis Of Performance",
                    SortOrder = 102,
                    IsActive = true,
                    CreatedUserId = 1,
                    CreatedDateTime = DateTime.UtcNow
                },
                 new Question
                 {
                     Id = 122,
                     QuestionSectionId = 34,
                     ResponseTypeId = 19,
                     Name = "Approver Recommendation",
                     SortOrder = 100,
                     IsActive = true,
                     CreatedUserId = 1,
                     CreatedDateTime = DateTime.UtcNow
                 }
                 
                 ,
                 new Question
                 {
                     Id = 123,
                     QuestionSectionId = 35,
                     ResponseTypeId = 6,
                     Name = "Requires TPA/Submission?",
                     SortOrder = 100,
                     IsActive = true,
                     CreatedUserId = 1,
                     CreatedDateTime = DateTime.UtcNow
                 },
                 new Question
                 {
                     Id = 124,
                     QuestionSectionId = 35,
                     ResponseTypeId = 6,
                     Name = "Verifiable reasons are provided for variance between reported and planned performance",
                     SortOrder = 100,
                     IsActive = true,
                     CreatedUserId = 1,
                     CreatedDateTime = DateTime.UtcNow
                 },
                 new Question
                 {
                     Id = 125,
                     QuestionSectionId = 35,
                     ResponseTypeId = 6,
                     Name = "Reported perfomance informatioom relates to the correct service and output",
                     SortOrder = 100,
                     IsActive = true,
                     CreatedUserId = 1,
                     CreatedDateTime = DateTime.UtcNow
                 },
                 new Question
                 {
                     Id = 126,
                     QuestionSectionId = 35,
                     ResponseTypeId = 6,
                     Name = "Reported performance information is for the correct reporting period",
                     SortOrder = 100,
                     IsActive = true,
                     CreatedUserId = 1,
                     CreatedDateTime = DateTime.UtcNow
                 },
                 new Question
                 {
                     Id = 127,
                     QuestionSectionId = 35,
                     ResponseTypeId = 6,
                     Name = "Supporting documents have a title and page number on each page and signed and dated by the resonsible person",
                     SortOrder = 100,
                     IsActive = true,
                     CreatedUserId = 1,
                     CreatedDateTime = DateTime.UtcNow
                 }
            );
        }
    }
}
