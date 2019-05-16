using Autofac;
using SiteHand.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SiteHand.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        SettingsViewModel model;
        public SettingsPage()
        {
            InitializeComponent();
            this.BindingContext = model = (Application.Current as App).Container.Resolve<SettingsViewModel>();
        }
    }
}