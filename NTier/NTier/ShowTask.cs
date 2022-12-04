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
    public partial class ShowTask : Form
    {
        public Common.Task SelectedTask = new Common.Task();
        public bool isSearch;
        public ShowTask()
        {
            InitializeComponent();
        }

        private void Show_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            TaskBLL taskBLL = new TaskBLL();
            dt = taskBLL.getData();
            dataGridView1.DataSource = dt;
           // List<Task> tk;


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            isSearch = true;
            if(dataGridView1.SelectedRows.Count > 0)
            {
            
                int index=dataGridView1.SelectedRows[0].Index;
                SelectedTask.Id=Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                SelectedTask.Title = Convert.ToString(dataGridView1.Rows[index].Cells[1].Value);
                SelectedTask.Description= Convert.ToString(dataGridView1.Rows[index].Cells[2].Value);
                SelectedTask.Deadline = Convert.ToString(dataGridView1.Rows[index].Cells[3].Value);
                this.Close();
            }
            else
            {
                MessageBox.Show("Select The ROW");

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isSearch = false;
            this.Close();
        }
    }
}
