using NPOMS.Domain.Entities;
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
    public  class PostService : IPostService
    {
        private IPostRepository _postRepository;
        private IUserRepository _userRepository;
        public PostService(IPostRepository postRepository,
            IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;

        }
        public async Task<IEnumerable<PostReport>> GetPostReports()
        {
            return await _postRepository.GetEntities();
        }

        public async Task<PostReport> GetPostReportById(int id)
        {
            return await _postRepository.GetById(id);
        }

        public async Task<IEnumerable<PostReport>> GetPostReportByPeriodId(int applicationPeriodId)
        {
            return await _postRepository.GetByPeriodId(applicationPeriodId);
        }

        public async Task<IEnumerable<PostReport>> GetPostReportByNpoId(int npoId)
        {
            return await _postRepository.GetByNpoId(npoId);
        }

        public Task<PostReport> GetByIds(int financialYearId, int applicationTypeId)
        {
            throw new NotImplementedException();
        }

        public async Task CreatePostReportEntity(PostReport model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.CreatedUserId = loggedInUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _postRepository.CreateEntity(model);
        }

        public async Task UpdatePostReportEntity(PostReport model, string currentUserId)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(currentUserId);

            model.CreatedUserId = loggedInUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _postRepository.UpdateEntity(model, loggedInUser.Id);
        }

        public Task<PostReport> GetIndicatorReportById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePostReportEntityQC(PostReport model, int currentUserId)
        {
            throw new NotImplementedException();
        }
    }
    
}
