using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Prism.Unity;
using Microsoft.Practices.Unity;

namespace SimpleLifeCounter.Droid
{
    [Activity(Label = "ライフカウンターくん for MTG", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // 横画面に固定
            this.RequestedOrientation = ScreenOrientation.SensorLandscape;

            // スリープモードにしない制御
            this.Window.SetFlags(WindowManagerFlags.KeepScreenOn, WindowManagerFlags.KeepScreenOn);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            //LoadApplication(new App());
            LoadApplication(new App(new AndroidInitializer()));
        }
    }
    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IUnityContainer container)
        {

        }
    }
}

