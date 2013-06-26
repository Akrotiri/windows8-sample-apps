
# Windows 8 Store Sample using the PayPal SDK

This is a simple store app in Javascript that demonstrates how you can use the PayPal Checkout SDK for Windows Store Applications. The PayPal SDK for Windows Store Apps is written as a `Windows Runtime Component` which means you will be able to use them in C# / C++ / Javascript apps. Additionally, Javascript/HTML5 developers can use `paypal.js`, a simple javascript wrapper, to integrate PayPal payments with minimal lines of code.

**Note:**  If you are a phone developer please look at the sample phone project in the same repository.

## Prerequisites

  * Visual Studio 2012.
	
## Installing the SDK

   * Download `PayPal.Checkout.vsix` from the PayPal Windows 8 SDK page.
   * Double click the VSIX file to install the SDK as an extension in your IDE. The PayPal Checkout SDK should now appear in your Tools -> Extensions and Updates menu under the 'Installed -> SDKs' category.
   
## Running the sample

   * Open the PayPalStoreSampleApp.sln file in Visual Studio 2012.
   * Install the SDK as described in the installation section.
   * A reference to the SDK has already been set for you in the sample project. If you are working on a fresh project, you will have to manually set up a reference to the SDK. You can do this from the solution explorer by clicking on "Add Reference", navigating to Windows -> Extensions and selecting "PayPal Checkout SDK".
   * The sample comes preconfigured with a merchant account. Run the project from within Visual Studio by simply clicking on the "Debug -> Start Debugging" menu.
   * If you would like to run the sample against your own PayPal account, 
      * First, onboard your merchant account as detailed at http://paypal.github.io/Windows8SDK/, and
      * Edit Pizza.html/PizzaCSharp.html to use your PayPal merchant emailid.
      
## For javascript developers

Javascript developers can choose between two integration modes when using the SDK.

	* Direct C# integration using WinRT's language interop capabilities.
	* Using paypal.js that provides a simple wrapper around the C# API and also a custom WinJS control.
	
The sample app showcases both integration modes.	
      
## Links

   * [C# reference] (http://paypal.github.io/Windows8SDK/csharp.html)
   * [Javascript reference] (http://paypal.github.io/Windows8SDK/javascript.html)
      

      
   