using System.IO;
using Xamarin.Forms;
using SimpleLifeCounter.Droid;

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
    }
}