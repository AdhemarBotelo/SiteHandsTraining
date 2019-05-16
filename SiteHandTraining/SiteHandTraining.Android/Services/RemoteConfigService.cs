using System;
using System.Threading.Tasks;
using Firebase.RemoteConfig;
using SiteHand.Core.Services;

namespace SiteHandTraining.Droid.Services
{
    public class RemoteConfigService : IRemoteConfig
    {
        public static FirebaseRemoteConfig firebaseRemoteConfig;

        private void InitRemoteConfig()
        {
            firebaseRemoteConfig = FirebaseRemoteConfig.Instance;
            FirebaseRemoteConfigSettings configSettings = new FirebaseRemoteConfigSettings.Builder()
                .SetDeveloperModeEnabled(true)
                .Build();
            firebaseRemoteConfig.SetConfigSettings(configSettings);
            firebaseRemoteConfig.SetDefaults(Resource.Xml.remote_config_defaults);
        }

        public string GetRemoteDataString(string key)
        {
            try
            {
                InitRemoteConfig();
                firebaseRemoteConfig.Fetch();
                firebaseRemoteConfig.ActivateFetched();
                return firebaseRemoteConfig.GetString(key);
            }
            catch (Exception)
            {
                return Resource.Xml.remote_config_defaults.ToString();
            }
        }
    }
}