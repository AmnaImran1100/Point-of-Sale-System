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
    class MyUserDL
    {
        static List<MyUserBL> userList = new List<MyUserBL>();

        static public void addUserIntoList(MyUserBL User)
        {
            userList.Add(User);
        }

        static public MyUserBL signIn()
        {
            MyUserBL User = MyUserUI.getUserInfoWithoutRole();
            foreach (MyUserBL storedUser in userList)
            {
                if (User.getUserName() == storedUser.getUserName() && User.getUserPassword() == storedUser.getUserPassword())
                {
                    return storedUser;
                }

            }
            return null;
        }

        public static void storeintoFile(string path, MyUserBL m)
        {
            StreamWriter f = new StreamWriter(path, true);
            f.WriteLine(m.getUserName() + "," + m.getUserPassword() + "," + m.getUserRole());
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
                    string userName = splittedRecord[0];
                    string userPassword = splittedRecord[1];
                    string userRole = splittedRecord[2];
                    MyUserBL s = new MyUserBL(userName, userPassword, userRole);
                    addUserIntoList(s);
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
