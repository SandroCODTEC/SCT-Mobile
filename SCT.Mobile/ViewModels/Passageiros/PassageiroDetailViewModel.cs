using Mvvm.Cammon.ViewModels.BaseModel;
using SCT.Mobile.Models;
using SCT.Mobile.Services;
using SCT.Mobile.Views.Passageiros;
using System;
using System.Linq;

namespace SCT.Mobile.ViewModels.Passageiros
{
    public partial class PassageiroDetailViewModel : DetailBaseViewModel<Passageiro, Guid, PassageiroService, PassageiroNewPage, PassageiroEditPage>
    {
        public PassageiroDetailViewModel(PassageiroService service) : base(service)
        {
            Title = "Visualizar Passageiro";
        }
    }
}
