using System;
using Autofac;
using SiteHand.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SiteHand.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailBook : ContentPage
    {
        DetailBookViewModel ViewModel;

        public DetailBook(string idVolume)
        {
            InitializeComponent();
            this.BindingContext = ViewModel = (Application.Current as App).Container.Resolve<DetailBookViewModel>(new NamedParameter("idVolume", idVolume));
        }

        private void GoSettingsPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SettingsPage());
        }
    }
}