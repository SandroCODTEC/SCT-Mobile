//using SQLite;
//using SQLite.Service.Domain.Core.Entities;
//using SQLite.Service.Domain.Core.Interfaces;
//using SQLite.Service.Domain.Core.Services.Helpers;
//using SQLiteNetExtensions.Extensions;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Net;
//using WebApi.Service.Domain.Core.Services;

//namespace SQLite.Service.Domain.Core.Services
//{
//    public abstract class SQLiteWithChildrenService<TOid, TEntity> : IService, IService<TOid, TEntity> where TEntity : IEntity<TOid>
//    {
//        private readonly SQLiteConnectionService connection;
//        private bool SchemaCreated = false;
//        public bool WithChildren { get; set; }
//        public SQLiteWithChildrenService()
//        {
//            connection = SQLiteConnectionService.Current;
//            EnsureTableAsync();
//        }

//        private void EnsureTableAsync()
//        {
//            if (!SchemaCreated)
//            {
//                connection.CreateTable<TEntity>();
//                SchemaCreated = true;
//            }
//        }

//        public IQueryable<TEntity> Get()
//        {
//            var query = new TableQuery<TEntity>(connection);
//            return query.AsQueryable();
//        }
//        public List<T> GetAllWithChildren<T>(Expression<Func<T, bool>> filter = null) where T: new()
//        {
//            var list = connection.GetAllWithChildren(filter);
//            return list;
//        }
//        public IResult<bool> Add(TEntity item)
//        {
//            try
//            {
//                connection.InsertWithChildren(item);
//                return new Success<bool>(true);
//            }
//            catch (SQLiteException ex)
//            {
//                return new Fail<bool>(new Error(ex.HResult, ex.Message));
//            }
//            catch (Exception ex)
//            {
//                return new Fail<bool>(new Error(ex.HResult, ex.Message));
//            }
//        }
//        public IResult<bool> Update(TEntity item)
//        {
//            try
//            {
//                connection.UpdateWithChildren(item);
//                return new Success<bool>(true);
//            }
//            catch (SQLiteException ex)
//            {
//                return new Fail<bool>(new Error(ex.HResult, ex.Message));
//            }
//            catch (Exception ex)
//            {
//                return new Fail<bool>(new Error(ex.HResult, ex.Message));
//            }
//        }
//        public IResult<bool> Delete(TEntity item)
//        {
//            try
//            {
//                connection.Delete(item, recursive: true);
//                return new Success<bool>(true);
//            }
//            catch (SQLiteException ex)
//            {
//                return new Fail<bool>(new Error(ex.HResult, ex.Message));
//            }
//            catch (Exception ex)
//            {
//                return new Fail<bool>(new Error(ex.HResult, ex.Message));
//            }
//        }
//    }
//}
