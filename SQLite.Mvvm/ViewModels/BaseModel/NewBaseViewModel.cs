using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SQLite.Service.Domain.Core.Interfaces;
using SQLite.Service.Domain.Core.Services.Helpers;

namespace Mvvm.Cammon.ViewModels.BaseModel
{
    public abstract partial class NewBaseViewModel<TEntity, TOid, TService> :
       BaseViewModel<TEntity, TOid, TService>
       where TEntity : new() where TService : IAsyncService<TOid, TEntity>
    {
        public NewBaseViewModel(TService service) : base(service)
        {
            Item = (TEntity)Activator.CreateInstance(typeof(TEntity));
        }
        [ObservableProperty]
        TEntity item;
        [RelayCommand]
        static async void Cancel()
        {
            await Shell.Current.GoToAsync("..", true);
        }
        [RelayCommand]
        public async void Save()
        {
            var result = await Service.AddAsync(Item);
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