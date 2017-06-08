using System;
using System.Globalization;

namespace FourmilliereAL
{
    public class ConvertisseurAttitudeVersImage : ConvertisseurValeurBase<ConvertisseurAttitudeVersImage>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value.ToString() == "AttitudeCombattante") {
                return "../../Media/warrior-ant.png";
            }

            return "../../Media/default-ant.png";
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
