using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace WpfApp6
{
    public partial class WindowVideoPlayer : Window
    {
        public static DispatcherTimer timer = new DispatcherTimer();
        public WindowVideoPlayer()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_tick;
        }

        private void timer_tick(object sender, EventArgs e)
        {
            VideoSlider.Value = Convert.ToDouble(PleerMedia.Position.TotalSeconds);
        }

        private void backToPreviousIcon(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Back))
            {
                timer.Stop();
                PleerMedia.LoadedBehavior = MediaState.Close;
                PleerMedia.UnloadedBehavior = MediaState.Close;
                this.Visibility = Visibility.Hidden;
                MainWindow.ThisChoosedVideoWindow.Visibility = Visibility.Visible;
                MainWindow.ThisChoosedVideoWindow.ChoosedVideo.Close();
                MainWindow.ThisChoosedVideoWindow.ChoosedVideo.Play();
                
            }
        }
        private void backFromVideoPlayer(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            PleerMedia.LoadedBehavior = MediaState.Close;
            PleerMedia.UnloadedBehavior = MediaState.Close;
            this.Visibility = Visibility.Hidden;
            MainWindow.ThisChoosedVideoWindow.Visibility = Visibility.Visible;
           MainWindow.ThisChoosedVideoWindow.ChoosedVideo.LoadedBehavior = MediaState.Manual;
           MainWindow.ThisChoosedVideoWindow.ChoosedVideo.Play();
        }

        private void stopThisVideo(object sender, RoutedEventArgs e)
        {
            PleerMedia.LoadedBehavior = MediaState.Pause;
        }

        private void continueVideoPlayer(object sender, RoutedEventArgs e)
        {
            PleerMedia.LoadedBehavior = MediaState.Play;
        }
        private void ChangeValueOfVideoSlider(object sender, MouseButtonEventArgs e)
        {
            PleerMedia.Pause();
            PleerMedia.Position = new TimeSpan(0, 0, Convert.ToInt32(Math.Round(VideoSlider.Value)));
            PleerMedia.Play();
        }
        private void MouseEnter(object sender, MouseButtonEventArgs e)
        {
           // MessageBox.Show("Mouse double click");
            Point position = PointToScreen(Mouse.GetPosition(MainWindow.ThisVideoPlayerWindow));
            if (position.Y >= 800)
            {
                StackPanelWithElements.Visibility = Visibility.Visible;
            }
            else
            {
                StackPanelWithElements.Visibility = Visibility.Hidden;
            }
        }

        private void Close(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}