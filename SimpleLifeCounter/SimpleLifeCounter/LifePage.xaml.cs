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
    public partial class LifePage : ContentPage
    {
        private AllPagesViewModel vm = new AllPagesViewModel();

        int DefaultLife;
        Color LifeFont_Color; 
        Color LifeButton_Color;

        Dictionary<string, Color> stringToColor;

        public LifePage()
        {
            InitializeComponent();

            // 上の邪魔なの消すおまじない
            NavigationPage.SetHasNavigationBar(this, false);

            // 色と文字列のリスト
            stringToColor = vm.getStringToColorList();

            // json read
            DataDraw();

            LeftPlyerLifeUp.Clicked += (sender, e) => LeftPlyerLife.Text = LifeUp(LeftPlyerLife);
            LeftPlyerLifeDown.Clicked += (sender, e) => LeftPlyerLife.Text = LifeDown(LeftPlyerLife);
            RightPlyerLifeUp.Clicked += (sender, e) => RightPlyerLife.Text = LifeUp(RightPlyerLife);
            RightPlyerLifeDown.Clicked += (sender, e) => RightPlyerLife.Text = LifeDown(RightPlyerLife);
            toMenuPage.Clicked += async(sender,e) => await Navigation.PushAsync(new MenuPage());

            LifeReset.Clicked += async (sender, e) =>
            {
                var accepted = true;
                if (vm.LifeResetCheck)
                {
                    accepted = await DisplayAlert(
                    "リセット", "ライフを初期値に戻しますか？", "はい", "いいえ");
                }
                if (accepted)
                {
                    DataDraw();
                }

            };
        }

        //ライフ増減
        private string LifeUp(Label Lifelabel)
        {
            return (int.Parse(Lifelabel.Text) + 1).ToString();
        }
        private string LifeDown(Label Lifelabel)
        {
            return (int.Parse(Lifelabel.Text) - 1).ToString();
        }

        // json read
        private void DataDraw()
        {
            try
            {
                var data = DependencyService.Get<ISaveAndLoad>().LoadData("temp.json");
                vm = JsonConvert.DeserializeObject<AllPagesViewModel>(data);

                DefaultLife = vm.Life_point;
                LeftPlyerLife.Text = DefaultLife.ToString();
                RightPlyerLife.Text = DefaultLife.ToString();

                //LifeButton_Color = nameToColor[vm.Life_Color];
                LifeButton_Color = stringToColor[vm.Life_Color];
                LeftPlyerLifeDown.BackgroundColor = LifeButton_Color;
                LeftPlyerLifeDown.BorderColor = LifeButton_Color;
                LeftPlyerLifeUp.BackgroundColor = LifeButton_Color;
                LeftPlyerLifeUp.BorderColor = LifeButton_Color;
                RightPlyerLifeDown.BackgroundColor = LifeButton_Color;
                RightPlyerLifeDown.BorderColor = LifeButton_Color;
                RightPlyerLifeUp.BackgroundColor = LifeButton_Color;
                RightPlyerLifeUp.BorderColor = LifeButton_Color;
                Content.BackgroundColor = LifeButton_Color;

                //LifeFont_Color = nameToColor[vm.LifeFont_Color];
                LifeFont_Color = stringToColor[vm.LifeFont_Color];
                LeftPlyerLife.TextColor = LifeFont_Color;
                RightPlyerLife.TextColor = LifeFont_Color;
            }
            catch (Exception e)
            {
                // ここは起動時に必ず読み込む
                vm.Life = 1;
                vm.Lifecolor = 1;
                vm.Backcolor = 13;

                vm.Life_Color = "White";
                vm.Life_point = 20;
                vm.LifeFont_Color = "Black";

                vm.LifeResetCheck = false;

                var json = JsonConvert.SerializeObject(vm);
                DependencyService.Get<ISaveAndLoad>().SaveData("temp.json", json);

                DataDraw();
            }
            
        }

    }
}
