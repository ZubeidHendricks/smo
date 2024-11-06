using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.Models
{
    public class BaseCompleteViewModel
    {
        public int ApplicationId { get; set; }
        public int QuarterId { get; set; }
        public int FinYear { get; set; }
        public int serviceDeliveryAreaId { get; set; }
        
    }
}
