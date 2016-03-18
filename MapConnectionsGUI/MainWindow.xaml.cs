using System.Threading;
using System.Windows;

namespace MapConnectionsGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            _initializeConnections();
        }

        private void Start_Button_Click(object sender, RoutedEventArgs e)
        {
            var t = new Thread(_continousUpdateListing);
            t.Start();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e) => _isRunning = false;
        private void miAbout_Click(object sender, RoutedEventArgs e) => MessageBox.Show(
                "This product includes GeoLite data created by MaxMind, available from http://www.maxmind.com.");
        private void miExit_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();

        private void StatusBar_Initialized(object sender, System.EventArgs e) =>
            _updateStatusBar();

        private void cnvMap_Initialized(object sender, System.EventArgs e) => _setMapBackground();
    }
}
