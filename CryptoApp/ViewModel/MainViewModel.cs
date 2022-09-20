using CryptoApp.Infrastructure;
using CryptoApp.Model;
using CryptoApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CryptoApp.ViewModel
{
    internal class MainViewModel : BaseNotifyPropertyChanged, INavigate
    {
        public ICommand CloseCommand { get; set; }
        public ICommand LoadMainPage { get; set; }
        public ICommand SearchCommand { get; set; }
        UserControl control;
        public UserControl Control 
        {
            get => control;
            set
            {
                control = value;
                NotifyPropertyChanged();
            }
        }
        string searchText;
        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                NotifyPropertyChanged();
            }
        }

        
        //        try
        //        {
        //            MainControlViewModel vm = (MainControlViewModel)Control.DataContext;
        //vm.Searching(searchText);
        //        }
        //        catch { }

        public MainViewModel()
        {
            Switcher.Content = this;
            Switcher.Switch(new MainControl());

            InitCommand();
        }
        private void InitCommand()
        {
            CloseCommand = new RelayCommand(x => ((MainView)x).Close());
            LoadMainPage = new RelayCommand(x => Switcher.Switch(new MainControl()));
            SearchCommand = new RelayCommand(x =>
            {
                try
                {
                    MainControlViewModel vm = (MainControlViewModel)Control.DataContext;
                    vm.Searching(x.ToString());
                }
                catch { }
            });
        }
        public void Navigate(UserControl control)
        {
            Control = control;
        }
    }
}
