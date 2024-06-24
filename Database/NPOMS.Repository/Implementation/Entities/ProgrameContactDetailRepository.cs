﻿using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
    public class ProgrameContactDetailRepository : BaseRepository<ProgramContactInformation>, IProgrameContactDetailRepository
    {

        public ProgrameContactDetailRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public async Task<IEnumerable<ProgramContactInformation>> GetContactDetailsByProgramId(int progId)
        {
            return await FindByCondition(x => x.ProgrammeId.Equals(progId) && x.IsActive)
                           .Include(x => x.Title)
                           .Include(x => x.Position)
                           .Include(x => x.Gender)
                           .Include(x => x.Race)
                           .Include(x => x.Language)
                           .Include(x => x.ApprovalStatus)
                           .AsNoTracking()
                           .ToListAsync();
        }
    }
}