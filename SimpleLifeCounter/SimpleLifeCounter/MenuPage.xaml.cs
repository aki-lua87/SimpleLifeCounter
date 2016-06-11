using Newtonsoft.Json;
using SimpleLifeCounter.ViewModels;
using System;
using System.Collections.Generic;
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
            this.BindingContext = vm; //バインドができない切れそう

            // 上の邪魔なの消すおまじない
            NavigationPage.SetHasNavigationBar(this, false);

            // 色と文字列のリスト
            stringToColor = vm.getStringToColorList();

            DataSet();
            DataDraw();

            SaveButton.Clicked += (sender, e) => SaveClicked();

            LifeFontColorPicker.SelectedIndexChanged += (sender, s) => 
            LifeFontColorPicker.BackgroundColor = stringToColor[LifeFontColorPicker.Items[LifeFontColorPicker.SelectedIndex]];

            BackgroundColorPicker.SelectedIndexChanged += (sender, e) =>
            BackgroundColorPicker.BackgroundColor = stringToColor[BackgroundColorPicker.Items[BackgroundColorPicker.SelectedIndex]];
        }

        // セーブ
        private void SaveClicked()
        {
            // ベタ書き(´・ω・｀) バインドできるんですよね……
            vm.Life = LifeNum.SelectedIndex;
            vm.Lifecolor = LifeFontColorPicker.SelectedIndex;
            vm.Backcolor = BackgroundColorPicker.SelectedIndex;

            vm.Life_Color = LifeFontColorPicker.Items[LifeFontColorPicker.SelectedIndex];
            vm.Life_point = int.Parse(LifeNum.Items[LifeNum.SelectedIndex]);
            vm.LifeFont_Color = BackgroundColorPicker.Items[BackgroundColorPicker.SelectedIndex];

            vm.LifeResetCheck = lrcSwitch.IsToggled;


            var json = JsonConvert.SerializeObject(vm);
            DependencyService.Get<ISaveAndLoad>().SaveData("temp.json", json);

            Navigation.PopAsync();

            // DisplayAlert("セーブ", "一度リセットして設定をてきおうしてください", "OK");
        }

        // ピッカーに値を
        private void DataSet()
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

        // 読み出し 
        private void DataDraw()
        { 
            var data = DependencyService.Get<ISaveAndLoad>().LoadData("temp.json");
            this.vm = JsonConvert.DeserializeObject<AllPagesViewModel>(data);

            // バインドできればここも(´・ω・`)
            LifeNum.SelectedIndex = vm.Life;
            BackgroundColorPicker.SelectedIndex = vm.Backcolor;
            LifeFontColorPicker.SelectedIndex = vm.Lifecolor;

            LifeFontColorPicker.BackgroundColor = stringToColor[LifeFontColorPicker.Items[LifeFontColorPicker.SelectedIndex]];
            BackgroundColorPicker.BackgroundColor = stringToColor[BackgroundColorPicker.Items[BackgroundColorPicker.SelectedIndex]];

            lrcSwitch.IsToggled = vm.LifeResetCheck;
        }

        // PIG
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}
