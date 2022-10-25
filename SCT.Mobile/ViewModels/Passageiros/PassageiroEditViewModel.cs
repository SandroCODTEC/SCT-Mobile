using Mvvm.Cammon.ViewModels.BaseModel;
using SCT.Mobile.Models;
using SCT.Mobile.Services;
using System;
using System.Linq;

namespace SCT.Mobile.ViewModels.Passageiros
{
    public partial class PassageiroEditViewModel : EditBaseViewModel<Passageiro, Guid, PassageiroService>
    {
        public PassageiroEditViewModel(PassageiroService service) : base(service)
        {
            Title = "Editar Passageiro";
        }
    }
}
