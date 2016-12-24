using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SimpleLifeCounter.Views
{

    public partial class MenuPage : ContentPage
    {
        //private MenuPageViewModel vm { get; } = new MenuPageViewModel();
        Dictionary<string, Color> stringToColor;

        private Button testButton;

        public MenuPage()
        {
            InitializeComponent();

            // 上の邪魔なの消すおまじない
            NavigationPage.SetHasNavigationBar(this, false);


            //Commandできない部分を
            //LifeFontColorPicker.SelectedIndexChanged += (sender, s) =>
            //{
            //    //セッターを弄る
            //    vm.ConfirmationLifeFontColor = stringToColor[LifeFontColorPicker.Items[LifeFontColorPicker.SelectedIndex]];
            //};

            //BackgroundColorPicker.SelectedIndexChanged += (sender, e) =>
            //{
            //    vm.ConfirmationBackgroundColor = stringToColor[BackgroundColorPicker.Items[BackgroundColorPicker.SelectedIndex]];
            //};

            // バインド設定
            // this.BindingContext = vm;
        }

        // セーブ
        private void SaveClicked(object sender, EventArgs e)
        {
            // データバインドできない部分を手書き
            //vm.SaveClicked
            //    (
            //    LifeNum.Items[LifeNum.SelectedIndex],
            //    LifeFontColorPicker.Items[LifeFontColorPicker.SelectedIndex],
            //    BackgroundColorPicker.Items[BackgroundColorPicker.SelectedIndex]
            //    );
            // Navigation.PopAsync();
        }



        // PIG
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}
