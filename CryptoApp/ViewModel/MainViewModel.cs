using CryptoApp.Infrastructure;
using CryptoApp.Model;
using CryptoApp.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CryptoApp.ViewModel
{
    internal class MainViewModel : BaseNotifyPropertyChanged, INavigate
    {
        public ICommand CloseCommand { get; set; }
        public ICommand LoadMainPage { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand ChangeMode { get; set; }
        Uri lightUrl = new Uri("https://img.icons8.com/ios/50/000000/light-on--v1.png");
        Uri darkUrl = new Uri("https://img.icons8.com/fluency-systems-regular/48/000000/light-off.png");
        string defaultModePath = "\\Themes\\Dark.xaml";
        string lightModePath = "\\Themes\\Light.xaml";
        string darkModePath = "\\Themes\\Dark.xaml";
        string selectedMode = "dark";
        ResourceDictionary resourceDictionary = new ResourceDictionary();
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
        ImageSource modeIcon;
        public ImageSource ModeIcon
        {
            get => modeIcon;
            set
            {
                modeIcon = value;
                NotifyPropertyChanged();
            }
        }

        public MainViewModel()
        {
            Switcher.Content = this;
            Switcher.Switch(new MainControl());
            ChangeTheme(defaultModePath);
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
                catch {
                    var view = new MainControl();                    
                    MainControlViewModel vm = (MainControlViewModel)view.DataContext;
                    vm.Searching(x.ToString());
                    Switcher.Switch(view);
                }
            });
            ChangeMode = new RelayCommand(x =>
            {
                if (selectedMode.Equals("dark"))
                {
                    ChangeTheme(lightModePath);
                    selectedMode = "light";
                }
                else if (selectedMode.Equals("light"))
                {
                    ChangeTheme(darkModePath);
                    selectedMode = "dark";
                }
            });
        }
        public void Navigate(UserControl control)
        {
            Control = control;
        }
        public void ChangeTheme(string path)
        {
            string p = Path.GetDirectoryName(Path.GetDirectoryName(Environment.CurrentDirectory));
            p = Directory.GetParent(p).FullName;
            resourceDictionary.Source = new Uri(p + path);
            Application.Current.MainWindow.Resources = resourceDictionary;
            if(path == lightModePath)
                ModeIcon = new BitmapImage(lightUrl);
            if (path == darkModePath)
                ModeIcon = new BitmapImage(darkUrl);
        }
    }
}
