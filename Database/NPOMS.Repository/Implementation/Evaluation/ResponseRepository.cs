﻿using NPOMS.Domain.Evaluation;
using NPOMS.Repository.Interfaces.Evaluation;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace NPOMS.Repository.Implementation.Evaluation
{
	public class ResponseRepository : BaseRepository<Response>, IResponseRepository
	{
		#region Contructors

		public ResponseRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

        #endregion

        #region Methods

        public async Task<IEnumerable<Response>> GetAllResponses()
        {
            return await FindAll()
                            .Include(x => x.ResponseOption)
                            .AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Response>> GetByIdsWithDetail(int fundingApplicationId, int currentUserId)
		{
			return await FindByCondition(x => x.FundingApplicationId.Equals(fundingApplicationId))
											  //&&
											  //x.CreatedUserId.Equals(currentUserId))
							.Include(x => x.ResponseOption)
							.AsNoTracking().ToListAsync();
		}

        public async Task<IEnumerable<Response>> GetScorecardByIdsWithDetail
        (int fundingApplicationId, int currentUserId)
        {
            return await FindByCondition(x => x.FundingApplicationId.Equals(fundingApplicationId)
                                              &&
                                              x.CreatedUserId.Equals(currentUserId))
                            .Include(x => x.ResponseOption)
                            .AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Response>> GetByFundingApplicationId(int fundingApplicationId)
		{
			return await FindByCondition(x => x.FundingApplicationId.Equals(fundingApplicationId))
							.Include(x => x.ResponseOption)
							.AsNoTracking().ToListAsync();
		}

		public async Task<IEnumerable<Response>> GetByFIdandQId(int fundingApplicationId, int questionId, int currentUserId)
		{
			return await FindByCondition(x => x.FundingApplicationId.Equals(fundingApplicationId) &&
											  x.QuestionId.Equals(questionId))
                                             // &&  x.CreatedUserId.Equals(currentUserId))
                .Include(x => x.CreatedUser).OrderBy(x => x.CreatedDateTime)
                            .AsNoTracking().ToListAsync();
		}

		public async Task<Response> GetResponseByIds(int fundingApplicationId, int questionId, int currentUserId)
		{
			return await FindByCondition(x => x.FundingApplicationId.Equals(fundingApplicationId) && 
											  x.QuestionId.Equals(questionId) &&
											  x.CreatedUserId.Equals(currentUserId))
							.AsNoTracking().FirstOrDefaultAsync();
		}

        public async Task<Response> GetResponseByIds(int fundingApplicationId, int questionId, int responseOptionId, int createdUserId)
        {
            return await FindByCondition(x => x.FundingApplicationId.Equals(fundingApplicationId) &&
                                              x.QuestionId.Equals(questionId) &&
                                              x.ResponseOptionId.Equals(responseOptionId) &&
                                              x.CreatedUserId.Equals(createdUserId))
                            .AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<Response> GetResponses(int fundingApplicationId, int questionId, int responseOptionId)
        {
            return await FindByCondition(x => x.FundingApplicationId.Equals(fundingApplicationId) &&
                                              x.QuestionId.Equals(questionId) &&
                                              x.ResponseOptionId.Equals(responseOptionId))
                            .AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<Response> GetResponses(int fundingApplicationId, int questionId, int responseOptionId, int createdUserId)
        {
            return await FindByCondition(x => x.FundingApplicationId.Equals(fundingApplicationId) &&
                                              x.QuestionId.Equals(questionId) &&
                                              x.ResponseOptionId.Equals(responseOptionId)&&
                                              x.CreatedUserId.Equals(createdUserId))
                            .AsNoTracking().FirstOrDefaultAsync();
        }

        /// <summary>
        /// Get collection of responses by FundingApplicationId, QuestionIds and CreatedUserId
        /// </summary>
        /// <param name="fundingApplicationId"></param>
        /// <param name="questionIds"></param>
        /// <param name="createdUserId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Response>> GetResponseCollectionByIds(int fundingApplicationId, List<int> questionIds, int createdUserId)
		{
			return await FindByCondition(x => x.FundingApplicationId.Equals(fundingApplicationId) && questionIds.Contains(x.QuestionId) && x.CreatedUserId.Equals(createdUserId))
								.Include(x => x.ResponseOption)
								.AsNoTracking().ToListAsync();
		}

        public async Task<Response> DeleteById(int id)
        {
            var model = await FindByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            await DeleteAsync(model);
            return model;
        }


        public async Task<Response> GetReportResponseByIds(int fundingApplicationId, int questionId, int qtrId, int currentUserId)
        {
            return await FindByCondition(x => x.FundingApplicationId.Equals(fundingApplicationId) &&
                                              x.QuestionId.Equals(questionId) &&
                                              x.QaurterId.Equals(qtrId) &&
                                              x.CreatedUserId.Equals(currentUserId))
                            .AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Response>> GetByIdsWithDetailReport(int fundingApplicationId, int qtrId, int currentUserId)
        {
            return await FindByCondition(x => x.FundingApplicationId.Equals(fundingApplicationId) && x.QaurterId.Equals(qtrId))
                            .Include(x => x.ResponseOption)
                            .AsNoTracking().ToListAsync();
        }

        #endregion
    }
}
