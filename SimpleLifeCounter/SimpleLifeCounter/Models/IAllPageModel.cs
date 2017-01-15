using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SimpleLifeCounter.Models
{
    public interface IAllPageModel : INotifyPropertyChanged
    {
        
        // ISaveAndLoad SaveAndLoad { get; set; }

        Setting Setting { get; set; }

        Color BackgroundColor { get; set; }
        Color LifeFontColor { get; set; }
        int DefaultLifePoint { get; set; }

        

        string JsonName { get; }
        string Message { get; set; }

        void CoinMessegeGenerate();

        void DiceMessegeGenerate();

        Task LoadData();

        Task SaveData();
    }
}
