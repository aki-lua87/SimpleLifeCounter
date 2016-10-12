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
        BoxView LeftPlayerTateLine, RightPlayerTateLine;


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
            LeftPlyerEnergyUp = new Button { Text="+", BackgroundColor = nameToColor[vm.BackgroundColor] };
            LeftPlyerEnergyDown = new Button { Text = "-", BackgroundColor = nameToColor[vm.BackgroundColor] };
            RightPlyerEnergyUp = new Button { Text = "+", BackgroundColor = nameToColor[vm.BackgroundColor] };
            RightPlyerEnergyDown = new Button { Text = "-", BackgroundColor = nameToColor[vm.BackgroundColor] };
            LeftPlyerEnergy = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "0",
                FontSize = 40,
                TextColor = nameToColor[vm.LifeFontColor]
            };
            RightPlyerEnergy = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "0",
                FontSize = 40,
                TextColor = nameToColor[vm.LifeFontColor]
            };
            LeftPlayerTateLine = new BoxView { Color = nameToColor[vm.LifeFontColor] };
            RightPlayerTateLine = new BoxView { Color = nameToColor[vm.LifeFontColor] };

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
                double EnergyButtonHorizon;
                EnergyButtonHorizon = 0.125;

                // 左ボタン設置
                absoluteLayout.Children.Add(LeftPlyerEnergyUp);
                absoluteLayout.Children.Add(LeftPlyerEnergyDown);
                AbsoluteLayout.SetLayoutFlags(LeftPlyerEnergyUp, AbsoluteLayoutFlags.All);
                AbsoluteLayout.SetLayoutFlags(LeftPlyerEnergyDown, AbsoluteLayoutFlags.All);
                AbsoluteLayout.SetLayoutBounds(LeftPlyerEnergyUp, new Rectangle(0, 0, EnergyButtonHorizon, 0.5));
                AbsoluteLayout.SetLayoutBounds(LeftPlyerEnergyDown, new Rectangle(0, 1, EnergyButtonHorizon, 0.5));
                // 右ボタン設置
                absoluteLayout.Children.Add(RightPlyerEnergyUp);
                absoluteLayout.Children.Add(RightPlyerEnergyDown);
                AbsoluteLayout.SetLayoutFlags(RightPlyerEnergyUp, AbsoluteLayoutFlags.All);
                AbsoluteLayout.SetLayoutFlags(RightPlyerEnergyDown, AbsoluteLayoutFlags.All);
                AbsoluteLayout.SetLayoutBounds(RightPlyerEnergyUp, new Rectangle(1, 0, EnergyButtonHorizon, 0.5));
                AbsoluteLayout.SetLayoutBounds(RightPlyerEnergyDown, new Rectangle(1, 1, EnergyButtonHorizon, 0.5));

                // 両数字設置
                absoluteLayout.Children.Add(LeftPlyerEnergy);
                absoluteLayout.Children.Add(RightPlyerEnergy);
                AbsoluteLayout.SetLayoutFlags(LeftPlyerEnergy, AbsoluteLayoutFlags.All);
                AbsoluteLayout.SetLayoutFlags(RightPlyerEnergy, AbsoluteLayoutFlags.All);
                AbsoluteLayout.SetLayoutBounds(LeftPlyerEnergy, new Rectangle(0.005, 0.5, 0.12, 0.4));
                AbsoluteLayout.SetLayoutBounds(RightPlyerEnergy, new Rectangle(0.995, 0.5, 0.12, 0.4));

                // ライフボタン調整
                AbsoluteLayout.SetLayoutBounds(LeftPlyerLifeUp, new Rectangle(0.195, 0, 0.31, 0.5));
                AbsoluteLayout.SetLayoutBounds(LeftPlyerLifeDown, new Rectangle(0.195, 1, 0.31, 0.5));
                AbsoluteLayout.SetLayoutBounds(RightPlyerLifeUp, new Rectangle(0.805, 0, 0.31, 0.5));
                AbsoluteLayout.SetLayoutBounds(RightPlyerLifeDown, new Rectangle(0.805 , 1, 0.31, 0.5));
                // ライフ数字調整
                AbsoluteLayout.SetLayoutBounds(LeftPlyerLife, new Rectangle(0.195, 0.5, 0.325, 0.5));
                AbsoluteLayout.SetLayoutBounds(RightPlyerLife, new Rectangle(0.805, 0.5, 0.325, 0.5));

                // 縦棒設置
                absoluteLayout.Children.Add(LeftPlayerTateLine);
                absoluteLayout.Children.Add(RightPlayerTateLine);
                AbsoluteLayout.SetLayoutFlags(LeftPlayerTateLine, AbsoluteLayoutFlags.All);
                AbsoluteLayout.SetLayoutFlags(RightPlayerTateLine, AbsoluteLayoutFlags.All);
                AbsoluteLayout.SetLayoutBounds(LeftPlayerTateLine, new Rectangle(0.13, 0, 0.001, 1));
                AbsoluteLayout.SetLayoutBounds(RightPlayerTateLine, new Rectangle(0.87, 0, 0.001, 1));

            }
            else
            {
                // EN関連除去
                absoluteLayout.Children.Remove(LeftPlyerEnergyUp);
                absoluteLayout.Children.Remove(LeftPlyerEnergyDown);
                absoluteLayout.Children.Remove(RightPlyerEnergyUp);
                absoluteLayout.Children.Remove(RightPlyerEnergyDown);

                absoluteLayout.Children.Remove(LeftPlyerEnergy);
                absoluteLayout.Children.Remove(RightPlyerEnergy);

                absoluteLayout.Children.Remove(LeftPlayerTateLine);
                absoluteLayout.Children.Remove(RightPlayerTateLine);

                // ライフを元に
                double ButtonHorizon = 0.45;
                AbsoluteLayout.SetLayoutBounds(LeftPlyerLifeUp, new Rectangle(0, 0, ButtonHorizon, 0.5));
                AbsoluteLayout.SetLayoutBounds(LeftPlyerLifeDown, new Rectangle(0, 1, ButtonHorizon, 0.5));
                AbsoluteLayout.SetLayoutBounds(RightPlyerLifeUp, new Rectangle(1, 0, ButtonHorizon, 0.5));
                AbsoluteLayout.SetLayoutBounds(RightPlyerLifeDown, new Rectangle(1, 1, ButtonHorizon, 0.5));

                AbsoluteLayout.SetLayoutBounds(LeftPlyerLife, new Rectangle(0.05, 0.5, 0.4, 0.5));
                AbsoluteLayout.SetLayoutBounds(RightPlyerLife, new Rectangle(0.95, 0.5, 0.4, 0.5));

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
