using Newtonsoft.Json;
using SimpleLifeCounter.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ServiceModel.Channels;
using Xamarin.Forms;

namespace SimpleLifeCounter.Models
{
    public class AllPageModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private DataModel _datalist;
        public DataModel DataList
        {
            get { return _datalist; }
            set
            {
                if (_datalist != value)
                {
                    _datalist = value;
                    OnPropertyChanged(nameof(_datalist));
                }
            }
        }

        public AllPageModel()
        {
            JsonRead();
        }

        public void JsonRead()
        {
            try
            {
                var data = DependencyService.Get<ISaveAndLoad>().LoadData("temp.json");
                DataList = JsonConvert.DeserializeObject<DataModel>(data);
            }
            catch (Exception)
            {
                // Jsonが無いときは作る
                DataList.LifeIndex = 1;
                DataList.DefaultLifePoint = 20;

                DataList.LifeColorIndex = 13;
                DataList.LifeFontColor = "White";

                DataList.BackgroundColorIndex = 3;
                DataList.BackgroundColor = "Blue";

                DataList.LifeResetCheck = true;

                var json = JsonConvert.SerializeObject(DataList);
                DependencyService.Get<ISaveAndLoad>().SaveData("temp.json", json);

                JsonRead();
            }
        }
        public void JsonWrite()
        {
            var json = JsonConvert.SerializeObject(DataList);
            DependencyService.Get<ISaveAndLoad>().SaveData("temp.json", json);
        }

        public void DoNotBindingSetVM(string lifePoint, string fontColor, string backgroundColor)
        {
            // データバインドできない部分をViewModelに手書き
            DataList.DefaultLifePoint = int.Parse(lifePoint);
            DataList.LifeFontColor = fontColor;
            DataList.BackgroundColor = backgroundColor;
        }
    }
}
