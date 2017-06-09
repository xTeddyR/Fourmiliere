using System;
using System.Globalization;
using System.Windows;

namespace FourmilliereAL
{
    public class ConvertisseurAttitudeVersCouleurs : ConvertisseurValeurBase<ConvertisseurAttitudeVersCouleurs>
    {

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(parameter != null) {
                if (value.ToString() == "AttitudeCombattante") {
                    return App.Current.FindResource("SecondaryDarkBrush");
                }

                return App.Current.FindResource("PrimaryDarkBrush");
            }

            if(value.ToString() == "AttitudeCombattante") {
                return App.Current.FindResource("SecondaryBrush");
            }

            return App.Current.FindResource("PrimaryBrush");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
