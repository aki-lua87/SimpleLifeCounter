using System.IO;
using Newtonsoft.Json;
using Xamarin.Forms;
using SimpleLifeCounter.Droid;
using SimpleLifeCounter.Models;

namespace SimpleLifeCounter.Droid
{
    class SaveAndLoad_Android : ISaveAndLoad
    {
        public void SaveData(string filename, string text)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            System.IO.File.WriteAllText(filePath, text);
        }
        public string LoadData(string filename)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = System.IO.Path.Combine(documentsPath, filename);
            if (System.IO.File.Exists(filePath))
            {
                return System.IO.File.ReadAllText(filePath);
            }
            return null;

        }
        public bool ClearData(string filename)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = System.IO.Path.Combine(documentsPath, filename);
            System.IO.File.Delete(filePath);
            return (!System.IO.File.Exists(filePath));
        }

        private string testJson()
        {
            Setting Setting = new Setting();
            Setting.BackgroundColorIndex = 7;
            Setting.LifeColorIndex = 11;
            Setting.LifeIndex = 2;
            Setting.LifeResetCheck = true;
            Setting.BigButtonCheck = true;
            Setting.SubCounterCheck = false;

            var json = JsonConvert.SerializeObject(Setting);
            return json;
        }
    }
}