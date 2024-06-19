using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointOfSales.BL;
using PointOfSales.DL;
using PointOfSales.UI;

namespace PointOfSales.UI
{
    class productsUI
    {
        static public productsBL getInputAboutProduct()
        {
            Console.Write("Enter Product Name = ");
            string name = Console.ReadLine();
            Console.Write("Enter the Category of the Product = ");
            string category = Console.ReadLine();
            Console.Write("Enter Price = ");
            int price = int.Parse(Console.ReadLine());
            Console.Write("Enter Qunatity of Product =");
            int quantity = int.Parse(Console.ReadLine());
            Console.Write("Enter minimun Threshold = ");
            int threshold = int.Parse(Console.ReadLine());
            productsBL p = new productsBL(name, category, price, quantity, threshold);
            return p;
        }

        static public void viewProducts()
        {
            Console.WriteLine("NAME" + "\t\t" + "CATEGORY" + "\t\t" + "PRICE" + "\t\t" + "QUANTITY" + "\t\t" + "THRESHOLD");
            foreach (productsBL p in productsDL.productList)
            {
                Console.WriteLine(p.getName() + "\t\t" + p.getCategory() + "\t\t" + p.getPrice() + "\t\t" + p.getQuantity() + "\t\t" + p.getThreshold());
            }
        }

        static public void printHighest()
        {
            int idx = productsDL.highestPriceProduct();
            Console.WriteLine("The product with the highest price is " + productsDL.productList[idx].getName() + " with price of " + productsDL.productList[idx].getPrice());
        }

        static public void viewSalesTax()
        {
            Console.WriteLine("NAME" + "\t\t" + "CATEGORY" + "\t\t" + "PRICE" + "\t\t" + "QUANTITY" + "\t\t" + "THRESHOLD" + "\t\t" + "TAX");
            foreach (productsBL p in productsDL.productList)
            {
                Console.WriteLine(p.getName() + "\t\t" + p.getCategory() + "\t\t" + p.getPrice() + "\t\t" + p.getQuantity() + "\t\t" + p.getThreshold() + "\t\t" + p.calculateTax());
            }
        }

        static public void productsBelowThreshold()
        {
            Console.WriteLine("Products Below Threshold:");
            foreach (productsBL p in productsDL.productList)
            {
                if (p.getQuantity() <= p.getThreshold())
                {
                    Console.WriteLine(p.getName() + " needs to be Ordered. ");
                }
            }
        }

        static public void buyProducts()
        {
            Console.Write("Enter the product you want to buy = ");
            string name = Console.ReadLine();
            Console.Write("Enter the qauntity = ");
            int quantity = int.Parse(Console.ReadLine());
            bool flag = false;

            foreach (productsBL p in productsDL.productList)
            {
                if (p.getName() == name && p.getQuantity() >= quantity)
                {
                    int temp = p.getQuantity();
                    p.setQuantity(quantity);
                    customersBL.boughtList.Add(p);
                    //int x = temp - quantity;
                    //p.setQuantity(x);
                    flag = true;
                }
            }
            if (flag == false)
            {
                Console.WriteLine("Product with this name does not exit.");
            }
            
        }

        static public void outputInvoice()
        {
            Console.WriteLine("PRODUCT" + "\t\t" + "PRICE" + "\t\t" + "QUANTITY");
            foreach (productsBL p in customersBL.boughtList)
            {
                Console.WriteLine(p.getName() + "\t\t" + p.getPrice() + "\t\t" + p.getQuantity());
            }
            Program.customer.calculateInvoice();
            Console.WriteLine("Your Total for all bought Products with Tax is " + Program.customer.generateInvoice());
        }
    }
}
