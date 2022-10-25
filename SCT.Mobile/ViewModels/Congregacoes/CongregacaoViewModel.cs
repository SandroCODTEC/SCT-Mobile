using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mvvm.Cammon.ViewModels.BaseModel;
using SCT.Mobile.Models;
using SCT.Mobile.Services;
using SCT.Mobile.Views.Eventos;
using SCT.Mobile.Views.Passageiros;
using SCT.Mobile.Views.Passagens;
using SQLite.Service.Domain.Core.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCT.Mobile.ViewModels.Congregacoes
{
    public partial class CongregacaoEditViewModel : EditBaseViewModel<Congregacao, Guid, CongregacaoService>
    {
        private readonly SaidaService saidaService;
        public CongregacaoEditViewModel(CongregacaoService service, SaidaService _saidaService) : base(service)
        {
            this.saidaService = _saidaService;
            Title = "Editar Congregação";
            Saida = new Saida();
        }

        [ObservableProperty]
        Saida saida;
        [ObservableProperty]
        bool isEditOpenSaida = false;
        [ObservableProperty]
        bool isAddOpenSaida = false;

        [RelayCommand]
        public void RemoveSaida(Saida value)
        {
            if (Item != null && Item.Saidas.Count > 0)
            {
                Item.Saidas.Remove(value);
                Item.OnPropertyChanged("Saidas");
            }
        }
        [RelayCommand]
        public async void SaveEditSaida()
        {
            await saidaService.UpdateAsync(Saida);
            IsAddOpenSaida = false;
            IsEditOpenSaida = false;
            Item.OnPropertyChanged("Saidas");
        }
        [RelayCommand]
        public async void SaveAddSaida()
        {
            await saidaService.AddAsync(Saida);
            Item.Saidas.Add(Saida);
            await Service.UpdateAsync(Item);
            IsAddOpenSaida = false;
            IsEditOpenSaida = false;
            Item.OnPropertyChanged("Saidas");
        }
        [RelayCommand]
        public void OpenAddSaida()
        {
            Saida = new Saida();
            IsAddOpenSaida = true;
        }
        [RelayCommand]
        public void OpenEditSaida(Saida value)
        {
            Saida = value;
            IsEditOpenSaida = true;
        }
        [RelayCommand]
        public void CloseSaida()
        {
            IsAddOpenSaida = false;
            IsEditOpenSaida = false;
        }
        public override async void Save()
        {
            var result = await Service.UpdateAsync(Item);
            if (result.IsSuccess)
            {
                Preferences.Set("Congregacao", Item.Oid.ToString());
                if (Preferences.ContainsKey("Evento"))
                {
                    await Shell.Current.GoToAsync($"{typeof(EventoListPage).Name}", true,
                        new Dictionary<string, object>() {
                    { "Item", Item }
                        });

                }
                else
                {
                    await Shell.Current.GoToAsync($"{typeof(PassageiroListPage).Name}", true,
                        new Dictionary<string, object>() {
                        { "Item", Item }
                        });
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", ((Fail<bool>)result).Error.Message, "OK");
            }
        }
    }
}
