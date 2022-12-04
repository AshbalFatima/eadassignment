using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDAL
    {
        public bool AddUser(User user)
        {
            string query = string.Format("Insert into Users(U_Name,Full_Name,Secret_Key,Email)Values('{0}','{1}','{2}','{3}')",user.Username,user.Name,user.Password,user.Email);
           
            DBHelper dh = new DBHelper();
            var x=dh.ExecuteNonQuery(query);
            if (x == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
