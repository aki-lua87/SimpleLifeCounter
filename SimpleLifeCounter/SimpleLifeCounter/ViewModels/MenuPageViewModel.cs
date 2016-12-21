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
        private bool _SubCounterCheck;

        private Color _confirmationBackgroundColor;
        private Color _confirmationLifeFontColor;

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
        public bool SubCounterCheck
        {
            get { return _SubCounterCheck; }
            set { this.SetProperty(ref this._SubCounterCheck, value); }
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
        public MenuPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IAllPageModel allPageModel)
        {
            Model = allPageModel;

            _navigationService = navigationService;
            _pageDialogService = pageDialogService;

            Load();
        }

        // データセーブ 分からないからズル
        public void Save()
        {
            Model.Setting.BackgroundColorIndex = BackgroundColorIndex;
            Model.Setting.LifeColorIndex = LifeColorIndex;
            Model.Setting.LifeIndex = LifeIndex;
            Model.Setting.LifeResetCheck = LifeResetCheck;
            Model.Setting.BigButtonCheck = BigButtonCheck;
            Model.Setting.SubCounterCheck = SubCounterCheck;

            var json = JsonConvert.SerializeObject(Model.Setting);
            DependencyService.Get<ISaveAndLoad>().SaveData(Model.JsonName, json);

            _navigationService.GoBackAsync();
        }
        // データロード
        public void Load()
        {
            try
            {
                var data = Model.SaveAndLoad.LoadData("setting.json");
                Model.Setting = JsonConvert.DeserializeObject<Setting>(data);

                this.BackgroundColorIndex = Model.Setting.BackgroundColorIndex;
                this.LifeColorIndex = Model.Setting.LifeColorIndex;
                this.LifeIndex = Model.Setting.LifeIndex;
                this.LifeResetCheck = Model.Setting.LifeResetCheck;
                this.BigButtonCheck = Model.Setting.BigButtonCheck;
                this.SubCounterCheck = Model.Setting.SubCounterCheck;

                // 仮
                ConfirmationBackgroundColor = Color.Aqua;
                ConfirmationLifeFontColor = Color.Fuchsia;
            }
            catch
            {
                Model.Setting.BackgroundColorIndex = 1;
                Model.Setting.LifeColorIndex = 1;
                Model.Setting.LifeIndex = 2;
                Model.Setting.LifeResetCheck = true;
                Model.Setting.BigButtonCheck = true;
                Model.Setting.SubCounterCheck = true;

                var json = JsonConvert.SerializeObject(Model.Setting);
                DependencyService.Get<ISaveAndLoad>().SaveData(Model.JsonName, json);
            }
        }

        // SaveButtonClick
        public void SaveClicked(string lifePoint, string fontColor, string backgroundColor)
        {
            
            Model.Setting.LifeColorIndex = LifeColorIndex;
            Model.Setting.BackgroundColorIndex = BackgroundColorIndex;
            Model.Setting.LifeIndex = LifeIndex;

            Model.Setting.LifeResetCheck = LifeResetCheck;
            Model.Setting.BigButtonCheck = BigButtonCheck;
            Model.Setting.SubCounterCheck = SubCounterCheck;

            Model.DefaultLifePoint = int.Parse(lifePoint);
            Model.LifeFontColor = nameToColor[fontColor];
            Model.BackgroundColor = nameToColor[backgroundColor];

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

        private void Navigate()
        {
            _navigationService.GoBackAsync();
        }


    }
}
