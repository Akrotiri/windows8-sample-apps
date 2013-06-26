
# Windows 8 Phone Sample using the PayPal SDK

This is a simple pizza store app that demonstrates how you can use the PayPal Checkout SDK for Windows Phone 8 in your phone apps. 

** Note: ** If you are a store app developer, please look at the sample store project in the same repository.

## Prerequisites

  * Visual Studio 2012 with the Windows Phone SDK installed.
  
## Running the sample

   * Open the PayPalPhoneSampleApp.sln file in Visual Studio 2012.   
   * A reference to the SDK has already been set for you in the sample project. If you are working on a fresh project, you will have to manually set up a reference to the SDK. You can do this from the solution explorer by clicking on "Add Reference" and browsing to the `PayPal.Checkout.SDK-WindowsPhone8.dll` file
   * The sample comes pre-configured with a merchant account. Run the project from within Visual Studio by simply clicking on the "Debug -> Start Debugging" menu.
   * If you would like to run the sample against your own PayPal account, 
      * First, onboard your merchant account as detailed at http://paypal.github.io/Windows8SDK/, and
      * Edit line# 34 of MainPage.xaml.cs to use your PayPal merchant emailid.
      
## Links

   * [C# reference] (http://paypal.github.io/Windows8SDK/csharp.html)

      
   