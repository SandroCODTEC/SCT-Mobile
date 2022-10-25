using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SQLite.Service.Domain.Core.Interfaces;
using System.Diagnostics;
using SQLite.Service.Domain.Core.Services.Helpers;

namespace Mvvm.Cammon.ViewModels.BaseModel
{
    [QueryProperty("Item", "Item")]
    public abstract partial class DetailBaseViewModel<TEntity, TOid, TService, TNewPage, TEditPage> :
       BaseViewModel<TEntity, TOid, TService>
        where TEntity : new()
        where TService : IAsyncService<TOid, TEntity>
        where TNewPage : IView
        where TEditPage : IView
    {
        public DetailBaseViewModel(TService service) : base(service)
        {
        }
        [ObservableProperty]
        TEntity item;
        //[RelayCommand]
        //public async Task LoadItemId(TOid itemId)
        //{
        //    try
        //    {
        //        Item = Service.Get().FirstOrDefault(w => w.Oid.Equals(itemId));
        //    }
        //    catch (Exception ex)
        //    {
        //        await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
        //    }
        //}
        [RelayCommand]
        async Task EditItemAsync()
        {
            if (Item == null)
                return;
            await Shell.Current.GoToAsync($"{typeof(TEditPage).Name}", true,
                new Dictionary<string, object>() {
                    { "Item", Item }
                });
        }
        [RelayCommand]
        public async Task DeleteItemAsync()
        {
            var delete = await Application.Current.MainPage.DisplayAlert("Apagando registro...", $"Tem certeza que deseja excluir o registro '{Item}'?", "Sim", "Não");
            if (!delete)
                return;
            try
            {
                var result = await Service.DeleteAsync(Item);
                if (result.IsSuccess)
                {
                    Cancel();
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", ((Fail<bool>)result).Error.Message, "OK");
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }
        [RelayCommand]
        static async void Cancel()
        {
            await Shell.Current.GoToAsync("..", true);
        }
    }
}