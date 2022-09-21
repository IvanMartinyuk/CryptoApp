using CryptoApp.Infrastructure;
using CryptoApp.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace CryptoApp.ViewModel
{
    internal class CurrencyViewModel : BaseNotifyPropertyChanged
    {
        public ICommand OpenBrowser { get; set; }
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
            OpenBrowser = new RelayCommand(x =>
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = Currency.MarketURL,
                    UseShellExecute = true
                });
            });
        }
    }
}
