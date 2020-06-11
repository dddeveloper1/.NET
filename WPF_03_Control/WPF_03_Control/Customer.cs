using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_03_Control
{
    [Serializable]
    public class Customer
    {
        public string CustomerType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public Customer()
        {

        }

        //public override string ToString()
        //{
        //    return $"{CustomerType}\t{FirstName}\t{LastName}\t{Email}";
        //}
    }
}
