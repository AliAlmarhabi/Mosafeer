using Foundation;
using System;
using System.Collections.Generic;
using System.Text;
using T.D.Project.dependency;
using T.D.Project.iOS.iOSDependency;
using UIKit;


[assembly: Xamarin.Forms.Dependency(typeof(iOSDependency))]
namespace T.D.Project.iOS.iOSDependency
{
    public class iOSDependency : IDialingCall , IShareApp
    {
        public void call(string number)
        {
            var uri = new NSUrl("tel:" + number);
            UIApplication.SharedApplication.OpenUrl(uri);
        }

        public void share()
        {
            var text = NSObject.FromObject("shareing driver app");
            var image = NSObject.FromObject("image");
            var item = new[] { text, image };
            var activity = new UIActivityViewController(item, null);
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(activity, true, null);
        }
    }
}
