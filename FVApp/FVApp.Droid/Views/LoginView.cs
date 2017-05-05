﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;

namespace FVApp.Droid.Views
{
    [Activity(Label = "LoginView")]
    public class LoginView : MvxActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);
                SetContentView(Resource.Layout.LoginView);
            }
            catch (Exception e)
            {

                throw;
            }
            
        }
    }
}