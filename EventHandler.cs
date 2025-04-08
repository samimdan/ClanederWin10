using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Claneder
{
    sealed partial class MainWindow:Window 
    {
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            WindowAppearanceUtilities.EnableBlur(this);
            WindowAppearanceUtilities.SetWindowTopMost(this);
        }
     
    }
}
