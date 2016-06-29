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
    public class AllPagesViewModel : DataModel
    {
        // Model
        private AllPageModel Model { get; } = new AllPageModel();
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // MenuPage Binding
        private int _lifeIndex;
        public new int LifeIndex
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
        public new int BackgroundColorIndex
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
        public new int LifeColorIndex
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
        public new bool LifeResetCheck
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
        public new string BackgroundColor
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
        public new string LifeFontColor
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
        public new int DefaultLifePoint
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



        //"""""""""""""""""""""""""""""""""""""""""""""""""""""
        Dictionary<string, Color> nameToColor = new Dictionary<string, Color>
        {
            { "Aqua", Color.Aqua }, { "Black", Color.Black },
            { "Blue", Color.Blue },
            { "Gray", Color.Gray }, { "Green", Color.Green },
            { "Lime", Color.Lime }, { "Maroon", Color.Maroon },
            { "Navy", Color.Navy }, { "Olive", Color.Olive },
            { "Purple", Color.Purple }, { "Red", Color.Red },
            { "Silver", Color.Silver }, { "Teal", Color.Teal },
            { "White", Color.White }, { "Yellow", Color.Yellow }
        };
        public Dictionary<string, Color> getStringToColorList()
        {
            return nameToColor;
        }


        public AllPagesViewModel()
        {
            this.Model.PropertyChanged += (_, e) =>
             {

                 if (e.PropertyName == nameof(AllPageModel.DataList))
                 {
                     this.DefaultLifePoint = Model.DataList.DefaultLifePoint;
                     this.LifeColorIndex = Model.DataList.LifeColorIndex;
                     this.BackgroundColorIndex = Model.DataList.BackgroundColorIndex;
                     this.LifeResetCheck = Model.DataList.LifeResetCheck;
                     this.LifeFontColor = Model.DataList.LifeFontColor;
                     this.BackgroundColor = Model.DataList.BackgroundColor;
                 }
             };
            Model.JsonRead();
        }

        // Model呼び出し
        public void  DataSave(string a, string b, string c)
        {

        }
        public AllPagesViewModel JsonRead()
        {
            return (AllPagesViewModel)Model.DataList;
        }



    }
}
