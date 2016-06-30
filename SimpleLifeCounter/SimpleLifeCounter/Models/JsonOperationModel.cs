using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SimpleLifeCounter.Models
{
    public class JsonOperationModel
    {
        public AllPageModel JsonRead()
        {
            try
            {
                var data = DependencyService.Get<ISaveAndLoad>().LoadData("temp.json");
                // vm = JsonConvert.DeserializeObject<AllPagesViewModel>(data);
                return JsonConvert.DeserializeObject<AllPageModel>(data);
            }
            catch (Exception)
            {
                return JsonRead();
            }
        }

        public void JsonWrite(AllPageModel vm)
        {
            var json = JsonConvert.SerializeObject(vm);
            DependencyService.Get<ISaveAndLoad>().SaveData("temp.json", json);
        }




    }
}
