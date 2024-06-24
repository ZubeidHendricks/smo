﻿using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
    public interface IProgrameBankDetailRepository : IBaseRepository<ProgramBankDetails>
    {
        Task<IEnumerable<ProgramBankDetails>> GetBankDetailsByProgramId(int progId);
    }
}