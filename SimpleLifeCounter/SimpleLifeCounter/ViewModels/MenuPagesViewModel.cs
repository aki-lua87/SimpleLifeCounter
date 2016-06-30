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
    class MenuPagesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //private AllPageModel Model { get; } = new AllPageModel();
        private AllPageModel Model = new AllPageModel();

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


        // picker系
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

        // Model購読
        public MenuPagesViewModel()
        {
            this.Model.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == nameof(AllPageModel.BackgroundColorIndex))
                {
                    this.BackgroundColorIndex = Model.BackgroundColorIndex;
                }
                if (e.PropertyName == nameof(AllPageModel.LifeColorIndex))
                {
                    this.LifeColorIndex = Model.LifeColorIndex;
                }
                if (e.PropertyName == nameof(AllPageModel.LifeIndex))
                {
                    this.LifeIndex = Model.LifeIndex;
                }
                if (e.PropertyName == nameof(AllPageModel.LifeResetCheck))
                {
                    this.LifeResetCheck = Model.LifeResetCheck;
                }
            };
        }

        // データセーブ 分からないからズル
        public void Save()
        {
            var json = JsonConvert.SerializeObject(Model);
            DependencyService.Get<ISaveAndLoad>().SaveData("temp.json", json);
        }
        // データロード
        public void Load()
        {
            var data = DependencyService.Get<ISaveAndLoad>().LoadData("temp.json");
            Model = JsonConvert.DeserializeObject<AllPageModel>(data);

            this.BackgroundColorIndex = Model.BackgroundColorIndex;
            this.LifeColorIndex = Model.LifeColorIndex;
            this.LifeIndex = Model.LifeIndex;
            this.LifeResetCheck = Model.LifeResetCheck;
        }

        // SaveButtonClick
        public void SaveClicked(string lifePoint, string fontColor, string backgroundColor)
        {
            Model.LifeColorIndex = LifeColorIndex;
            Model.BackgroundColorIndex = BackgroundColorIndex;
            Model.LifeIndex = LifeIndex;

            Model.LifeResetCheck = LifeResetCheck;

            Model.DefaultLifePoint = int.Parse(lifePoint);
            Model.LifeFontColor = fontColor;
            Model.BackgroundColor = backgroundColor;

            Model.Message = "null!!!!!!";

            this.Save();
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


    }
}
