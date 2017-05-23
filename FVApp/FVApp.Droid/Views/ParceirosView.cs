using System;

using Android.App;
using Android.OS;
using MvvmCross.Droid.Support.V7.AppCompat;

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
                //var tbPrincipal = FindViewById<Toolbar>(Resource.Id.toolbarBackCheck);
                //SetSupportActionBar(tbPrincipal);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}