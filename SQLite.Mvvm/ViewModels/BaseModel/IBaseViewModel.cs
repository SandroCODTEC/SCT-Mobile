using SQLite.Service.Domain.Core.Interfaces;

namespace MVVM.Cammon.ViewModels.BaseModel
{
    public interface IBaseViewModel<TOid, TEntity, TService>
        where TEntity : IEntity<TOid> 
        where TService : IService<TOid, TEntity>
    {
        TService Service { get; set; }
        bool IsBusy { get; set; }
        string Title { get; set; }

    }
}