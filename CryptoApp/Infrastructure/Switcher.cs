using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CryptoApp.Infrastructure
{
    public static class Switcher
    {
        public static INavigate Content { get; set; }
        public static void Switch(UserControl userControl) => Content.Navigate(userControl);
    }
}
