using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPOMS.Repository.Implementation.Core;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Tests.Config;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Tests.Repository
{
	public class DepartmentTest
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentTest()
        {
            _departmentRepository = new DepartmentRepository(ContextConfig.GetContext());
        }

        [TestMethod]
        public async Task Departments_Exists()
        {
            var departments = await _departmentRepository.GetEntities(false);
            Assert.IsTrue(departments.Count() > 0);
        }
    }
}
