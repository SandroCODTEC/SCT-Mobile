using SCT.Mobile.Models;
using SQLite.Service.Domain.Core.Services;
using System;
using System.Linq;

namespace SCT.Mobile.Services
{
    public class DependenteService : SQLiteAsyncService<Guid, Dependente>
    {
    }
}
