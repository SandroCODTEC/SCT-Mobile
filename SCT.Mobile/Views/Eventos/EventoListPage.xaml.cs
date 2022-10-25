using SCT.Mobile.ViewModels;
using SCT.Mobile.ViewModels.Eventos;

namespace SCT.Mobile.Views.Eventos;

public partial class EventoListPage : ContentPage
{
	public EventoListPage(EventoListViewModel vm)
	{
		InitializeComponent();
        BindingContext = ViewModel = vm;
    }
    EventoListViewModel ViewModel { get; }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        ViewModel.OnAppearing();
    }
}