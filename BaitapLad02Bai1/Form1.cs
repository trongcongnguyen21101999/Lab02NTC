using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaitapLad02Bai1
{
    public partial class Form1 : Form
    {
        private List<Info> listInfo = new List<Info>();

        public Form1()
        {
            InitializeComponent();
            TaoBang();
            Control.CheckForIllegalCrossThreadCalls = false;
            
        }

        public void TaoBang()
        {
            lstData.Columns.Add("Họ Tên", 210);
            lstData.Columns.Add("Loại", 80);
            lstData.Columns.Add("Học Bổng", 120);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxLoai.Text)
            {
                case "Khá":
                    txtMucHocBong.Text = "100.000 VNĐ";
                    break;
                case "Giỏi":
                    txtMucHocBong.Text = "300.000 VNĐ";
                    break;
                case "Xuất sắc":
                    txtMucHocBong.Text = "500.000 VNĐ";
                    break;
            }
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Thread thd = new Thread(Them);
            if (CheckNull())
            {
                thd.Start();
            }
            else
            {
                MessageBox.Show("Chưa nhập đủ thông tin","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        void Them()
        {
            Info info = new Info(txtHoTen.Text, txtTruong.Text, cmbLop.Text, cbxLoai.Text, txtMucHocBong.Text);
            listInfo.Add(info);
            lstData.Items.Add(AddItem());
        }

        public void ClearBox()
        {
            txtHoTen.Text = txtMucHocBong.Text = txtTruong.Text = "";
            cbxLoai.Text = cmbLop.Text = "";
        }

        public ListViewItem AddItem()
        {
            ListViewItem liv = new ListViewItem();

            liv.Text = txtHoTen.Text;
            liv.SubItems.Add(cbxLoai.Text);
            string HB = txtMucHocBong.Text;
            HB = HB.Substring(0, HB.IndexOf("VNĐ") - 1);
            liv.SubItems.Add(HB);
            liv.Tag = (lstData.Items.Count - 1).ToString();

            return liv;
        }

        public bool CheckNull()
        {
            if (txtHoTen.Text == "")
            {
                return false;
            }
            if (txtTruong.Text == "")
            {
                return false;
            }
            if (txtMucHocBong.Text == "")
            {
                return false;
            }
            if (cmbLop.Text == "")
            {
                return false;
            }
            return true;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (lstData.SelectedItems.Count > 0)
            {
                for (int i = 0; i < lstData.SelectedItems.Count; i++)
                {
                    for (int j = 0; j < lstData.SelectedItems[i].SubItems.Count; j++)
                    {
                        lstData.SelectedItems[i].SubItems.RemoveAt(j);
                    }
                }
            }
        }
    }
}
