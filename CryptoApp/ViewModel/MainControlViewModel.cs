using CryptoApp.Infrastructure;
using CryptoApp.Model;
using CryptoApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoApp.ViewModel
{
    internal class MainControlViewModel : BaseNotifyPropertyChanged
    {
        
        public List<Currency> currencies = new List<Currency>();
        public List<Currency> Currencies
        {
            get => currencies;
            set
            {
                currencies = value;
                NotifyPropertyChanged();
            }
        }
        public Currency selectedCurrency;
        public Currency SelectedCurrency
        {
            get => selectedCurrency;
            set
            {
                selectedCurrency = value;
                OpenCurrency();
            }
        }
        public MainControlViewModel()
        {
            Task<List<Currency>> task = Task.Run(() => NetworkManager.GetPage(0));
            Currencies = task.Result;
        }
        public void Searching(string parameter)
        {
            Task<List<Currency>> currencyTask = Task.Run(() => NetworkManager.Searching(parameter));
            Currencies = currencyTask.Result;
        }
        public void OpenCurrency()
        {
            CurrencyView cv = new CurrencyView();
            CurrencyViewModel currencyViewModel = (CurrencyViewModel)cv.DataContext;
            currencyViewModel.Currency = SelectedCurrency;
            Switcher.Switch(cv);
        }
        
    }
}
