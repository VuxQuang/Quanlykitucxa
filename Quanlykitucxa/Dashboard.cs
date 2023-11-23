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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            Form1 fn = new Form1();
            fn.Show();
            this.Close();
        }

        private void btnManageRooms_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
