using System;
using System.Threading.Tasks;
using System.Windows.Input;
using SiteHand.Core.Services;
using SiteHand.Core.Validations;
using SiteHand.Core.Views;
using Xamarin.Forms;

namespace SiteHand.Core.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public ValidatableObject<string> Email { get; set; }
        public ValidatableObject<string> Password { get; set; }
        public string ErrorAuthentication { get; set; }
        public bool IsErrorAuthentication { get; set; }
        public ICommand LoginCmd { get; }

        readonly IFirebaseAuthenticator FirebaseAuthenticator;
        Action PropChangedCallBack => (LoginCmd as Command).ChangeCanExecute;

        public LoginViewModel(IFirebaseAuthenticator firebaseAuthenticator)
        {
            this.FirebaseAuthenticator = firebaseAuthenticator;
            LoginCmd = new Command(async () => await Login(), () => Email.IsValid && Password.IsValid && !IsBusy);

            Email = new ValidatableObject<string>(PropChangedCallBack, new EmailValidator()) { Value = "test@jalasoft.com" };
            Password = new ValidatableObject<string>(PropChangedCallBack, new PasswordValidator()) { Value = "123qwe" };
        }

        async Task Login()
        {
            IsBusy = true;           
            IsErrorAuthentication = false;
            ErrorAuthentication = string.Empty;
            PropChangedCallBack();

            try
            {
                string AuthToken = await this.FirebaseAuthenticator.LoginWithEmailPasswordAsync(Email.Value, Password.Value);
                if (!string.IsNullOrEmpty(AuthToken))
                {
                    Application.Current.Properties["User"] = Email.Value;
                    (Application.Current as App).MainPage = new NavigationPage(new ListBookxPage());
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                IsErrorAuthentication = true;
                ErrorAuthentication = "Invalid Credentials" ;
            }
            finally
            {
                IsBusy = false;
                PropChangedCallBack();
            }

        }
    }
}
