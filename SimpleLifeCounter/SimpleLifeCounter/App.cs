using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prism;
using Prism.Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SimpleLifeCounter
{
    public class App : PrismApplication
    {
        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<LifePage>();
            Container.RegisterTypeForNavigation<MenuPage>();
        }

        protected override void OnInitialized()
        {
            NavigationService.NavigateAsync("NavigationPage/LifePage");
        }

    }
}
