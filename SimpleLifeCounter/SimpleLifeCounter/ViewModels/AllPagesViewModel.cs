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

        public Color Life_Color;
        public Color Background_Color;
        public int Life_point;


    }
}
