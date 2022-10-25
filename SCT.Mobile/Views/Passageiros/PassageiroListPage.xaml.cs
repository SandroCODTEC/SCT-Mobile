using SCT.Mobile.ViewModels;
using SCT.Mobile.ViewModels.Passageiros;

namespace SCT.Mobile.Views.Passageiros;

public partial class PassageiroListPage : ContentPage
{
	public PassageiroListPage(PassageiroListViewModel vm)
	{
		InitializeComponent();
        BindingContext = ViewModel = vm;
    }
    PassageiroListViewModel ViewModel { get; }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        ViewModel.OnAppearing();
    }
}