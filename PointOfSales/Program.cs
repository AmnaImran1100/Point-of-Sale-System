using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointOfSales.BL;
using PointOfSales.DL;
using PointOfSales.UI;

namespace PointOfSales
{
    class Program
    {

        static public customersBL customer = new customersBL();

        static void Main(string[] args)
        {
            string userPath = "userInfo.txt";
            string productsPath = "productsInfo.txt";
            if (MyUserDL.readFromFile(userPath))
            {
                Console.WriteLine("Users Data Loaded Successfully");
            }
            if (productsDL.readFromFile(productsPath))
            {
                Console.WriteLine("Products Data Loaded Successfully");
            }
            menuUI.clear();
            int option = 0;
            while (option != 3)
            {
                option = MyUserUI.mainMenu();
                if (option == 1) //SignIn
                {
                    MyUserBL User = MyUserDL.signIn();
                    if (User != null)
                    {
                        if (User.isAdmin()) // checks through class behaviour if the user is admin or not //Show Admin menu
                        {
                            menuUI.clear();
                            int adminOption = 0;
                            while (adminOption != 6)
                            {
                                adminOption = menuUI.adminMenu();
                                if (adminOption == 1)
                                {
                                    productsBL p = productsUI.getInputAboutProduct();
                                    productsDL.addProductInList(p);
                                    productsDL.storeintoFile(productsPath, p);
                                    menuUI.clear();
                                }
                                else if (adminOption == 2)
                                {
                                    productsUI.viewProducts();
                                    menuUI.clear();
                                }
                                else if (adminOption == 3)
                                {
                                    productsUI.printHighest();
                                    menuUI.clear();
                                }
                                else if (adminOption == 4)
                                {
                                    productsUI.viewSalesTax();
                                    menuUI.clear();
                                }
                                else if (adminOption == 5)
                                {
                                    productsUI.productsBelowThreshold();
                                    menuUI.clear();
                                }
                            }
                        }
                        else //Show user menu
                        {
                            menuUI.clear();;
                            int userOption = 0;
                            while (userOption != 4)
                            {
                                userOption = menuUI.userMenu();
                                if (userOption == 1)
                                {
                                    productsUI.viewProducts();
                                    menuUI.clear();
                                }
                                else if (userOption == 2)
                                {
                                    productsUI.viewProducts();
                                    productsUI.buyProducts();
                                    menuUI.clear();
                                }
                                else if (userOption == 3)
                                {
                                    productsUI.outputInvoice();
                                    menuUI.clear();
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid User");
                    }
                }
                else if (option == 2) //SignUp
                {
                    MyUserBL User = MyUserUI.getUserInfoWithRole();
                    MyUserDL.addUserIntoList(User);
                    MyUserDL.storeintoFile(userPath,User);
                    menuUI.clear();
                }
                else
                {
                    break;
                }
                Console.Clear();
            }
        }
    }
}
