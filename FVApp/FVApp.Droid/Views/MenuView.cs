
using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace FVApp.Droid.Views
{
    [Activity()]
    public class MenuView : MvxAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }

        protected override void OnViewModelSet()
        {
            //base.OnViewModelSet();
            SetContentView(Resource.Layout.MenuView);
            var tbMenu = FindViewById<Toolbar>(Resource.Id.toolBarOnlyTitle);
            SetSupportActionBar(tbMenu);
        }
    }
}