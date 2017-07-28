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
using Android.Util;
using Android.Graphics;

namespace FVApp.Droid.CustomBinding
{
    public class ExtendedTextView : TextView
    {
        public ExtendedTextView(Context context) : base(context) { }
        public ExtendedTextView(Context context, IAttributeSet attrs) : base(context, attrs) { }
        public ExtendedTextView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr) { }
        public ExtendedTextView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes) { }
        protected ExtendedTextView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer) { }

        public Color BindableTextColor // property to bind to in XML
        {
            get { return new Color(CurrentTextColor); }
            set { SetTextColor(value); }
        }
    }
}