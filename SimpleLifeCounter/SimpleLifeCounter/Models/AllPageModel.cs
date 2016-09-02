using SimpleLifeCounter.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ServiceModel.Channels;

using Xamarin.Forms;
using Newtonsoft.Json;
using Prism.Mvvm;

namespace SimpleLifeCounter.Models
{
    public class AllPageModel : BindableBase
    {
        private int _lifeIndex;
        private int _backgroundColorIndex;
        private int _lifeColorIndex;

        private bool _lifeResetCheck;

        private string _backgroundColor;
        private string _lifeFontColor;
        private int _defaultLifePoint;
        private string _message;

        // MenuPage Binding
        public int LifeIndex
        {
            get { return _lifeIndex; }
            set { this.SetProperty(ref this._lifeIndex, value); }
        }
        public int BackgroundColorIndex
        {
            get { return _backgroundColorIndex; }
            set { this.SetProperty(ref this._backgroundColorIndex, value); }
        }
        public int LifeColorIndex
        {
            get { return _lifeColorIndex; }
            set { this.SetProperty(ref this._lifeColorIndex, value); }
        }
        public bool LifeResetCheck
        {
            get { return _lifeResetCheck; }
            set { this.SetProperty(ref this._lifeResetCheck, value); }
        }

        //LifePage Bainding
        public string BackgroundColor
        {
            get { return this._backgroundColor; }
            set { this.SetProperty(ref this._backgroundColor, value); }
        }

        public string LifeFontColor
        {
            get { return _lifeFontColor; }
            set { this.SetProperty(ref this._lifeFontColor, value); }
        }

        public int DefaultLifePoint
        {
            get { return _defaultLifePoint; }
            set { this.SetProperty(ref this._defaultLifePoint, value); }
        }
        public string Message
        {
            get { return _message; }
            set { this.SetProperty(ref this._message, value); }
        }



        public void DoNotBindingSetVM(string lifePoint, string fontColor, string backgroundColor)
        {
            // データバインドできない部分をViewModelに手書き
            DefaultLifePoint = int.Parse(lifePoint);
            LifeFontColor = fontColor;
            BackgroundColor = backgroundColor;
        }

        public void CoinMessegeGenerate()
        {
            Random rnd = new Random();
            this.Message = rnd.Next(0, 100) < 50 ? "おもて":"うら";
        }
        public void DiceMessegeGenerate()
        {
            Random rnd = new Random();
            this.Message = $"{rnd.Next(1, 21).ToString()}";
        }

        // jsonにセーブ
        // セーブしたときにイベント発行
        // VMで発火してJsonの値を格納


        public AllPageModel()
        {
            
        }
        public AllPageModel(string messege)
        {
            LifeIndex = 1;
            BackgroundColorIndex = 3;
            LifeColorIndex = 13;

            LifeResetCheck = false;

            BackgroundColor = "Gray";
            LifeFontColor = "White";
            DefaultLifePoint = 20;

            Message = messege;
        }

    }
}
