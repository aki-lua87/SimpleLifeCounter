using SimpleLifeCounter.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using PCLStorage;
using Prism.Mvvm;

namespace SimpleLifeCounter.Models
{
    public class AllPageModel : BindableBase,IAllPageModel
    {
        // public ISaveAndLoad SaveAndLoad { get; set; }

        private Setting _Setting = new Setting();

        private Color _backgroundColor;
        private Color _lifeFontColor;
        private int _defaultLifePoint;
        public string JsonName => "setting.json";
        private string _message;

        public Setting Setting
        {
            get { return _Setting; }
            set { this.SetProperty(ref _Setting, value); }
        }

        

        //LifePage Bainding
        public Color BackgroundColor
        {
            get { return this._backgroundColor; }
            set { this.SetProperty(ref this._backgroundColor, value); }
        }

        public Color LifeFontColor
        {
            get { return _lifeFontColor; }
            set { this.SetProperty(ref this._lifeFontColor, value); }
        }

        public int DefaultLifePoint
        {
            get { return _defaultLifePoint; }
            set { this.SetProperty(ref this._defaultLifePoint, value); }
        }
        public string Message
        {
            get { return _message; }
            set { this.SetProperty(ref this._message, value); }
        }

        
        public void DoNotBindingSetVM(string lifePoint, Color fontColor, Color backgroundColor)
        {
            // データバインドできない部分をViewModelに手書き
            DefaultLifePoint = int.Parse(lifePoint);
            LifeFontColor = fontColor;
            BackgroundColor = backgroundColor;
        }

        public void CoinMessegeGenerate()
        {
            Random rnd = new Random();
            this.Message = rnd.Next(0, 100) < 50 ? "おもて":"うら";
        }
        public void DiceMessegeGenerate()
        {
            Random rnd = new Random();
            this.Message = $"{rnd.Next(1, 21).ToString()}";
        }

        // セーブしたときにイベント発行
        // VMで発火してJsonの値を格納

        public AllPageModel()
        {
            //SaveAndLoad = saveAndLoad;
        }

        public async Task SaveData()
        {
            Debug.WriteLine("（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）amarin.Formsの初期化完了前に、PCLStorage（というよりXamarin.Plugins）は利用できない点に注意(Save)");
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFile file = await rootFolder.CreateFileAsync(JsonName, CreationCollisionOption.ReplaceExisting);
            await file.WriteAllTextAsync(JsonConvert.SerializeObject(Setting));
        }

        public async Task LoadData()
        {
            Debug.WriteLine("（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）amarin.Formsの初期化完了前に、PCLStorage（というよりXamarin.Plugins）は利用できない点に注意(Load)");
            IFolder rootFolder = FileSystem.Current.LocalStorage;

            ExistenceCheckResult res = await rootFolder.CheckExistsAsync(JsonName);
            if (res == ExistenceCheckResult.NotFound)
            {
                await SaveData();
            }


            IFile file = await rootFolder.GetFileAsync(JsonName);
            Setting = JsonConvert.DeserializeObject<Setting>(file.ReadAllTextAsync().Result);
        }
    }
}
