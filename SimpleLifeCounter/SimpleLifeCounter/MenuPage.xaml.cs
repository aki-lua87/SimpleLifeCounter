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
        private AllPageModel model = new AllPageModel();
        Dictionary<string, Color> stringToColor;

        public MenuPage()
        {
            InitializeComponent();

            // 上の邪魔なの消すおまじない
            NavigationPage.SetHasNavigationBar(this, false);

            // 色と文字列のリストを取得
            stringToColor = model.getVm().getStringToColorList();
            PickerSet();
            
            // SaveButton.Clicked += (sender, e) => SaveClicked(); // Xamlで指定できるけどどっちがいいかな

            LifeFontColorPicker.SelectedIndexChanged += (sender, s) => 
            LifeFontColorPicker.BackgroundColor = stringToColor[LifeFontColorPicker.Items[LifeFontColorPicker.SelectedIndex]];

            BackgroundColorPicker.SelectedIndexChanged += (sender, e) =>
            BackgroundColorPicker.BackgroundColor = stringToColor[BackgroundColorPicker.Items[BackgroundColorPicker.SelectedIndex]];

            model.JsonRead();
            this.BindingContext = model.getVm();
        }

        // セーブ
        private void SaveClicked(object sender, EventArgs e)
        {
            // データバインドできない部分をViewModelに手書き
            model.DoNotBindingSetVM(
                LifeNum.Items[LifeNum.SelectedIndex]
                , LifeFontColorPicker.Items[LifeFontColorPicker.SelectedIndex]
                , BackgroundColorPicker.Items[BackgroundColorPicker.SelectedIndex]);
            model.JsonWrite();
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
