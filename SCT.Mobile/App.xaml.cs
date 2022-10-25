using Microsoft.Maui;
using Microsoft.Maui.Controls;
using SCT.Mobile.Services;
using SCT.Mobile.ViewModels;
using SCT.Mobile.Views;
using SCT.Mobile.Views.Congregacoes;
using SCT.Mobile.Views.Passageiros;
using Application = Microsoft.Maui.Controls.Application;

namespace SCT.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            //DependencyService.Register<NavigationService>();

            //Routing.RegisterRoute(typeof(ItemDetailPage).FullName, typeof(ItemDetailPage));
            //Routing.RegisterRoute(typeof(NewItemPage).FullName, typeof(NewItemPage));


            #region Passageiro
            Routing.RegisterRoute(nameof(PassageiroDetailPage), typeof(PassageiroDetailPage));
            Routing.RegisterRoute(nameof(PassageiroNewPage), typeof(PassageiroNewPage));
            Routing.RegisterRoute(nameof(PassageiroEditPage), typeof(PassageiroEditPage));
            Routing.RegisterRoute(nameof(PassageiroListPage), typeof(PassageiroListPage));
            #endregion

            #region Congregação
            Routing.RegisterRoute(nameof(CongregacaoEditPage), typeof(CongregacaoEditPage));
            #endregion

            MainPage = new MainPage();
            // Use the NavigateToAsync<ViewModelName> method
            // to display the corresponding view.
            // Code lines below show how to navigate to a specific page.
            // Comment out all but one of these lines
            // to open the corresponding page.
            //var navigationService = DependencyService.Get<INavigationService>();
            //navigationService.NavigateToAsync<LoginViewModel>(true);


        }
    }
}
