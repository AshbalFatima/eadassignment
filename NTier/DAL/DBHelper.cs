using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class DBHelper
    {
        public static String connectionString = "server=DESKTOP-8U3554N\\SQLEXPRESS;Database=student;Integrated Security=SSPI;";
        public DataTable GetDataTable(string query)
        {
            SqlConnection conn = null;
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adp = new SqlDataAdapter(query,conn);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    return dt;
                }
                   

            }
            catch(Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public int ExecuteNonQuery(string query)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();            
                SqlCommand cmd = new SqlCommand(query,conn);
                
                var x=cmd.ExecuteNonQuery();
                
                if (x>0)
                {
                    return x;
                }
                else
                {
                    return -1;
                }
            }catch(Exception exp)
            {
                throw (exp);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}
