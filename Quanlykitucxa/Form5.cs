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
    public partial class Form5 : Form
    {
        String query;
        function fn = new function();
        public Form5()
        {
            InitializeComponent();
        }
        public void ClearAll()
        {
            txtMobile.Clear();
            txtDesignation.SelectedIndex = -1;
            txtIdProof.Clear();
            txtFather.Clear();
            txtMother.Clear();
            txtName.Clear();
            txtPermanent.Clear();
            txtEmail.Clear();
            txtStatus.SelectedIndex = -1;
        }
        private void btnExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            query = "SELECT * FROM newEmployee WHERE emobile =" + txtMobile.Text + "";
            DataSet ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count != 0)
            {
                txtName.Text = ds.Tables[0].Rows[0][2].ToString();
                txtFather.Text = ds.Tables[0].Rows[0][3].ToString();
                txtMother.Text = ds.Tables[0].Rows[0][4].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0][5].ToString();
                txtPermanent.Text = ds.Tables[0].Rows[0][6].ToString();
                txtIdProof.Text = ds.Tables[0].Rows[0][7].ToString();
                txtDesignation.Text = ds.Tables[0].Rows[0][8].ToString();
                txtStatus.Text = ds.Tables[0].Rows[0][9].ToString();

            }
            else
            {
                MessageBox.Show("Xin mời nhập thêm thông tin", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearAll();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Int64 mobile = Int64.Parse(txtMobile.Text);
            String name = txtName.Text;
            String fname = txtFather.Text;
            String mname = txtMother.Text;
            String email = txtEmail.Text;
            String paddress = txtPermanent.Text;
            String idproof = txtIdProof.Text;
            String designation = txtDesignation.Text;
            String working = txtStatus.Text;
            

            query = "Update newEmployee set ename ='" + name + "', efname = '" + fname + "', emname = '" + mname + "', eemail = '" + email + "', epaddress ='" + paddress + "', eidproof = '" + idproof + "', edesignation ='" + designation + "', working = '" + working + "' where emobile = " + mobile + "";
            fn.setData(query, "Cập nhật dữ liệu thành công");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           if (MessageBox.Show("Bạn có chắc muốn xóa thông tin ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                query = "Delete From newEmployee WHERE emobile =" + txtMobile.Text + "";
                fn.setData(query, "Đã xóa hồ sơ thông tin");
                ClearAll();
            }
        }
    }
}
