using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// Class for representation integer in hexadecimal notation
    /// </summary>
    public class HexadecimalFormatProvider : IFormatProvider, ICustomFormatter
    {
        /// <summary>
        /// Hexadecimal digits
        /// </summary>
        private string _digits16 = "0123456789abcdef";

        /// <summary>
        /// Allow using many format providers
        /// </summary>
        IFormatProvider _parent;


        public HexadecimalFormatProvider() : this(CultureInfo.CurrentCulture) { }

        public HexadecimalFormatProvider(IFormatProvider parent)
        {
            _parent = parent;
        }

        /// <summary>
        /// IFormatProvider member for getting ICustomFormatter object 
        /// </summary>
        /// <param name="formatType">Format type</param>
        /// <returns>ICustomFormatter object</returns>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            return null;
        }

        /// <summary>
        /// Hexadecimal string representation of integer 
        /// </summary>
        /// <param name="format">String with format(s)</param>
        /// <param name="arg">Integer number</param>
        /// <param name="formatProvider">IFormatProvider object implements hexadecimal view</param>
        /// <returns>String hexadecimal representation of integer</returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg == null)
                throw new ArgumentNullException("String is null");

            if (format != "Hex" || arg.GetType() != typeof(Int32))
                return string.Format(_parent, "{0:" + format + "}", arg);

            int number = (Int32)arg;
            StringBuilder result = new StringBuilder();

            while (number != 0)
            {
                int digit10 = number % 16;
                result.Append(_digits16[digit10]);
                number /= 16;
            }
            char[] helpArray = result.ToString().ToCharArray();
            Array.Reverse(helpArray);

            return new string(helpArray);
        }
    }
}
