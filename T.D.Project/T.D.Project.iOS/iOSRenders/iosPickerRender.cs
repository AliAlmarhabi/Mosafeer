using System;
using System.Collections.Generic;
using System.Text;
using T.D.Project.iOS.iOSRenders;
using T.D.Project.View.CustomRenders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ControlsRenders),typeof(iosPickerRender))]
namespace T.D.Project.iOS.iOSRenders
{
   public class iosPickerRender : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement  == null)
            {
                Control.TextAlignment = UIKit.UITextAlignment.Right;
            }
        }
    }
}
