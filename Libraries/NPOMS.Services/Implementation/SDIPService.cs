using NPOMS.Domain.Entities;
using NPOMS.Repository.Implementation.Entities;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.Implementation
{
    public class SDIPService : ISDIPService
    {
        private ISDIPRepository _sdipRepository;
        private IUserRepository _userRepository;
        public SDIPService(ISDIPRepository sdipRepository, IUserRepository userRepository)
        {
            _sdipRepository = sdipRepository;
            _userRepository = userRepository;


        }

        public async Task CreateSDIPReportEntity(SDIPReport model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.CreatedUserId = loggedInUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _sdipRepository.CreateEntity(model);
        }

        public Task<SDIPReport> GetByIds(int financialYearId, int applicationTypeId)
        {
            throw new NotImplementedException();
        }

        public async Task<SDIPReport> GetSDIPReportById(int id)
        {
            return await _sdipRepository.GetById(id);
        }

        public async Task<IEnumerable<SDIPReport>> GetSDIPReportByNpoId(int npoId)
        {
            return await _sdipRepository.GetByNpoId(npoId);
        }

        public async Task<IEnumerable<SDIPReport>> GetSDIPReportByPeriodId(int applicationPeriodId)
        {
            return await _sdipRepository.GetByPeriodId(applicationPeriodId);
        }

        public async Task<IEnumerable<SDIPReport>> GetSDIPReports()
        {
            return await _sdipRepository.GetEntities();
        }

        public async Task UpdateSDIPReportEntity(SDIPReport model, string currentUserId)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(currentUserId);

            model.CreatedUserId = loggedInUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _sdipRepository.UpdateEntity(model, loggedInUser.Id);
        }

   
    }
}
