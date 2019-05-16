using Android.Content;
using Android.Text.Util;
using SiteHand.Core.Controls;
using SiteHandTraining.Droid.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(HyperlinkLabel), typeof(HyperlinkLabelRenderer))]
namespace SiteHandTraining.Droid.Controls
{
    public class HyperlinkLabelRenderer : LabelRenderer
    {
        Context mContext;
        public HyperlinkLabelRenderer(Context context) : base(context)
        {
            this.mContext = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            
            Control.AutoLinkMask= MatchOptions.WebUrls;
            Control.SetTextColor(Android.Graphics.Color.Blue);
            Linkify.AddLinks(Control, MatchOptions.WebUrls);
        }
    }
}