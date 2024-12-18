﻿using NPOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
    public interface IProgrameContactDetailRepository : IBaseRepository<ProgramContactInformation>
    {
        Task<IEnumerable<ProgramContactInformation>> GetContactDetailsByProgramId(int programmeId, int npoProfileId);
        Task<IEnumerable<ProgramContactInformation>> GetContactDetails(int npoProfileId);
        Task<IEnumerable<ProgramContactInformation>> GetContactDetailsByIds(int programmeId, int npoProfileId, int subProgramId, int subProgramTypeId);
    }
}
