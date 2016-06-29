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
        // private AllPageModel model = new AllPageModel();
        private AllPagesViewModel vm = new AllPagesViewModel();

        public LifePage()
        {
            InitializeComponent();
            BindingContext = vm;

            // 上の邪魔なの消すおまじない
            NavigationPage.SetHasNavigationBar(this, false);

            // LifeSet
            LeftPlyerLife.Text = vm.DefaultLifePoint.ToString();
            RightPlyerLife.Text = vm.DefaultLifePoint.ToString();

            LeftPlyerLifeUp.Clicked += (sender, e) => LeftPlyerLife.Text = intToStr(CountUp(LeftPlyerLife.Text));
            LeftPlyerLifeDown.Clicked += (sender, e) => LeftPlyerLife.Text = intToStr(CountDown(LeftPlyerLife.Text));
            RightPlyerLifeUp.Clicked += (sender, e) => RightPlyerLife.Text = intToStr(CountUp(RightPlyerLife.Text));
            RightPlyerLifeDown.Clicked += (sender, e) => RightPlyerLife.Text = intToStr(CountDown(RightPlyerLife.Text));

            toMenuPageButton.Clicked += async(sender,e) => await Navigation.PushAsync(new MenuPage());
            LifeResetButton.Clicked += async (sender, e) =>
            {
                if (vm.LifeResetCheck ? (await DisplayAlert("リセット", "ライフを初期値に戻しますか？", "はい", "いいえ")) : true)
                {
                    LeftPlyerLife.Text = vm.DefaultLifePoint.ToString();
                    RightPlyerLife.Text = vm.DefaultLifePoint.ToString();
                }
            };

            DiceThrow.Clicked += async (sender, e) => await DisplayAlert("ダイス", Random20().ToString(), "OK");
            CoinToss.Clicked += async (sender, e) => await DisplayAlert("コイン", RandomBoolean() ? "おもて" : "うら", "OK");
        }

        // CIP
        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.JsonRead();
            BindingContext = vm;

            // もしデフォルトライフとVMの値が違うならデフォルトライフに代入して適用とかにする
            LeftPlyerLife.Text = vm.DefaultLifePoint.ToString();
            RightPlyerLife.Text = vm.DefaultLifePoint.ToString();
        }

        public Boolean RandomBoolean()
        {
            Random rnd = new Random();
            return rnd.Next(0, 100) < 50;
        }
        public int Random20()
        {
            Random rnd = new Random();
            return rnd.Next(1, 21);
        }
        public int CountUp(string count)
        {
            return strToInt(count) + 1;
        }
        public int CountDown(string count)
        {
            return strToInt(count) - 1;
        }
        public int strToInt(string str)
        {
            return int.Parse(str);
        }
        public string intToStr(int i)
        {
            return i.ToString();
        }

    }
}
