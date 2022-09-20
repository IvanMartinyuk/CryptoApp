using CryptoApp.Infrastructure;
using CryptoApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.ViewModel
{
    internal class CurrencyViewModel : BaseNotifyPropertyChanged
    {
        public Currency currency;
        public Currency Currency 
        {
            get => currency;
            set
            { 
                currency = value;
                NotifyPropertyChanged();
            }
        }
        public CurrencyViewModel()
        {
            InitCommand();
        }

        private void InitCommand()
        {
            
        }
    }
}
