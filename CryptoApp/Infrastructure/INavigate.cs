using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CryptoApp.Infrastructure
{
    public interface INavigate
    {
        void Navigate(UserControl userControl);
    }
}
