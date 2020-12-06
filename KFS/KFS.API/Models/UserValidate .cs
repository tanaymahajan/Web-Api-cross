using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KFS.API.Models
{
    public class UserValidate
    {
        public static bool Login(string username,string password)
        {
            UserBL userbl = new UserBL();
            var UserList = userbl.GetUsers();

            return UserList.Any(y => y.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) && y.Password == password);
        }
        public static User GetUserDetails(string username, string password)
        {
            UserBL userBL = new UserBL();
            return userBL.GetUsers().FirstOrDefault(user =>
                user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)
                && user.Password == password);
        }
    }
}