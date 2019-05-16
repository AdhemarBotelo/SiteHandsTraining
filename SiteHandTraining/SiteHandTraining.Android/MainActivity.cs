
using Android.App;
using Android.Util;
using Android.Content.PM;
using Android.Gms.Common;
using Android.OS;
using Android.Widget;
using Firebase;
using Firebase.Messaging;
using Firebase.Iid;
using SiteHand.Core;

namespace SiteHandTraining.Droid
{
    [Activity(Label = "SiteHandTraining", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        static readonly string TAG = "MainActivity";
        internal static readonly string CHANNEL_ID = "sitehand_channel";
        internal static readonly int NOTIFICATION_ID = 100;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            FirebaseApp.InitializeApp(Application.Context);
            LoadApplication(new App(new DroidModule()));

            CheckForGoogleServices();
            CreateNotificationChannel();
            FirebaseMessaging.Instance.SubscribeToTopic("bookapp");
            //FirebaseMessaging.Instance.UnsubscribeFromTopic("books");
            // to do expose a service to subscribe and unsubscribe push notification y share code
        }


        /// <summary>
        // Check if the Google Play Services is available to recieve Push Notification from Firebase
        /// </summary>
        /// <returns></returns>
        public bool CheckForGoogleServices()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                {
                    Toast.MakeText(this, GoogleApiAvailability.Instance.GetErrorString(resultCode), ToastLength.Long);
                }
                else
                {
                    Toast.MakeText(this, "This device does not support Google Play Services", ToastLength.Long);
                }
                return false;
            }
            else {
                Toast.MakeText(this, "This device support Google Play Services", ToastLength.Long);
            }
            return true;
        }

        void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                // Notification channels are new in API 26 (and not a part of the
                // support library). There is no need to create a notification 
                // channel on older versions of Android.
                return;
            }

            var channel = new NotificationChannel(CHANNEL_ID, "FCM Notifications", NotificationImportance.Max)
            {
                Description = "Firebase Cloud Messages appear in this channel"
            };

            var notificationManager = (NotificationManager)GetSystemService(NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }


    }
}