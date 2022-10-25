using SCT.Mobile.ViewModels.Passageiros;

namespace SCT.Mobile.Views.Passageiros;

public partial class PassageiroNewPage : ContentPage
{
    public PassageiroNewPage(PassageiroNewViewModel vm)
    {
        InitializeComponent();
        BindingContext = ViewModel = vm;
    }
    public PassageiroNewViewModel ViewModel { get; set; }

    private void Save_Clicked(object sender, EventArgs e)
    {
        dataForm.Commit();
        var valid = dataForm.Validate();
        if (valid)
            ViewModel.SaveCommand.Execute(sender);
    }
}