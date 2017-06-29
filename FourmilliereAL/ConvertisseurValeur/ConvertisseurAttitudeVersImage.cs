using System;
using System.Globalization;

namespace FourmilliereAL
{
    public class ConvertisseurAttitudeVersImage : ConvertisseurValeurBase<ConvertisseurAttitudeVersImage>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.ToString() == "AttitudeCombattante") {
                return "pack://application:,,,/Resources/warrior-ant.png";
            }
            
            if (value.ToString() == "AttitudeEnnemi") {
                return "pack://application:,,,/Resources/red-ant.png";
            }

            if(value.ToString() == "AttitudeCueilleuse") {
                return "pack://application:,,,/Resources/cueilleuse.png";
            }

            return "pack://application:,,,/Resources/default-ant.png";
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
