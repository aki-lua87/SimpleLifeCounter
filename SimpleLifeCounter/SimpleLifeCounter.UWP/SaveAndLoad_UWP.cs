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
        
        public string LoadData(string filename)
        {
            var json = JsonConvert.SerializeObject(new AllPageModel());
            return json;
        }

        public void SaveData(string filename, string text)
        {
            
        }

        public bool ClearData(string filename)
        {
            return true;
        }
        

        /*
        public string LoadData(string filename)
        {
            System.Diagnostics.Debug.WriteLine($"【Json is Load】");
            var task = LoadDataAsync(filename);
            System.Diagnostics.Debug.WriteLine($"【Json is Load2-1】");
            task.Wait();
            System.Diagnostics.Debug.WriteLine($"【Json is Load3[]】");
            return task.Result;
        }
        
        async Task<string> LoadDataAsync(string filename)
        {
            var local = Windows.Storage.ApplicationData.Current.LocalFolder;
            if (local != null)
            {
                var file = await local.GetItemAsync(filename);
                Stream stream = new MemoryStream(Encoding.Unicode.GetBytes(file.Path));
                System.Diagnostics.Debug.WriteLine($"【Json is Load2-2】");
                using (StreamReader streamReader = new StreamReader(stream))
                {
                    var text = streamReader.ReadToEnd();
                    System.Diagnostics.Debug.WriteLine($"【Json is Load2-3[]】");
                    return text;
                }
            }
            return "(´・ω・｀)";
        }
        
        public async void SaveData(string filename, string text)
        {
            var local = Windows.Storage.ApplicationData.Current.LocalFolder;
            var file = await local.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            using (StreamWriter writer = new StreamWriter(await file.OpenStreamForWriteAsync()))
            {
                writer.Write(text);
            }
            System.Diagnostics.Debug.WriteLine($"【Json is Save1】");
        }

        public bool ClearData(string filename)
        {
            return true;
        }

        /////////////////////////////////////////////////////LoadTest
        public async Task<string> LoadTextFileFromLocalFolderAsync(string fileName)
        {
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            if ((await folder.GetFilesAsync()).Where(q => q.Name == fileName).Any())
            {
                StorageFile file = await folder.GetFileAsync(fileName);
                return await FileIO.ReadTextAsync(file);
            }
            else
            {
                return "null";
            }
        }
        public async Task SaveTextFileToLocalFolderAsync(string fileName, string value)
        {
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            StorageFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, value);
            System.Diagnostics.Debug.WriteLine($"【Json is Save2】");
        }
        /////////////////////////////////////////////////////////
        */


    }
}