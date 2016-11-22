using SimpleLifeCounter.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using DependencyService = Xamarin.Forms.DependencyService;

namespace SimpleLifeCounter.ViewModels
{
    class LifePageViewModel : BindableBase
    {
        private AllPageModel Model = new AllPageModel();
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;

        //LifePage Bainding
        private string _backgroundColor;
        private string _lifeFontColor;
        private int _defaultLifePoint;
        private bool _lifeResetCheck;
        private bool _bigButtonCheck;
        private bool _energyCounterCheck;
        private string _message;

        private string _leftLifePoint, _rightLifePoint;
        
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
        public bool EnergyCounterCheck
        {
            get { return _energyCounterCheck; }
            set { this.SetProperty(ref this._energyCounterCheck, value); }
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
        public DelegateCommand ResetLifeCommand { get; private set; }
        public DelegateCommand CoinTossCommand { get; private set; }
        public DelegateCommand DiceCollCommand { get; private set; }
        public DelegateCommand NavigationCommand { get; private set; }

        private void Navigate()
        {
            _navigationService.NavigateAsync("MenuPage");
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public LifePageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) 
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            
            Load();

            this.RightUpCommand = new DelegateCommand(() => RightLifePoint = (int.Parse(RightLifePoint) + 1).ToString());
            this.RightDownCommand = new DelegateCommand(() => RightLifePoint = (int.Parse(RightLifePoint) - 1).ToString());
            this.LeftUpCommand = new DelegateCommand(() => LeftLifePoint = (int.Parse(LeftLifePoint) + 1).ToString());
            this.LeftDownCommand = new DelegateCommand(() => LeftLifePoint = (int.Parse(LeftLifePoint) - 1).ToString());
            this.NavigationCommand = new DelegateCommand(Navigate);

            setLifePoint();
        }

        // Model購読


        // データロード
        public void Load()
        {
            try
            {
                var data = DependencyService.Get<ISaveAndLoad>().LoadData("temp.json");
                Model = JsonConvert.DeserializeObject<AllPageModel>(data);
                this.BackgroundColor = Model.BackgroundColor;
                this.LifeFontColor = Model.LifeFontColor;
                this.DefaultLifePoint = Model.DefaultLifePoint;
                this.LifeResetCheck = Model.LifeResetCheck;
                this.BigButtonCheck = Model.BigButtonCheck;
                this.EnergyCounterCheck = Model.EnergyCounterCheck;
                this.Message = Model.Message;

            }
            catch (Exception)
            {
                var json = JsonConvert.SerializeObject(new AllPageModel("初期化"));
                DependencyService.Get<ISaveAndLoad>().SaveData("temp.json", json);
                Load();
            }
        }

        // Model呼び出し
        public void CoinMessegeGenerate()
        {
            Model.CoinMessegeGenerate();
            this.Message = Model.Message;
        }
        public void DiceMessegeGenerate()
        {
            Model.DiceMessegeGenerate();
            this.Message = Model.Message;
        }

        public void setLifePoint()
        {
            LeftLifePoint = DefaultLifePoint.ToString();
            RightLifePoint = DefaultLifePoint.ToString();
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public Task<bool> CanNavigateAsync(NavigationParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
