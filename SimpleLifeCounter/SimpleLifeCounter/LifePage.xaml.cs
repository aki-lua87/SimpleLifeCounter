using Newtonsoft.Json;
using SimpleLifeCounter.ViewModels;
using SimpleLifeCounter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SimpleLifeCounter
{
    public partial class LifePage : ContentPage
    {
        private LifePageViewModel vm { get; } = new LifePageViewModel();

        public LifePage()
        {
            InitializeComponent();

            BindingContext = vm;

            // 上の邪魔なの消すおまじない
            NavigationPage.SetHasNavigationBar(this, false);

            // ResetButtonの大きさ
            SettingLayout();

            // 画面遷移
            toMenuPageButton.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new MenuPage());
            };

            // DisplayAlert
            LifeResetButton.Clicked += async (sender, e) =>
            {
                if (vm.LifeResetCheck ? (await DisplayAlert("リセット", "ライフを初期値に戻しますか？", "はい", "いいえ")) : true)
                {
                    vm.setLifePoint();
                }
            };
            // DisplayAlert
            DiceThrow.Clicked += async (sender, e) =>
            {
                vm.DiceMessegeGenerate();
                await DisplayAlert("ダイス", $"{vm.Message}", "OK");
            };

            // DisplayAlert
            CoinToss.Clicked += async (sender, e) =>
            {
                vm.CoinMessegeGenerate();
                await DisplayAlert("コイン", $"{vm.Message}", "OK");
            };
        }

        // CIP
        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm.Load();
            BindingContext = vm;

            SettingLayout();
        }

        private void SettingLayout()
        {
            if (vm.BigButtonCheck)
            {
                AbsoluteLayout.SetLayoutBounds(LifeResetButton, new Rectangle(0.5, 1, 0.19, 0.18));
            }
            else
            {
                AbsoluteLayout.SetLayoutBounds(LifeResetButton, new Rectangle(0.5, 1, 0.11, 0.2));
            }
        }


    }
}
