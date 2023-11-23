using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Xml;
namespace Quanlykitucxa
{
    internal class function
    {

        protected SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-2023JEV\\SQLEXPRESS;database=hostel;Integrated Security = True";
            return con;
        }

        public DataSet getData(String query)
        {
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            SqlDataAdapter da= new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void setData(String query, String msg)
        {
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(msg, "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
