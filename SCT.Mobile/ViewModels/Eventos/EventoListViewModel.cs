using CommunityToolkit.Mvvm.Input;
using Mvvm.Cammon.ViewModels.BaseModel;
using SCT.Mobile.Models;
using SCT.Mobile.Services;
using SCT.Mobile.Views.Eventos;

namespace SCT.Mobile.ViewModels.Eventos
{
    public partial class EventoListViewModel :
        ListBaseViewModel<Evento, Guid, EventoService, EventoNewPage, EventoDetailPage, EventoEditPage>
    {
        public EventoListViewModel(EventoService service) : base(service)
        {
            Title = "Eventos";
        }
        [RelayCommand]
        async Task Search(string value)
        {
            await Task.Delay(100);
            if (IsBusy)
                return;
            IsBusy = true;

            try
            {
                Items.Clear();

                var items = await Service.GetListAsync(w => w.Descricao.Contains(value));
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Erro", ex.Message, "OK"); ;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }

    public partial class EventoDetailViewModel : DetailBaseViewModel<Evento, Guid, EventoService, EventoNewPage, EventoEditPage>
    {
        public EventoDetailViewModel(EventoService service) : base(service)
        {
            Title = "Visualizar Evento";
        }
    }
    public partial class EventoEditViewModel : EditBaseViewModel<Evento, Guid, EventoService>
    {
        public EventoEditViewModel(EventoService service) : base(service)
        {
            Title = "Editar Evento";
        }
    }
    public partial class EventoNewViewModel : NewBaseViewModel<Evento, Guid, EventoService>
    {
        public EventoNewViewModel(EventoService service) : base(service)
        {
            Title = "Novo Evento";
        }
    }
}
