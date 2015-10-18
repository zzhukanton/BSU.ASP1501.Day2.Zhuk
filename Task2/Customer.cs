using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Task2
{
    public class Customer
    {
        public string Name { get; set; }

        public string ContactPhone { get; set; }

        public decimal Revenue { get; set; }

        public Customer()
        {
        }

        public Customer(string name, string phone, decimal revenue)
        {
            Name = name;
            ContactPhone = phone;
            Revenue = revenue;
        }
    }
}
