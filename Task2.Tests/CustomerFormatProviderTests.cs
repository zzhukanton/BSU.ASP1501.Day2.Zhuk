using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task2;

namespace Task2.Tests
{
    [TestFixture]
    public class CustomerFormatProviderTests
    {
        private IFormatProvider fp = new CustomerFormatProvider();
        private static Customer c = new Customer("Anton", "+375298708064", (decimal)650000.15);

        [TestCase("{0:N}", Result = "Customer record: Anton")]
        [TestCase("{0:P}", Result = "Customer record: +375298708064")]
        [TestCase("{0:R}", Result = "Customer record: 650000,15")]
        [TestCase("{0:NP}", Result = "Customer record: Anton, +375298708064")]
        [TestCase("{0:NR}", Result = "Customer record: Anton, 650000,15")]
        [TestCase("{0:PR}", Result = "Customer record: +375298708064, 650000,15")]
        [TestCase("{0:NPR}", Result = "Customer record: Anton, +375298708064, 650000,15")]
        [TestCase("{0}", Result = "Unknown format for this type")]
        public string Format_StringOutputOfCustomerWithFormat(string format)
        {
            return String.Format(fp, format, c);
        }

        [TestCase("{0:N}", ExpectedException = typeof(ArgumentException))]
        public string Format_NotCustomer(string format)
        {
            StringBuilder s = new StringBuilder("123");
            return String.Format(fp, format, s);
        }
    }
}
