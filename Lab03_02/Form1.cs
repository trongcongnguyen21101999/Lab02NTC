using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadFont();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode.Equals(Keys.N))
                {
                    tsmiNew_Click(null, null);
                    MessageBox.Show("Tao Mới");
                }
            }
        }

        private void tsmiNew_Click(object sender, EventArgs e)
        {
            rtxtData.Text = "";
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
        }

        public void LoadFont()
        {
            InstalledFontCollection installed = new InstalledFontCollection();

            foreach (FontFamily item in installed.Families)
            {
                tscbxFont.Items.Add(item.Name);
            }
            //int[] A = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            string[] A = { "8", "9", "10", "11", "12", "14", "16", "18", "20", "22", "24", "26", "28", "36", "48", "72" };

            tscbxSize.Items.AddRange(A);
            
        }
    }
}
