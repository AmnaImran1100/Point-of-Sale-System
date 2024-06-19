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
    class MyUserUI
    {
        static public int mainMenu()
        {
            Console.WriteLine("*************************************");
            Console.WriteLine("              LOGIN MENU             ");
            Console.WriteLine("*************************************");
            Console.WriteLine("1.SignIn");
            Console.WriteLine("2.SignUp");
            Console.WriteLine("3.Exit");
            Console.Write("Enter Option =");
            int option = int.Parse(Console.ReadLine());
            return option;
        }

        static public MyUserBL getUserInfoWithRole()
        {
            Console.Write("Enter Name = ");
            string userName = Console.ReadLine();
            Console.Write("Enter Password = ");
            string userPassword = Console.ReadLine();
            Console.Write("Enter Role = ");
            string userRole = Console.ReadLine();
            MyUserBL User = new MyUserBL(userName, userPassword, userRole);
            return User;
        }// for sign up

        static public MyUserBL getUserInfoWithoutRole()
        {
            Console.Write("Enter Name = ");
            string userName = Console.ReadLine();
            Console.Write("Enter Passwrod = ");
            string userPassword = Console.ReadLine();
            MyUserBL User = new MyUserBL(userName, userPassword);
            return User;
        }// for sign in
    }
}
