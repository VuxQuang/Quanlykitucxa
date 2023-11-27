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
    public partial class Employee : Form
    {
        function fn = new function();
        String query;
        public Employee()
        {
            InitializeComponent();
        }
        public void ClearAll()
        {
            txtMobile.Clear();
            txtEmail.Clear();
            txtName.Clear();
            txtFather.Clear();
            txtMother.Clear();
            txtPermanent.Clear();
            txtDesignation.SelectedIndex = -1;
            txtIdProof.Clear();
        }
        private void btnExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtMobile.Text != "" && txtName.Text !="" && txtFather.Text != "" && txtMother.Text != "" && txtEmail.Text != "" && txtPermanent.Text != "" && txtIdProof.Text != "" && txtDesignation.SelectedIndex != -1)
            {
                Int64 mobile = Int64.Parse(txtMobile.Text);
                String name = txtName.Text;
                String fname = txtFather.Text;
                String mname = txtMother.Text;
                String email = txtEmail.Text;
                String address = txtPermanent.Text;
                String designation = txtDesignation.Text;
                String idproof = txtIdProof.Text;

                query = "insert into newEmployee(emobile,ename,efname,emname,eemail,epaddress,eidproof,edesignation) values (" + mobile + ", '" + name + "', '" + fname + "','" + mname + "','" + email + "','" + address + "','" + idproof + "','" + designation + "')";
                fn.setData(query, "Đã thêm nhân viên mới thành công");
                ClearAll();
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông tin cần xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
               
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            this.Location = new Point(470, 110);
        }
    }
}
