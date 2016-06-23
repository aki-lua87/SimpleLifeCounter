using Newtonsoft.Json;
using SimpleLifeCounter.ViewModels;
using System;
using System.Collections.Generic;
using System.ServiceModel.Channels;
using Xamarin.Forms;

namespace SimpleLifeCounter.Models
{
    class AllPageModel
    {
        private AllPagesViewModel vm = new AllPagesViewModel();

        public AllPageModel()
        {
            JsonRead();
        }

        public void JsonRead()
        {
            try
            {
                var data = DependencyService.Get<ISaveAndLoad>().LoadData("temp.json");
                vm = JsonConvert.DeserializeObject<AllPagesViewModel>(data);
            }
            catch (Exception)
            {
                // Jsonが無いときは作る
                vm.LifeIndex = 1;
                vm.DefaultLifePoint = 20;

                vm.LifeColorIndex = 13;
                vm.LifeFontColor = "White";

                vm.BackgroundColorIndex = 3;
                vm.BackgroundColor = "Blue";

                vm.LifeResetCheck = true;

                var json = JsonConvert.SerializeObject(vm);
                DependencyService.Get<ISaveAndLoad>().SaveData("temp.json", json);

                JsonRead();
            }
        }
        public void JsonWrite()
        {
            var json = JsonConvert.SerializeObject(vm);
            DependencyService.Get<ISaveAndLoad>().SaveData("temp.json", json);
        }

        public void DoNotBindingSetVM(string lifePoint,string fontColor,string backgroundColor)
        {
            // データバインドできない部分をViewModelに手書き
            vm.DefaultLifePoint = int.Parse(lifePoint);
            vm.LifeFontColor = fontColor;
            vm.BackgroundColor = backgroundColor;
        }

        public Boolean RandomBoolean()
        {
            Random rnd = new Random();
            return rnd.Next(0, 100) < 50;
        }
        public int Random20()
        {
            Random rnd = new Random();
            return rnd.Next(1, 21);
        }

        public string LifeUp(Label Lifelabel)
        {
            return (int.Parse(Lifelabel.Text) + 1).ToString();
        }
        public string LifeDown(Label Lifelabel)
        {
            return (int.Parse(Lifelabel.Text) - 1).ToString();
        }

        public AllPagesViewModel getVm()
        {
            return vm;
        }
        public bool getResetCheck()
        {
            return vm.LifeResetCheck;
        }
        public string getStringDefaultLife()
        {
            return vm.DefaultLifePoint.ToString();
        }

    }
}
