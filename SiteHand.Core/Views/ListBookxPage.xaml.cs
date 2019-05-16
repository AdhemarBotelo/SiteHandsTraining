using System;
using Autofac;
using SiteHand.Core.Models;
using SiteHand.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SiteHand.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListBookxPage : ContentPage
    {
        ListBooksViewModel ViewModel;
        Volume VolumeSelected;

        public ListBookxPage()
        {
            InitializeComponent();
            this.BindingContext = ViewModel = (Application.Current as App).Container.Resolve<ListBooksViewModel>();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.ClearModel();
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            VolumeSelected = args.SelectedItem as Volume;
            if (VolumeSelected == null)
                return;

            await Navigation.PushAsync(new DetailBook(VolumeSelected.id));

            BookListView.SelectedItem = null;
        }

        private void GoSettingsPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SettingsPage());
        }
    }
}