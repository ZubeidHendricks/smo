using NPOMS.Services.DTOs.FundingAssessments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
    public interface IApplicationFundingAssessmentService
    {
       Task<IEnumerable<dtoFundingAssessmentApplicationGet>> GetAllFundingAssessmentApplications(string userIdentifier);
    }
}
