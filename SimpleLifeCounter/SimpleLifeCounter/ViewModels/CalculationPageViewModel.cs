using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json;
using PCLStorage;
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

        private readonly string ToMenuPage = "MenuPage";

        private string _backgroundColor = "Black";
        private string _lifeFontColor = "Black";
        private int _defaultLifePoint = 20;
        private bool _lifeResetCheck = true;
        private bool _bigButtonCheck = true;
        private bool _subCounterCheck = true;
        private string _message;

        private string _leftLifePoint, _rightLifePoint;
        private string _leftSubCounter, _subRightCounter;

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

        public string LeftSubCounter
        {
            get { return _leftSubCounter; }
            set { this.SetProperty(ref this._leftSubCounter, value); }
        }

        public string SubRightCounter
        {
            get { return _subRightCounter; }
            set { this.SetProperty(ref this._subRightCounter, value); }
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

            this.SubLeftUpCommand = new DelegateCommand(() => LeftSubCounter = (int.Parse(LeftSubCounter) + 1).ToString());
            this.SubLeftDownCommand = new DelegateCommand(() => LeftSubCounter = (int.Parse(LeftSubCounter) - 1).ToString());
            this.SubRightUpCommand = new DelegateCommand(() => SubRightCounter = (int.Parse(SubRightCounter) + 1).ToString());
            this.SubRightDownCommand = new DelegateCommand(() => SubRightCounter = (int.Parse(SubRightCounter) - 1).ToString());

            NavigationCommand = new DelegateCommand(Navigate);
            DiceRollCommand = new DelegateCommand(DiceRoll);
            CoinTossCommand = new DelegateCommand(CoinToss);
            LifeResetCommand = new DelegateCommand(ResetLife);

            Model.PropertyChanged += Model_PropertyChanged;
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
                InitLife();
            }
        }

        private void InitLife()
        {
                LeftLifePoint = DefaultLifePoint.ToString();
                RightLifePoint = DefaultLifePoint.ToString();
                LeftSubCounter = 0.ToString();
                SubRightCounter = 0.ToString();
        }

        public async void Load()
        {

                 await Model.LoadData();
                // Model.Setting = JsonConvert.DeserializeObject<Setting>(data);

            //catch
            //{
            //    Debug.WriteLine("（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）キャッチ");

            //    Model.Setting.BackgroundColorIndex = 3;
            //    Model.Setting.LifeColorIndex = 13;
            //    Model.Setting.LifeIndex = 1;
            //    Model.Setting.LifeResetCheck = false;
            //    Model.Setting.BigButtonCheck = true;
            //    Model.Setting.SubCounterCheck = true;

            //    await Model.SaveData();
            //    Debug.WriteLine("（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）キャッチ処理終了");
            //    Load();
            //    return;
            //}

            this.BackgroundColor = indexToColor[Model.Setting.BackgroundColorIndex + 1];
            this.LifeFontColor = indexToColor[Model.Setting.LifeColorIndex + 1];
            this.DefaultLifePoint = (Model.Setting.LifeIndex + 1) * 10;
            this.LifeResetCheck = Model.Setting.LifeResetCheck;
            this.BigButtonCheck = Model.Setting.BigButtonCheck;
            this.SubCounterCheck = Model.Setting.SubCounterCheck;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Debug.WriteLine("（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）ここ？");
            Load();
            InitLife();
            Debug.WriteLine("（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）ふんす！！！");
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
