using SCT.Mobile.ViewModels.Passagens;

namespace SCT.Mobile.Views.Passagens;

public partial class PassagemDetailPage : ContentPage
{
    public PassagemDetailPage(PassagemDetailViewModel mv)
    {
        InitializeComponent();
        BindingContext = mv;
        dataForm.IsReadOnly = true;
    }
}