using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLifeCounter.Models
{
    public interface IAllPageModel : INotifyPropertyChanged
    {
        ISaveAndLoad SaveAndLoad { get; set; }

        Setting Setting { get; set; }

        string Message { get; set; }

        void CoinMessegeGenerate();

        void DiceMessegeGenerate();
    }
}
