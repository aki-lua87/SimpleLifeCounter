﻿using SimpleLifeCounter.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;

namespace SimpleLifeCounter.ViewModels
{
    class LifePageViewModel : BindableBase
    {
        //private AllPageModel Model { get; } = new AllPageModel();
        private AllPageModel Model = new AllPageModel();

        //LifePage Bainding
        private string _backgroundColor;
        private string _lifeFontColor;
        private int _defaultLifePoint;
        private bool _lifeResetCheck;
        private string _message;

        private int _leftLifePoint, _rightLifePoint;
        public int LeftLifePoint
        {
            get { return _leftLifePoint; }
            set { this.SetProperty(ref this._leftLifePoint, value); }
        }
        public int RightLifePoint
        {
            get { return _rightLifePoint; }
            set { this.SetProperty(ref this._rightLifePoint, value); }
        }

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

        public bool LifeResetCheck
        {
            get { return _lifeResetCheck; }
            set { this.SetProperty(ref this._lifeResetCheck, value); }
        }

        public string Message
        {
            get { return _message; }
            set { this.SetProperty(ref this._message, value); }
        }

        public DelegateCommand RightUpCommand { get; private set; }
        public DelegateCommand RightDownCommand { get; private set; }
        public DelegateCommand LeftUpCommand { get; private set; }
        public DelegateCommand LeftDownCommand { get; private set; }
        public DelegateCommand ResetLifeCommand { get; private set; }
        public DelegateCommand CoinTossCommand { get; private set; }
        public DelegateCommand DiceCollCommand { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public LifePageViewModel()
        {
            // this.Model.PropertyChanged += ModelPropertyChanged; //これが反映されない
            Load();

            this.RightUpCommand = new DelegateCommand(() => this.RightLifePoint++);
            this.RightDownCommand = new DelegateCommand(() => this.RightLifePoint--);
            this.LeftUpCommand = new DelegateCommand(() => this.LeftLifePoint++);
            this.LeftDownCommand = new DelegateCommand(() => this.LeftLifePoint--);
            this.ResetLifeCommand = new DelegateCommand(() => setLifePoint());

            this.CoinTossCommand = new DelegateCommand(() =>
            {
                
            });
            this.DiceCollCommand = new DelegateCommand(() =>
            {
                
            });

            setLifePoint();
        }

        // Model購読
        

        // データロード
        public void Load()
        {
            try
            {
                var data = DependencyService.Get<ISaveAndLoad>().LoadData("temp.json");
                System.Diagnostics.Debug.WriteLine("【Jsonエラーここ？ｰｰ(・ω・`)】");
                Model = JsonConvert.DeserializeObject<AllPageModel>(data);
                System.Diagnostics.Debug.WriteLine("【Jsonエラーそれともここ？ｰｰ(・ω・`)】");
                this.BackgroundColor = Model.BackgroundColor;
                this.LifeFontColor = Model.LifeFontColor;
                this.DefaultLifePoint = Model.DefaultLifePoint;
                this.LifeResetCheck = Model.LifeResetCheck;
                this.Message = Model.Message;
                System.Diagnostics.Debug.WriteLine("【(・ω・`)｛ロードメソッドはここで終わっている(ｷﾘｯ】");
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("【例外だよーJsonﾂｸﾙﾖｰｰｰ(´・ω・)】");
                var json = JsonConvert.SerializeObject(new AllPageModel());
                DependencyService.Get<ISaveAndLoad>().SaveData("temp.json", json);
                System.Diagnostics.Debug.WriteLine("【Jsonﾂｸｯﾀﾖｰｰ(・ω・`)】");
                Load();
            }
        }

        // Model呼び出し
        public void CoinMessegeGenerate()
        {
            Model.CoinMessegeGenerate();
            this.Message = Model.Message;
        }
        public void DiceMessegeGenerate()
        {
            Model.DiceMessegeGenerate();
            this.Message = Model.Message;
        }

        public void setLifePoint()
        {
            LeftLifePoint = DefaultLifePoint;
            RightLifePoint = DefaultLifePoint;
        }
    }
}
