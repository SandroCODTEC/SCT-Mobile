using CommunityToolkit.Mvvm.ComponentModel;
using DevExpress.Xpo;
using SCT.Mobile.Helpers;
using SCT.Mobile.Services;
using SCT.Mobile.ViewModels;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SCT.Mobile.Views
{
    public partial class MainPage : Shell
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = ServiceHelper.Current.GetService<MainViewModel>();
        }
    }
}