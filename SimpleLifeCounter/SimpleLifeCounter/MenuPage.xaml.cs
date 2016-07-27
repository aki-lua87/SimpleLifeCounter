using Newtonsoft.Json;
using SimpleLifeCounter.Models;
using SimpleLifeCounter.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SimpleLifeCounter
{

    public partial class MenuPage : ContentPage
    {
        private MenuPageViewModel vm { get; } = new MenuPageViewModel();
        Dictionary<string, Color> stringToColor;

        public MenuPage()
        {
            InitializeComponent();

            // 上の邪魔なの消すおまじない
            NavigationPage.SetHasNavigationBar(this, false);

            // 色と文字列のリストを取得
            stringToColor = vm.getStringToColorList();

            // Pickerに値をセット
            PickerSet();

            //Commandできない部分を
            LifeFontColorPicker.SelectedIndexChanged += (sender, s) =>
            {
                vm.ConfirmationLifeFontColor = stringToColor[LifeFontColorPicker.Items[LifeFontColorPicker.SelectedIndex]];
            };

            BackgroundColorPicker.SelectedIndexChanged += (sender, e) =>
            {
                vm.ConfirmationBackgroundColor = stringToColor[BackgroundColorPicker.Items[BackgroundColorPicker.SelectedIndex]];
            };

            // バインド設定
            this.BindingContext = vm;
        }

        // セーブ
        private void SaveClicked(object sender, EventArgs e)
        {
            // データバインドできない部分を手書き
            vm.SaveClicked
                (
                LifeNum.Items[LifeNum.SelectedIndex],
                LifeFontColorPicker.Items[LifeFontColorPicker.SelectedIndex],
                BackgroundColorPicker.Items[BackgroundColorPicker.SelectedIndex]
                );
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

        // PIG
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}
