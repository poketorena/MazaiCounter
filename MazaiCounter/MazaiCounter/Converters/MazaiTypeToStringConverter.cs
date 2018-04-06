using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Xamarin.Forms;
using MazaiCounter.Models;

namespace MazaiCounter.Converters
{
    public class MazaiTypeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return "NullError";
            }

            if (value is MazaiType type)
            {
                switch (type)
                {
                    case MazaiType.RedBull:
                        {
                            return "RedBull";
                        }

                    case MazaiType.Monster:
                        {
                            return "Monster";
                        }

                    case MazaiType.MonsterAbsolutelyZero:
                        {
                            return "Monster Absolutely Zero";
                        }

                    case MazaiType.MonsterKhaos:
                        {
                            return "Monster KHAOS";
                        }

                    case MazaiType.MonsterTheDoctor:
                        {
                            return "Monster THE DOCTOR";
                        }

                    default:
                        {
                            return "ArgumentError";
                        }
                }
            }
            else
            {
                return "TypeError";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
