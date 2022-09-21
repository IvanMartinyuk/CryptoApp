using CryptoApp.Infrastructure;
using CryptoApp.Model;
using CryptoApp.View;
using LiveCharts.Configurations;
using LiveCharts.Defaults;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
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
        ChartValues<ObservableValue> values;
        public ChartValues<ObservableValue> Values
        {
            get => values;
            set
            {
                values = value;
                NotifyPropertyChanged();
            }
        }
        CartesianMapper<ObservableValue> mapper;
        public CartesianMapper<ObservableValue> Mapper
        {
            get => mapper;
            set
            {
                mapper = value;
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
        public void SetChart(string name)
        {
            Task<ChartValues<ObservableValue>> task = Task.Run(() => NetworkManager.GetHistory(name));
            Values = task.Result;
            Mapper = Mappers.Xy<ObservableValue>()
                .X((item, index) => index)
                .Y(item => item.Value);

        }
    }
}
