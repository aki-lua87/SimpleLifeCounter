using Newtonsoft.Json;
using SimpleLifeCounter.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ServiceModel.Channels;
using Xamarin.Forms;

namespace SimpleLifeCounter.Models
{
    public class AllPageModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // MenuPage Binding
        private int _lifeIndex;
        public int LifeIndex
        {
            get { return _lifeIndex; }
            set
            {
                if (_lifeIndex != value)
                {
                    _lifeIndex = value;
                    OnPropertyChanged(nameof(LifeIndex));
                }
            }
        }

        private int _backgroundColorIndex;
        public int BackgroundColorIndex
        {
            get { return _backgroundColorIndex; }
            set
            {
                if (_backgroundColorIndex != value)
                {
                    _backgroundColorIndex = value;
                    OnPropertyChanged(nameof(BackgroundColorIndex));
                }
            }
        }

        private int _lifeColorIndex;
        public int LifeColorIndex
        {
            get { return _lifeColorIndex; }
            set
            {
                if (_lifeColorIndex != value)
                {
                    _lifeColorIndex = value;
                    OnPropertyChanged(nameof(LifeColorIndex));
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

            System.Diagnostics.Debug.WriteLine($"【CoinGenerate---{Message}---------】");
        }
        public void DiceMessegeGenerate()
        {
            Random rnd = new Random();
            this.Message = $"{rnd.Next(1, 21).ToString()}";

            System.Diagnostics.Debug.WriteLine($"【DiceGenerate---{Message}---------】");
        }

        public string LifeUp(Label Lifelabel)
        {
            return (int.Parse(Lifelabel.Text) + 1).ToString();
        }
        public string LifeDown(Label Lifelabel)
        {
            return (int.Parse(Lifelabel.Text) - 1).ToString();
        }

        // jsonにセーブ
        // セーブしたときにイベント発行
        // VMで発火してJsonの値を格納


        public AllPageModel()
        {
            LifeIndex = 1;
            BackgroundColorIndex = 2;
            LifeColorIndex = 13;

            LifeResetCheck = true;

            BackgroundColor = "Blue";
            LifeFontColor = "White";
            DefaultLifePoint = 20;

            Message = "Test";
        }

    }
}
