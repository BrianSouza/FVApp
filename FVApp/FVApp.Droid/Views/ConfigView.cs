using System;

using Android.App;
using Android.OS;
using MvvmCross.Droid.Support.V7.AppCompat;
using Android.Support.V7.Widget;

namespace FVApp.Droid.Views
{
    [Activity(Label = "ConfigView")]
    public class ConfigView : MvxAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected override void OnViewModelSet()
        {
            try
            {
                SetContentView(Resource.Layout.ConfigView);
                var tbPrincipal = FindViewById<Toolbar>(Resource.Id.toolbarBackCheck);
                SetSupportActionBar(tbPrincipal);
                //SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}