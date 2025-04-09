using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Claneder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded +=    MainWindow_Loaded;
            
            TimerStart();
            PopulateDateInfo();
            //StartBlinking("Blinking");
            PopulateWeatherInfo();
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {

       
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

      

       
    }
}
