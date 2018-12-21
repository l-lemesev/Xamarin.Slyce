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

            string accountId = "";
            string apiKey = "";
            string spaceId = "";


            SlyceSDK.Slyce.GetInstance(this).Open(accountId, apiKey, spaceId, new SlyceFragmentLauncher(this));
        }
    }
}