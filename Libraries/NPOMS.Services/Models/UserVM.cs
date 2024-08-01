using NPOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.Models
{
    public class UserVM
    {
        public string FullName { get; set; }
        public string Email { get; set; } = string.Empty;
        public int Id { get; set; }
    }

    public class ApplicationWithUsers
    {
        public Application model { get; set; }
        public UserVM[] users { get; set; }
    }
}
