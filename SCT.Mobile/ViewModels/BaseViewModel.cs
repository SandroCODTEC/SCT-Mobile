using CommunityToolkit.Mvvm.ComponentModel;
using SCT.Mobile.Models;
using SCT.Mobile.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SCT.Mobile.ViewModels
{
    public abstract partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        bool isBusy = false;
        [ObservableProperty]
        string title = string.Empty;

        public virtual Task InitializeAsync(object parameter)
        {
            return Task.CompletedTask;
        }
    }
}