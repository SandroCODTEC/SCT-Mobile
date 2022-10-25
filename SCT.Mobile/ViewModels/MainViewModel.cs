using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SCT.Mobile.Helpers;
using SCT.Mobile.Models;
using SCT.Mobile.Services;
using SCT.Mobile.Views.Congregacoes;
using SCT.Mobile.Views.Eventos;

namespace SCT.Mobile.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        private readonly CongregacaoService _congregacaoService;
        private readonly EventoService _eventoService;
        public MainViewModel(CongregacaoService congregacaoService, EventoService eventoService)
        {
            _congregacaoService = congregacaoService;
            _eventoService = eventoService;

            Task.Run(() => { CheckExisteCongregacao(); return Task.CompletedTask; });
        }
        [ObservableProperty]
        bool existeEvento = false;
        [ObservableProperty]
        bool existeCongregacao = false;
        [ObservableProperty]
        Congregacao congregacao;
        [ObservableProperty]
        Evento evento;


        [RelayCommand]
        public async void CheckExisteCongregacao()
        {
            ExisteCongregacao = Preferences.ContainsKey("Congregacao");
            CheckExisteEvento();
            if (!ExisteCongregacao)
            {
                Congregacao = (await _congregacaoService.GetAllAsync()).FirstOrDefault();
                await Shell.Current.GoToAsync($"{typeof(CongregacaoEditPage).Name}", true,
                    new Dictionary<string, object>() {
                                    { "Item", Congregacao }
                    });
            }
            else if (!ExisteEvento)
            {
                await Shell.Current.GoToAsync($"{typeof(EventoListPage).Name}", true);
            }
        }
        [RelayCommand]
        public void CheckExisteEvento()
        {
            ExisteEvento = Preferences.ContainsKey("Evento");
        }
    }
}