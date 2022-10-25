using dart_core_api.Contexts;
using dart_core_api.Models;
using dart_core_api.Services.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dart_core_api.Services.Project
{
    public interface IProjectService : IBaseService<ProjectModel>
    {

    }
    public class ProjectService : BaseService<ProjectModel>, IProjectService 
    {
        private readonly MainDbContext _dbMain;
        public ProjectService(MainDbContext dbMain): base(dbMain) 
        {
            _dbMain = dbMain;
        }

    }
}
