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
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SetLayout();
        }


        private void CreateSubCounterElement()
        {
            // カウント用ボタン
            LeftPlyerSubCounterUp = new Button { Text = "+" };
            LeftPlyerSubCounterUp.SetBinding(Button.BackgroundColorProperty, "BackgroundColor");
            LeftPlyerSubCounterUp.SetBinding(Button.CommandProperty, "SubLeftUpCommand");

            LeftPlyerSubCounterDown = new Button { Text = "-" };
            LeftPlyerSubCounterDown.SetBinding(Button.BackgroundColorProperty, "BackgroundColor");
            LeftPlyerSubCounterDown.SetBinding(Button.CommandProperty, "SubLeftDownCommand");

            RightPlyerSubCounterUp = new Button { Text = "+" };
            RightPlyerSubCounterUp.SetBinding(Button.BackgroundColorProperty, "BackgroundColor");
            RightPlyerSubCounterUp.SetBinding(Button.CommandProperty, "SubRightUpCommand");

            RightPlyerSubCounterDown = new Button { Text = "-" };
            RightPlyerSubCounterDown.SetBinding(Button.BackgroundColorProperty, "BackgroundColor");
            RightPlyerSubCounterDown.SetBinding(Button.CommandProperty, "SubRightDownCommand");

            // カウンタ用数字
            LeftPlyerSubCounter = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = 40,
            };
            LeftPlyerSubCounter.SetBinding(Label.TextColorProperty, "LifeFontColor");

            RightPlyerSubCounter = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = 40,
            };
            RightPlyerSubCounter.SetBinding(Label.TextColorProperty, "LifeFontColor");

            // なんか、線
            LeftPlayerTateLine = new BoxView { };
            LeftPlayerTateLine.SetBinding(BoxView.ColorProperty, "LifeFontColor");
            RightPlayerTateLine = new BoxView { };
            RightPlayerTateLine.SetBinding(BoxView.ColorProperty, "LifeFontColor");
        }

        private void SetLayout()
        {
            // Viewに一瞬だけVMとデータバインドしたスイッチを配置して真理値を読み取ってそのあと即Removeする感じに
            var tempSubCount = new Switch();
            tempSubCount.SetBinding(Switch.IsToggledProperty, "SubCounterCheck");
            absoluteLayout.Children.Add(tempSubCount);

            var tempReset = new Switch();
            tempReset.SetBinding(Switch.IsToggledProperty, "BigButtonCheck");
            absoluteLayout.Children.Add(tempReset);

            // ボタンの大きさ
            AbsoluteLayout.SetLayoutBounds(LifeResetButton, tempReset.IsToggled ? new Rectangle(0.5, 1, 0.19, 0.18) : new Rectangle(0.5, 1, 0.11, 0.2));

            // エネルギーカウンター
            if (tempSubCount.IsToggled) //if ()
            {
                double subCounterButtonHorizon;
                subCounterButtonHorizon = 0.125;

                // 左ボタン設置
                absoluteLayout.Children.Add(LeftPlyerSubCounterUp);
                absoluteLayout.Children.Add(LeftPlyerSubCounterDown);
                AbsoluteLayout.SetLayoutFlags(LeftPlyerSubCounterUp, AbsoluteLayoutFlags.All);
                AbsoluteLayout.SetLayoutFlags(LeftPlyerSubCounterDown, AbsoluteLayoutFlags.All);
                AbsoluteLayout.SetLayoutBounds(LeftPlyerSubCounterUp, new Rectangle(0, 0, subCounterButtonHorizon, 0.5));
                AbsoluteLayout.SetLayoutBounds(LeftPlyerSubCounterDown, new Rectangle(0, 1, subCounterButtonHorizon, 0.5));
                // 右ボタン設置
                absoluteLayout.Children.Add(RightPlyerSubCounterUp);
                absoluteLayout.Children.Add(RightPlyerSubCounterDown);
                AbsoluteLayout.SetLayoutFlags(RightPlyerSubCounterUp, AbsoluteLayoutFlags.All);
                AbsoluteLayout.SetLayoutFlags(RightPlyerSubCounterDown, AbsoluteLayoutFlags.All);
                AbsoluteLayout.SetLayoutBounds(RightPlyerSubCounterUp, new Rectangle(1, 0, subCounterButtonHorizon, 0.5));
                AbsoluteLayout.SetLayoutBounds(RightPlyerSubCounterDown, new Rectangle(1, 1, subCounterButtonHorizon, 0.5));

                // 両数字設置
                absoluteLayout.Children.Add(LeftPlyerSubCounter);
                absoluteLayout.Children.Add(RightPlyerSubCounter);
                AbsoluteLayout.SetLayoutFlags(LeftPlyerSubCounter, AbsoluteLayoutFlags.All);
                AbsoluteLayout.SetLayoutFlags(RightPlyerSubCounter, AbsoluteLayoutFlags.All);
                AbsoluteLayout.SetLayoutBounds(LeftPlyerSubCounter, new Rectangle(0.005, 0.5, 0.12, 0.4));
                AbsoluteLayout.SetLayoutBounds(RightPlyerSubCounter, new Rectangle(0.995, 0.5, 0.12, 0.4));
                LeftPlyerSubCounter.SetBinding(Label.TextProperty, "LeftSubCounter");
                RightPlyerSubCounter.SetBinding(Label.TextProperty, "SubRightCounter");

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
            absoluteLayout.Children.Remove(tempSubCount);
            absoluteLayout.Children.Remove(tempReset);

        }
    }

    
}
