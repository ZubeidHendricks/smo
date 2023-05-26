﻿using NPOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
    public interface IProjectImplementationRepository : IBaseRepository<ProjectImplementation>
    {
        Task<ProjectImplementation> GetById(int id);
        //Task CreateEntity(ProjectImplementation model);
    }
}
