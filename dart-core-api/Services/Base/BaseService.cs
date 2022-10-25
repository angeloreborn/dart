using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace dart_core_api.Services.Base
{
    public interface IBaseService<ServiceType>
    {
        List<ServiceType> All();
        List<ServiceType> Filter(Expression<Func<ServiceType, bool>> filter);
        void Delete(Expression<Func<ServiceType, bool>> filter);
    }

    public class BaseService<ServiceType> where ServiceType : class
    {
        private readonly DbContext _dbContext;
        public BaseService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ServiceType> All() => _dbContext.Set<ServiceType>().ToList();
        public List<ServiceType> Filter(Expression<Func<ServiceType, bool>> filter) => _dbContext.Set<ServiceType>().Where(filter).ToList();
        public void Delete(Expression<Func<ServiceType, bool>> filter) => _dbContext.Set<ServiceType>().RemoveRange(Filter(filter));


    }
}
