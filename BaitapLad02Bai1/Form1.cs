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
    public partial class Form : System.Windows.Forms.Form
    {
        private List<Info> listInfo = new List<Info>();
        private int X;
        public int dem;

        public Form()
        {
            InitializeComponent();
            TaoBang();
            Control.CheckForIllegalCrossThreadCalls = false;
            lstData.FullRowSelect = true;
            
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
            
            listInfo.Add(new Info(txtHoTen.Text, txtTruong.Text, cmbLop.Text, cbxLoai.Text, txtMucHocBong.Text));
            lstData.Items.Add(AddItem());
            ClearBox();
        }

        public void ClearBox()
        {
            txtHoTen.Text = txtTruong.Text = "";
            //txtMucHocBong.Text = "";
            //cbxLoai.Text = cmbLop.Text = "";
        }

        public ListViewItem AddItem()
        {
            ListViewItem liv = new ListViewItem(txtHoTen.Text);

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
            while (X == -1){ }
            listInfo[X].Name = lstData.Items[X].SubItems[0].Text = txtHoTen.Text;
            listInfo[X].Lop = cmbLop.Text;
            listInfo[X].Loai = lstData.Items[X].SubItems[1].Text = cbxLoai.Text;
            listInfo[X].HocBong = lstData.Items[X].SubItems[2].Text = (txtMucHocBong.Text).Substring(0, (txtMucHocBong.Text).IndexOf("VNĐ") - 1);
            listInfo[X].Truong = txtTruong.Text;
            X = -1;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //if (lstData.SelectedItems.Count > 0)
            //{
            //    for (int i = 0; i < lstData.SelectedItems.Count; i++)
            //    {
            //        int a = lstData.TabIndex;
            //        lstData.SelectedItems[i].Remove();
            //    }
            //}
            //else
            //{

            //}

            dem = int.Parse(txtHoTen.Text);
            //for (int i = 0; i < X; i++)
            //{
            //    txtTruong.Text = i.ToString();
            //}
            Thread th = new Thread(Tang);
            th.Start();
        }

        void Tang()
        {
            
            for (int i = 0; i < dem; i++)
            {
                txtTruong.Text = i.ToString();
            }
        }

        private void lstData_SelectedIndexChanged(object sender, EventArgs e)
        {
            Thread thread = new Thread(LoadInfo);
            thread.Start();
        }


        void LoadInfo()
        {
            if (lstData.SelectedItems.Count > 0)
            {
                int index = -1;
                for (int i = 0; i < lstData.Items.Count; i++)
                {
                    if (lstData.Items[i].Text == lstData.SelectedItems[0].Text)
                    {
                        index = i;
                        X = index;
                        break;
                    }
                }

                txtHoTen.Text = listInfo[index].Name;
                txtTruong.Text = listInfo[index].Truong;
                txtMucHocBong.Text = listInfo[index].HocBong;
                cbxLoai.Text = listInfo[index].Loai;
                cmbLop.Text = listInfo[index].Lop;
            }
        }
    }
}
