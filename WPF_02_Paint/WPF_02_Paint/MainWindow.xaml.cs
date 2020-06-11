using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_02_Paint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            start.IsChecked = true;

            for (int i = 8; i < 72; i += 2)
                cbSize.Items.Add(i);

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            foreach (var item in stackpanel.Children)
            {
                if (item is RadioButton)
                {
                    RadioButton rb = item as RadioButton;
                    if ((bool)rb.IsChecked)
                        ink.EditingMode = (InkCanvasEditingMode)Enum.Parse(typeof(InkCanvasEditingMode), rb.Content.ToString());
                }
            }
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "str file(*.str)|*.str";
            if(ofd.ShowDialog() == true)
                ink.Strokes = new StrokeCollection(new FileStream(ofd.FileName, FileMode.Open));
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "STR file(*.str)|*.str";
            if (sfd.ShowDialog() == true)
                ink.Strokes.Save(new FileStream(sfd.FileName, FileMode.Create));
        }

        private void Size_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ink.DefaultDrawingAttributes.Width = ink.DefaultDrawingAttributes.Height = Convert.ToDouble(cbSize.SelectedItem);
        }

        private void Color_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ink.DefaultDrawingAttributes.Color = (Color)ColorConverter.ConvertFromString((cbColor.SelectedItem as Label).Content.ToString());
        }
    }
}
