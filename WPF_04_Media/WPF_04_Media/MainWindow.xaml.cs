using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WPF_04_Media
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick; ;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if(Media.Source != null && Media.NaturalDuration.HasTimeSpan)
            {
                TimeLine.Minimum = 0;
                TimeLine.Value = Media.Position.TotalSeconds;
            }
        }

        private void Media_MediaOpened(object sender, RoutedEventArgs e)
        {
            TimeLine.Maximum = Media.NaturalDuration.TimeSpan.TotalSeconds;
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
                Media.Source = new Uri(ofd.FileName);
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            Media.Play();
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            Media.Stop();
        }

        private void Mute_Click(object sender, RoutedEventArgs e)
        {
            Media.Volume = 0;
        }

        private void TimeLine_LostMouseCapture(object sender, MouseEventArgs e)
        {
            TimeSpan timeSpan = new TimeSpan(0, 0, Convert.ToInt32(Math.Round(TimeLine.Value)));
            Media.Position = timeSpan;
        }
    }
}
