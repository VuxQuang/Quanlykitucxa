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
    public partial class Form3 : Form
    {
        function fn = new function();
        String query;
        public Form3()
        {
            InitializeComponent();
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.Location = new Point(470, 110);
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "MMMM yyyy";
        }
        public void setDataGrid(Int64 mobile)
        {
            query = "SELECT * FROM fees WHERE mobileNo=" + mobile + "";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void clearAll()
        {
            txtMobile.Clear();
            txtName.Clear();
            txtAmount.Clear();
            txtEmail.Clear();
            txtRoomNo.Clear();
            dataGridView1.DataSource = 0;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtMobile.Text != "")
            {
                query = "Select name, email, roomNo from newStudent WHERE mobile=" + txtMobile.Text + "";
                DataSet ds = fn.getData(query);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtName.Text = ds.Tables[0].Rows[0][0].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0][1].ToString();
                }   txtRoomNo.Text = ds.Tables[0].Rows[0][2].ToString();
                    setDataGrid(Int64.Parse(txtMobile.Text));
            }
            else
            {
                MessageBox.Show("Hồ sơ này không tồn tại", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (txtMobile.Text != "" && txtAmount.Text !="")
            {
                query = "SELECT * FROM fees WHERE mobileNo =" + Int64.Parse(txtMobile.Text) + " and fmonth= '" + dateTimePicker.Text + "'";
                DataSet ds = fn.getData(query);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    Int64 mobile = Int64.Parse(txtMobile.Text);
                    String month = dateTimePicker.Text;
                    Int64 amount = Int64.Parse(txtAmount.Text);

                    query = "insert into fees values(" + mobile + ",'" + month + "'," + amount + ")";
                    fn.setData(query, "Phí đã trả");
                    clearAll();
                } else
                {
                    MessageBox.Show("Không có lệ phí" + dateTimePicker.Text + "Còn lại", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
