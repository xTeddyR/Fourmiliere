using System;
using System.Globalization;
using System.Windows;

namespace FourmilliereAL
{
    public class ConvertisseurHeureVersHeureFormatter : ConvertisseurValeurBase<ConvertisseurHeureVersHeureFormatter>
    {

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if((int)value < 10) {
                return "0" + value;
            }

            return value;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
