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
    class MyUserBL
    {
        private string userName;
        private string userPassword;
        private string userRole;

        public void setUserName(string userName)
        {
            this.userName = userName;
        }

        public void setUserPassword(string userPassword)
        {
            this.userPassword = userPassword;
        }

        public void setUserRole(string userRole)
        {
            this.userRole = userRole;
        }

        public string getUserName()
        {
            return userName;
        }

        public string getUserPassword()
        {
            return userPassword;
        }

        public string getUserRole()
        {
            return userRole;
        }

        public MyUserBL(string userName, string userPassword, string userRole) // for signup
        {
            this.userName = userName;
            this.userPassword = userPassword;
            this.userRole = userRole;
        }

        public MyUserBL(string userName, string userPassword) // for signin
        {
            this.userName = userName;
            this.userPassword = userPassword;
            this.userRole = "NA";
        }
        public bool isAdmin() // checks if user is admin
        {
            if (userRole == "Admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
