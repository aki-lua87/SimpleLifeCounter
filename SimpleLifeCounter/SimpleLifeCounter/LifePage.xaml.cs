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
        private AllPageModel model = new AllPageModel();

        public LifePage()
        {
            InitializeComponent();
            BindingContext = model.getVm();

            // 上の邪魔なの消すおまじない
            NavigationPage.SetHasNavigationBar(this, false);

            // LifeSet
            LeftPlyerLife.Text = model.getStringDefaultLife();
            RightPlyerLife.Text = model.getStringDefaultLife();

            LeftPlyerLifeUp.Clicked += (sender, e) => LeftPlyerLife.Text = model.LifeUp(LeftPlyerLife);
            LeftPlyerLifeDown.Clicked += (sender, e) => LeftPlyerLife.Text = model.LifeDown(LeftPlyerLife);
            RightPlyerLifeUp.Clicked += (sender, e) => RightPlyerLife.Text = model.LifeUp(RightPlyerLife);
            RightPlyerLifeDown.Clicked += (sender, e) => RightPlyerLife.Text = model.LifeDown(RightPlyerLife);

            toMenuPageButton.Clicked += async(sender,e) => await Navigation.PushAsync(new MenuPage());
            LifeResetButton.Clicked += async (sender, e) =>
            {
                if (model.getResetCheck() ? (await DisplayAlert("リセット", "ライフを初期値に戻しますか？", "はい", "いいえ")) : true)
                {
                    LeftPlyerLife.Text = model.getStringDefaultLife();
                    RightPlyerLife.Text = model.getStringDefaultLife();
                }
            };

            DiceThrow.Clicked += async (sender, e) => await DisplayAlert("ダイス", model.Random20().ToString(), "OK");

            CoinToss.Clicked += async (sender, e) => await DisplayAlert("コイン", model.RandomBoolean() ? "おもて" : "うら", "OK");




        }

        // CIP
        protected override void OnAppearing()
        {
            base.OnAppearing();
            model.JsonRead();
            BindingContext = model.getVm();
        }

    }
}
