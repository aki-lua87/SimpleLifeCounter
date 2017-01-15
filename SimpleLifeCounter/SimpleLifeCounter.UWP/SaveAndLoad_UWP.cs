using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Windows.UI.Xaml.Automation;
using PCLStorage;

namespace SimpleLifeCounter.UWP
{
    class SaveAndLoad_UWP : ISaveAndLoad
    {

        public string LoadData(string filename)
        {
            return testLoad(filename).Result;
        }

        public void SaveData(string filename, string text)
        {
            test(filename, text);
        }

        public bool ClearData(string filename)
        {
            return true;
        }

        public async Task test(string filename,string text)
        {
            await testSave(filename, text);
        }

        private async Task tempMethod1(string filename, string text)
        {
            Debug.WriteLine("（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）セーブ");
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync(filename, Windows.Storage.CreationCollisionOption.ReplaceExisting);
            await Windows.Storage.FileIO.WriteTextAsync(sampleFile, text);
            Debug.WriteLine("（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）セーブ完了");
        }

        private async Task<string> tempMefhod2(string filename)
        {
            Debug.WriteLine("（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）ロード");
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = await storageFolder.GetFileAsync(filename);
            return await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
        }

        private async Task testSave(string filename, string text)
        {
            Debug.WriteLine("（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）セーブs");
            IFolder rootFolder = FileSystem.Current.LocalStorage; 
            IFile file = await rootFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting); 
            await file.WriteAllTextAsync(text);
            Debug.WriteLine("（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）セーブe");
        }

        private async Task<string> testLoad(string filename)
        {
            Debug.WriteLine("（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）（´・ω・｀）ロード");
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFile file = await rootFolder.GetFileAsync(filename);
            return await file.ReadAllTextAsync();
        }
    }
}