using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SimpleLifeCounter.ViewModels
{
    class MenuPagesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Color _confirmationBackgroundColor;
        public Color ConfirmationBackgroundColor
        {
            get { return _confirmationBackgroundColor; }
            set
            {
                if (_confirmationBackgroundColor != value)
                {
                    _confirmationBackgroundColor = value;
                    OnPropertyChanged("ConfirmationBackgroundColor");
                }
            }
        }

        private Color _confirmationLifeFontColor;
        public Color ConfirmationLifeFontColor
        {
            get { return _confirmationLifeFontColor; }
            set
            {
                if(_confirmationLifeFontColor != value)
                {
                    _confirmationLifeFontColor = value;
                    OnPropertyChanged("ConfirmationLifeFontColor");
                }
            }
        }

    }
}
