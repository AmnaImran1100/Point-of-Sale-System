using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointOfSales.BL;
using PointOfSales.DL;
using PointOfSales.UI;

namespace PointOfSales.BL
{
    class productsBL
    {
        private string name;
        private string category;
        private int price;
        private int quantity;
        private int threshold;

        public productsBL(string name, string category, int price, int quantity, int threshold)
        {
            this.name = name;
            this.category = category;
            this.price = price;
            this.quantity = quantity;
            this.threshold = threshold;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setCategory(string category)
        {
            this.category = category;
        }

        public void setPrice(int price)
        {
            this.price = price;
        }

        public void setQuantity(int quantity)
        {
            this.quantity = quantity;
        }

        public void setThreshold(int threshold)
        {
            this.threshold = threshold;
        }

        public string getName()
        {
            return name;
        }

        public string getCategory()
        {
            return category;
        }

        public int getPrice()
        {
            return price;
        }

        public int getQuantity()
        {
            return quantity;
        }

        public int getThreshold()
        {
            return threshold;
        }

        public double calculateTax()
        {
            if (category == "grocery" || category == "Grocery")
            {
                return (0.1 * price) ;
            }
            else if (category == "fruits" || category == "Fruits")
            {
                return (0.05 * price);
            }
            else
            {
                return (0.15 * price);
            }
        }
    }
}
