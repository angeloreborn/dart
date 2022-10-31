using dart_core_api.Services.Machine;
using dart_core_api.Services.Project;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace dart_core_api.Services.System
{
    public interface IServiceFactory
    {
        object? GetService(string service);
        object? GetServiceByType(Type serviceType);
    }
    public class ServiceFactory : IServiceFactory
    {
        private readonly IProjectService _projectService;
        public ServiceFactory(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public object? GetService(string service)
        {
            switch (service)
            {
                case nameof(IProjectService): return _projectService;
            } 
            return  null;
        }

        public object? GetServiceByType(Type serviceType)
        {
            switch (serviceType)
            {
                case IProjectService: return _projectService;
            }
            return null;
        }
    }
}
