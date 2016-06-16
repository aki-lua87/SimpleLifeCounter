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
        private MenuPagesViewModel mvm = new MenuPagesViewModel();
        Dictionary<string, Color> stringToColor;

        public MenuPage()
        {
            InitializeComponent();
            this.BindingContext = vm;
            this.BindingContext = mvm; 

            // 上の邪魔なの消すおまじない
            NavigationPage.SetHasNavigationBar(this, false);

            // 色と文字列のリスト
            stringToColor = vm.getStringToColorList();

            DataSet();
            DataDraw();

            SaveButton.Clicked += (sender, e) => SaveClicked();

            LifeFontColorPicker.SelectedIndexChanged += (sender, s) => 
            mvm.ConfirmationLifeFontColor = stringToColor[LifeFontColorPicker.Items[LifeFontColorPicker.SelectedIndex]];

            BackgroundColorPicker.SelectedIndexChanged += (sender, e) =>
            mvm.ConfirmationBackgroundColor = stringToColor[BackgroundColorPicker.Items[BackgroundColorPicker.SelectedIndex]];
        }

        // セーブ
        private void SaveClicked()
        {
            // ベタ書き(´・ω・｀) バインドできるんですよね……
            vm.LifeIndex = LifeNum.SelectedIndex;
            vm.LifeColorIndex = LifeFontColorPicker.SelectedIndex;
            vm.BackgroundColorIndex = BackgroundColorPicker.SelectedIndex;

            vm.LifeFontColor = LifeFontColorPicker.Items[LifeFontColorPicker.SelectedIndex];
            vm.DefaultLifePoint = int.Parse(LifeNum.Items[LifeNum.SelectedIndex]);
            vm.BackgroundColor = BackgroundColorPicker.Items[BackgroundColorPicker.SelectedIndex];

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

            mvm.ConfirmationLifeFontColor = vm.getLifeFontColor();
            mvm.ConfirmationBackgroundColor = vm.getBackgroundColor();

            // バインドできればここも(´・ω・`)
            LifeNum.SelectedIndex = vm.LifeIndex;
            BackgroundColorPicker.SelectedIndex = vm.BackgroundColorIndex;
            LifeFontColorPicker.SelectedIndex = vm.LifeColorIndex;

            lrcSwitch.IsToggled = vm.LifeResetCheck;
        }

        // PIG
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}
