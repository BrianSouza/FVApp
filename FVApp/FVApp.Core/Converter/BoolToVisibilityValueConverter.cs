using MvvmCross.Platform.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using MvvmCross.Platform.UI;
using MvvmCross.Plugins.Color;
using MvvmCross.Plugins.Visibility;

namespace FVApp.Core.Converter
{
    //public class MvxBoolToColorValueConverter : MvxValueConverter<bool, MvxColor>
    //{

    //    protected override MvxColor Convert(bool value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        if (!value)
    //        {
    //            // FF0000
    //            return MvxColors.Red;
    //        }
    //        //227D41
    //        return MvxColors.Blue;
    //    }
    //}

    public class BoolToVisibilityValueConverter : MvxBaseVisibilityValueConverter<bool>
    {
        protected override MvxVisibility Convert(bool value, object parameter, CultureInfo culture)
        {
            if (!value)
                return MvxVisibility.Hidden;
            else
                return MvxVisibility.Visible;
        }
    }

   
}
