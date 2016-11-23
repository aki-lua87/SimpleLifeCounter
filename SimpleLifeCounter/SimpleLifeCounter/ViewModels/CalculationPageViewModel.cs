using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Prism.Services;

namespace SimpleLifeCounter.ViewModels
{
    public class CalculationPageViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;

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



        public CalculationPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
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

            this.NavigationCommand = new DelegateCommand(Navigate);
            this.DiceRollCommand = new DelegateCommand(DiceRoll);
            this.CoinTossCommand = new DelegateCommand(CoinToss);
            this.LifeResetCommand = new DelegateCommand(ResetLife);
            

            LeftLifePoint = "20";
            RightLifePoint = "20";
            SubLeftLifePoint = "0";
            SubRightLifePoint = "0";
            BackgroundColor = "Blue";
            LifeFontColor = "White";
            DefaultLifePoint = 20;
            LifeResetCheck = true;
        }
        private void Navigate()
        {
            _navigationService.NavigateAsync("MenuPage");
        }

        private async void DiceRoll()
        {
            await _pageDialogService.DisplayAlertAsync("dice", "114514", "閉じる");
        }

        private async void CoinToss()
        {
            await _pageDialogService.DisplayAlertAsync("coin", "うら", "閉じる");
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

    }
}
