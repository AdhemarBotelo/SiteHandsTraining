using Autofac;
using SiteHand.Core.Services;
using SiteHandTraining.Droid.Services;

namespace SiteHandTraining.Droid
{
    class DroidModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FirebaseAuthenticator>().As<IFirebaseAuthenticator>().SingleInstance();
            builder.RegisterType<RemoteConfigService>().As<IRemoteConfig>().SingleInstance();
        }
    }
}