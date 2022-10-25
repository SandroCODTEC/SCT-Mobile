using CommunityToolkit.Mvvm.ComponentModel;
using SQLite.Service.Domain.Core.Interfaces;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mvvm.Cammon.ViewModels.BaseModel
{
    public abstract partial class BaseViewModel<TEntity,TOid, TService> : ObservableObject
        where TEntity : new() 
        where TService : IAsyncService<TOid, TEntity>
    {
        public BaseViewModel(TService service)
        {
            this.Service = service;
        }
        public TService Service { get; set; }
        [ObservableProperty]
        bool isBusy = false;
        [ObservableProperty]
        string title = string.Empty;
    }
}