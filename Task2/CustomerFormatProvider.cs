using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// Help class for different representation Customer objects
    /// </summary>
    public class CustomerFormatProvider: IFormatProvider, ICustomFormatter
    {
        /// <summary>
        /// Parent provider
        /// </summary>
        private IFormatProvider _parentProvider;

        /// <summary>
        /// Keeps formats and their string representations
        /// </summary>
        private Dictionary<string, string> _formatList;

        #region Constructors
        public CustomerFormatProvider() : this(CultureInfo.CurrentCulture)
        {
        }

        public CustomerFormatProvider(IFormatProvider parent)
        {
            _parentProvider = parent;
        }
        #endregion

        /// <summary>
        /// IFormatProvider method returns IFormatProvider object
        /// </summary>
        /// <param name="formatType">Format type</param>
        /// <returns>IFormatProvider object</returns>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter)) return this;
                return null;
        }

        /// <summary>
        /// Format method version for Customer type
        /// </summary>
        /// <param name="format">Format string</param>
        /// <param name="arg">Customer object</param>
        /// <param name="formatProvider">Format provider for Customer</param>
        /// <returns></returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            Customer c = arg as Customer;
            if (c == null)
                throw new ArgumentException("Wrong type of argument");

            _formatList = new Dictionary<string, string>() 
            {
                { "N", c.Name },
                { "P", c.ContactPhone },
                { "R", c.Revenue.ToString() },
                { "NP", c.Name + ", " + c.ContactPhone },
                { "NR", c.Name + ", " + c.Revenue.ToString() },
                { "PR", c.ContactPhone + ", " + c.Revenue.ToString() },
                { "NPR", c.Name + ", " + c.ContactPhone + ", " + c.Revenue.ToString() }
            };

            foreach (string formatCode in _formatList.Keys)
            {
                if (format == formatCode)
                    return string.Format("Customer record: {0}",_formatList[formatCode]);
            }

            return "Unknown format for this type";
        }
    }
}
