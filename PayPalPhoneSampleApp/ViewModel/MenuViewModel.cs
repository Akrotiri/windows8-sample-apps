using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayPal.Sample.Phone.Helper;
using PayPal.Sample.Phone.Model;

namespace PayPal.Sample.Phone.ViewModel
{
    public class MenuViewModel
    {
        public class MenuItems : ObservableCollection<MenuItem>
        {
            public MenuItems()
            {
               
            }

        }

        public MenuItems UngroupedItems
        {
            get
            {
                MenuItems m = new MenuItems();
                var items = Menu.GetAvailableItems();
                foreach (var item in items)
                {
                    m.Add(item);
                }
                return m;
            }
        }

        public List<KeyedList<string, MenuItem>> GroupedItems
        {
            get
            {
                var items = Menu.GetAvailableItems();

                var groupedItems =
                    from item in items
                    orderby item.Name
                    group item by item.Category into itemsByCategory
                    select new KeyedList<string, MenuItem>(itemsByCategory);

                return new List<KeyedList<string, MenuItem>>(groupedItems);
            }
        }
    }
}
