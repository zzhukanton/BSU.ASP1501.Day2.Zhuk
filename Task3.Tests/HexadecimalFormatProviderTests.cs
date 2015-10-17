using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task3;

namespace Task3.Tests
{
    [TestFixture]
    public class HexadecimalFormatProviderTests
    {
        [TestCase("{0:Hex}", 196, Result = "c4")]
        [TestCase("{0:E} in hexadecimal is {0:Hex}", 196, Result = "1,960000E+002 in hexadecimal is c4")]
        [TestCase("{0}", 200, Result = "200")]
        [TestCase("", 200, Result = "")]
        [TestCase(null, 200, ExpectedException = typeof(ArgumentNullException))]
        public string Format_ReturnHexadecimalNumber(string arg, int number)
        {
            string result;
            IFormatProvider fmt = new HexadecimalFormatProvider();

            result = string.Format(fmt, arg, number);

            return result;
        }
    }
}
