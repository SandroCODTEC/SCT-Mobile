using SCT.Mobile.ViewModels.Congregacoes;

namespace SCT.Mobile.Views.Congregacoes;

public partial class CongregacaoEditPage : ContentPage
{
    public CongregacaoEditPage(CongregacaoEditViewModel vm)
    {
        InitializeComponent();
        BindingContext = ViewModel = vm;
        //colorChoiceChipGroup.SelectionChanged += OnColorChanged;
    }

    private void DataForm_GeneratePropertyItem(object sender, DevExpress.Maui.DataForm.DataFormPropertyGenerationEventArgs e)
    {
        if(e.Item.FieldName == "Saidas")
        {
            e.Item.RowOrder = 9;
        }
    }

    public CongregacaoEditViewModel ViewModel { get; set; }
    private void Save_Clicked(object sender, EventArgs e)
    {
        dataForm.Commit();
        var valid = dataForm.Validate();
        if (valid)
            ViewModel.SaveCommand.Execute(sender);
    }

    private void saidasChip_ChipRemoveIconClicked(object sender, DevExpress.Maui.Editors.ChipEventArgs e)
    {
        ViewModel.RemoveSaidaCommand.Execute(e.Item);
    }

    private void SimpleButton_Clicked(object sender, EventArgs e)
    {
        ViewModel.Saida = new Models.Saida();
        //popupSaida.IsOpen = true;
    }
}