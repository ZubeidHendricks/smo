using NPOMS.Repository;
using NPOMS.Repository.Implementation;
using NPOMS.Repository.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Test.Repository
{
    [TestClass]
    public class UserTest
    {
        /*private readonly IUserRepository _userRepository;

        public UserTest()
        {
            _userRepository = new UserRepository(ContextConfig.GetContext());
        }

        [TestMethod]
        public async Task User_Exist()
        {
            var users = await _userRepository.GetAllUsersAsync();
            Assert.IsTrue(users.Count() > 0);
        }

        [TestMethod]
        public async Task SystemUser_Exist()
        {
            var users = await _userRepository.GetUserByUserNameAsync("Mogammad.Philander@westerncape.gov.za");
            Assert.IsTrue(users.DepartmentId == 2);
            Assert.IsFalse(users.DepartmentId == 1);
            Assert.IsFalse(users.FirstName == "Yaasier");
        }

        [TestMethod]
        public async Task SystemUser_Has_AdminRoles()
        {
            var users = await _userRepository.GetUserByUserNameAsync("Millicent.Finney@westerncape.gov.za");
            Assert.IsTrue(users.RoleIId == 1);
        }

        [TestMethod]
        public async Task SystemUser_Belongs_ToDepartment()
        {
            var users = await _userRepository.GetUserByUserNameAsync("Reidwhan.Ganief@westerncape.gov.za");
            Assert.IsTrue(users.DepartmentId > 0);
        }
        */
    }
}
