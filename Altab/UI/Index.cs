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
using Altab.Entries;

namespace UI
{
    public partial class Index : Form
    {
        Altab.Altab altab = new Altab.Altab();
        public Index()
        {
            InitializeComponent();
            InitAltab();
        }


        private void InitAltab()
        {
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
            if (entry.Icon != null)
            {
                e.Graphics.DrawIcon(entry.Icon, new Rectangle(0, e.Bounds.Y, 16, 16));
            }
            Rectangle textPosition = e.Bounds;
            textPosition.Offset(16, 0);
            e.Graphics.DrawString(entry.Name, e.Font,
                     new SolidBrush(e.ForeColor), textPosition, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Escape:
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    Minimize();
                    return;
                case Keys.Up:
                    if (listBox1.Items.Count > 0)
                        listBox1.SelectedIndex = listBox1.SelectedIndex == 0 ? listBox1.Items.Count - 1 : listBox1.SelectedIndex - 1;
                    break;
                case Keys.Down:
                    if (listBox1.Items.Count > 0)
                        listBox1.SelectedIndex = listBox1.SelectedIndex == listBox1.Items.Count - 1 ? 0 : listBox1.SelectedIndex + 1;
                    break;

                case Keys.Enter:
                    ((Entry)listBox1.SelectedItem).Run();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    Minimize();
                    //Don't
                    break;
            }
        }

        private void Minimize()
        {
            textBox1.Text = "";
            WindowState = FormWindowState.Minimized;
        }

        private void OnPressEnter()
        {
            ((Entry)listBox1.SelectedItem).Run();
            Minimize();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Select();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '\r': //Enter
                    ((Entry)listBox1.SelectedItem).Run();
                    e.Handled = true;
                    Minimize();
                    //Don't
                    break;
            }
        }
    }
}
