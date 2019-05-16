using System.Threading.Tasks;
using Firebase.Auth;
using SiteHand.Core.Services;

namespace SiteHandTraining.iOS.Services
{
    public class FirebaseAuthenticator : IFirebaseAuthenticator
    {
        public async Task<string> LoginWithEmailPasswordAsync(string email, string password)
        {
            try
            {
                var user = await Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
                return await user.User.GetIdTokenAsync();
            }
            catch (System.Exception)
            {
                return "12341234asdfja;lsdjfasdf";
            }

        }
    }
}