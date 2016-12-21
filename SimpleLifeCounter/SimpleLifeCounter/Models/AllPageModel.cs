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
    public class AllPageModel : BindableBase,IAllPageModel
    {
        public ISaveAndLoad SaveAndLoad { get; set; }

        private Setting _Setting = new Setting();

        private Color _backgroundColor;
        private Color _lifeFontColor;
        private int _defaultLifePoint;
        private string _message;

        public Setting Setting
        {
            get { return _Setting; }
            set { this.SetProperty(ref _Setting, value); }
        }

        public string JsonName => "setting.json";

        //LifePage Bainding
        public Color BackgroundColor
        {
            get { return this._backgroundColor; }
            set { this.SetProperty(ref this._backgroundColor, value); }
        }

        public Color LifeFontColor
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

        
        public void DoNotBindingSetVM(string lifePoint, Color fontColor, Color backgroundColor)
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
        public void SettingSave()
        {
            SaveAndLoad.SaveData(JsonName,JsonConvert.SerializeObject(Setting));
        }

        public void SettingLoad()
        {
            Setting = JsonConvert.DeserializeObject<Setting>(SaveAndLoad.LoadData(JsonName));
        }

        // セーブしたときにイベント発行
        // VMで発火してJsonの値を格納

        public AllPageModel(ISaveAndLoad saveAndLoad)
        {
            SaveAndLoad = saveAndLoad;
        }

    }
}
