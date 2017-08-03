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
using Android.Opengl;
using MvvmCross.Platform.Converters;
using System.Globalization;


namespace FVApp.Droid.Converters
{
    public class BoolToVisibilityValueConverter : MvxValueConverter<bool, ViewStates>
    {
        protected override ViewStates Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            //return base.Convert(value, targetType, parameter, culture);
            if (!value)
                return ViewStates.Gone;
            else
                return ViewStates.Visible;
        }
    }
}