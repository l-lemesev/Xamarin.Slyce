using Android.App;
using Android.OS;
using SlyceSDK.Util;
using Android.Support.V4.App;


namespace Xamarin.Android.Slyce.Sample
{
    [Activity(Label = "Xamarin.Android.Slyce.Sample", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : FragmentActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);



            setupSlyce();
        }

        void setupSlyce()
        {
            SlyceLogging.Instance.LogLevel = SlyceLogging.Info;

            // Ensure the core native library is loaded. TODO: do this automatically.
            Java.Lang.JavaSystem.LoadLibrary("slyce_core");

            string accountId = "slyce_integrations";
            string apiKey = "l3Jk79JZM8ATo68dv2vrJc8m6YOdMIzv6BM0UwdW-F8";
            string spaceId = "n2b4mfqcDji5Q9hyU8h3Ve";


            SlyceSDK.Slyce.GetInstance(this).Open(accountId, apiKey, spaceId, new SlyceFragmentLauncher(this));
        }
    }
}