using System;
using System.Globalization;
using FourmilliereAL.Core;

namespace FourmilliereAL
{
    public class ConvertisseurMeteoVersImage : ConvertisseurValeurBase<ConvertisseurMeteoVersImage>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((MeteoType)value == MeteoType.Jour) {
                return "pack://application:,,,/Resources/Meteo/sun.png";
            }

            return "pack://application:,,,/Resources/Meteo/moon.png";
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
