using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;

namespace NTier
{
    public partial class AddTask : Form
    {
        public AddTask()
        {
            InitializeComponent();
        }
        public int Task_Id;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtDeadline.Text == "" || txtDescription.Text == "" || txtTitle.Text == "")
            {
                MessageBox.Show("Please Fill All the Boxes");
            }
            else
            {
                TaskBLL tBLL = new TaskBLL();
                Common.Task task = new Common.Task();
                task.Title = txtTitle.Text;
                task.Deadline = txtDeadline.Text;
                task.Description = txtDescription.Text;


                bool result = tBLL.AddTask(task);
                if (result)
                {
                    MessageBox.Show("Data Added Succesfully");

                }
                else
                {
                    MessageBox.Show("Data Added Failed");
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowTask sh = new ShowTask();
            sh.ShowDialog();
            //this.Close();
            if (sh.isSearch)
            {
                Task_Id = sh.SelectedTask.Id;
                txtTitle.Text=sh.SelectedTask.Title.ToString();
                txtDescription.Text=sh.SelectedTask.Description.ToString();
                txtDeadline.Text=sh.SelectedTask.Deadline.ToString();
                btnDelete.Enabled=true;
                btnUpdate.Enabled=true;
            }
        }

        //DELETE BUTTON
        private void button2_Click(object sender, EventArgs e)
        {
            
            Common.Task task=new Common.Task();
            task.Title=txtTitle.Text;
            task.Description=txtDescription.Text;
            task.Deadline=txtDeadline.Text;
            TaskBLL tBLL = new TaskBLL();
            var result=tBLL.DeleteTask(task);

            if (result)
            {
                //sh.SelectedTask = null;
                txtTitle.Text = "";
                txtDescription.Text = "";
                txtDeadline.Text = "";
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
            }
            else
            {
                MessageBox.Show("Task Deleteion Failed");
            }

        }

        private void AddTask_Load(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //ShowTask sh = new ShowTask();
            //sh.ShowDialog();
            Common.Task task = new Common.Task();
            //MessageBox.Show();
            task.Id=Task_Id;
            MessageBox.Show(Convert.ToString(task.Id));
            task.Title = txtTitle.Text;
            task.Description = txtDescription.Text;
            task.Deadline = txtDeadline.Text;
            TaskBLL tBLL = new TaskBLL();
            var result = tBLL.UpdateTask(task);

            if (result)
            {
               // sh.SelectedTask = null;
                txtTitle.Text = "";
                txtDescription.Text = "";
                txtDeadline.Text = "";
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
            }
            else
            {
                MessageBox.Show("Task Updation Failed");
            }
        }
    }
}
