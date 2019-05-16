using System;
using System.Collections.Generic;
using System.Text;

namespace SiteHand.Core.Services
{
    public interface IRemoteConfig
    {
        string GetRemoteDataString(string key);
    }
}
