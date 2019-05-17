using System;
using System.Threading.Tasks;
using System.Windows.Input;
using SiteHand.Core.Views;
using Xamarin.Forms;

namespace SiteHand.Core.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public ICommand LogOutCmd { get; }
        public string UserName { get;}

        Action propChangedCallBack => (LogOutCmd as Command).ChangeCanExecute;

        public SettingsViewModel()
        {
            LogOutCmd = new Command(async () =>  await Logout(), () => !IsBusy);
            Title = "Settings";
            try
            {
                UserName = Application.Current.Properties["User"].ToString();
            }
            catch (Exception)
            {
                UserName = "There was a problem getting user Name  contact your Administrator... :(";
            }
            
            
        }

        async Task Logout()
        {
            IsBusy = true;
            propChangedCallBack();

            Application.Current.Properties.Clear();
            (Application.Current as App).MainPage = new NavigationPage(new LoginPage());

            IsBusy = false;
            propChangedCallBack();

        }
    }
}
