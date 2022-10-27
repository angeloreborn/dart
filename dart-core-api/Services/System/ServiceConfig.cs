using dart_core_api.Contexts;

namespace dart_core_api.Services.System
{
    public interface IServiceConfig
    {    

    }
    public class ServiceConfig : IServiceConfig
    {
        private readonly ConfigDbContext _dbContext;
        public ServiceConfig(ConfigDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
