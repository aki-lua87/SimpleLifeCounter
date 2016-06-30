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

        // Modelを購読
        public LifePageViewModel()
        {
            this.Model.PropertyChanged += (_, e) =>
              {
                  if (e.PropertyName == nameof(AllPageModel.BackgroundColor))
                  {
                      this.BackgroundColor = Model.BackgroundColor;
                  }
                  if (e.PropertyName == nameof(AllPageModel.LifeFontColor))
                  {
                      this.LifeFontColor = Model.LifeFontColor;
                  }
                  if (e.PropertyName == nameof(AllPageModel.DefaultLifePoint))
                  {
                      this.DefaultLifePoint = Model.DefaultLifePoint;
                  }
                  if (e.PropertyName == nameof(AllPageModel.LifeResetCheck))
                  {
                      this.LifeResetCheck = Model.LifeResetCheck;
                  }
                  if (e.PropertyName == nameof(AllPageModel.Message))
                  {
                      this.Message = Model.Message;
                  }
              };
            Load();
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
            Model.CoinMessegeGenerate();
            this.Message = Model.Message;
        }
        public void DiceMessegeGenerate()
        {
            Model.DiceMessegeGenerate();
            this.Message = Model.Message;
        }
    }
}
