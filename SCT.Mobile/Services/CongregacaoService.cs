using SCT.Mobile.Models;
using SQLite.Service.Domain.Core.Services;
using System;
using System.Linq;

namespace SCT.Mobile.Services
{
    public class CongregacaoService : SQLiteAsyncService<Guid, Congregacao>
    {
        public CongregacaoService(): base()
        {
            WithChildren = true;
            Task.Run(async () => await Configure());
        }
        private async Task Configure()
        {
            await CreateOrUpdateTableAsync<Saida>();
            if ((await GetAllAsync()).Count() == 0)
            {
                var congregacao = new Congregacao();
                if (congregacao.Saidas.Count == 0)
                {
                    var saidaService = new SaidaService();
                    var itens = saidaService.GetAllAsync();
                    var saida1 = new Saida()
                    {
                        Parada = 1,
                    };
                    var saida2 = new Saida()
                    {
                        Parada = 2,
                    };
                    await saidaService.AddAsync(saida1);
                    await saidaService.AddAsync(saida2);
                    congregacao.Saidas.AddRange(new Saida[] { saida1, saida2 });
                    await UpdateAsync(congregacao);
                }
                await AddAsync(congregacao);
            }

        }
    }
}
