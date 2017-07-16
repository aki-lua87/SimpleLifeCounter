using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleLifeCounter.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleLifeCounter
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DicePage : ContentPage
	{
        private DicePageViewModel vm { get; } = new DicePageViewModel();

        public DicePage ()
		{
			InitializeComponent ();

            NavigationPage.SetHasNavigationBar(this, false);

            BindingContext = vm;
            vm.DiceRoll();

            ExitButton.Clicked += (sender, e) =>
            {
                Navigation.PopAsync();
            };
        }
	}
}