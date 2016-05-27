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

            // 上の邪魔なの消すおまじない
            NavigationPage.SetHasNavigationBar(this, false);

            // Pickerに要素を追加
            int Num = 10;
            foreach (string colorName in nameToColor.Keys)
            {
                LifeColorPicker.Items.Add(colorName);
                BackgroundColorPicker.Items.Add(colorName);
                LifeNum.Items.Add(Num.ToString());
                Num += 10;
            }

            SaveButton.Clicked += (sender, e) => SaveClicked();

        }

        private void SaveClicked()
        {
            // SQLじゃないとダメね
            Application.Current.Properties["id"] = LifeColorPicker;
            Application.Current.Properties["id"] = BackgroundColorPicker;
            Application.Current.Properties["id"] = LifeNum;
        }

    }
}
