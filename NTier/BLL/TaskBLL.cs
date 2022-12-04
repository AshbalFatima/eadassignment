using Common;
using DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TaskBLL
    {
        public bool AddTask(Common.Task task,User user)
        {
            TaskDAL tdll = new TaskDAL();
            return tdll.AddTask(task, user);
        } 
        public bool AddTask(Common.Task task)
        {
            TaskDAL tdll = new TaskDAL();
            return tdll.AddTask(task);
        }
        public DataTable getData()
        {
            DataTable dt = new DataTable();
            TaskDAL tdll = new TaskDAL();
            dt = tdll.getData();
            return dt;
        }
        public bool DeleteTask(Common.Task task)
        {
            return new TaskDAL().DeleteTask(task);
        }

        public bool UpdateTask(Common.Task task)
        {
            return new TaskDAL().UpdateTask(task);
        }
    }
}
