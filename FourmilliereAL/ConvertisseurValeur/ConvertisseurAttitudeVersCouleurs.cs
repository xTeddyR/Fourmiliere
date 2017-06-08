using System;
using System.Globalization;
using System.Windows;

namespace FourmilliereAL
{
    public class ConvertisseurAttitudeVersCouleurs : ConvertisseurValeurBase<ConvertisseurAttitudeVersCouleurs>
    {

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            App.Current.FindResource("PrimaryLightBrush");

            if(value.ToString() == "AttitudeCombattante") {
                return App.Current.FindResource("SecondaryLightBrush");
            }

            return App.Current.FindResource("PrimaryLightBrush");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
