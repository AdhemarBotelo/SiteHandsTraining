using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SiteHand.Core.Services
{
    public interface IFirebaseAuthenticator
    {
        Task<string> LoginWithEmailPasswordAsync(string email, string password);
    }
}
