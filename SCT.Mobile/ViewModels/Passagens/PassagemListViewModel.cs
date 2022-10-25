using CommunityToolkit.Mvvm.Input;
using Mvvm.Cammon.ViewModels.BaseModel;
using SCT.Mobile.Models;
using SCT.Mobile.Services;
using SCT.Mobile.Views.Passagens;

namespace SCT.Mobile.ViewModels.Passagens
{
    public partial class PassagemListViewModel :
        ListBaseViewModel<Passagem, Guid, PassagemService, PassagemNewPage, PassagemDetailPage, PassagemEditPage>
    {
        public PassagemListViewModel(PassagemService service) : base(service)
        {
            Title = "Passagems";
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

                var items = await Service.GetListAsync(w => w.Passageiro.Nome.Contains(value));
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
    public partial class PassagemDetailViewModel : DetailBaseViewModel<Passagem, Guid, PassagemService, PassagemNewPage, PassagemEditPage>
    {
        public PassagemDetailViewModel(PassagemService service) : base(service)
        {
            Title = "Visualizar Passagem";
        }
    }
    public partial class PassagemEditViewModel : EditBaseViewModel<Passagem, Guid, PassagemService>
    {
        public PassagemEditViewModel(PassagemService service) : base(service)
        {
            Title = "Editar Passagem";
        }
    }
    public partial class PassagemNewViewModel : NewBaseViewModel<Passagem, Guid, PassagemService>
    {
        public PassagemNewViewModel(PassagemService service) : base(service)
        {
            Title = "Nova Passagem";
        }
    }
}
