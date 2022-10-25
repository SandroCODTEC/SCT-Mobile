using CommunityToolkit.Maui;
using DevExpress.Maui;
using Microsoft.Maui;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using SCT.Mobile.Services;
using SCT.Mobile.ViewModels;
using SCT.Mobile.ViewModels.Congregacoes;
using SCT.Mobile.ViewModels.Eventos;
using SCT.Mobile.ViewModels.Passageiros;
using SCT.Mobile.ViewModels.Passagens;
using SCT.Mobile.Views;
using SCT.Mobile.Views.Congregacoes;
using SCT.Mobile.Views.Eventos;
using SCT.Mobile.Views.Passageiros;
using SCT.Mobile.Views.Passagens;

namespace SCT.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseDevExpress()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("roboto-regular.ttf", "Roboto");
                    fonts.AddFont("roboto-medium.ttf", "Roboto-Medium");
                    fonts.AddFont("roboto-bold.ttf", "Roboto-Bold");
                    fonts.AddFont("univia-pro-regular.ttf", "Univia-Pro");
                    fonts.AddFont("univia-pro-medium.ttf", "Univia-Pro Medium");
                })
                .UseMauiCompatibility();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            #region Passageiros
            builder.Services.AddTransient<PassageiroService>();
            builder.Services.AddTransient<PassageiroListPage>();
            builder.Services.AddTransient<PassageiroListViewModel>();
            builder.Services.AddTransient<PassageiroDetailPage>();
            builder.Services.AddTransient<PassageiroDetailViewModel>();
            builder.Services.AddTransient<PassageiroEditPage>();
            builder.Services.AddTransient<PassageiroEditViewModel>();
            builder.Services.AddTransient<PassageiroNewPage>();
            builder.Services.AddTransient<PassageiroNewViewModel>();
            #endregion

            #region Congregação
            builder.Services.AddTransient<CongregacaoService>();
            builder.Services.AddTransient<CongregacaoEditPage>();
            builder.Services.AddTransient<CongregacaoEditViewModel>();
            #endregion

            #region Saída
            builder.Services.AddTransient<SaidaService>();
            #endregion

            #region Dependentes
            builder.Services.AddTransient<DependenteService>();
            #endregion

            #region EventoDia
            builder.Services.AddTransient<EventoDiaService>();
            #endregion

            #region Eventos
            builder.Services.AddTransient<EventoService>();
            builder.Services.AddTransient<EventoListPage>();
            builder.Services.AddTransient<EventoListViewModel>();
            builder.Services.AddTransient<EventoDetailPage>();
            builder.Services.AddTransient<EventoDetailViewModel>();
            builder.Services.AddTransient<EventoEditPage>();
            builder.Services.AddTransient<EventoEditViewModel>();
            builder.Services.AddTransient<EventoNewPage>();
            builder.Services.AddTransient<EventoNewViewModel>();
            #endregion

            #region Passagens
            builder.Services.AddTransient<PassagemService>();
            builder.Services.AddTransient<PassagemListPage>();
            builder.Services.AddTransient<PassagemListViewModel>();
            builder.Services.AddTransient<PassagemDetailPage>();
            builder.Services.AddTransient<PassagemDetailViewModel>();
            builder.Services.AddTransient<PassagemEditPage>();
            builder.Services.AddTransient<PassagemEditViewModel>();
            builder.Services.AddTransient<PassagemNewPage>();
            builder.Services.AddTransient<PassagemNewViewModel>();
            #endregion
            return builder.Build();
        }
    }
}