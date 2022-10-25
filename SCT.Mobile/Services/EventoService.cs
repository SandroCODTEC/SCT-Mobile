using SCT.Mobile.Models;
using SQLite.Service.Domain.Core.Services;
using System;
using System.Linq;

namespace SCT.Mobile.Services
{
    public class EventoService : SQLiteAsyncService<Guid, Evento>
    {
        public EventoService()
        {
            WithChildren = true;
        }
    }
}
