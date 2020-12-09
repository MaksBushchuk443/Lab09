using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab09
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
          
            double x1min = double.Parse(tbX1min.Text);
            double x1max = double.Parse(tbX2max.Text);
            double x2min = double.Parse(tbX2min.Text);
            double x2max = double.Parse(tbX2max.Text);
            double dx1 = double.Parse(tbDx1.Text); double
            dx2 = double.Parse(tbDx2.Text);
            gv.ColumnCount = (int)Math.Truncate((x2max - x2min) / dx2) + 1;
            gv.RowCount = (int)Math.Truncate((x1max - x1min) / dx1) + 1;
            for  (int i = 0; i < gv.RowCount; i++)
            gv.Rows[i].HeaderCell.Value = (x1min + i * dx1).ToString("0.000");
            gv.RowHeadersWidth = 80;
            for (int i = 0; i < gv.ColumnCount; i++)
            {
                gv.Columns[i].HeaderCell.Value = (x2min + i *
               dx2).ToString("0.000");
                gv.Columns[i].Width = 60;
            }
            int cl, rw; double
            x1, x2, y;
            rw = 0; x1 = x1min;
            while (x1 <= x1max)
            {
                x2 = x2min;
                cl = 0;
                while (x2 <= x2max)
                {
                    y = x1 + x2;
                    gv.Rows[rw].Cells[cl].Value = y.ToString("0.000");
                    x2 += dx2; cl++;
                }
                x1
             += dx1;
                rw++;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbX1min.Text = "";
            tbX1max.Text = "";
            tbX2min.Text = "";
            tbX2max.Text = "";
            tbDx1.Text = "";
            tbDx2.Text = "";
            gv.Rows.Clear();
            for (int Cl = 0; Cl < gv.ColumnCount; Cl++)
                gv.Columns[Cl].HeaderCell.Value = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Закрити програму?", "Вихід з програми",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            Application.Exit();
        }
    }
}
