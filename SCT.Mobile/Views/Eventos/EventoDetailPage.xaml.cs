using SCT.Mobile.ViewModels.Eventos;

namespace SCT.Mobile.Views.Eventos;

public partial class EventoDetailPage : ContentPage
{
    public EventoDetailPage(EventoDetailViewModel mv)
    {
        InitializeComponent();
        BindingContext = mv;
        dataForm.IsReadOnly = true;
    }
}