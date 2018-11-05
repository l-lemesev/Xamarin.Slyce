using Foundation;
using UIKit;
using Xamarin.iOS.Slyce;

namespace Xamarin.iOS.Slyce.Sample
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations

        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // Override point for customization after application launch.
            // If not required for your application you can safely delete this method

            SlyceLogging.Shared().LogLevel = SlyceLogLevel.Info;

            string accountId = "";
            string apiKey = "";
            string spaceId = "";
               
            Slyce.Shared().OpenWithAccountIdentifier(accountId, apiKey, spaceId, (NSError error) => {

                // This is an asynchronous completion handler. It is called when
                // the Slyce open operation either completes successfully or failed

                if (error != null) {
                    System.Diagnostics.Debug.WriteLine("Slyce open failed!");

                    // Slyce failed to open. This can be due to incorrect credentials
                    // or a poor network connection.

                } else {
                    System.Diagnostics.Debug.WriteLine("Slyce open suceeded!");

                    // Slyce opened successfully. You can now proceed to use SlyceSDK
                    // services.

                    doSomethingWithSlyce();
                }
            });


            return true;
        }

        private void doSomethingWithSlyce()
        {
            System.Diagnostics.Debug.WriteLine("Slyce.Shared().DefaultSession = " + Slyce.Shared().DefaultSession.DebugDescription);

            SlyceViewController slvc = new SlyceViewController(Slyce.Shared(), SlyceViewControllerMode.Universal);
            slvc.Delegate = new SlyceVCDelegate();
            Window.RootViewController.PresentViewController(slvc, false, null);
        }

        public override void OnResignActivation(UIApplication application)
        {
            // Invoked when the application is about to move from active to inactive state.
            // This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
            // or when the user quits the application and it begins the transition to the background state.
            // Games should use this method to pause the game.
        }

        public override void DidEnterBackground(UIApplication application)
        {
            // Use this method to release shared resources, save user data, invalidate timers and store the application state.
            // If your application supports background exection this method is called instead of WillTerminate when the user quits.
        }

        public override void WillEnterForeground(UIApplication application)
        {
            // Called as part of the transiton from background to active state.
            // Here you can undo many of the changes made on entering the background.
        }

        public override void OnActivated(UIApplication application)
        {
            // Restart any tasks that were paused (or not yet started) while the application was inactive. 
            // If the application was previously in the background, optionally refresh the user interface.
        }

        public override void WillTerminate(UIApplication application)
        {
            // Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
        }


        class SlyceVCDelegate: SlyceViewControllerDelegate {


            //[Export("slyceViewController:didOpenSession:")]
            public override void SlyceViewController(SlyceViewController viewController, SlyceSession session) {

            }


            //[Export("slyceViewController:shouldDisplayDefaultDetailForItemDescriptor:")]
            public override bool SlyceViewController(SlyceViewController viewController, SlyceItemDescriptor itemDescriptor) {
                // Launch your Item detail view controller here after retrieving the desired data from the item descriptors.

                System.Diagnostics.Debug.WriteLine("Should display detial for item " + itemDescriptor.ToString());

                return true;
            }


            //[Export("slyceViewController:shouldDisplayDefaultListForItemDescriptors:")]
            public override bool SlyceViewController(SlyceViewController viewController, SlyceItemDescriptor[] itemDescriptors) {
                // Loop through the itemDescriptor to get the needed data
                // Launch your Items list view controller here after retrieving the desired data from the item descriptors.


                System.Diagnostics.Debug.WriteLine("Should display default list");

                return true;
            }
        }
    }
}

