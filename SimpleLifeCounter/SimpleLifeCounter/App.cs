using Prism.Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SimpleLifeCounter.Views;
using Microsoft.Practices.Unity;

namespace SimpleLifeCounter
{
    public class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            NavigationService.NavigateAsync("/NavigationPage/CalculationPage");
            // NavigationService.NavigateAsync("/NavigationPage/MenuPage");

        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            
            Container.RegisterTypeForNavigation<MenuPage>();
            Container.RegisterTypeForNavigation<LifePage>();
            Container.RegisterTypeForNavigation<CalculationPage>();
        }
    }
}
