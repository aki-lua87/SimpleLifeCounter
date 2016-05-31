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
        Color Background_Color;
        Color LifeButtonColor;

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
                var accepted = await this.DisplayAlert(
                "リセット", "ライフを初期値に戻しますか？", "はい", "いいえ");
                if (accepted)
                {
                    //LeftPlyerLife.Text = DefaultLife.ToString();
                    //RightPlyerLife.Text = DefaultLife.ToString();
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

        private void DataDraw()
        {
            try
            {
                var data = DependencyService.Get<ISaveAndLoad>().LoadData("temp.json");
                this.vm = JsonConvert.DeserializeObject<AllPagesViewModel>(data);

                DefaultLife = vm.Life_point;
                LeftPlyerLife.Text = DefaultLife.ToString();
                RightPlyerLife.Text = DefaultLife.ToString();

                LifeButtonColor = vm.Life_Color;
                LeftPlyerLifeDown.BackgroundColor = LifeButtonColor;
                LeftPlyerLifeDown.BorderColor = LifeButtonColor;
                LeftPlyerLifeUp.BackgroundColor = LifeButtonColor;
                LeftPlyerLifeUp.BorderColor = LifeButtonColor;
                RightPlyerLifeDown.BackgroundColor = LifeButtonColor;
                RightPlyerLifeDown.BorderColor = LifeButtonColor;
                RightPlyerLifeUp.BackgroundColor = LifeButtonColor;
                RightPlyerLifeUp.BorderColor = LifeButtonColor;

                Background_Color = vm.Background_Color;
                this.Content.BackgroundColor = Background_Color;
            }
            catch (Exception)
            {

                // jsonデータがない場合初期値をイン〔ここじゃないと思う〕 //というか事前に作っておくべき
                vm.Life = 1;
                vm.Lifecolor = 1;
                vm.Backcolor = 13;

                vm.Life_Color = Color.White;
                vm.Life_point = 20;
                vm.Background_Color = Color.Black;

                var json = JsonConvert.SerializeObject(vm);
                DependencyService.Get<ISaveAndLoad>().SaveData("temp.json", json);

                DataDraw();
            }

        }

    }
}
