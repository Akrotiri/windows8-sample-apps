using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayPal.Sample.Phone.Model
{
    public class MenuItem
    {
        private string price;
        public MenuItem(string name, string desc, string price, string itemId, string category, string image)
        {
            this.Name = name;
            this.Price = price;
            this.ItemId = itemId;
            this.Description = desc;            
            this.Category = category;
            this.Image = new Uri(String.Format(image), UriKind.Relative);
        }

        public string Name { get; set; }        
        public string Description { get; set; }
        public string Price
        {
            get
            {
                return this.price + "$";
            }
            set
            {
                this.price = value;
            }
        }
        public string ItemId { get; set; }
        public string Category { get; set; }        
        public Uri Image { get; set; }        
    }
}
