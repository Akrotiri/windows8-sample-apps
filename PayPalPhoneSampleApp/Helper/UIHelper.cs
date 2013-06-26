using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PayPal.Sample.Phone.Helper
{
    class UIHelper
    {
        // Helper method for storyboard animations
        // since WP8 seems to lack static binding of enum values
        public System.Windows.Visibility HiddenVisibility
        {
            get
            {
                return System.Windows.Visibility.Collapsed;
            }
        }

        public System.Windows.Visibility DisplayedVisibility
        {
            get
            {
                return System.Windows.Visibility.Visible;
            }
        }
    }
}
