using SimpleLifeCounter.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using SimpleLifeCounter.Views;
using Xamarin.Forms.Xaml;
using DependencyService = Xamarin.Forms.DependencyService;

namespace SimpleLifeCounter.ViewModels
{
    class MenuPageViewModel : BindableBase
    {
        private readonly IAllPageModel Model;

        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;

        // MenuPage Binding
        private int _lifeIndex;
        private int _backgroundColorIndex;
        private int _lifeColorIndex;
        private bool _lifeResetCheck;
        private bool _bigButtonCheck;
        private bool _energyCounterCheck;

        private Color _confirmationBackgroundColor;
        private Color _confirmationLifeFontColor;

        public DelegateCommand testCommand { get; private set; }

        // PickerにIndexとスイッチ
        public int LifeIndex
        {
            get { return _lifeIndex; }
            set { this.SetProperty(ref this._lifeIndex, value); }
        }
        public int BackgroundColorIndex
        {
            get { return _backgroundColorIndex; }
            set { this.SetProperty(ref this._backgroundColorIndex, value); }
        }
        public int LifeColorIndex
        {
            get { return _lifeColorIndex; }
            set { this.SetProperty(ref this._lifeColorIndex, value); }
        }
        public bool LifeResetCheck
        {
            get { return _lifeResetCheck; }
            set { this.SetProperty(ref this._lifeResetCheck, value); }
        }
        public bool BigButtonCheck
        {
            get { return _bigButtonCheck; }
            set { this.SetProperty(ref this._bigButtonCheck, value); }
        }
        public bool EnergyCounterCheck
        {
            get { return _energyCounterCheck; }
            set { this.SetProperty(ref this._energyCounterCheck, value); }
        }


        // pickerの背景
        public Color ConfirmationBackgroundColor
        {
            get { return _confirmationBackgroundColor; }
            set { this.SetProperty(ref this._confirmationBackgroundColor, value); }
        }
        public Color ConfirmationLifeFontColor
        {
            get { return _confirmationLifeFontColor; }
            set { this.SetProperty(ref this._confirmationLifeFontColor, value); }
        }


        // コンストラクタ
        public MenuPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;

            // ------------------------------------------
            testCommand = new DelegateCommand(Navigate);
            ConfirmationBackgroundColor = Color.Aqua;
            ConfirmationLifeFontColor = Color.Fuchsia;
            EnergyCounterCheck = true;
            BigButtonCheck = true;
            LifeResetCheck = true;
            LifeColorIndex = 1;
            BackgroundColorIndex = 1;
            LifeIndex = 2;


            // this.Load();
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
            var data = Model.SaveAndLoad.LoadData("temp.json");
            Model.Setting = JsonConvert.DeserializeObject<Setting>(data);

            /*
            this.BackgroundColorIndex = Model.Setting.BackgroundColorIndex;
            this.LifeColorIndex = Model.LifeColorIndex;
            this.LifeIndex = Model.LifeIndex;
            this.LifeResetCheck = Model.LifeResetCheck;
            this.BigButtonCheck = Model.BigButtonCheck;
            this.EnergyCounterCheck = Model.EnergyCounterCheck;
            */
        }

        // SaveButtonClick
        public void SaveClicked(string lifePoint, string fontColor, string backgroundColor)
        {
            /*
            Model.LifeColorIndex = LifeColorIndex;
            Model.BackgroundColorIndex = BackgroundColorIndex;
            Model.LifeIndex = LifeIndex;

            Model.LifeResetCheck = LifeResetCheck;
            Model.BigButtonCheck = BigButtonCheck;
            Model.EnergyCounterCheck = EnergyCounterCheck;

            Model.DefaultLifePoint = int.Parse(lifePoint);
            Model.LifeFontColor = fontColor;
            Model.BackgroundColor = backgroundColor;

            Model.Message = "null!!!!!!";

            this.Save();
            */
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

        private void Navigate()
        {
            _navigationService.GoBackAsync();
        }


    }
}
