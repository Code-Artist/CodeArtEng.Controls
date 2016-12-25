using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;

namespace System.ComponentModel
{
    /// <summary>
    /// Improved implementation of <see cref="DateTimeConverter"/> with intention to fix issue where 
    /// where time at 12:00 AM is not display.
    /// </summary>
    public class DateTimeConverter2 : DateTimeConverter
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public DateTimeConverter2() : base() { }

        /// <summary>
        /// Convert from <see cref="DateTime"/> to <see cref="string"/>
        /// </summary>
        /// <param name="context"></param>
        /// <param name="culture"></param>
        /// <param name="value"></param>
        /// <param name="destinationType"></param>
        /// <returns></returns>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            string dateTimeString = value.ToString();
            return dateTimeString;
        }
    }
}
