using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Platform.Converters;
using Android.Graphics;
using System.Globalization;

namespace FVApp.Droid.Converters
{


    public class BoolToColorValueConverter : MvxValueConverter<bool, Color>
    {
        private static readonly Color ErrorTextColor = new Color(255, 0, 0);
        private static readonly Color StandardTextColor = new Color(16, 214, 125);

        protected override Color Convert(bool value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!value)
                return ErrorTextColor;
            else
                return StandardTextColor;
        }
    }
}