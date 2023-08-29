using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using NPOMS.Repository.Extensions;
using NPOMS.Repository.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
	public class FundingApplicationRepository : BaseRepository<FundingApplication>, IFundingApplicationRepository
	{
		#region Constructors

		public FundingApplicationRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		public Task CreateFundingApplication(FundingApplication model)
		{
			throw new NotImplementedException();
		}

		public Task DeleteFundingApplication(int fundingApplicationId, int currentUserId)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<FundingApplication>> ExportAllFundingApplicationsAsync()
		{
			throw new NotImplementedException();
		}

		public Task<FundingApplication> FundingApplicationExist(int programmeId, int applicationCategoryId, int currentUserId)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<FundingApplication>> GetAllFundingApplicationsAsync(int currentUserId, int roleId)
		{
			throw new NotImplementedException();
		}

		public Task<FundingApplication> GetFundingApplicationByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task UpdateFundingApplication(FundingApplication model)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region Methods

		//public async Task<IEnumerable<FundingApplication>> GetAllFundingApplicationsAsync(int currentUserId, int roleId)
		//{
		//	if (roleId == Convert.ToInt32(RoleEnum.Capturer))
		//	{
		//		return await FindByCondition(x => x.CreatedUserId.Equals(currentUserId))
		//						.Where(x => x.IsActive)
		//						.Include(x => x.Programme).ThenInclude(x => x.FundingTemplateType)
		//						.Include(x => x.Programme).ThenInclude(x => x.FinYear)
		//						.Include(x => x.FundingApplicationApplicationCategoryMappings).ThenInclude(x => x.ApplicationCategory)
		//						.Include(x => x.Status)
		//						.Include(x => x.BusinessInformation)
		//						.Include(x => x.MunicipalityInformation).ThenInclude(x => x.Municipality)
		//						.OrderByDescending(x => x.Id)
		//						.AsNoTracking()
		//						.ToListAsync();
		//	}
		//	else
		//	{
		//		return await FindAll()
		//						.Where(x => x.IsActive)
		//						.Include(x => x.Programme).ThenInclude(x => x.FundingTemplateType)
		//						.Include(x => x.Programme).ThenInclude(x => x.FinYear)
		//						.Include(x => x.FundingApplicationApplicationCategoryMappings).ThenInclude(x => x.ApplicationCategory)
		//						.Include(x => x.Status)
		//						.Include(x => x.BusinessInformation)
		//						.Include(x => x.MunicipalityInformation).ThenInclude(x => x.Municipality)
		//						.OrderByDescending(x => x.Id)
		//						.AsNoTracking()
		//						.ToListAsync();
		//	}
		//}

		//public async Task<IEnumerable<FundingApplication>> ExportAllFundingApplicationsAsync()
		//{
		//	return await FindAll()
		//					//.Include(x => x.ApplicationCategory)
		//					.Where(x => x.IsActive)
		//					.Include(x => x.Status)
		//					/*.Include(x => x.ContactInformation)
		//					.Include(x => x.ProjectManagerContactInformation)
		//					.Include(x => x.BusinessInformation)
		//						.ThenInclude(x => x.BBBEELevel)
		//					.Include(x => x.ApplicationInformation)
		//					.Include(x => x.ProjectDescription)
		//					.Include(x => x.ProjectImpact)*/
		//					.Include(x => x.CreatedUser)
		//					.Include(x => x.UpdatedUser)
		//					.Include(x => x.VerifiedUser)
		//					.Include(x => x.ApprovedUser)
		//					.Include(x => x.Programme)
		//						.ThenInclude(y => y.FundingTemplateType)
		//					.Include(x => x.Programme)
		//						.ThenInclude(y => y.FinYear)
		//					.AsNoTracking()
		//					.ToListAsync();
		//}

		//public async Task<FundingApplication> FundingApplicationExist(int programmeId, int applicationCategoryId, int currentUserId)
		//{
		//	return await FindByCondition(x => x.ProgrammeId.Equals(programmeId)
		//					&& x.FundingApplicationApplicationCategoryMappings.ApplicationCategoryId.Equals(applicationCategoryId)
		//					&& x.CreatedUserId.Equals(currentUserId))
		//					.Where(x => x.IsActive)
		//					.AsNoTracking()
		//					.FirstOrDefaultAsync();
		//}

		//public async Task CreateFundingApplication(FundingApplication model)
		//{
		//	model.RefNo = StringExtentions.GenerateNewCode("APP");
		//	model.CreatedDateTime = DateTime.Now;
		//	await CreateAsync(model);
		//}

		//public async Task<FundingApplication> GetFundingApplicationByIdAsync(int id)
		//{
		//	return await FindByCondition(x => x.Id.Equals(id))
		//					.Include(x => x.FundingApplicationApplicationCategoryMappings).ThenInclude(x => x.ApplicationCategory)
		//					.Include(x => x.CreatedUser)
		//					.Include(x => x.UpdatedUser)
		//					.Include(x => x.VerifiedUser)
		//					.Include(x => x.ApprovedUser)
		//					.AsNoTracking()
		//					.FirstOrDefaultAsync();
		//}

		//public async Task UpdateFundingApplication(FundingApplication model)
		//{
		//	await UpdateAsync(model);
		//}

		//public async Task DeleteFundingApplication(int fundingApplicationId, int currentUserId)
		//{
		//	var model = await FindByCondition(x => x.Id.Equals(fundingApplicationId)).FirstOrDefaultAsync();
		//	model.IsActive = false;
		//	model.UpdatedUserId = currentUserId;
		//	model.UpdatedDateTime = DateTime.Now;

		//	await UpdateAsync(model);
		//}

		#endregion
	}
}
