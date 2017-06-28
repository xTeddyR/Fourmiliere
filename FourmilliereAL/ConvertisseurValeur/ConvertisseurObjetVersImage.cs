using System;
using System.Globalization;

namespace FourmilliereAL
{
    public class ConvertisseurObjetVersImage : ConvertisseurValeurBase<ConvertisseurObjetVersImage>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.ToString() == "Baton") {
                return "pack://application:,,,/Resources/axe.png";
            }
            
            if (value.ToString() == "Panier") {
                return "pack://application:,,,/Resources/basket.png";
            }

            return "pack://application:,,,/Resources/axe.png";
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
