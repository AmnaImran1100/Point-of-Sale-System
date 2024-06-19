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
    class customersBL
    {
        private double grocerytotal;
        private double fruittotal;
        private double otherstotal;
        static public List<productsBL> boughtList = new List<productsBL>();

        public void calculateInvoice()
        {
            foreach (productsBL b in boughtList)
            {
                if (b.getCategory() == "grocery" || b.getCategory() == "Grocery")
                {
                    grocerytotal = b.getPrice() * b.getQuantity();
                }
                else if (b.getCategory() == "fruits" || b.getCategory() == "Fruits")
                {
                    fruittotal = b.getPrice() * b.getQuantity();
                }
                else
                {
                    otherstotal = b.getPrice() * b.getQuantity();
                }
            }
        }

        public double generateInvoice()
        {
            return (1.1 * grocerytotal) + (1.05 * fruittotal) + (1.15 * otherstotal);
        }
    }
}
