using System.Collections.Generic;
using Xamarin.Forms;

namespace SimpleLifeCounter.Views
{
    public partial class CalculationPage : ContentPage
    {
        Label LeftPlyerSubCounter, RightPlyerSubCounter;
        Button LeftPlyerSubCounterUp, LeftPlyerSubCounterDown, RightPlyerSubCounterUp, RightPlyerSubCounterDown;
        BoxView LeftPlayerTateLine, RightPlayerTateLine;


        public CalculationPage()
        {
            InitializeComponent();

            // 上の邪魔なの消すおまじない
            NavigationPage.SetHasNavigationBar(this, false);

            CreateSubCounterElement();
            SetLayout();

            // SettingLayout();

            // DisplayAlert
            //LifeResetButton.Clicked += async (sender, e) =>
            //{
            //    if (vm.LifeResetCheck ? (await DisplayAlert("リセット", "ライフを初期値に戻しますか？", "はい", "いいえ")) : true)
            //    {
            //        vm.setLifePoint();
            //        LeftPlyerSubCounter.Text = 0.ToString();
            //        RightPlyerSubCounter.Text = 0.ToString();
            //    }
            //};
            //// DisplayAlert
            //DiceThrow.Clicked += async (sender, e) =>
            //{
            //    vm.DiceMessegeGenerate();
            //    await DisplayAlert("ダイス", $"{vm.Message}", "OK");
            //};

            //// DisplayAlert
            //CoinToss.Clicked += async (sender, e) =>
            //{
            //    vm.CoinMessegeGenerate();
            //    await DisplayAlert("コイン", $"{vm.Message}", "OK");
            //};
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            // SettingLayout();
        }



        private void CreateSubCounterElement()
        {
            // カウント用ボタン
            LeftPlyerSubCounterUp = new Button { Text = "+" };
            LeftPlyerSubCounterUp.SetBinding(Button.BackgroundColorProperty, "BackgroundColor");
            LeftPlyerSubCounterUp.SetBinding(Button.CommandProperty, "LeftPlyerSubCounterUpCommand");

            LeftPlyerSubCounterDown = new Button { Text = "-" };
            LeftPlyerSubCounterDown.SetBinding(Button.BackgroundColorProperty, "BackgroundColor");
            LeftPlyerSubCounterDown.SetBinding(Button.CommandProperty, "LeftPlyerSubCounterDownCommand");

            RightPlyerSubCounterUp = new Button { Text = "+" };
            RightPlyerSubCounterUp.SetBinding(Button.BackgroundColorProperty, "BackgroundColor");
            RightPlyerSubCounterUp.SetBinding(Button.CommandProperty, "RightPlyerSubCounterUpCommand");

            RightPlyerSubCounterDown = new Button { Text = "-" };
            RightPlyerSubCounterDown.SetBinding(Button.BackgroundColorProperty, "BackgroundColor");
            RightPlyerSubCounterDown.SetBinding(Button.CommandProperty, "RightPlyerSubCounterDownCommand");

            // カウンタ用数字
            LeftPlyerSubCounter = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "0",
                FontSize = 40,
            };
            LeftPlyerSubCounter.SetBinding(Label.TextColorProperty, "LifeFontColor");

            RightPlyerSubCounter = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "0",
                FontSize = 40,
            };
            RightPlyerSubCounter.SetBinding(Label.TextColorProperty, "LifeFontColor");

            // なんか、線
            LeftPlayerTateLine = new BoxView { };
            LeftPlayerTateLine.SetBinding(BoxView.ColorProperty, "LifeFontColor");
            RightPlayerTateLine = new BoxView { };
            RightPlayerTateLine.SetBinding(BoxView.ColorProperty, "LifeFontColor");

            // サブカウンタのコマンド登録
            //LeftPlyerSubCounterUp.Clicked += (sender, e) => LeftPlyerSubCounter.Text = (int.Parse(LeftPlyerSubCounter.Text) + 1).ToString();
        }

        private void SetLayout()
        {
            // ボタンの大きさ
            if (true)
            {
                AbsoluteLayout.SetLayoutBounds(LifeResetButton, new Rectangle(0.5, 1, 0.19, 0.18));
            }
            else
            {
                AbsoluteLayout.SetLayoutBounds(LifeResetButton, new Rectangle(0.5, 1, 0.11, 0.2));
            }

            // エネルギーカウンター
            if (true) //if (vm.SubCounterCounterCheck)
            {
                double SubCounterButtonHorizon;
                SubCounterButtonHorizon = 0.125;

                // 左ボタン設置
                absoluteLayout.Children.Add(LeftPlyerSubCounterUp);
                absoluteLayout.Children.Add(LeftPlyerSubCounterDown);
                AbsoluteLayout.SetLayoutFlags(LeftPlyerSubCounterUp, AbsoluteLayoutFlags.All);
                AbsoluteLayout.SetLayoutFlags(LeftPlyerSubCounterDown, AbsoluteLayoutFlags.All);
                AbsoluteLayout.SetLayoutBounds(LeftPlyerSubCounterUp, new Rectangle(0, 0, SubCounterButtonHorizon, 0.5));
                AbsoluteLayout.SetLayoutBounds(LeftPlyerSubCounterDown, new Rectangle(0, 1, SubCounterButtonHorizon, 0.5));
                // 右ボタン設置
                absoluteLayout.Children.Add(RightPlyerSubCounterUp);
                absoluteLayout.Children.Add(RightPlyerSubCounterDown);
                AbsoluteLayout.SetLayoutFlags(RightPlyerSubCounterUp, AbsoluteLayoutFlags.All);
                AbsoluteLayout.SetLayoutFlags(RightPlyerSubCounterDown, AbsoluteLayoutFlags.All);
                AbsoluteLayout.SetLayoutBounds(RightPlyerSubCounterUp, new Rectangle(1, 0, SubCounterButtonHorizon, 0.5));
                AbsoluteLayout.SetLayoutBounds(RightPlyerSubCounterDown, new Rectangle(1, 1, SubCounterButtonHorizon, 0.5));

                // 両数字設置
                absoluteLayout.Children.Add(LeftPlyerSubCounter);
                absoluteLayout.Children.Add(RightPlyerSubCounter);
                AbsoluteLayout.SetLayoutFlags(LeftPlyerSubCounter, AbsoluteLayoutFlags.All);
                AbsoluteLayout.SetLayoutFlags(RightPlyerSubCounter, AbsoluteLayoutFlags.All);
                AbsoluteLayout.SetLayoutBounds(LeftPlyerSubCounter, new Rectangle(0.005, 0.5, 0.12, 0.4));
                AbsoluteLayout.SetLayoutBounds(RightPlyerSubCounter, new Rectangle(0.995, 0.5, 0.12, 0.4));

                // ライフボタン調整
                AbsoluteLayout.SetLayoutBounds(LeftPlyerLifeUp, new Rectangle(0.195, 0, 0.31, 0.5));
                AbsoluteLayout.SetLayoutBounds(LeftPlyerLifeDown, new Rectangle(0.195, 1, 0.31, 0.5));
                AbsoluteLayout.SetLayoutBounds(RightPlyerLifeUp, new Rectangle(0.805, 0, 0.31, 0.5));
                AbsoluteLayout.SetLayoutBounds(RightPlyerLifeDown, new Rectangle(0.805, 1, 0.31, 0.5));
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

                // 色
                //LeftPlyerSubCounterUp.BackgroundColor = nameToColor[vm.BackgroundColor];
                //LeftPlyerSubCounterDown.BackgroundColor = nameToColor[vm.BackgroundColor];
                //RightPlyerSubCounterUp.BackgroundColor = nameToColor[vm.BackgroundColor];
                //RightPlyerSubCounterDown.BackgroundColor= nameToColor[vm.BackgroundColor];
                //LeftPlyerSubCounter.TextColor = nameToColor[vm.LifeFontColor];
                //RightPlyerSubCounter.TextColor = nameToColor[vm.LifeFontColor];
            }
            else
            {
                // EN関連除去
                absoluteLayout.Children.Remove(LeftPlyerSubCounterUp);
                absoluteLayout.Children.Remove(LeftPlyerSubCounterDown);
                absoluteLayout.Children.Remove(RightPlyerSubCounterUp);
                absoluteLayout.Children.Remove(RightPlyerSubCounterDown);

                absoluteLayout.Children.Remove(LeftPlyerSubCounter);
                absoluteLayout.Children.Remove(RightPlyerSubCounter);

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

                LeftPlyerSubCounter.Text = 0.ToString();
                RightPlyerSubCounter.Text = 0.ToString();
            }

        }







        Dictionary<string, Color> _nameToColor = new Dictionary<string, Color>
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
