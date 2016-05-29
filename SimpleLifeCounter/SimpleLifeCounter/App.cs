using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SimpleLifeCounter
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            // NavigationPage.SetHasNavigationBar(this, false);
            MainPage = new NavigationPage(new LifePage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

    }
}
