using Newtonsoft.Json;
using SimpleLifeCounter.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SimpleLifeCounter.ViewModels
{
    class LifePageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //private AllPageModel Model { get; } = new AllPageModel();
        private AllPageModel Model = new AllPageModel();

        private Boolean TempBool = true; // めうめうめうめうめうめうめう


        //LifePage Bainding
        private string _backgroundColor;
        public string BackgroundColor
        {
            get { return _backgroundColor; }
            set
            {
                if (_backgroundColor != value)
                {
                    _backgroundColor = value;
                    OnPropertyChanged(nameof(BackgroundColor));
                }
            }
        }

        private string _lifeFontColor;
        public string LifeFontColor
        {
            get { return _lifeFontColor; }
            set
            {
                if (_lifeFontColor != value)
                {
                    _lifeFontColor = value;
                    OnPropertyChanged(nameof(LifeFontColor));
                }
            }
        }

        private int _defaultLifePoint;
        public int DefaultLifePoint
        {
            get { return _defaultLifePoint; }
            set
            {
                if (_defaultLifePoint != value)
                {
                    _defaultLifePoint = value;
                    OnPropertyChanged(nameof(DefaultLifePoint));
                }
            }
        }

        private bool _lifeResetCheck;
        public bool LifeResetCheck
        {
            get { return _lifeResetCheck; }
            set
            {
                if (_lifeResetCheck != value)
                {
                    _lifeResetCheck = value;
                    OnPropertyChanged(nameof(LifeResetCheck));
                }
            }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                if (_message != value)
                {
                    _message = value;
                    OnPropertyChanged(nameof(Message));
                }
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public LifePageViewModel()
        {

            System.Diagnostics.Debug.WriteLine("【Const----------------------------1】");

            this.Model.PropertyChanged += ModelPropertyChanged;

            Load();
        }

        // Model購読
        public void ModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(AllPageModel.BackgroundColor):
                    break;
                case nameof(AllPageModel.LifeFontColor):
                    break;
                case nameof(AllPageModel.DefaultLifePoint):
                    break;
                case nameof(AllPageModel.LifeResetCheck):
                    break;
                case nameof(AllPageModel.Message):
                    this.Message = Model.Message;
                    System.Diagnostics.Debug.WriteLine("【Messegeﾀﾞﾖｰｰｰ(´・ω・`)】");
                    break;
                default:
                    System.Diagnostics.Debug.WriteLine("【(´・ω・`)】");
                    break;
            }
        }

        public void DebugMethod() // なんだよこれーーーーーーーーーーーーーーーーーーーー
        {
            if(TempBool)
            {
                this.Model.PropertyChanged += ModelPropertyChanged;
                TempBool = false;
            }
            
        }

        // 分からないからズル
        // データロード
        public void Load()
        {
            try
            {
                var data = DependencyService.Get<ISaveAndLoad>().LoadData("temp.json");
                Model = JsonConvert.DeserializeObject<AllPageModel>(data);
                this.BackgroundColor = Model.BackgroundColor;
                this.LifeFontColor = Model.LifeFontColor;
                this.DefaultLifePoint = Model.DefaultLifePoint;
                this.LifeResetCheck = Model.LifeResetCheck;
                this.Message = Model.Message;
            }
            catch (Exception)
            {
                var json = JsonConvert.SerializeObject(Model);
                DependencyService.Get<ISaveAndLoad>().SaveData("temp.json", json);
                Load();
            }
        }

        // Model呼び出し
        public void CoinMessegeGenerate()
        {
            System.Diagnostics.Debug.WriteLine($"【Coin------------{Message}-----------1】");
            Model.CoinMessegeGenerate();

            //this.Message = Model.Message;
        }
        public void DiceMessegeGenerate()
        {
            System.Diagnostics.Debug.WriteLine($"【Dice------------{Message}-----------1】");
            Model.DiceMessegeGenerate();

            //this.Message = Model.Message;
        }
    }
}
