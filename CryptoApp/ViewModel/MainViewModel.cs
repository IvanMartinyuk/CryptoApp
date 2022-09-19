using CryptoApp.Infrastructure;
using CryptoApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoApp.ViewModel
{
    internal class MainViewModel : BaseNotifyPropertyChanged
    {
        public ICommand CloseCommand { get; set; }
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
        public MainViewModel()
        {
            Task<List<Currency>> task = Task.Run(() => CoinCapParser.GetPage(0));
            Currencies = task.Result;
            InitCommand();
        }
        private async Task GetDataAsync()
        {
            
        }
        private void InitCommand()
        {
            CloseCommand = new RelayCommand(x => ((MainView)x).Close());
        }
    }
}
