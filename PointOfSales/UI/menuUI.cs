using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSales.UI
{
    class menuUI
    {
        static public void clear()
        {
            Console.ReadKey();
            Console.Clear();
        }

        static public int adminMenu()
        {
            Console.WriteLine("*************************************************");
            Console.WriteLine("             POINT OF SALE (ADMIN MENU)          ");
            Console.WriteLine("*************************************************");
            Console.WriteLine("1. ADD Product");
            Console.WriteLine("2. View All Products");
            Console.WriteLine("3. Find Product with the Highest Unit Price");
            Console.WriteLine("4. View Sales Tax of All Products");
            Console.WriteLine("5. Products to be Ordered");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your option = ");
            int option = int.Parse(Console.ReadLine());
            return option;
        }

        static public int userMenu()
        {
            Console.WriteLine("*************************************************");
            Console.WriteLine("             POINT OF SALE (USER MENU)           ");
            Console.WriteLine("*************************************************");
            Console.WriteLine("1. View All Products");
            Console.WriteLine("2. Buy the products");
            Console.WriteLine("3. Generate Invoice");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your option = ");
            int option = int.Parse(Console.ReadLine());
            return option;
        }
    }
}
