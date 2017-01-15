using System;
using PCLStorage;
using Xamarin.Forms;

namespace SimpleLifeCounter.Views
{
    public partial class PrismContentPage1 : ContentPage
    {
        IFolder rootFolder = FileSystem.Current.LocalStorage;
        public PrismContentPage1()
        {
            InitializeComponent();

            test1();
        }

        private void SaveClicked(object sender, EventArgs e)
        {
            test2();
        }

        private void LoadClicked(object sender, EventArgs e)
        {
            test1();
        }

        private async void DeleteClicked(object sender, EventArgs e)
        {
            ExistenceCheckResult res = await rootFolder.CheckExistsAsync("name.txt");
            if (res == ExistenceCheckResult.FileExists)
            {
                IFile file = await rootFolder.GetFileAsync("name.txt");
                await file.DeleteAsync();
                loadedLabel.Text = "";
            }
        }

        private async void test1()
        {
            ExistenceCheckResult res = await rootFolder.CheckExistsAsync("name.txt");
            if (res == ExistenceCheckResult.FileExists)
            {
                IFile file = await rootFolder.GetFileAsync("name.txt");
                string name = await file.ReadAllTextAsync();
                loadedLabel.Text = name;
            }
            else
            {
                await DisplayAlert("Error", "File is not found", "OK");
            }
        }

        private async void test2()
        {
            IFile file = await rootFolder.CreateFileAsync("name.txt", CreationCollisionOption.ReplaceExisting);
            await file.WriteAllTextAsync(entry.Text);
        }
    }
}
