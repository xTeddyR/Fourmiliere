using System;
using System.Globalization;

namespace FourmilliereAL
{
    public class ConvertisseurAttitudeVersImage : ConvertisseurValeurBase<ConvertisseurAttitudeVersImage>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.ToString() == "AttitudeCombattante") {
                return "pack://application:,,,/Media/warrior-ant.png";
            }
            
            if (value.ToString() == "AttitudeEnnemi") {
                return "pack://application:,,,/Media/red-ant.png";
            }

            return "pack://application:,,,/Media/default-ant.png";
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
