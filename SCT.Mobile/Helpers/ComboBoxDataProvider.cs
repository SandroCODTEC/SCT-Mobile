using DevExpress.Maui.DataForm;
using SCT.Mobile.Models;
using SCT.Mobile.Services;
using System.Collections;

namespace DataForm_ComboBoxEditor
{
    public class ComboBoxDataProvider : IPickerSourceProvider
    {
        public IEnumerable GetSource(string propertyName)
        {
            if (propertyName == "Grupo")
            {
                return ValuesDataProvider.Grupos;
            }
            if (propertyName == "Passageiro")
            {
                return GetPassageiros();
            }
            return null;
        }
        List<Passageiro> GetPassageiros() {
            var passageiroServie = new PassageiroService();
            return passageiroServie.GetListAsync(w => w.Ativo, orderBy: o => o.Nome).Result;
        }
        //public partial class MainPage : ContentPage
        //{
        //    public MainPage()
        //    {
        //        InitializeComponent();
        //        dataForm.DataObject = new EmployeeInfo();
        //        dataForm.PickerSourceProvider = new ComboBoxDataProvider();
        //    }
        //}
    }
}