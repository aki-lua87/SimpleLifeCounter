using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using SimpleLifeCounter.Models;

namespace SimpleLifeCounter.ViewModels
{
    class DicePageViewModel : BindableBase
    {
        private AllPageModel Model = new AllPageModel();
        private string _leftDice, _rightDice;

        public string LeftDice
        {
            get { return _leftDice; }
            set { this.SetProperty(ref this._leftDice, value); }
        }

        public string RightDice
        {
            get { return _rightDice; }
            set { this.SetProperty(ref this._rightDice, value); }
        }

        public void DiceRoll()
        {
            var (_leftDice, _rightDice) = Model.DiceMessegeGenerate();
            LeftDice = _leftDice;
            RightDice = _rightDice;
        }
    }
}
