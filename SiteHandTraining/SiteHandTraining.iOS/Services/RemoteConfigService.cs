using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using SiteHand.Core.Services;
using UIKit;
using Firebase.RemoteConfig;

namespace SiteHandTraining.iOS.Services
{
    public class RemoteConfigService : IRemoteConfig
    {
        RemoteConfig firebaseRemoteConfig;


        private void InitRemoteConfig()
        {
            firebaseRemoteConfig = RemoteConfig.SharedInstance;
            RemoteConfigSettings configSettings = new RemoteConfigSettings(true);
            firebaseRemoteConfig.ConfigSettings = configSettings;
        }

        public string GetRemoteDataString(string key)
        {
            try
            {
                InitRemoteConfig();
                firebaseRemoteConfig.Fetch(new RemoteConfigFetchCompletionHandler(handler));
                firebaseRemoteConfig.ActivateFetched();
                return firebaseRemoteConfig.GetConfigValue(key).StringValue;
            }
            catch (Exception ex)
            {
                return "all";
            }
            
        }

        public void handler(RemoteConfigFetchStatus status,NSError error) {
            
        }
    }
}