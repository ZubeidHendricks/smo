using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.Models
{
    public class DtoActivity
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public int FinancialYearId { get; set; }
        public string FinancialYear { get; set; }
        public string Quarter { get; set; }
        public int Recipient { get; set; }
        public int ObjectiveId { get; set; }
        public int ActivityTypeId { get; set; }
        public string ActivityName { get; set; }
        public string ActivityDescription { get; set; }
        public int Target { get; set; }
        public string SuccessIndicator { get; set; }
        public int DemographicDistrictId { get; set; }
        public string DemographicDistrictName { get; set; }
        public string AreaName { get; set; }
        public string ActivityManicipalityName { get; set; }
        public int MunicipalityId { get; set; }
        public string MunicipalityName { get; set; }
        public string ActivitySubDistrictsName { get; set; }
        public int SubstructureId { get; set; }
        public string SubstructureName { get; set; }
        public int AreaId { get; set; }
    }
}
