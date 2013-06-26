using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace PayPal.Sample.Phone.Controls
{
    public partial class MenuControl : UserControl
    {
        public MenuControl()
        {
            InitializeComponent();
        }

        public IList SelectedItems
        {
            get
            {
                return this.MenuControl_Copy.SelectedItems;
            }
        }

        public int SelectedIndex
        {
            get
            {
                return this.MenuControl_Copy.SelectedIndex;
            }
            set
            {
                this.MenuControl_Copy.SelectedIndex = value;
            }
        }
    }
}
