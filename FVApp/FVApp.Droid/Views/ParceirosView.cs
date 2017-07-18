using System;

using Android.App;
using Android.OS;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Binding.Droid.Views;
using FVApp.Droid.Resources.adapter;

namespace FVApp.Droid.Views
{
    [Activity(Label = "ParceirosView")]
    public class ParceirosView : MvxAppCompatActivity
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
                SetContentView(Resource.Layout.ParceirosView);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}