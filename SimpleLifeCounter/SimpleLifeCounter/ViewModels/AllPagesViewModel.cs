using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SimpleLifeCounter.ViewModels
{
    class AllPagesViewModel : INotifyPropertyChanged
    {
        private int _life;

        public int Life
        {
            get { return _life; }
            set
            {
                if (_life != value)
                {
                    _life = value;
                    OnPropertyChanged("Life");
                }
            }
        }

        private int _backcolor;

        public int Backcolor
        {
            get { return _backcolor; }
            set
            {
                if (_backcolor != value)
                {
                    _backcolor = value;
                    OnPropertyChanged("Backcolor");
                }
            }
        }

        private int _lifecolor;

        public int Lifecolor
        {
            get { return _lifecolor; }
            set
            {
                if (_lifecolor != value)
                {
                    _lifecolor = value;
                    OnPropertyChanged("Lifecolor");
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }


        //aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa!!!WDefergedgergerg
        private string _Life_Color;
        public string Life_Color
        {
            get { return _Life_Color; }
            set
            {
                if (_Life_Color != value)
                {
                    _Life_Color = value;
                    OnPropertyChanged("Life_Color");
                }
            }
        }


        private string _LifeFont_Color;
        public string LifeFont_Color
        {
            get { return _LifeFont_Color; }
            set
            {
                if (_LifeFont_Color != value)
                {
                    _LifeFont_Color = value;
                    OnPropertyChanged("LifeFont_Color");
                }
            }
        }




        private int _Life_point;
        public int Life_point
        {
            get { return _Life_point; }
            set
            {
                if (_Life_point != value)
                {
                    _Life_point = value;
                    OnPropertyChanged("Life_point");
                }
            }
        }

    }
}
