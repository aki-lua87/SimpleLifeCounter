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

        Label LeftPlyerEnergy,RightPlyerEnergy;
        Button LeftPlyerEnergyUp, LeftPlyerEnergyDown, RightPlyerEnergyUp, RightPlyerEnergyDown;


        public LifePage()
        {
            InitializeComponent();

            BindingContext = vm;

            // 上の邪魔なの消すおまじない
            NavigationPage.SetHasNavigationBar(this, false);

            // レイアウト設定の適用
            Dictionary<string, Color> stringToColor;
            stringToColor = nameToColor;

            // EN
            LeftPlyerEnergyUp = new Button { BackgroundColor = nameToColor[vm.BackgroundColor] };
            LeftPlyerEnergyDown = new Button { BackgroundColor = nameToColor[vm.BackgroundColor] };
            RightPlyerEnergyUp = new Button { BackgroundColor = nameToColor[vm.BackgroundColor] };
            RightPlyerEnergyDown = new Button { BackgroundColor = nameToColor[vm.BackgroundColor] };
            LeftPlyerEnergy = new Label { Text = "0", FontSize = 40, TextColor = nameToColor[vm.LifeFontColor] };
            RightPlyerEnergy = new Label { Text = "0", FontSize = 40, TextColor = nameToColor[vm.LifeFontColor] };
            // ENイベント登録
            LeftPlyerEnergyUp.Clicked += (sender, e) => LeftPlyerEnergy.Text = (int.Parse(LeftPlyerEnergy.Text) + 1).ToString();
            LeftPlyerEnergyDown.Clicked += (sender, e) => LeftPlyerEnergy.Text = (int.Parse(LeftPlyerEnergy.Text) - 1).ToString();
            RightPlyerEnergyUp.Clicked += (sender, e) => RightPlyerEnergy.Text = (int.Parse(RightPlyerEnergy.Text) + 1).ToString();
            RightPlyerEnergyDown.Clicked += (sender, e) => RightPlyerEnergy.Text = (int.Parse(RightPlyerEnergy.Text) - 1).ToString();

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
                    LeftPlyerEnergy.Text = 0.ToString();
                    RightPlyerEnergy.Text = 0.ToString();
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
            // ボタンの大きさ
            if (vm.BigButtonCheck)
            {
                AbsoluteLayout.SetLayoutBounds(LifeResetButton, new Rectangle(0.5, 1, 0.19, 0.18));
            }
            else
            {
                AbsoluteLayout.SetLayoutBounds(LifeResetButton, new Rectangle(0.5, 1, 0.11, 0.2));
            }

            // エネルギーカウンター
            if (vm.EnergyCounterCheck)
            {
                // 左ボタン
                absoluteLayout.Children.Add(LeftPlyerEnergyUp);
                absoluteLayout.Children.Add(LeftPlyerEnergyDown);
                AbsoluteLayout.SetLayoutFlags(LeftPlyerEnergyUp, AbsoluteLayoutFlags.All);
                AbsoluteLayout.SetLayoutFlags(LeftPlyerEnergyDown, AbsoluteLayoutFlags.All);
                AbsoluteLayout.SetLayoutBounds(LeftPlyerEnergyUp, new Rectangle(0, 0, 0.15, 0.5));
                AbsoluteLayout.SetLayoutBounds(LeftPlyerEnergyDown, new Rectangle(0, 1, 0.15, 0.5));
                // 右ボタン
                absoluteLayout.Children.Add(RightPlyerEnergyUp);
                absoluteLayout.Children.Add(RightPlyerEnergyDown);
                AbsoluteLayout.SetLayoutFlags(RightPlyerEnergyUp, AbsoluteLayoutFlags.All);
                AbsoluteLayout.SetLayoutFlags(RightPlyerEnergyDown, AbsoluteLayoutFlags.All);
                AbsoluteLayout.SetLayoutBounds(RightPlyerEnergyUp, new Rectangle(1, 0, 0.15, 0.5));
                AbsoluteLayout.SetLayoutBounds(RightPlyerEnergyDown, new Rectangle(1, 1, 0.15, 0.5));

                // 両数字
                absoluteLayout.Children.Add(LeftPlyerEnergy);
                absoluteLayout.Children.Add(RightPlyerEnergy);
                AbsoluteLayout.SetLayoutFlags(LeftPlyerEnergy, AbsoluteLayoutFlags.PositionProportional);
                AbsoluteLayout.SetLayoutFlags(RightPlyerEnergy, AbsoluteLayoutFlags.PositionProportional);
                AbsoluteLayout.SetLayoutBounds(LeftPlyerEnergy, new Rectangle(0.05, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
                AbsoluteLayout.SetLayoutBounds(RightPlyerEnergy, new Rectangle(0.95, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

                // ライフボタン調整
                AbsoluteLayout.SetLayoutBounds(LeftPlyerLifeUp, new Rectangle(0.2, 0, 0.3, 0.5));
                AbsoluteLayout.SetLayoutBounds(LeftPlyerLifeDown, new Rectangle(0.2, 1, 0.3, 0.5));
                AbsoluteLayout.SetLayoutBounds(RightPlyerLifeUp, new Rectangle(0.8, 0, 0.3, 0.5));
                AbsoluteLayout.SetLayoutBounds(RightPlyerLifeDown, new Rectangle(0.8 , 1, 0.3, 0.5));

                

            }
            else
            {
                absoluteLayout.Children.Remove(LeftPlyerEnergyUp);
                absoluteLayout.Children.Remove(LeftPlyerEnergyDown);
                absoluteLayout.Children.Remove(RightPlyerEnergyUp);
                absoluteLayout.Children.Remove(RightPlyerEnergyDown);

                absoluteLayout.Children.Remove(LeftPlyerEnergy);
                absoluteLayout.Children.Remove(RightPlyerEnergy);
                AbsoluteLayout.SetLayoutBounds(LeftPlyerLifeUp, new Rectangle(0, 0, 0.5, 0.5));
                AbsoluteLayout.SetLayoutBounds(LeftPlyerLifeDown, new Rectangle(0, 1, 0.5, 0.5));
                AbsoluteLayout.SetLayoutBounds(RightPlyerLifeUp, new Rectangle(1, 0, 0.5, 0.5));
                AbsoluteLayout.SetLayoutBounds(RightPlyerLifeDown, new Rectangle(1, 1, 0.5, 0.5));

                LeftPlyerEnergy.Text = 0.ToString();
                RightPlyerEnergy.Text = 0.ToString();
            }


        }
        Dictionary<string, Color> nameToColor = new Dictionary<string, Color>
        {
            { "Aqua", Color.Aqua }, { "Black", Color.Black },
            { "Blue", Color.Blue },
            { "Gray", Color.Gray }, { "Green", Color.Green },
            { "Lime", Color.Lime }, { "Maroon", Color.Maroon },
            { "Navy", Color.Navy }, { "Olive", Color.Olive },
            { "Purple", Color.Purple }, { "Red", Color.Red },
            { "Silver", Color.Silver }, { "Teal", Color.Teal },
            { "White", Color.White }, { "Yellow", Color.Yellow }
        };
    }
}
