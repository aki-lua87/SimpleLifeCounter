using Microsoft.Practices.Unity;
using Prism.Unity;

namespace SimpleLifeCounter.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            // LoadApplication(new SimpleLifeCounter.App());
            LoadApplication(new SimpleLifeCounter.App(new UwpInitializer()));
        }
    }
    public class UwpInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ISaveAndLoad, SaveAndLoad_UWP>(new ContainerControlledLifetimeManager());
        }
    }

}
