using Mvvm.Cammon.ViewModels.BaseModel;
using SCT.Mobile.Models;
using SCT.Mobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCT.Mobile.ViewModels.Dependetes
{
    public partial class DependenteNewViewModel : NewBaseViewModel<Dependente, Guid, DependenteService>
    {
        public DependenteNewViewModel(DependenteService service) : base(service)
        {
            Title = "Novo Dependente";
        }
    }
}
