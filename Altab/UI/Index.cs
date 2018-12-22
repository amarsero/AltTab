using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Altab;

namespace UI
{
    public partial class Index : Form
    {
        Altab.Altab altab = new Altab.Altab();
        public Index()
        {
            InitializeComponent();
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.DataSource = altab.Deposit.SearchAll(textBox1.Text);
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Entry entry = listBox1.Items[e.Index] as Entry;
            e.DrawBackground();
            Graphics g = e.Graphics;
            Brush brush = ((e.State & DrawItemState.Selected) == DrawItemState.Selected) ?
                          Brushes.Red : new SolidBrush(e.BackColor);
            g.FillRectangle(brush, e.Bounds);
            e.Graphics.DrawString(entry.Name, e.Font,
                     new SolidBrush(e.ForeColor), e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                Minimize();
                return;
            }
        }

        private void Minimize()
        {
            textBox1.Text = "";
            WindowState = FormWindowState.Minimized;
        }
    }
}
