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
    public partial class UpdateStudent : Form
    {
        String query;
        function fn = new function();
        public UpdateStudent()
        {
            InitializeComponent();
        }
        public void clearAll()
        {
            txtMobile.Clear();
            txtName.Clear();
            txtEmail.Clear();
            txtMother.Clear();
            txtFather.Clear();
            txtCollege.Clear();
            txtIdProof.Clear();
            txtPermanent.Clear();
            txtRoomNo.Clear();
            comboxLiving.SelectedIndex = -1;
        }
        private void btnExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateStudent_Load(object sender, EventArgs e)
        {
            this.Location = new Point(470, 110);
            UpdateStudent upd = new UpdateStudent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            query = "SELECT * FROM newStudent WHERE mobile =" + txtMobile.Text + "";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows.Count != 0)
            {
                txtName.Text = ds.Tables[0].Rows[0][2].ToString();
                txtFather.Text = ds.Tables[0].Rows[0][3].ToString();
                txtMother.Text = ds.Tables[0].Rows[0][4].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0][5].ToString();
                txtPermanent.Text = ds.Tables[0].Rows[0][6].ToString();
                txtCollege.Text = ds.Tables[0].Rows[0][7].ToString();
                txtIdProof.Text = ds.Tables[0].Rows[0][8].ToString();
                txtRoomNo.Text  = ds.Tables[0].Rows[0][9].ToString();
                comboxLiving.Text = ds.Tables[0].Rows[0][10].ToString();
            }
            else
            {
                clearAll();
                MessageBox.Show("Số điện thoại không hợp lệ", "Thông tin" , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Int64 mobile = Int64.Parse(txtMobile.Text);
            String name = txtName.Text;
            String fname = txtFather.Text;
            String mname = txtMother.Text;
            String email = txtEmail.Text;
            String paddress = txtPermanent.Text;
            String college = txtCollege.Text;
            String idproof = txtIdProof.Text;
            Int64 roomNo = Int64.Parse(txtRoomNo.Text);
            String livingStatus = comboxLiving.Text;

            query = "update newStudent set name='" + name + "', fname ='" + fname + "', mname='" + mname +"', email='" + email + "', paddress = '" + paddress + "', college= '" + college + "',idproof='" + idproof + "', roomNo= " + roomNo + ", living= '" + livingStatus + "' where mobile= " + mobile + " update rooms set Booked = '" + livingStatus + "' where roomNo =" + roomNo + "";
            fn.setData(query, "Cập nhật dữ liệu thành công");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn không", "Xác nhận", MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                query = "DELETE FROM newStudent WHERE mobile=" + txtMobile.Text + "";
                fn.setData(query, "Da xoa sinh vien");
                clearAll();
            }
        }
    }
}
