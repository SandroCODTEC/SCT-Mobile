using SQLite.Service.Domain.Core.Models;
using SQLite.Service.Domain.Core.Services.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SQLite.Service.Domain.Core.Interfaces
{
    public interface IService<TOid, TEntity> where TEntity : IEntity<TOid>
    {
        Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null);
        Task CreateOrUpdateTableAsync<T>() where T : new();
        Task<T> GetWithChildrenAsync<T>(TOid oid) where T : new();
        Task<IList<T>> GetAllWithChildrenAsync<T>(Expression<Func<T, bool>> filter = null) where T : new();
        Task<IResult<bool>> AddAsync(TEntity item);
        Task<IResult<bool>> UpdateAsync(TEntity item);
        Task<IResult<bool>> DeleteAsync(TEntity item);
    }
    public interface IAsyncService<TOid, TEntity> where TEntity : new()
    {
        Task CreateOrUpdateTableAsync<TChild>() where TChild : new();
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(TOid oid);
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate = null);
        Task<List<TEntity>> GetListAsync<TValue>(Expression<Func<TEntity, bool>> predicate = null, Expression<Func<TEntity, TValue>> orderBy = null);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        AsyncTableQuery<TEntity> AsQueryable();
        Task<TEntity> GetWithChildrenAsync(TOid oid);
        Task<List<TEntity>> GetAllWithChildrenAsync(Expression<Func<TEntity, bool>> filter = null);
        Task<IResult<bool>> AddAsync(TEntity item);
        Task<IResult<bool>> UpdateAsync(TEntity item);
        Task<IResult<bool>> DeleteAsync(TEntity item);
    }
}
