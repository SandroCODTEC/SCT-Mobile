using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SQLite.Service.Domain.Core.Interfaces;
using System.Collections.ObjectModel;
using System.Security.Cryptography;

namespace Mvvm.Cammon.ViewModels.BaseModel
{
    public interface IListBaseViewModel<TEntity, TOid, TService, TNewPage, TDetailPage, TEditPage>
    where TEntity : new()
    where TService : IAsyncService<TOid, TEntity>
    where TNewPage : IView
    where TDetailPage : IView
    where TEditPage : IView
    {
        void OnAppearing();

        ObservableCollection<TEntity> Items { get; }
        TEntity SelectedItem { get; set; }
    }
    public abstract partial class ListBaseViewModel<TEntity, TOid, TService, TNewPage, TDetailPage, TEditPage> :
        BaseViewModel<TEntity, TOid, TService>,
        IListBaseViewModel<TEntity, TOid, TService, TNewPage, TDetailPage, TEditPage>
        where TEntity : new()
        where TService : IAsyncService<TOid, TEntity>
        where TNewPage : IView
        where TDetailPage : IView
        where TEditPage : IView
    {
        public ListBaseViewModel(TService service) : base(service)
        {
            Items = new ObservableCollection<TEntity>();
            SearchVisible = false;
        }
        [ObservableProperty]
        TEntity selectedItem;
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(SearchNotVisible), nameof(IconSearch))]
        bool searchVisible;
        public string IconSearch => SearchVisible ? "searchclear" : "search";
        public bool SearchNotVisible => !SearchVisible;
        public ObservableCollection<TEntity> Items { get; }
        public async void OnAppearing()
        {
            SelectedItem = default;
            await LoadItemsAsync();
        }
        [RelayCommand]
        void SearchEnabled()
        {
            SearchVisible = !SearchVisible;

        }
        [RelayCommand]
        async Task LoadItemsAsync()
        {
            if (IsBusy)
                return;
            IsBusy = true;

            try
            {
                Items.Clear();

                var items = await Service.GetAllAsync();
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

        [RelayCommand]
        async Task AddItemAsync(object obj)
        {
            await Shell.Current.GoToAsync(typeof(TNewPage).Name);
        }

        [RelayCommand]
        async Task ItemTappedAsync(TEntity item)
        {
            if (item == null)
                return;
            await Shell.Current.GoToAsync($"{typeof(TDetailPage).Name}", true,
                new Dictionary<string, object>() {
                    { "Item", item }
                });
        }
    }
}