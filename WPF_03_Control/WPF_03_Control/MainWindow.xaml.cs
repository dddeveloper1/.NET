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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace WPF_03_Control
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<Customer> customers { get; set; } = new List<Customer>();

        public MainWindow()
        {
            InitializeComponent();
            cbCustomerType.Items.Add("Normal");
            cbCustomerType.Items.Add("VIP");

            LoadCustomers();

            
        }

        private void LoadCustomers()
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Customer>));
                string file = "customers.xml";
                using (Stream stream = new FileStream(file, FileMode.Open, FileAccess.Read))
                    customers = (List<Customer>)xml.Deserialize(stream);
                //foreach (Customer item in customers)
                //    lbCustomers.Items.Add(item);
                lbCustomers.ItemsSource = customers;
                lbCustomers.DisplayMemberPath = "FirstName";
            }
            catch { }
        }

        private void SaveCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(cbCustomerType.Text) &&
                !String.IsNullOrWhiteSpace(tbFirstName.Text) &&
                !String.IsNullOrWhiteSpace(tbLastName.Text) &&
                !String.IsNullOrWhiteSpace(tbEmail.Text))
            {
                Customer customer = new Customer
                {
                    CustomerType = cbCustomerType.Text,
                    FirstName = tbFirstName.Text,
                    LastName = tbFirstName.Text,
                    Email = tbEmail.Text
                };

                customers.Add(customer);
                lbCustomers.Items.Add(customer);

                cbCustomerType.Text = tbEmail.Text = tbFirstName.Text = tbLastName.Text = "";
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string file = "customers.xml";
            XmlSerializer xml = new XmlSerializer(customers.GetType());
            using (Stream stream = new FileStream(file, FileMode.Create, FileAccess.Write))
            {
                xml.Serialize(stream, customers);
            }
        }
    }
}
