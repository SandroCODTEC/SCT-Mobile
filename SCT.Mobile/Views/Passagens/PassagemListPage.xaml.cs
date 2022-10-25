using SCT.Mobile.ViewModels;
using SCT.Mobile.ViewModels.Passagens;

namespace SCT.Mobile.Views.Passagens;

public partial class PassagemListPage : ContentPage
{
	public PassagemListPage(PassagemListViewModel vm)
	{
		InitializeComponent();
        BindingContext = ViewModel = vm;
    }
    PassagemListViewModel ViewModel { get; }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        ViewModel.OnAppearing();
    }
}