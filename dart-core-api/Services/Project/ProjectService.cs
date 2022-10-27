using dart_core_api.Contexts;
using dart_core_api.Schemas.MainSchema;
using dart_core_api.Services.Base;
using dart_core_api.Services.System;
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
        private readonly IServiceTools _tools;
        public ProjectService(MainDbContext dbMain, IServiceTools tools) : base(dbMain , tools) 
        {
            _dbMain = dbMain;
            _tools = tools;
        }

    }
}
