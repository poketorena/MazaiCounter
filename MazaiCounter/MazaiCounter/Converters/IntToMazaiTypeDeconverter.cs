using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Globalization;
using MazaiCounter.Models;

namespace MazaiCounter.Converters
{
    class IntToMazaiTypeDeconverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }
            if (value is int num)
            {
                return (MazaiType)Enum.ToObject(typeof(MazaiType), num);

            }
            throw new ArgumentException();
        }
    }
}
