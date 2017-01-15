using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PCLStorage;
using Xamarin.Forms;
using SimpleLifeCounter.Droid;
using SimpleLifeCounter.Models;

namespace SimpleLifeCounter.Droid
{
    
    class SaveAndLoad_Android : ISaveAndLoad
    {
        IFolder rootFolder = FileSystem.Current.LocalStorage;

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

        //public string LoadData(string filename)
        //{
        //    Debug.WriteLine("（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）111111111111111111start");
        //    return getLoadData(filename).Result;
        //}

        //public void SaveData(string filename, string text)
        //{
        //    Debug.WriteLine("（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）222222222222222222start");
        //    setSaveData(filename, text);
        //}

        //public bool ClearData(string filename)
        //{
        //    return true;
        //}

        //private async Task<string> getLoadData(string filename)
        //{
        //    IFolder rootFolder = FileSystem.Current.LocalStorage;
        //    Debug.WriteLine("（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）1111111111111111111sterp1");

        //    ExistenceCheckResult res1 = await rootFolder.CheckExistsAsync("name.txt");
        //    if (res1 != ExistenceCheckResult.FileExists)
        //    {
        //        Debug.WriteLine("（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）1111111111111111111sterp1");
        //    }
        //    else
        //    {
        //        Debug.WriteLine("（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）1111111111111111111sterp2");
        //    }

        //    ExistenceCheckResult res = await rootFolder.CheckExistsAsync(filename);
        //    Debug.WriteLine("（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）1111111111111111111sterp");
        //    if (res == ExistenceCheckResult.FileExists)
        //    {
        //        Debug.WriteLine("（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）111111111111111111OK");
        //        IFile file = await rootFolder.GetFileAsync(filename);
        //        return await file.ReadAllTextAsync();
        //    }
        //    else
        //    {
        //        Debug.WriteLine("（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）111111111111111111ﾀﾞﾒｰ");
        //        return null;
        //    }

        //}

        //private async void setSaveData(string filename, string text)
        //{
        //    var rootFolder = FileSystem.Current.LocalStorage;
        //    var file = await rootFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
        //    await file.WriteAllTextAsync(text);
        //    Debug.WriteLine("（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）222222222222222222222222End");
        //}
    }
}