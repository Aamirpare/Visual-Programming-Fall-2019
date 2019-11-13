using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDemo2
{
    public partial class Editor : Form
    {
        public Editor()
        {
            InitializeComponent();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            var result =  this.CloseApplication();
            if (result == DialogResult.No) e.Cancel = true;
        }
        private DialogResult CloseApplication()
        {
            DialogResult result = MessageBox.Show("Would you like to exit application", "Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            return result;
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CloseApplication();
        }
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.ShowDialog();
            richTextBox1.Font = fd.Font;
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open file dialog";
            ofd.Filter = "Text File *.txt|*.txt";
            if( ofd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = System.IO.File.ReadAllText(ofd.FileName);
                MessageBox.Show(""+richTextBox1.Text.Length);
            }

        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save file dialog";
            sfd.Filter = "Text File *.txt|*.txt";
            if( sfd.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(sfd.FileName, richTextBox1.Text);
            }
        }

        private void gridViewDemoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new GridViewDemo();
            frm.ShowDialog();
        }
    }
}
