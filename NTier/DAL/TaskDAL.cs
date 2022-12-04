using Common;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace DAL
{
    public class TaskDAL
    {
        public bool AddTask(Common.Task task, User user)
        {
            string query = string.Format("Insert into UTask(Title,Description,Date,U_Id) Values({0},{1},{2},{3})", task.Title, task.Description, task.Deadline, user.Id);
            DBHelper dh = new DBHelper();
            var x = dh.ExecuteNonQuery(query);
            if (x == -1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool AddTask(Common.Task task)
        {
            string query = string.Format("Insert into Task(Title,Description,Deadline) Values('{0}','{1}','{2}')", task.Title, task.Description, task.Deadline);
            DBHelper dh = new DBHelper();
            var x = dh.ExecuteNonQuery(query);
            if (x == -1)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public DataTable getData()
        {
            string query = string.Format("Select * from Task");
            DBHelper dh = new DBHelper();

            DataTable dt = new DataTable();
            dt = dh.GetDataTable(query);
            return dt;

        }
        public bool DeleteTask(Common.Task task)
        {
            //MessageBox.Show("HY");
            string query = String.Format(
                "Delete from Task where Title='{0}'",task.Title);
            DBHelper dh = new DBHelper();
            var x = dh.ExecuteNonQuery(query);
            if (x == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool UpdateTask(Common.Task task)
        {
            string query = String.Format("Update Task Set Title='{0}',Description='{1}',Deadline='{2}' where Task_Id='{3}'", task.Title, task.Description, task.Deadline,task.Id);
            DBHelper dh = new DBHelper();
            var x = dh.ExecuteNonQuery(query);
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
