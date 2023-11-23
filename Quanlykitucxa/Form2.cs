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
    public partial class Form2 : Form
    {
        function fn = new function();
        String query;
        public Form2()
        {
            InitializeComponent();
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Location = new Point(470, 110);
            labelRoom.Visible = false;
            labelRoomExist.Visible = false;

            query = "SELECT * FROM rooms";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            query = "SELECT * FROM rooms WHERE  roomNo =" + txtRoomNo.Text + "";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows.Count == 0)
            {
                
                String status;
                if (checkBox1.Checked)
                {
                    status = "Cho thuê phòng thành công";
                }
                else { status = "Chưa hợp lệ"; }
                labelRoomExist.Visible = false;
                query = "insert into rooms(roomNo,roomStatus) values (" + txtRoomNo.Text + ",'" + status + "')";
                fn.setData(query, "Da them phong");
                Form2_Load(this, null);
            }
            else
            {
                labelRoomExist.Text = "Phong da co";
                labelRoomExist.Visible = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            query = "SELECT * FROM rooms WHERE roomNo=" + txtRoomNo2.Text + "";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows.Count == 0)
            {
                labelRoom.Text = "Phòng này không tồn tại";
                labelRoom.Visible = true;
                checkBox2.Checked = false;
            } else
            {
                labelRoom.Text = "Phòng này đã tìm thấy";
                labelRoom.Visible = true;

                if (ds.Tables[0].Rows[0][1].ToString() == "Yes") 
                {
                    checkBox2.Checked = true;
                }
                else
                {
                    checkBox2.Visible = false;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String status;
            if (checkBox2.Checked)
            {
                status = "Phòng trống";
            }
            else
            {
                status = "Chưa hợp lệ";
            }
            query = "update rooms set roomStatus ='" + status + "' where roomNo =" + txtRoomNo2.Text + "";
            fn.setData(query, "Cap nhat da thanh cong");
            Form2_Load(this, null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (labelRoom.Text =="Phòng này đã tìm thấy")
            {
                query = "delete from rooms where roomNo=" + txtRoomNo2.Text + "";
                fn.setData(query, "Đã xóa thành công");
                Form2_Load(this, null);
            }
            else
            {
                MessageBox.Show("Không tìm thấy phòng cần thấy!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
