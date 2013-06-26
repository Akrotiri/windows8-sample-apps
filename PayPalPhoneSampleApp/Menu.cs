using System.Collections.Generic;
using PayPal.Sample.Phone.Model;

namespace PayPal.Sample.Phone
{
    public class Menu
    {
        public static List<MenuItem> GetAvailableItems()
        {
            List<MenuItem> menu = new List<MenuItem>();
            menu.Add(new MenuItem("Margharita", "Classic Margharita pizza. Simply yummy", "5.00", "ITEM001", "Pizza", "/Assets/Pizza1.jpg"));
            menu.Add(new MenuItem("Supreme Pizza", "A feast of pepperoni, ham, beef, Italian sausage, red onions and mushrooms,", "7.00", "ITEM002", "Pizza", "/Assets/Pizza2.jpg"));
            menu.Add(new MenuItem("Domashnyaya", "Home style pizza", "8.50", "ITEM003", "Pizza", "/Assets/Pizza3.jpg"));
            menu.Add(new MenuItem("Diet coke", "", "2.00", "ITEM004", "Drinks", "/Assets/CokeCan.gif"));
            return menu;
        }
    }
}
