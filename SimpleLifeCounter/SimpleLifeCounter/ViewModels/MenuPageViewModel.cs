using SimpleLifeCounter.Models;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;

namespace SimpleLifeCounter.ViewModels
{
    class MenuPageViewModel : BindableBase, INavigationAware
    {
        private readonly IAllPageModel Model;

        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;
       
        // MenuPage Binding
        private int _lifeIndex = 13;
        private int _backgroundColorIndex = 13;
        private int _lifeColorIndex = 1;
        private bool _lifeResetCheck;
        private bool _bigButtonCheck;
        private bool _subCounterCheck;

        private Color _confirmationBackgroundColor;
        private Color _confirmationLifeFontColor;

        private bool _initFlag = false;
        private bool _loadFlag = false;

        // PickerにIndexとスイッチ
        public int LifeIndex
        {
            get { return _lifeIndex; }
            set
            {
                Debug.WriteLine($"（´・ω・｀）（´・ω・｀）（´・ω・｀）おっす値をセットするやで　_lifeIndex＝＞{value}");
                this.SetProperty(ref this._lifeIndex, value);
                //Save();
            }
        }
        public int BackgroundColorIndex
        {
            get { return _backgroundColorIndex; }
            set
            {
                Debug.WriteLine($"（´・ω・｀）（´・ω・｀）（´・ω・｀）おっす値をセットするやで　_backgroundColorIndex＝＞{value}");
                this.SetProperty(ref this._backgroundColorIndex, value);
                ConfirmationBackgroundColor = nameToColor[BackgroundColorSelection[BackgroundColorIndex]];
                //Save();
            }
        }
        public int LifeColorIndex
        {
            get { return _lifeColorIndex; }
            set
            {
                Debug.WriteLine($"（´・ω・｀）（´・ω・｀）（´・ω・｀）おっす値をセットするやで　_lifeColorIndex＝＞{value}");
                this.SetProperty(ref this._lifeColorIndex, value);
                ConfirmationLifeFontColor = nameToColor[LifeColorSelection[LifeColorIndex]];
                //Save();
            }
        }
        public bool LifeResetCheck
        {
            get { return _lifeResetCheck; }
            set
            {
                Debug.WriteLine($"（´・ω・｀）（´・ω・｀）（´・ω・｀）おっす値をセットするやで　_lifeResetCheck＝＞{value}");
                this.SetProperty(ref this._lifeResetCheck, value);
                //Save();
            }
        }
        public bool BigButtonCheck
        {
            get { return _bigButtonCheck; }
            set
            {
                Debug.WriteLine($"（´・ω・｀）（´・ω・｀）（´・ω・｀）おっす値をセットするやで　_bigButtonCheck＝＞{value}");
                this.SetProperty(ref this._bigButtonCheck, value);
                //Save();
            }
        }
        public bool SubCounterCheck
        {
            get { return _subCounterCheck; }
            set
            {
                Debug.WriteLine($"（´・ω・｀）（´・ω・｀）（´・ω・｀）おっす値をセットするやで　_subCounterCheck＝＞{value}");
                this.SetProperty(ref this._subCounterCheck, value);
                //Save();
            }
        }

        public DelegateCommand SaveClickCommand { get; private set; }


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

        private int[] _lifeSelection;
        private string[] _lifeColorSelection;
        private string[] _backgroundColorSelection;

        public int[] LifeSelection
        {
            get { return _lifeSelection; }
            set { this.SetProperty(ref this._lifeSelection, value); }
        }
        public string[] LifeColorSelection
        {
            get { return _lifeColorSelection; }
            set { this.SetProperty(ref this._lifeColorSelection, value); }
        }
        public string[] BackgroundColorSelection
        {
            get { return _backgroundColorSelection; }
            set { this.SetProperty(ref this._backgroundColorSelection, value); }
        }


        // コンストラクタ
        public MenuPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IAllPageModel allPageModel)
        {
            Model = allPageModel;

            _navigationService = navigationService;
            _pageDialogService = pageDialogService;

            LifeSelection = new[] {10 ,20, 30, 40, 50};

            LifeColorSelection = new string[nameToColor.Values.Count];
            nameToColor.Keys.CopyTo(LifeColorSelection, 0);

            BackgroundColorSelection = new string[nameToColor.Values.Count];
            nameToColor.Keys.CopyTo(BackgroundColorSelection, 0);

            SaveClickCommand = new DelegateCommand(SaveClicked);
            Debug.WriteLine("（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）コンストラクタ終了やで");
        }

        // データセーブ 分からないからズル
        public async void Save()
        {
            Debug.WriteLine("（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）セーブやで");
            Debug.WriteLine($"（´・ω・｀）（´・ω・｀）（´・ω・｀)ちなみにフラグは{_loadFlag.ToString()} & {_initFlag}やで");
            if (!_loadFlag && _initFlag)
            {
                Model.Setting.LifeColorIndex = LifeColorIndex;
                Model.Setting.BackgroundColorIndex = BackgroundColorIndex;
                Model.Setting.LifeIndex = LifeIndex;

                Model.Setting.LifeResetCheck = LifeResetCheck;
                Model.Setting.BigButtonCheck = BigButtonCheck;
                Model.Setting.SubCounterCheck = SubCounterCheck;

                await Model.SaveData();
            }
            Debug.WriteLine("（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）セーブ終了やで");
        }
        // データロード
        public async void Load()
        {
            Debug.WriteLine("（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）ロードやで");

            _loadFlag = true;

            await Model.LoadData();

            this.BackgroundColorIndex = Model.Setting.BackgroundColorIndex;
            this.LifeColorIndex = Model.Setting.LifeColorIndex;
            this.LifeIndex = Model.Setting.LifeIndex;
            this.LifeResetCheck = Model.Setting.LifeResetCheck;
            this.BigButtonCheck = Model.Setting.BigButtonCheck;
            this.SubCounterCheck = Model.Setting.SubCounterCheck;

            _loadFlag = false;
            Debug.WriteLine("（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）ロード終了やで");
        }

        // SaveButtonClick
        public void SaveClicked()
        {
            Save();
            _navigationService.GoBackAsync();
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

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Debug.WriteLine("（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）OnNavigatedTo");
            Device.BeginInvokeOnMainThread(Load);
            _initFlag = true;
        }

        private void Navigate()
        {
            _navigationService.GoBackAsync();
        }




    }
}
