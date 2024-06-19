using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PointOfSales.BL;
using PointOfSales.DL;
using PointOfSales.UI;

namespace PointOfSales.DL
{
    class productsDL
    {
        static public List<productsBL> productList = new List<productsBL>();

        static public void addProductInList(productsBL p)
        {
            productList.Add(p);
        }

        static public int highestPriceProduct()
        {
            float highestPrice = 0.0F;
            int idx = 0;
            for (int x = 0; x < productList.Count; x++)
            {
                if (productList[x].getPrice() > highestPrice)
                {
                    highestPrice = productList[x].getPrice();
                    idx = x;
                }
            }
            return idx;
        }

        public static void storeintoFile(string path, productsBL m)
        {
            StreamWriter f = new StreamWriter(path, true);
            f.WriteLine(m.getName() + "," + m.getCategory() + "," + m.getPrice() + "," + m.getQuantity() + "," + m.getThreshold());
            f.Flush();
            f.Close();
        }

        public static bool readFromFile(string path)
        {
            StreamReader f = new StreamReader(path);
            string record;
            if (File.Exists(path))
            {
                while ((record = f.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');
                    string name = splittedRecord[0];
                    string category = splittedRecord[1];
                    int price = int.Parse(splittedRecord[2]);
                    int quantity = int.Parse(splittedRecord[3]);
                    int threshold = int.Parse(splittedRecord[4]);
                    productsBL s = new productsBL(name, category, price, quantity, threshold);
                    productList.Add(s);
                }
                f.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
