using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SimpleLifeCounter.Views
{

    public partial class MenuPage : ContentPage
    {
        //private MenuPageViewModel vm { get; } = new MenuPageViewModel();
        Dictionary<string, Color> stringToColor;

        private Button testButton;

        public MenuPage()
        {
            InitializeComponent();

            testButton = new Button{Text = "TestButton"};
            testButton.SetBinding(Button.CommandProperty,"testCommand");
            stackLayout.Children.Add(testButton);

            // 上の邪魔なの消すおまじない
            //NavigationPage.SetHasNavigationBar(this, false);

            // 色と文字列のリストを取得
            stringToColor = nameToColor;

            // Pickerに値をセット
            PickerSet();

            //Commandできない部分を
            LifeFontColorPicker.SelectedIndexChanged += (sender, s) =>
            {
                //vm.ConfirmationLifeFontColor = stringToColor[LifeFontColorPicker.Items[LifeFontColorPicker.SelectedIndex]];
            };

            BackgroundColorPicker.SelectedIndexChanged += (sender, e) =>
            {
                //vm.ConfirmationBackgroundColor = stringToColor[BackgroundColorPicker.Items[BackgroundColorPicker.SelectedIndex]];
            };

            // バインド設定
            // this.BindingContext = vm;
        }

        // セーブ
        private void SaveClicked(object sender, EventArgs e)
        {
            // データバインドできない部分を手書き
            //vm.SaveClicked
            //    (
            //    LifeNum.Items[LifeNum.SelectedIndex],
            //    LifeFontColorPicker.Items[LifeFontColorPicker.SelectedIndex],
            //    BackgroundColorPicker.Items[BackgroundColorPicker.SelectedIndex]
            //    );
            Navigation.PopAsync();
        }

        // ピッカーに値をセット
        private void PickerSet()
        {
            // Pickerに要素を追加
            int Num = 10; //LifePoint
            foreach (string colorName in stringToColor.Keys)
            {
                LifeFontColorPicker.Items.Add(colorName);
                BackgroundColorPicker.Items.Add(colorName);
                LifeNum.Items.Add(Num.ToString()); //ついでにライフもPickerに追加
                Num += 10; 
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

        // PIG
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}
