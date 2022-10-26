using AutoMapper;
using dart_core_api.Helper;
using dart_core_api.Models;
using dart_core_api.Services.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace dart_core_api.Services.Base
{
    public interface IBaseService<ServiceType>
    {
        List<ServiceType> All();
        List<ServiceType> Filter(Expression<Func<ServiceType, bool>> filter);
        void DeleteBy(Expression<Func<ServiceType, bool>> filter);
    }

    public class BaseService<ServiceType> where ServiceType : class
    {
        private readonly DbContext _dbContext;
        private DbSet<ServiceType>? _dbSet;
        public BaseService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<ServiceType> All() => _dbContext.Set<ServiceType>().ToList();
        public List<ServiceType> Filter(Expression<Func<ServiceType, bool>> filter) => _dbContext.Set<ServiceType>().Where(filter).ToList();
        public EntityEntry<ServiceType> Delete(ServiceType serviceType) => _dbContext.Set<ServiceType>().Remove(serviceType);
        public void DeleteBy(Expression<Func<ServiceType, bool>> filter) => _dbContext.Set<ServiceType>().RemoveRange(Filter(filter));
        public EntityEntry<ServiceType> Add(ServiceType serviceType) => _dbContext.Set<ServiceType>().Add(serviceType);
        public EntityEntry<ServiceType> Update(ServiceType serviceType) => _dbContext.Set<ServiceType>().Update(serviceType);
        public void UpdateRange(ServiceType serviceType) => _dbContext.Set<ServiceType>().UpdateRange(serviceType);
        public bool Exists(Expression<Func<ServiceType, bool>> filter) => _dbContext.Set<ServiceType>().Any(filter);
        public List<ServiceType> Paginate<TProperty>(Expression<Func<ServiceType, bool>> filter, Paging paging) => _dbContext.Set<ServiceType>().Where(filter).Skip(paging.Page * paging.PageSize).Take(paging.PageSize).ToList();
        public IQueryable<ServiceType> Query() => _dbContext.Set<ServiceType>().AsQueryable();
        public BaseDbService<ServiceType> Include<TProp>(params Expression<Func<ServiceType,TProp>>[] expressions)
        {
            _dbSet = _dbContext.Set<ServiceType>();
            expressions.SelectMany(x => _dbSet.Include(x.Body.ToString()));

            return new BaseDbService<ServiceType>(_dbSet);
        }
    }

    public class BaseDbService<DServiceType> where DServiceType : class
    {
        private readonly DbSet<DServiceType> _dbSet;
        public BaseDbService(DbSet<DServiceType> dbSet) 
        {
            _dbSet = dbSet;
        }
        public List<DServiceType> Filter(Expression<Func<DServiceType, bool>> filter) => _dbSet.Where(filter).ToList();
        public List<DServiceType> Paginate<TProperty>(Expression<Func<DServiceType, bool>> filter, Paging paging) => _dbSet.Where(filter).Skip(paging.Page * paging.PageSize).Take(paging.PageSize).ToList();
        public IQueryable<DServiceType> Query() => _dbSet.AsQueryable();

    }
}
