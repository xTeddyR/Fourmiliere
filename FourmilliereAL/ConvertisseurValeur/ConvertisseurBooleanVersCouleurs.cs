using System;
using System.Globalization;
using System.Windows;

namespace FourmilliereAL
{
    public class ConvertisseurBooleanVersCouleurs : ConvertisseurValeurBase<ConvertisseurBooleanVersCouleurs>
    {

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if((Boolean)value == true) {
                return App.Current.FindResource("SecondaryDarkBrush");
            }

            return App.Current.FindResource("DisableLightBrush");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
