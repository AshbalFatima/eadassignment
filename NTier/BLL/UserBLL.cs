using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DAL;

namespace BLL
{
    public class UserBLL
    {
        public bool AddUser(User user)
        {
            UserDAL udal = new UserDAL();
            return udal.AddUser(user);
        }
    }
}
