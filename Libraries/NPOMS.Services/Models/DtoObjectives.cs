using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.Models
{
    public class DtoObjectives
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public string FinancialYear { get; set; }
        public string Quarter { get; set; }
        public int Recipient { get; set; }
        public string ObjectiveName { get; set; }
        public string ObjectiveDescription { get; set; }
    }
}
