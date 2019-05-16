using Autofac;
using SiteHand.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SiteHand.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginViewModel model;

        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = model = (Application.Current as App).Container.Resolve<LoginViewModel>();
        }
    }
}