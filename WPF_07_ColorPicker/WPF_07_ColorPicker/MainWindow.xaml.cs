using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPF_07_ColorPicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<string> colors = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();
            slider0.Value = 255;
            lbColors.ItemsSource = colors;
        }

        private void checkExistColorInCollection()
        {
            bool checkExist = false;

            for (int i = 0; i < colors.Count; i++)
            {
                if (lblPreviewColor.Background.ToString() == colors[i])
                {
                    btnAdd.IsEnabled = false;
                    checkExist = true;
                }
            }

            if (!checkExist)
                btnAdd.IsEnabled = true;
        }

        private void slider0_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lblPreviewColor.Background = new SolidColorBrush(Color.FromArgb((byte)slider0.Value, (byte)slider1.Value, (byte)slider2.Value, (byte)slider3.Value));
            checkExistColorInCollection();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            colors.Add(lblPreviewColor.Background.ToString());
            btnAdd.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            colors.Remove((string)btn.DataContext);
        }
    }
}
