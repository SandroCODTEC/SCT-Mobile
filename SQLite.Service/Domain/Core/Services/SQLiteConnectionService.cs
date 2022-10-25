using SQLite;
using SQLite.Service.Domain.Core.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Service.Domain.Core.Services
{
    public class SQLiteAsyncConnectionService : SQLiteAsyncConnection
    {

        static readonly Lazy<SQLiteAsyncConnectionService> currentHolder = new Lazy<SQLiteAsyncConnectionService>(() => new SQLiteAsyncConnectionService());

        public static SQLiteAsyncConnectionService Current => currentHolder.Value;

        SQLiteAsyncConnectionService(): base($"{FileSystem.AppDataDirectory}App.db", true)
        {
        }
    }
    public class SQLiteConnectionService : SQLiteConnection
    {

        static readonly Lazy<SQLiteConnectionService> currentHolder = new Lazy<SQLiteConnectionService>(() => new SQLiteConnectionService());

        public static SQLiteConnectionService Current => currentHolder.Value;

        SQLiteConnectionService() : base($"{FileSystem.AppDataDirectory}App.db", true)
        {
        }
    }
}
