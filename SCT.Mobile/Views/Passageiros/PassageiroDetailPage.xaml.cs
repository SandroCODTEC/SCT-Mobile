using SCT.Mobile.ViewModels.Passageiros;

namespace SCT.Mobile.Views.Passageiros;

public partial class PassageiroDetailPage : ContentPage
{
    public PassageiroDetailPage(PassageiroDetailViewModel mv)
    {
        InitializeComponent();
        BindingContext = mv;
        dataForm.IsReadOnly = true;
    }
}