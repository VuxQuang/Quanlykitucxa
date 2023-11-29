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
    public partial class EmployeePayment : Form
    {
        String query;
        function fn = new function();
        public EmployeePayment()
        {
            InitializeComponent();
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EmployeePayment_Load(object sender, EventArgs e)
        {
            this.Location = new Point(470, 110);
            monthDateTime.Format = DateTimePickerFormat.Custom;
            monthDateTime.CustomFormat = "MMMM yyyy";
        }
        public void clearAll()
        {
            txtName.Clear();
            txtDesigation.Clear();
            txtEmail.Clear();
            txtPayment.Clear();
            txtMobile.Clear();
            dataGridView1.DataSource = 0;
        }
        public void setDataGrid(Int64 mobile)
        {
            query = "SELECT * FROM employeeSalary WHERE mobileNo = " + mobile + "";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtMobile.Text != "")
            {
                query = "Select ename, eemail, edesignation from newEmployee Where emobile = " + txtMobile.Text + "";
                DataSet ds = fn.getData(query);

                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtName.Text = ds.Tables[0].Rows[0][0].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtDesigation.Text = ds.Tables[0].Rows[0][2].ToString();

                    setDataGrid(Int64.Parse(txtMobile.Text));
                }
                else
                {
                    MessageBox.Show("Hồ sơ này không tồn tại", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số điện thoại", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if(txtMobile.Text != "" && txtPayment.Text != "")
            {
                query = "Select * from employeeSalary WHERE mobileNo = " + txtMobile.Text + "AND fmonth ='" + monthDateTime.Text + "'"; 
                DataSet ds = fn.getData(query);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    Int64 mobile = Int64.Parse(txtMobile.Text);
                    String month = monthDateTime.Text;
                    Int64 amount = Int64.Parse(txtPayment.Text);

                    query = "Insert into employeeSalary values("+mobile+",'" + month + "', " + amount + ")";
                    fn.setData(query, "Lương tháng" + monthDateTime.Text + "Đã trả là" + amount);
                    setDataGrid(mobile);
                }
                else
                {
                    MessageBox.Show("Vui lòng kiểm tra lại", "Thông tin", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();        
        }
    }
}

