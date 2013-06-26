using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PayPal.Sample.Phone.Resources;
using PayPal.Checkout;
using PayPal.Sample.Phone.Model;
using PayPal.Sample.Phone.Helper;

namespace PayPal.Sample.Phone
{
    public partial class MainPage : PhoneApplicationPage
    {

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            this.LayoutRoot.DataContext = new PayPal.Sample.Phone.ViewModel.MenuViewModel();
            this.Status.DataContext = new UIHelper();
        }

        private async void TryNow_Click(object sender, RoutedEventArgs e)
        {   
            // Create a BuyNow object with your PayPal 
            // merchant account emailid. Remember to onboard
            // your merchant account by granting third party 
            // permissions as detailed in the docs
            BuyNow bn = new BuyNow("enduser_biz@gmail.com");
            bn.UseSandbox = true;

            // Add items to the purchase
            foreach (MenuItem s in this.MenuControl.SelectedItems)
            {
                ItemBuilder builder = new ItemBuilder(s.Name)
                .Description(s.Name)
                .ID(s.ItemId)
                .Price(s.Price);
                bn.AddItem(builder);
            }
            
            // Attach event handlers. The BuyNow class emits 5 events
            // start, auth, error, cancel and complete
            bn.Start += new EventHandler<PayPal.Checkout.Event.StartEventArgs>((source, args) =>
            {
                this.Status.Message.Text = "Initiating payment";
            });
            bn.Auth += new EventHandler<PayPal.Checkout.Event.AuthEventArgs>((source, args) =>
            {               
                this.Status.Message.Text = "Authenticating payment: " + args.Token;
            });
            bn.Complete += new EventHandler<PayPal.Checkout.Event.CompleteEventArgs>((source, args) =>
            {                
                this.Status.displayStoryboard.Begin();
                this.Status.Message.Text = "Your payment is complete. Transaction id: " + args.TransactionID;
                clearSelection();
            });
            bn.Cancel += new EventHandler<PayPal.Checkout.Event.CancelEventArgs>((source, args) =>
            {
                this.Status.displayStoryboard.Begin();
                this.Status.Message.Text = "Your payment was cancelled.";
                clearSelection();
            });
            bn.Error += new EventHandler<PayPal.Checkout.Event.ErrorEventArgs>((source, args) =>
            {
                this.Status.displayStoryboard.Begin();
                this.Status.Message.Text = "There was an error processing your payment: " + args.Type + " " + args.Message;
                clearSelection();
            });

            // Ready to go. Call the asynchronous Execute operation
            // to initiate the payment. Remember to mark your calling
            // function with the async keyword since this is an async call
            bool ret = await bn.Execute();
        }

        private void clearSelection()
        {
            this.MenuControl.SelectedIndex = -1;
        }
    }
}