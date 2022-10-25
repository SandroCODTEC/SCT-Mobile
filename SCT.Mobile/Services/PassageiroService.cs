using SCT.Mobile.Models;
using SQLite.Service.Domain.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCT.Mobile.Services
{
    public class PassageiroService : SQLiteAsyncService<Guid, Passageiro>
    {
    }
    public class SaidaService : SQLiteAsyncService<Guid, Saida>
    {
    }
    public class EventoDiaService : SQLiteAsyncService<Guid, EventoDia>
    {
    }
    public class PassagemService : SQLiteAsyncService<Guid, Passagem>
    {
        public PassagemService() : base()
        {
            Task.Run(async () => await Configure());
        }
        private async Task Configure()
        {
            await CreateOrUpdateTableAsync<PassagemDia>();
        }
    }
}
