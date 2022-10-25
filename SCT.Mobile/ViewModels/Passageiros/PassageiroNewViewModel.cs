using Mvvm.Cammon.ViewModels.BaseModel;
using SCT.Mobile.Models;
using SCT.Mobile.Services;
using System;
using System.Linq;

namespace SCT.Mobile.ViewModels.Passageiros
{
    public partial class PassageiroNewViewModel : NewBaseViewModel<Passageiro, Guid, PassageiroService>
    {
        public PassageiroNewViewModel(PassageiroService service) : base(service)
        {
            Title = "Novo Passageiro";
        }
    }
}
