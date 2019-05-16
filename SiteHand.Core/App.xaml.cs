
using Autofac;
using SiteHand.Core.ViewModels;
using SiteHand.Core.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SiteHand.Core
{
    public partial class App : Application
    {
        public IContainer Container { get; }
        public string UserName { get; set; }

        public App(Module module)
        {
            InitializeComponent();
            Container = BuildContainer(module);
            try
            {
                UserName = Application.Current.Properties["User"].ToString();
                MainPage = new NavigationPage(new ListBookxPage());
            }
            catch (System.Exception)
            {
                MainPage = new NavigationPage(new LoginPage());
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        IContainer BuildContainer(Module module)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<LoginViewModel>().AsSelf();
            builder.RegisterType<SettingsViewModel>().AsSelf();
            builder.RegisterType<ListBooksViewModel>().AsSelf();
            builder.RegisterType<DetailBookViewModel>().AsSelf();
            builder.RegisterModule(module);
            return builder.Build();
        }
    }
}