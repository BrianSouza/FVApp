
using Android.App;
using Android.OS;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace FVApp.Droid.Views
{
    [Activity(Label = "PedidosView")]
    public class PedidosView : MvxAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }
        protected override void OnViewModelSet()
        {
            //base.OnViewModelSet();
            SetContentView(Resource.Layout.PedidosView);
        }
    }
}