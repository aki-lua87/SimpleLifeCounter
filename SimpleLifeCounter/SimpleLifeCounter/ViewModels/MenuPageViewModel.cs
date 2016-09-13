using SimpleLifeCounter.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;

namespace SimpleLifeCounter.ViewModels
{
    class MenuPageViewModel : BindableBase
    {
        private AllPageModel Model = new AllPageModel();

        // MenuPage Binding
        private int _lifeIndex;
        private int _backgroundColorIndex;
        private int _lifeColorIndex;
        private bool _lifeResetCheck;
        private bool _bigButtonCheck;

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
        public MenuPageViewModel()
        {
            this.Load();
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
            this.BigButtonCheck = Model.BigButtonCheck;
        }

        // SaveButtonClick
        public void SaveClicked(string lifePoint, string fontColor, string backgroundColor)
        {
            Model.LifeColorIndex = LifeColorIndex;
            Model.BackgroundColorIndex = BackgroundColorIndex;
            Model.LifeIndex = LifeIndex;

            Model.LifeResetCheck = LifeResetCheck;
            Model.BigButtonCheck = BigButtonCheck;

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
