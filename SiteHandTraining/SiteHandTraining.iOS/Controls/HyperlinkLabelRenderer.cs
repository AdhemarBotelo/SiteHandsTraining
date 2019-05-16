
using Foundation;
using SiteHand.Core.Controls;
using SiteHandTraining.iOS.Controls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(HyperlinkLabel), typeof(HyperlinkLabelRenderer))]
namespace SiteHandTraining.iOS.Controls
{
    public class HyperlinkLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            Control.UserInteractionEnabled = true;

            Control.TextColor = UIColor.Blue;

            var gesture = new UITapGestureRecognizer();

            gesture.AddTarget(() =>
            {
                var url = new NSUrl(Control.Text);

                if (UIApplication.SharedApplication.CanOpenUrl(url))
                    UIApplication.SharedApplication.OpenUrl(url);
            });

            Control.AddGestureRecognizer(gesture);
        }
    }
}