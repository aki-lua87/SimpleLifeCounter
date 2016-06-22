using Newtonsoft.Json;
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
        private AllPagesViewModel vm = new AllPagesViewModel();
        Dictionary<string, Color> stringToColor;

        public MenuPage()
        {
            InitializeComponent();
            this.BindingContext = vm;


            // 上の邪魔なの消すおまじない
            NavigationPage.SetHasNavigationBar(this, false);

            // 色と文字列のリストを取得
            stringToColor = vm.getStringToColorList();

            PickerSet();
            JsonRead();

            // SaveButton.Clicked += (sender, e) => SaveClicked(); // Xamlで指定できる

            LifeFontColorPicker.SelectedIndexChanged += (sender, s) => 
            LifeFontColorPicker.BackgroundColor = stringToColor[LifeFontColorPicker.Items[LifeFontColorPicker.SelectedIndex]];

            BackgroundColorPicker.SelectedIndexChanged += (sender, e) =>
            BackgroundColorPicker.BackgroundColor = stringToColor[BackgroundColorPicker.Items[BackgroundColorPicker.SelectedIndex]];

        }

        // セーブ
        private void SaveClicked(object sender, EventArgs e)
        {
            // データバインドできない部分をViewModelに手書き
            vm.LifeFontColor = LifeFontColorPicker.Items[LifeFontColorPicker.SelectedIndex];
            vm.DefaultLifePoint = int.Parse(LifeNum.Items[LifeNum.SelectedIndex]);
            vm.BackgroundColor = BackgroundColorPicker.Items[BackgroundColorPicker.SelectedIndex];

            var json = JsonConvert.SerializeObject(vm);
            DependencyService.Get<ISaveAndLoad>().SaveData("temp.json", json);

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

        // JSON読み出し 
        private void JsonRead()
        { 
            var data = DependencyService.Get<ISaveAndLoad>().LoadData("temp.json");
            this.vm = JsonConvert.DeserializeObject<AllPagesViewModel>(data);
            this.BindingContext = vm;
        }

        // PIG
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}
