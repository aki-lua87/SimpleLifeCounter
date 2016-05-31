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

            SaveButton.Clicked += (sender, e) => SaveClicked();
        }

        private void SaveClicked()
        {
            // ベタ書き(´・ω・｀)
            vm.Life = int.Parse(LifeNum.Items[LifeNum.SelectedIndex]);
            vm.Lifecolor = nameToColor[LifeColorPicker.Items[LifeColorPicker.SelectedIndex]];
            vm.Backcolor = nameToColor[BackgroundColorPicker.Items[BackgroundColorPicker.SelectedIndex]];

            var json = JsonConvert.SerializeObject(vm);
            DependencyService.Get<ISaveAndLoad>().SaveData("temp.json", json);
        }

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
    }
}
