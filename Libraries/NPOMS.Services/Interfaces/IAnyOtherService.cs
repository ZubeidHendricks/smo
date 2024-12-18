﻿using NPOMS.Domain.Entities;
using NPOMS.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
    public interface IAnyOtherService
    {
        Task<IEnumerable<AnyOtherInformationReport>> GetEntities();

        Task<AnyOtherInformationReport> GetById(int id);

        Task<IEnumerable<AnyOtherInformationReport>> GetByPeriodId(int applicationPeriodId);

        Task<IEnumerable<AnyOtherInformationReport>> GetByNpoId(int npoId);

        Task<AnyOtherInformationReport> GetByIds(int financialYearId, int applicationTypeId);

        Task CreateEntity(AnyOtherInformationReport model, string userIdentifier);

        Task UpdateEntity(AnyOtherInformationReport model, string currentUserId);
        Task UpdateEntityQC(AnyOtherInformationReport model, string currentUserId);
        Task<IEnumerable<AnyOtherInformationReport>> UpdateAnyOtherStatus(BaseCompleteViewModel model, string currentUserId);
        
        Task CreateAudit(AnyOtherReportAudit audit, string currentUderId);
    }
}
