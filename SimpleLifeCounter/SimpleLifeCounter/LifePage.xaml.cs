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

        public LifePage()
        {
            InitializeComponent();

            // 上の邪魔なの消すおまじない
            NavigationPage.SetHasNavigationBar(this, false);

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
                    // バインドできればライフりせっとのみでおｋ
                    DataDraw();
                }

            };
        }

        // CIP
        protected override void OnAppearing()
        {
            base.OnAppearing();
            DataDraw();
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
                BindingContext = vm;

                DefaultLife = vm.DefaultLifePoint;
                LeftPlyerLife.Text = DefaultLife.ToString();
                RightPlyerLife.Text = DefaultLife.ToString();
            }
            catch (Exception)
            {
                // ここは起動時に必ず読み込む
                vm.LifeIndex = 1;
                vm.DefaultLifePoint = 20;

                vm.LifeColorIndex = 13;
                vm.LifeFontColor = "White";
                
                vm.BackgroundColorIndex = 3;
                vm.BackgroundColor = "Blue";
                
                vm.LifeResetCheck = false;

                var json = JsonConvert.SerializeObject(vm);
                DependencyService.Get<ISaveAndLoad>().SaveData("temp.json", json);

                DataDraw();
            }
            
        }

    }
}
