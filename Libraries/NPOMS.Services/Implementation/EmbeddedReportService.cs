using AutoMapper;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Services.Interfaces;
using NPOMS.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Services.Implementation
{
	public class EmbeddedReportService : IEmbeddedReportService
	{
		#region Fields

		private IMapper _mapper;
		private IEmbeddedReportRepository _embeddedReportRepository;

		#endregion

		#region Constructors

		public EmbeddedReportService(
			IMapper mapper,
			IEmbeddedReportRepository embeddedReportRepository
			)
		{
			_mapper = mapper;
			_embeddedReportRepository = embeddedReportRepository;
		}

		#endregion

		#region Methods

		public async Task<List<EmbeddedReportViewModel>> GetEmbeddedReports()
		{
			var reports = await _embeddedReportRepository.GetEntities();
			return _mapper.Map<List<EmbeddedReportViewModel>>(reports);
		}

		public async Task<EmbeddedReportViewModel> GetEmbeddedReportById(int id)
		{
			var report = await _embeddedReportRepository.GetById(id);
			return _mapper.Map<EmbeddedReportViewModel>(report);
		}

		#endregion

	}
}
