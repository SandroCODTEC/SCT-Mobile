using SQLite.Service.Domain.Core.Interfaces;
using SQLite.Service.Domain.Core.Services.Helpers;
using SQLiteNetExtensions.Extensions;
using SQLiteNetExtensionsAsync.Extensions;
using System.Linq.Expressions;
using WebApi.Service.Domain.Core.Services;

//var connection = new SQLiteAsyncConnection(() => sqlite.GetConnectionWithLock());
//await connection.CreateTablesAsync<Ingredient, Stock>();
//IRepository<Stock> stockRepo = new Repository<Stock>(connection);
//IRepository<Ingredient> ingredientRepo = new Repository<Ingredient>(connection);
//var stock1 = new Stock
//{
//    IngredientId = 1,
//    DaysToExpire = 3,
//    EntryDate = DateTime.Now,
//    Location = StockLocations.Fridge,
//    MeasureUnit = MeasureUnits.Liter,
//    Price = 5.50m,
//    ProductName = "Leche Auchan",
//    Quantity = 3,
//    Picture = "test.jpg",
//    Family = IngredientFamilies.Dairy
//};
//var stockId = await stockRepo.Insert(stock1);
//var all = await stockRepo.Get();
//var single = await stockRepo.Get(72);
//var search = await stockRepo.Get(x => x.ProductName.StartsWith("something"));
//var orderedSearch = await stockRepo.Get(predicate: x => x.DaysToExpire < 4, orderBy: x => x.EntryDate);
//Se o Repositório não atender às suas necessidades de consulta, você poderá usar o AsQueryable():
//public async Task<List<Stock>> Search(string searchQuery, StockLocations location, IngredientFamilies family)
//{
//    var query = stockRepo.AsQueryable();
//    if (!string.IsNullOrEmpty(searchQuery))
//    {
//        query = query.Where(x => x.ProductName.Contains(searchQuery) || x.Barcode.StartsWith(searchQuery));
//    }
//    if (location != StockLocations.All)
//    {
//        query = query.Where(x => x.Location == location);
//    }
//    if (family != IngredientFamilies.All)
//    {
//        query = query.Where(x => x.Family == family);
//    }
//    return await query.OrderBy(x => x.ExpirationDays).ToListAsync();
//}

//https://stackoverflow.com/questions/29050400/generic-repository-for-sqlite-net-in-xamarin-project
namespace SQLite.Service.Domain.Core.Services
{
    public abstract class SQLiteAsyncService<TOid, TEntity> : IAsyncService<TOid, TEntity> where TEntity : new()
    {

        private readonly SQLiteAsyncConnectionService connection;
        private bool SchemaCreated = false;
        public bool WithChildren { get; set; } = false;
        public SQLiteAsyncService()
        {
            connection = SQLiteAsyncConnectionService.Current;
            Task.Run(async () => await EnsureTableAsync());

        }

        private async Task EnsureTableAsync()
        {
            if (!SchemaCreated)
            {
                await connection.CreateTableAsync<TEntity>();
                SchemaCreated = true;
            }
        }
        public async Task CreateOrUpdateTableAsync<TChild>() where TChild : new() => 
            await connection.CreateTableAsync<TChild>();

        public AsyncTableQuery<TEntity> AsQueryable() =>
           connection.Table<TEntity>();

        public async Task<List<TEntity>> GetAllAsync() =>
            await connection.Table<TEntity>().ToListAsync();

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            var query = connection.Table<TEntity>();

            if (predicate != null)
                query = query.Where(predicate);

            return await query.ToListAsync();
        }
        public async Task<List<TEntity>> GetListAsync<TValue>(Expression<Func<TEntity, bool>> predicate = null, Expression<Func<TEntity, TValue>> orderBy = null)
        {
            var query = connection.Table<TEntity>();

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = query.OrderBy(orderBy);

            return await query.ToListAsync();
        }
        public async Task<TEntity> GetAsync(TOid oid) =>
             await connection.FindAsync<TEntity>(oid);


        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate) =>
            await connection.FindAsync(predicate);

        public async Task<TEntity> GetWithChildrenAsync(TOid oid)
        {
            return await connection.GetWithChildrenAsync<TEntity>(oid);
        }

        public async Task<List<TEntity>> GetAllWithChildrenAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            return await connection.GetAllWithChildrenAsync(predicate);
        }
        public async Task<List<TEntity>> GetAllWithChildrenAsync<TValue>(Expression<Func<TEntity, bool>> predicate = null)
        {
            return await connection.GetAllWithChildrenAsync(predicate);
        }

        public async Task<IResult<bool>> AddAsync(TEntity item)
        {
            try
            {
                if (WithChildren)
                    await connection.InsertWithChildrenAsync(item);
                else await connection.InsertAsync(item);
                return new Success<bool>(true);
            }
            catch (SQLiteException ex)
            {
                return new Fail<bool>(new Error(ex.HResult, ex.Message));
            }
            catch (Exception ex)
            {
                return new Fail<bool>(new Error(ex.HResult, ex.Message));
            }
        }
        public async Task<IResult<bool>> UpdateAsync(TEntity item)
        {
            try
            {
                if (WithChildren)
                    await connection.UpdateWithChildrenAsync(item);
                else await connection.UpdateAsync(item);
                return new Success<bool>(true);
            }
            catch (SQLiteException ex)
            {
                return new Fail<bool>(new Error(ex.HResult, ex.Message));
            }
            catch (Exception ex)
            {
                return new Fail<bool>(new Error(ex.HResult, ex.Message));
            }
        }
        public async Task<IResult<bool>> DeleteAsync(TEntity item)
        {
            try
            {
                await connection.DeleteAsync(item, WithChildren);
                return new Success<bool>(true);
            }
            catch (SQLiteException ex)
            {
                return new Fail<bool>(new Error(ex.HResult, ex.Message));
            }
            catch (Exception ex)
            {
                return new Fail<bool>(new Error(ex.HResult, ex.Message));
            }
        }

    }
    public abstract class SQLiteService<TOid, TEntity> : IService<TOid, TEntity> where TEntity : IEntity<TOid>
    {

        private readonly SQLiteConnectionService connection;
        private bool SchemaCreated = false;
        public bool WithChildren { get; set; } = false;
        public SQLiteService()
        {
            connection = SQLiteConnectionService.Current;
            Task.Run(async () => await EnsureTableAsync());
        }

        private async Task EnsureTableAsync()
        {
            if (!SchemaCreated)
            {
                await Task.Run(() => connection.CreateTable<TEntity>());
                SchemaCreated = true;
            }
        }
        public async Task CreateOrUpdateTableAsync<T>() where T : new()
        {
            await Task.Run(() => connection.CreateTable<T>());
        }
        public async Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            var result = await Task.Run(() => (new TableQuery<TEntity>(connection)).Where(filter).AsQueryable());
            return result;
        }
        public async Task<T> GetWithChildrenAsync<T>(TOid oid) where T : new()
        {
            var result = await Task.Run(() => connection.GetWithChildren<T>(oid));
            return result;
        }
        public async Task<IList<T>> GetAllWithChildrenAsync<T>(Expression<Func<T, bool>> filter = null) where T : new()
        {
            return await Task.Run(() => connection.GetAllWithChildren(filter));
        }
        public async Task<IResult<bool>> AddAsync(TEntity item)
        {
            try
            {
                if (WithChildren)
                    await Task.Run(() => connection.InsertWithChildren(item));
                else await Task.Run(() => connection.Insert(item));
                return new Success<bool>(true);
            }
            catch (SQLiteException ex)
            {
                return new Fail<bool>(new Error(ex.HResult, ex.Message));
            }
            catch (Exception ex)
            {
                return new Fail<bool>(new Error(ex.HResult, ex.Message));
            }
        }
        public async Task<IResult<bool>> UpdateAsync(TEntity item)
        {
            try
            {
                if (WithChildren)
                    await Task.Run(() => connection.UpdateWithChildren(item)); 
                else await Task.Run(() => connection.Update(item)); 
                return new Success<bool>(true);
            }
            catch (SQLiteException ex)
            {
                return new Fail<bool>(new Error(ex.HResult, ex.Message));
            }
            catch (Exception ex)
            {
                return new Fail<bool>(new Error(ex.HResult, ex.Message));
            }
        }
        public async Task<IResult<bool>> DeleteAsync(TEntity item)
        {
            try
            {
                await Task.Run(() => connection.Delete(item, WithChildren));
                return new Success<bool>(true);
            }
            catch (SQLiteException ex)
            {
                return new Fail<bool>(new Error(ex.HResult, ex.Message));
            }
            catch (Exception ex)
            {
                return new Fail<bool>(new Error(ex.HResult, ex.Message));
            }
        }
    }
}
