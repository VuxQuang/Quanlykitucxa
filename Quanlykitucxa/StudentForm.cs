using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Quanlykitucxa
{
    public partial class StudentForm : Form
    {
        String query;
        function fn = new function();
        public StudentForm()
        {
            InitializeComponent();
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clearAll()
        {
            txtMobile.Clear();
            txtName.Clear();
            txtFather.Clear();
            txtMother.Clear();
            txtEmail.Clear();
            txtPermanent.Clear();
            txtCollege.Clear();
            txtIdProof.Clear();
            comboRoomNo.SelectedIndex = -1;
        }
        private void comboRoomNo_Load(object sender, EventArgs e)
        {
            this.Location = new Point(470, 110);
            query = "SELECT roomNo from rooms WHERE roomStatus='Yes' AND Booked = 'No'";
            DataSet ds = fn.getData(query);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Int64 room = Int64.Parse(ds.Tables[0].Rows[i][0].ToString());
                comboRoomNo.Items.Add(room);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMobile.Text != "" && txtName.Text != "" && txtFather.Text != "" && txtMother.Text != "" && txtEmail.Text != ""  && txtPermanent.Text != "" && txtCollege.Text != "" && txtIdProof.Text != "" && comboRoomNo.SelectedIndex != -1)
            {
                Int64 mobile = Int64.Parse(txtMobile.Text);
                String name = txtName.Text;
                String fname = txtFather.Text;
                String mname = txtMother.Text;
                String email = txtEmail.Text;
                String paddress = txtPermanent.Text;
                String college = txtCollege.Text;
                String idproof = txtIdProof.Text;
                Int64 roomNo = Int64.Parse(comboRoomNo.Text);
                query = "insert into newStudent(mobile,name,fname,mname,email,paddress,college,idproof,roomNo) values (" + mobile + "," + name + "," + fname + "," + mname + "," + email + "," + paddress + "," + college + "," + idproof + "," + roomNo + ") update rooms set Booked ='Yes' WHERE roomNO = " + roomNo + "";
                fn.setData(query, "Sinh vien dang ki thanh cong");
                clearAll();
            }
            else
            {
                MessageBox.Show("Hay dien het yeu cau cua thong tin", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}


