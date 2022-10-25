using SCT.Mobile.ViewModels.Passagens;

namespace SCT.Mobile.Views.Passagens;

public partial class PassagemNewPage : ContentPage
{
    public PassagemNewPage(PassagemNewViewModel vm)
    {
        InitializeComponent();
        BindingContext = ViewModel = vm;
    }
    public PassagemNewViewModel ViewModel { get; set; }

    private void Save_Clicked(object sender, EventArgs e)
    {
        dataForm.Commit();
        var valid = dataForm.Validate();
        if (valid)
            ViewModel.SaveCommand.Execute(sender);
    }
}