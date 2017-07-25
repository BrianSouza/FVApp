using MvvmCross.Platform.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using MvvmCross.Platform.UI;

namespace FVApp.Core.Converter
{
    public class MvxBoolToColorValueConverter : MvxValueConverter<bool, MvxColor>
    {

        protected override MvxColor Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value)
            {
                // FF0000
                return new MvxColor(255, 0, 0);
            }
            //227D41
            return new MvxColor(34, 125, 65);
        }

    }
}
