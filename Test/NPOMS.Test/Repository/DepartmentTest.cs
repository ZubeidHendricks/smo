using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPOMS.Repository;
using NPOMS.Repository.Implementation.Core;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Test.Config;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Test.Repository
{
    public class DepartmentTest
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly RepositoryContext _context;

        public DepartmentTest()
        {
            _departmentRepository = new DepartmentRepository(_context,ContextConfig.GetContext());
        }

        [TestMethod]
        public async Task Departments_Exists()
        {
            var departments = await _departmentRepository.GetEntities(false);
            Assert.IsTrue(departments.Count() > 0);
        }
    }
}
