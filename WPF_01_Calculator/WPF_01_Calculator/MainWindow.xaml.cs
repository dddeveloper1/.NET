using System;
using System.Windows;
using System.Windows.Controls;

namespace WPF_01_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double firstOperand, secondOperand;
        bool isEqualUp = false;
        string symbol = String.Empty;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Koma_Click(object sender, RoutedEventArgs e)
        {
            if (lblResult.Content != null)
                if (!lblResult.Content.ToString().Contains(","))
                    lblResult.Content += (sender as Button).Content.ToString();
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {

            if (lblResult.Content == null)
                return;

            symbol = String.Empty;
            firstOperand = Convert.ToDouble(lblResult.Content.ToString());

            if (String.IsNullOrWhiteSpace(symbol))
            {
                symbol = (sender as Button).Content.ToString();
                lblResult.Content += symbol.ToString();

            }
            lblTemp.Content = lblResult.Content;
            lblResult.Content = null;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (lblResult.Content == null || lblResult.Content.ToString() == "")
                return;

            lblResult.Content = lblResult.Content.ToString().Remove(lblResult.Content.ToString().Length - 1);
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            lblResult.Content = lblTemp.Content = null;
            symbol = String.Empty;
        }

        private void CE_Click(object sender, RoutedEventArgs e)
        {
            if (!isEqualUp)
                lblResult.Content = null;
            else
            {
                C_Click(null, null);
                isEqualUp = false;
            }
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            if (lblResult.Content != null && firstOperand != 0 && symbol != String.Empty)
            {
                secondOperand = double.Parse(lblResult.Content.ToString());
                lblTemp.Content += secondOperand.ToString() + " = ";

                if (symbol == "/" && secondOperand == 0)
                {
                    lblResult.Content = "Cannot divide by zero.";
                    return;
                }
                if (symbol == "/")
                    firstOperand /= secondOperand;
                else if (symbol == "*")
                    firstOperand *= secondOperand;
                else if (symbol == "+")
                    firstOperand += secondOperand;
                else if (symbol == "-")
                    firstOperand -= secondOperand;


                lblResult.Content = firstOperand.ToString();
                firstOperand = secondOperand = 0;

                isEqualUp = true;
            }
        }

        private void Figure_Click(object sender, RoutedEventArgs e)
        {
            lblResult.Content += (sender as Button).Content.ToString();
        }


    }
}
