using SCT.Mobile.ViewModels.Eventos;

namespace SCT.Mobile.Views.Eventos;

public partial class EventoNewPage : ContentPage
{
    public EventoNewPage(EventoNewViewModel vm)
    {
        InitializeComponent();
        BindingContext = ViewModel = vm;
    }
    public EventoNewViewModel ViewModel { get; set; }

    private void Save_Clicked(object sender, EventArgs e)
    {
        dataForm.Commit();
        var valid = dataForm.Validate();
        if (valid)
            ViewModel.SaveCommand.Execute(sender);
    }
}