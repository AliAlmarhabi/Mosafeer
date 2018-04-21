using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using T.D.Project.Droid.androidRenders;
using T.D.Project.View.CustomRenders;
using XLabs.Forms.Controls;
using Android.Widget;
using Android.Graphics.Drawables;
using Android.Graphics;

[assembly: ExportRenderer(typeof(ControlsRenders), typeof(androidPickerRender))]
namespace T.D.Project.Droid.androidRenders
{
    public class androidPickerRender : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {

            base.OnElementChanged(e);
            if (e.OldElement != null)
            {
                Control.Gravity = Android.Views.GravityFlags.Right;
            }
    }
    }
}