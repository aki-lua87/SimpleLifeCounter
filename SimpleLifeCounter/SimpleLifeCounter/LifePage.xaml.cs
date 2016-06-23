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
            JsonRead();

            /* 画像がなんか微妙い
            // メニュー用画像にタップイベントを追加
            var toMenu = new TapGestureRecognizer();
            toMenu.Tapped += (sender,e) => Navigation.PushAsync(new MenuPage());
            toMenuPage.GestureRecognizers.Add(toMenu);
            toMenuPage.Source = ImageSource.FromResource("SimpleLifeCounter.images.set.png");

            // ライフリセット画像にタップイベントを追加
            var resetLife = new TapGestureRecognizer();
            resetLife.Tapped += async (sender, e) => 
            {
                if(vm.LifeResetCheck ? (await DisplayAlert("リセット", "ライフを初期値に戻しますか？", "はい", "いいえ")) : true)
                {
                    LeftPlyerLife.Text = DefaultLife.ToString();
                    RightPlyerLife.Text = DefaultLife.ToString();
                }
            };
            LifeReset.GestureRecognizers.Add(resetLife);
            LifeReset.Source = ImageSource.FromResource("SimpleLifeCounter.images.rst.png");

            */

            LeftPlyerLifeUp.Clicked += (sender, e) => LeftPlyerLife.Text = LifeUp(LeftPlyerLife);
            LeftPlyerLifeDown.Clicked += (sender, e) => LeftPlyerLife.Text = LifeDown(LeftPlyerLife);
            RightPlyerLifeUp.Clicked += (sender, e) => RightPlyerLife.Text = LifeUp(RightPlyerLife);
            RightPlyerLifeDown.Clicked += (sender, e) => RightPlyerLife.Text = LifeDown(RightPlyerLife);

            toMenuPageButton.Clicked += async(sender,e) => await Navigation.PushAsync(new MenuPage());
            LifeResetButton.Clicked += async (sender, e) =>
            {
                if (vm.LifeResetCheck ? (await DisplayAlert("リセット", "ライフを初期値に戻しますか？", "はい", "いいえ")) : true)
                {
                    LeftPlyerLife.Text = DefaultLife.ToString();
                    RightPlyerLife.Text = DefaultLife.ToString();
                }
            };
        }

        // CIP
        protected override void OnAppearing()
        {
            base.OnAppearing();
            JsonRead();
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
        private void JsonRead()
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
                
                vm.LifeResetCheck = true;

                var json = JsonConvert.SerializeObject(vm);
                DependencyService.Get<ISaveAndLoad>().SaveData("temp.json", json);

                JsonRead();
            }
            
        }

    }
}
