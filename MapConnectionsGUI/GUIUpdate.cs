using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MapConnectionsGUI
{

    partial class MainWindow : Window
    {
        private readonly ImageBrush _ib = new ImageBrush();

        private void _setMapBackground()
        {
            //_ib.
            //if (cnvMap.IsInitialized)
            //{
            //    _ib.ImageSource = new BitmapImage(new Uri(@"Assets\Images\WorldMap.jpg", UriKind.Relative));
            //    cnvMap.Background = _ib;
            //}
        }

        private void _updateStatusBar()
        {
            if(tBStatusBar.IsInitialized)
                tBStatusBar.Text = $"Refresh rate: {_refreshFrequency}\tms";
        }
    }
}
