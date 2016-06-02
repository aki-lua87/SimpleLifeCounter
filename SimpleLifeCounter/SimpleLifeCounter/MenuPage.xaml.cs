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

        public MenuPage()
        {
            InitializeComponent();
            //this.BindingContext = vm; //バインドができない切れそう

            // 上の邪魔なの消すおまじない
            NavigationPage.SetHasNavigationBar(this, false);

            DataSet();
            DataDraw();

            SaveButton.Clicked += (sender, e) => SaveClicked();
        }

        // セーブ
        private void SaveClicked()
        {
            
            // ベタ書き(´・ω・｀)
            vm.Life = LifeNum.SelectedIndex;
            vm.Lifecolor = LifeColorPicker.SelectedIndex;
            vm.Backcolor = BackgroundColorPicker.SelectedIndex;

            vm.Life_Color = LifeColorPicker.Items[LifeColorPicker.SelectedIndex];
            vm.Life_point = int.Parse(LifeNum.Items[LifeNum.SelectedIndex]);
            vm.LifeFont_Color = BackgroundColorPicker.Items[BackgroundColorPicker.SelectedIndex];


            var json = JsonConvert.SerializeObject(vm);
            DependencyService.Get<ISaveAndLoad>().SaveData("temp.json", json);

            DisplayAlert("セーブ値", "" + vm.Life_Color + vm.Life_point + vm.LifeFont_Color, "OK");
            //DisplayAlert("現在の値", "" + LeftPlyerLife.Text + LeftPlyerLifeUp.BackgroundColor + Content.BackgroundColor, "OK");
        }

        // ピッカーに値を
        private void DataSet()
        {
            // Pickerに要素を追加
            int Num = 10; //LifPoint
            foreach (string colorName in nameToColor.Keys)
            {
                LifeColorPicker.Items.Add(colorName);
                BackgroundColorPicker.Items.Add(colorName);
                LifeNum.Items.Add(Num.ToString());
                Num += 10;
            }
        }

        // 読み出し
        private void DataDraw()
        { 
                var data = DependencyService.Get<ISaveAndLoad>().LoadData("temp.json");
                this.vm = JsonConvert.DeserializeObject<AllPagesViewModel>(data);

                LifeNum.SelectedIndex = vm.Life;
                BackgroundColorPicker.SelectedIndex = vm.Backcolor;
                LifeColorPicker.SelectedIndex = vm.Lifecolor;

        }
    }
}
