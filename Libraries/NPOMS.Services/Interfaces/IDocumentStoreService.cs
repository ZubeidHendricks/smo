using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPOMS.Domain.Core;
using NPOMS.Domain.ResourceParameters;
using NPOMS.Services.Helpers.Paging;
using NPOMS.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
	public interface IDocumentStoreService
	{
		Task<List<string>> BrowseFiles(int? pageSize = 5);

		Task Create(IFormCollection form, string userIdentifier);

		Task Delete(string resourceId, string userIdentifier);

		Task<FileStreamResult> Download(string resourceId);

		Task<PagedList<DocumentStoreViewModel>> Get(DocumentStoreResourceParameters documentStoreResourceParameters);

		Task Update(DocumentStore model, string userIdentifier);
	}
}
