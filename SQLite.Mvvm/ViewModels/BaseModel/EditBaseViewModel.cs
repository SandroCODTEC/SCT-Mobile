using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SQLite.Service.Domain.Core.Interfaces;
using SQLite.Service.Domain.Core.Services.Helpers;

namespace Mvvm.Cammon.ViewModels.BaseModel
{
    [QueryProperty("Item", "Item")]
    public abstract partial class EditBaseViewModel<TEntity, TOid, TService> :
       BaseViewModel<TEntity, TOid, TService>
       where TEntity : new() where TService : IAsyncService<TOid, TEntity>
    {
        public EditBaseViewModel(TService service) : base(service)
        {
        }
        [ObservableProperty]
        TEntity item;

        [RelayCommand]
        public virtual async void Cancel()
        {
            await Shell.Current.GoToAsync("..", true);
        }
        [RelayCommand]
        public virtual async void Save()
        {
            var result = await Service.UpdateAsync(Item);
            if (result.IsSuccess)
            {
                Cancel();
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", ((Fail<bool>)result).Error.Message, "OK");
            }
        }
    }
}