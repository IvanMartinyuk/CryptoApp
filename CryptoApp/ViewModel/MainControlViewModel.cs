using CryptoApp.Infrastructure;
using CryptoApp.Model;
using CryptoApp.View;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CryptoApp.ViewModel
{
    internal class MainControlViewModel : BaseNotifyPropertyChanged
    {
        int i = 0;
        bool isSelectedEnter = false;
        string plusImage = "\\plus.png";
        ImageSource logoFrom;
        int indexFrom = -1;
        int indexTo = -1;
        bool isSetFrom = false;
        bool isSetTo = false;
        public ICommand CalculateFrom { get; set; }
        public ICommand CalculateTo { get; set; }
        public ICommand CalculateCommand { get; set; }
        public ImageSource LogoFrom
        {
            get => logoFrom;
            set
            {
                logoFrom = value;
                NotifyPropertyChanged();
            }
        }
        ImageSource logoTo;
        public ImageSource LogoTo
        {
            get => logoTo;
            set
            {
                logoTo = value;
                NotifyPropertyChanged();
            }
        }
        string currencyFromName = "Bitcoin";
        public string CurrencyFromName
        {
            get => currencyFromName;
            set
            {
                currencyFromName = value;
                NotifyPropertyChanged();
            }
        }
        string calculateResult;
        public string CalculateResult
        {
            get => calculateResult;
            set
            {
                calculateResult = value;
                NotifyPropertyChanged();
            }
        }
        //string countText;
        //public string CountText
        //{
        //    get => countText;
        //    set
        //    {
        //        countText = value;
        //        NotifyPropertyChanged();
        //    }
        //}
        double countValue = 0;
        double percentValue = 0;
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
                NotifyPropertyChanged();
                if(!isSelectedEnter)
                    OpenCurrency();
            }
        }
        public MainControlViewModel()
        {
            Task<List<Currency>> task = Task.Run(() => NetworkManager.GetPage(0));
            Currencies = task.Result;
            Uri uri = new Uri(Environment.CurrentDirectory + plusImage);
            LogoFrom = new BitmapImage(uri);
            LogoTo = new BitmapImage(uri);
            InitCommand();
        }

        private void InitCommand()
        {
            CalculateFrom = new RelayCommand(x => isSetFrom = true);
            CalculateTo = new RelayCommand(x => isSetTo = true);
            CalculateCommand = new RelayCommand(x =>
            {
                TextBox textBox = (TextBox)x;
                try
                {
                    countValue = Convert.ToDouble(textBox.Text);
                    percentValue = Convert.ToDouble(textBox.Tag);
                    Calculate();
                }
                catch { }
            });
        }

        public void Searching(string parameter)
        {
            Task<List<Currency>> currencyTask = Task.Run(() => NetworkManager.Searching(parameter));
            Currencies = currencyTask.Result;
        }
        public void OpenCurrency()
        {
            isSelectedEnter = true;
            i++;            
            Task.Run(() => IClear());
            if (i == 2)
            {
                CurrencyView cv = new CurrencyView();
                CurrencyViewModel currencyViewModel = (CurrencyViewModel)cv.DataContext;
                currencyViewModel.Currency = SelectedCurrency;
                Switcher.Switch(cv);
            }
            if(i == 1)
            {
                if (isSetFrom)
                {
                    LogoFrom = new BitmapImage(new Uri(SelectedCurrency.ImageUrl));
                    indexFrom = Currencies.FindIndex(x => x.Id == SelectedCurrency.Id);
                    isSetFrom = false;
                    Calculate();
                }
                if (isSetTo)
                {
                    LogoTo = new BitmapImage(new Uri(SelectedCurrency.ImageUrl));
                    indexTo = Currencies.FindIndex(x => x.Id == SelectedCurrency.Id);
                    isSetTo = false;
                    Calculate();
                }
            }
            SelectedCurrency = null;
            isSelectedEnter = false;
        }
        public void Calculate()
        {
            if(indexTo != -1 && indexFrom != -1)
            {
                Currency from = Currencies[indexFrom];
                Currency to = Currencies[indexTo];
                double usd = from.PriceUsd * countValue;
                double result = usd / to.PriceUsd;
                result -= result * (percentValue / 100);
                CalculateResult = Math.Round(result, 2).ToString();
            }
        }

        private async Task IClear()
        {
            Thread.Sleep(400);
            i = 0;
        }
    }
}
