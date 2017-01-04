using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SimpleLifeCounter.Views
{

    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();

            // 上の邪魔なの消すおまじない
            NavigationPage.SetHasNavigationBar(this, false);
        }

        // セーブ
        private void SaveClicked(object sender, EventArgs e)
        {

        }



        // PIG
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}
