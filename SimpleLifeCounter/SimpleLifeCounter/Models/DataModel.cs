using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleLifeCounter.ViewModels;

namespace SimpleLifeCounter.Models
{
    public class DataModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        // picker index
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
    }
}
