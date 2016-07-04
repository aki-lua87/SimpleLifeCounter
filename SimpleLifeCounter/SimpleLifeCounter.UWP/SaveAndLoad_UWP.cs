using System.IO;
using Xamarin.Forms;
using SimpleLifeCounter.UWP;
using System.Threading.Tasks;
using Windows.Storage;

using System;
using System.Text;
using System.Linq;
using SimpleLifeCounter.Models;
using Newtonsoft.Json;

[assembly: Dependency(typeof(SaveAndLoad_UWP))]

namespace SimpleLifeCounter.UWP
{

    class SaveAndLoad_UWP : ISaveAndLoad
    {
        private AllPageModel Model = new AllPageModel();
        public string LoadData(string filename)
        {
            var json = JsonConvert.SerializeObject(Model);
            return json;
        }

        public void SaveData(string filename, string text)
        {
            
        }

        public bool ClearData(string filename)
        {
            return true;
        }



    }
}