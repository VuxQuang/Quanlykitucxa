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
    
    public partial class LeavedEmployee : Form
    {
        String query;
        function fn = new function();
        public LeavedEmployee()
        {
            InitializeComponent();
        }

        private void LeavedEmployee_Load(object sender, EventArgs e)
        {
            this.Location = new Point(470, 110);
            query = "Select * from newEmployee Where working = 'No'";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
