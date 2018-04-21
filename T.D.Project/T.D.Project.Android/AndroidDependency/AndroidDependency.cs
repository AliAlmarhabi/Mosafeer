using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using T.D.Project.dependency;
using Xamarin.Forms;
using T.D.Project.Droid.AndroidDependency;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidDependency))]
namespace T.D.Project.Droid.AndroidDependency
{
    public class AndroidDependency : IDialingCall , IShareApp
    {
        public void call(string number)
        {
            var uri = Android.Net.Uri.Parse("tel:" + number);
            var intent = new Intent(Intent.ActionCall, uri);
            Forms.Context.StartActivity(intent);
        }

        public void share()
        {
            var intent = new Intent(Android.Content.Intent.ActionSend);
            intent.SetType("text/plain");
            intent.PutExtra(Intent.ExtraText, "share driver app");
            Forms.Context.StartActivity(Intent.CreateChooser(intent, "اختر التطبيق"));

        }
    }
}