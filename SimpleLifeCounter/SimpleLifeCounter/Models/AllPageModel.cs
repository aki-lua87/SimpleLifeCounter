using Newtonsoft.Json;
using SimpleLifeCounter.ViewModels;
using System;
using System.ServiceModel.Channels;
using Xamarin.Forms;

namespace SimpleLifeCounter.Models
{
    class AllPageModel
    {
        private AllPagesViewModel vm = new AllPagesViewModel();
        private int DefaultLife;

        private void JsonRead()
        {
            try
            {
                var data = DependencyService.Get<ISaveAndLoad>().LoadData("temp.json");
                vm = JsonConvert.DeserializeObject<AllPagesViewModel>(data);

                DefaultLife = vm.DefaultLifePoint;
            }
            catch (Exception)
            {
                // ここは起動時に必ず読み込む
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


    }
}
