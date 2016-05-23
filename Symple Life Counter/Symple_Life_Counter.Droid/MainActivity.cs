using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Symple_Life_Counter.Droid
{
    [Activity(Label = "Symple_Life_Counter", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // 横画面に固定
            this.RequestedOrientation = ScreenOrientation.Landscape;

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
            
        }
    }
}

