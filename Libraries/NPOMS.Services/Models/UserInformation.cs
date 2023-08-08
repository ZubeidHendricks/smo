using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.Models
{
    public class UserInformation
    {
        public class UserViewModel
        {

            public int CreatedUserName { get; set; }

            public DateTime CreatedDateTime { get; set; }

            public int UpdatedUserName { get; set; }

            public DateTime UpdatedDateTime { get; set; }
        }
    }
}
