using Autofac;
using SiteHand.Core.Services;
using SiteHandTraining.iOS.Services;

namespace SiteHandTraining.iOS
{
    public class IOSModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FirebaseAuthenticator>().As<IFirebaseAuthenticator>().SingleInstance();
            builder.RegisterType<RemoteConfigService>().As<IRemoteConfig>().SingleInstance();
        }
    }
}