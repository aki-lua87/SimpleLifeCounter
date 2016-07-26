using Newtonsoft.Json;
using SimpleLifeCounter.ViewModels;
using SimpleLifeCounter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

//using Microsoft.Practices.Prism.Mvvm;

namespace SimpleLifeCounter
{
    public partial class LifePage : ContentPage//, IView
    {
        int DefaultLifePoint;
        private LifePageViewModel vm { get; } = new LifePageViewModel();

        public LifePage()
        {
            InitializeComponent();
            
            BindingContext = vm;

            // 上の邪魔なの消すおまじない
            NavigationPage.SetHasNavigationBar(this, false);

            // LifeSet
            DefaultLifePoint = vm.DefaultLifePoint;
            setDefaltLifePoint();

            LeftPlyerLifeUp.Clicked += (sender, e) => LeftPlyerLife.Text = LifeUp(LeftPlyerLife);
            LeftPlyerLifeDown.Clicked += (sender, e) => LeftPlyerLife.Text = LifeDown(LeftPlyerLife);
            RightPlyerLifeUp.Clicked += (sender, e) => RightPlyerLife.Text = LifeUp(RightPlyerLife);
            RightPlyerLifeDown.Clicked += (sender, e) => RightPlyerLife.Text = LifeDown(RightPlyerLife);

            toMenuPageButton.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new MenuPage());
            };
            LifeResetButton.Clicked += async (sender, e) =>
            {
                if (vm.LifeResetCheck ? (await DisplayAlert("リセット", "ライフを初期値に戻しますか？", "はい", "いいえ")) : true)
                {
                    setDefaltLifePoint();
                }
            };
            DiceThrow.Clicked += async (sender, e) =>
            {
                vm.DiceMessegeGenerate();
                await DisplayAlert("ダイス", $"{vm.Message}", "OK");
            };

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

            vm.tempBoolReset(); // なんだよこれ・・・・・
            vm.Load();

            BindingContext = vm;

            // もしデフォルトライフとVMの値が違うならデフォルトライフに代入して適用とかにする
            if(DefaultLifePoint != vm.DefaultLifePoint)
            {
                DefaultLifePoint = vm.DefaultLifePoint;
                setDefaltLifePoint();
            }
        }

        // とりあえず動かすためにここに置く
        private string LifeUp(Label l)
        {
            return (int.Parse(l.Text) + 1).ToString();
        }
        private string LifeDown(Label l)
        {
            return (int.Parse(l.Text) - 1).ToString();
        }
        private void setDefaltLifePoint()
        {
            LeftPlyerLife.Text = DefaultLifePoint.ToString();
            RightPlyerLife.Text = DefaultLifePoint.ToString();
        }

    }
}
