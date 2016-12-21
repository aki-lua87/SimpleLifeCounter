using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Prism.Navigation;
using Prism.Services;
using SimpleLifeCounter.Models;
using SimpleLifeCounter.Views;
using Xamarin.Forms;

namespace SimpleLifeCounter.ViewModels
{
    public class CalculationPageViewModel : BindableBase, INavigationAware
    {
        private readonly IAllPageModel Model;

        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;

        // public ReadOnlyReactiveProperty<Setting> CurrentPage { get; }

        private readonly string ToMenuPage = "MenuPage";

        private string _backgroundColor;
        private string _lifeFontColor;
        private int _defaultLifePoint;
        private bool _lifeResetCheck;
        private bool _bigButtonCheck;
        private bool _subCounterCheck;
        private string _message;

        private string _leftLifePoint, _rightLifePoint;
        private string _subLeftLifePoint, _subRightLifePoint;

        public string LeftLifePoint
        {
            get { return _leftLifePoint; }
            set { this.SetProperty(ref this._leftLifePoint, value); }
        }

        public string RightLifePoint
        {
            get { return _rightLifePoint; }
            set { this.SetProperty(ref this._rightLifePoint, value); }
        }

        public string SubLeftLifePoint
        {
            get { return _subLeftLifePoint; }
            set { this.SetProperty(ref this._subLeftLifePoint, value); }
        }

        public string SubRightLifePoint
        {
            get { return _subRightLifePoint; }
            set { this.SetProperty(ref this._subRightLifePoint, value); }
        }

        public string BackgroundColor
        {
            get { return this._backgroundColor; }
            set { this.SetProperty(ref this._backgroundColor, value); }
        }
        public string LifeFontColor
        {
            get { return _lifeFontColor; }
            set { this.SetProperty(ref this._lifeFontColor, value); }
        }
        public int DefaultLifePoint
        {
            get { return _defaultLifePoint; }
            set { this.SetProperty(ref this._defaultLifePoint, value); }
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
            get { return _subCounterCheck; }
            set { this.SetProperty(ref this._subCounterCheck, value); }
        }

        public string Message
        {
            get { return _message; }
            set { this.SetProperty(ref this._message, value); }
        }

        public DelegateCommand RightUpCommand { get; private set; }
        public DelegateCommand RightDownCommand { get; private set; }
        public DelegateCommand LeftUpCommand { get; private set; }
        public DelegateCommand LeftDownCommand { get; private set; }
        public DelegateCommand LifeResetCommand { get; private set; }
        public DelegateCommand CoinTossCommand { get; private set; }
        public DelegateCommand DiceRollCommand { get; private set; }
        public DelegateCommand NavigationCommand { get; private set; }
        public DelegateCommand SubRightUpCommand { get; private set; }
        public DelegateCommand SubRightDownCommand { get; private set; }
        public DelegateCommand SubLeftUpCommand { get; private set; }
        public DelegateCommand SubLeftDownCommand { get; private set; }



        public CalculationPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService,IAllPageModel allPageModel)
        {
            Model = allPageModel;

            _navigationService = navigationService;
            _pageDialogService = pageDialogService;

            this.LeftUpCommand = new DelegateCommand(() => LeftLifePoint = (int.Parse(LeftLifePoint) + 1).ToString());
            this.LeftDownCommand = new DelegateCommand(() => LeftLifePoint = (int.Parse(LeftLifePoint) - 1).ToString());
            this.RightUpCommand = new DelegateCommand(() => RightLifePoint = (int.Parse(RightLifePoint) + 1).ToString());
            this.RightDownCommand = new DelegateCommand(() => RightLifePoint = (int.Parse(RightLifePoint) - 1).ToString());

            this.SubLeftUpCommand = new DelegateCommand(() => SubLeftLifePoint = (int.Parse(SubLeftLifePoint) + 1).ToString());
            this.SubLeftDownCommand = new DelegateCommand(() => SubLeftLifePoint = (int.Parse(SubLeftLifePoint) - 1).ToString());
            this.SubRightUpCommand = new DelegateCommand(() => SubRightLifePoint = (int.Parse(SubRightLifePoint) + 1).ToString());
            this.SubRightDownCommand = new DelegateCommand(() => SubRightLifePoint = (int.Parse(SubRightLifePoint) - 1).ToString());

            NavigationCommand = new DelegateCommand(Navigate);
            DiceRollCommand = new DelegateCommand(DiceRoll);
            CoinTossCommand = new DelegateCommand(CoinToss);
            LifeResetCommand = new DelegateCommand(ResetLife);

            Model.PropertyChanged += Model_PropertyChanged;

            Load();
            InitLife();
        }

        private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Message")
            {
                this.Message = Model.Message;
            }
        }

        private void Navigate()
        {
            _navigationService.NavigateAsync(ToMenuPage);
        }

        private async void DiceRoll()
        {
            Model.DiceMessegeGenerate();
            await _pageDialogService.DisplayAlertAsync("dice", Message , "閉じる");
        }

        private async void CoinToss()
        {
            Model.CoinMessegeGenerate();
            await _pageDialogService.DisplayAlertAsync("Coin", Message , "閉じる");
        }

        private async void ResetLife()
        {
            if (!LifeResetCheck || await _pageDialogService.DisplayAlertAsync("リセット", "ライフを初期値に戻しますか？", "はい", "いいえ"))
            {
                LeftLifePoint = DefaultLifePoint.ToString();
                RightLifePoint = DefaultLifePoint.ToString();
                SubLeftLifePoint = 0.ToString();
                SubRightLifePoint = 0.ToString();
            }
        }
        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            BigButtonCheck = false;
            SubCounterCheck = false;
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            // 再描写処理
            
        }

        private async void InitLife()
        {
                LeftLifePoint = DefaultLifePoint.ToString();
                RightLifePoint = DefaultLifePoint.ToString();
                SubLeftLifePoint = 0.ToString();
                SubRightLifePoint = 0.ToString();
        }

        public void Load()
        {
            try
            {
                var data = Model.SaveAndLoad.LoadData(Model.JsonName);
                Model.Setting = JsonConvert.DeserializeObject<Setting>(data);

                this.BackgroundColor = indexToColor[Model.Setting.BackgroundColorIndex];
                this.LifeFontColor =indexToColor[Model.Setting.LifeColorIndex];
                this.DefaultLifePoint = Model.Setting.LifeIndex * 10;
                this.LifeResetCheck = Model.Setting.LifeResetCheck;
                this.BigButtonCheck = Model.Setting.BigButtonCheck;
                this.SubCounterCheck = Model.Setting.SubCounterCheck;
            }
            catch
            {
                Model.Setting.BackgroundColorIndex = 3;
                Model.Setting.LifeColorIndex = 5;
                Model.Setting.LifeIndex = 2;
                Model.Setting.LifeResetCheck = true;
                Model.Setting.BigButtonCheck = true;
                Model.Setting.SubCounterCheck = true;

                var json = JsonConvert.SerializeObject(Model.Setting);
                Model.SaveAndLoad.SaveData(Model.JsonName, json);
            }
        }

        Dictionary<int, string> indexToColor = new Dictionary<int, string>
        {
            { 1, "Aqua" }, { 2, "Black" },
            { 3, "Blue" },
            { 4, "Gray" }, { 5, "Green" },
            { 6, "Lime" }, { 7, "Maroon" },
            { 8, "Navy" }, { 9, "Olive" },
            { 10, "Purple" }, { 11, "Red" },
            { 12, "Silver" }, { 13, "Teal" },
            { 14, "White" }, { 15, "Yellow" }
        };
    }
}
