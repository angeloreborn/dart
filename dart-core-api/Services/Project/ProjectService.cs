using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using dart_core_api.Contexts;
using dart_core_api.Helper;
using dart_core_api.Hubs;
using dart_core_api.Schemas.MainSchema;
using dart_core_api.Services.Base;
using dart_core_api.Services.System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Construction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace dart_core_api.Services.Project
{
    public interface IProjectService : IBaseService<ProjectModel>
    {
        ServiceResponse<SolutionFile> OpenSolution(string solutionPath);
        ServiceResponse<ProjectInSolution> OpenProject(string solutionPath, string projectId);
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
        public ServiceResponse<SolutionFile> OpenSolution(string solutionPath)
        {
            try
            {
                SolutionFile solutionFile = SolutionFile.Parse(solutionPath);

                if (solutionFile is null)
                    throw new Error("Solution could not be opened");

                return new ServiceResponse<SolutionFile>(solutionFile);
            }
            catch (Error error)
            {
                return new ServiceResponse<SolutionFile>(null)
                {
                    Error = error
                };
            }
        }
        public ServiceResponse<ProjectInSolution> OpenProject(string solutionPath, string projectId)
        {
            try
            {
                ServiceResponse<SolutionFile> response = this.OpenSolution(solutionPath);

                if (response.Value is null)
                    throw new Error("Solution could not be opened");

                IReadOnlyDictionary<string, ProjectInSolution> projectsByGuid = response.Value.ProjectsByGuid;

                bool projectExistsInSolution = projectsByGuid.TryGetValue(projectId, out ProjectInSolution? project);

                if (projectExistsInSolution is false) 
                    throw new Error("Project does not exist in the solution");

                if (project is null)
                    throw new Error("Project failed to load");

                return new ServiceResponse<ProjectInSolution>(project);
            }
            catch (Error error)
            {
                return new ServiceResponse<ProjectInSolution>()
                {
                    Error = error
                };
            }
        }
    }
}
