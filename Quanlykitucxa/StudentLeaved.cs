using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlykitucxa
{
    
    public partial class StudentLeaved : Form
    {
        String query;
        function fn = new function();
        public StudentLeaved()
        {
            InitializeComponent();
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StudentLeaved_Load(object sender, EventArgs e)
        {
            this.Location = new Point(470, 110);
            query = "SELECT * FROM newStudent WHERE living='No'";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
