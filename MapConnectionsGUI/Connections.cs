using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using MapConnections;

namespace MapConnectionsGUI
{

    partial class MainWindow
    {
        private bool _isRunning;
        private const int RefreshFrequencyDefault = 100;
        private int _refreshFrequency = RefreshFrequencyDefault;
        private readonly ListConnections _lc = new ListConnections();

        private void _initializeConnections()
        {
            ConnectionsList_dataGrid.DataContext = _lc.ActiveConnections;
        }

        internal Image CreateMarker()
        {
            var marker = new Image
            {
                Width = 32,
                Height = 32,
                Source = new BitmapImage(new Uri(@"Assets\Images\LocationMarker.png", UriKind.Relative))
            };
            return marker;
        }

        private void _drawGeoMarkers()
        {
            cnvMap.Children.Clear();
            foreach (var m in _lc.ActiveConnections)
            {
                var img = CreateMarker();
                //TODO: Currently markers are placed with no respect to resized background and longitude/latitude is not notmalized from -+180w/-+90h to canvas size
                //TODO: For a reason markers stopped appearing.
                //var ratio = Math.Min(cnvMap.RenderSize.Width / _ib.ImageSource.Width, cnvMap.RenderSize.Height / _ib.ImageSource.Height);
                //var imageBrushWidth = _ib.ImageSource.Width * ratio;
                //var imageBrushHeight = _ib.ImageSource.Height * ratio;
                Canvas.SetLeft(img, 100+m.Longitude.GetValueOrDefault());
                Canvas.SetTop(img, 100+m.Latitude.GetValueOrDefault());
                cnvMap.Children.Add(img);
            }

        }

        private void _continousUpdateListing()
        {
            if (_isRunning) return;
            _isRunning = true;
            _refreshFrequency = RefreshFrequencyDefault;
            try
            {
                while (_isRunning)
                {
                    var watch = Stopwatch.StartNew();
                    //TODO: Sometimes throws Null exception
                    Application.Current.Dispatcher.Invoke(_updateStatusBar);
                    Application.Current.Dispatcher.Invoke(_lc.PopulateList);
                    Application.Current.Dispatcher.Invoke(_drawGeoMarkers);
                    watch.Stop();

                    if (watch.ElapsedMilliseconds + 150 >= _refreshFrequency)
                        _refreshFrequency = ((int)watch.ElapsedMilliseconds +
                                             150);
                    Thread.Sleep(_refreshFrequency);
                }
            }
            catch (TaskCanceledException)
            {
                _isRunning = false;
            }
        }
    }
}
