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
        

        public Index()
        {
            InitializeComponent();
        }

        private void Index_Load(object sender, EventArgs e)
        {
            Searcher.OnStart();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.DataSource = Searcher.SearchAll(textBox1.Text);
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Graphics g = e.Graphics;
            Brush brush = ((e.State & DrawItemState.Selected) == DrawItemState.Selected) ?
                          Brushes.Red : new SolidBrush(e.BackColor);
            g.FillRectangle(brush, e.Bounds);
            e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), e.Font,
                     new SolidBrush(e.ForeColor), e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }

    }
}
