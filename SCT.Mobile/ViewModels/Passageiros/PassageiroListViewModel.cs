using CommunityToolkit.Mvvm.Input;
using Mvvm.Cammon.ViewModels.BaseModel;
using SCT.Mobile.Models;
using SCT.Mobile.Services;
using SCT.Mobile.Views.Passageiros;

namespace SCT.Mobile.ViewModels.Passageiros
{
    public partial class PassageiroListViewModel :
        ListBaseViewModel<Passageiro, Guid, PassageiroService, PassageiroNewPage, PassageiroDetailPage, PassageiroEditPage>
    {
        public PassageiroListViewModel(PassageiroService service) : base(service)
        {
            Title = "Passageiros";
        }
        [RelayCommand]
        async Task Search(string value)
        {
            await Task.Delay(100);
            if (IsBusy)
                return;
            IsBusy = true;

            try
            {
                Items.Clear();

                var items = await Service.GetListAsync(w => w.Nome.Contains(value));
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Erro", ex.Message, "OK"); ;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
