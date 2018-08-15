using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using SlyceSDK;
using SlyceSDK.Exception;
using SlyceSDK.Util;

namespace Xamarin.Android.Slyce.Sample
{
    [Activity(Label = "Xamarin.Android.Slyce.Sample", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);

            button.Click += delegate { button.Text = $"{count++} clicks!"; };

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

            SlyceSDK.Slyce.GetInstance(this).Open(accountId, apiKey, spaceId, new MySlyceOpenCompletionHandler(this));
        }


        // TODO: I'm sure there is a better way to implement the completion handler, but the author is a C# novice.
        private class MySlyceOpenCompletionHandler : Java.Lang.Object, ISlyceCompletionHandler {

            private Context context;

            public MySlyceOpenCompletionHandler(Context context) {
                this.context = context;
            }

            public void OnCompletion(SlyceError error) {

                if (error != null)
                {
                    System.Diagnostics.Debug.WriteLine("Error opening Slyce: " + error.LocalizedMessage);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Slyce.GetInstance(this).DefaultSession = " + SlyceSDK.Slyce.GetInstance(context).DefaultSession.ToString());
                }

            }
        }
    }
}

