using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Symple_Life_Counter
{
    public partial class MainPage : ContentPage
    {
        const int DefaultLife = 20;

        public MainPage()
        {
            InitializeComponent();

            LeftPlyerLifeUp.Clicked += (sender, e) => LeftPlyerLife.Text = LifeUp(LeftPlyerLife);
            LeftPlyerLifeDown.Clicked += (sender, e) => LeftPlyerLife.Text = LifeDown(LeftPlyerLife);
            RightPlyerLifeUp.Clicked += (sender, e) => RightPlyerLife.Text = LifeUp(RightPlyerLife);
            RightPlyerLifeDown.Clicked += (sender,e) => RightPlyerLife.Text = LifeDown(RightPlyerLife);

            LifeReset.Clicked += async(sender, e) => 
            {
                var accepted = await this.DisplayAlert(
                "リセット", "ライフを初期値に戻しますか？", "はい", "いいえ");
                if (accepted)
                {
                    LeftPlyerLife.Text = DefaultLife.ToString();
                    RightPlyerLife.Text = DefaultLife.ToString();
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

    }
}
