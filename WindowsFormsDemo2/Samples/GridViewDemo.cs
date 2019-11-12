using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDemo2
{
    public partial class GridViewDemo : Form
    {
        DataTable table = new DataTable();
        public GridViewDemo()
        {
            InitializeComponent();
            ///comboBox1.SelectedIndex = comboBox1.FindString("Pakistan");
            
            table.Columns.Add("Registration", typeof(int));
            table.Columns.Add("Full Name", typeof(string));
            table.Columns.Add("Email", typeof(string));
            table.Columns.Add("Phone", typeof(string));
            dataGridViewStudents.DataSource = table;
        }

        private void buttonPopulate_Click(object sender, EventArgs e)
        {
            string connectionStr = @"Data Source=localhost; Initial Catalog=UnipresentDB; Integrated Security=true";
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Student", connectionStr);
            DataTable dt = new DataTable("Student");
            da.Fill(dt);
            dataGridViewStudents.DataSource = dt;
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cb = sender as ComboBox;
            MessageBox.Show(cb.SelectedItem.ToString());
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            var dtp = sender as DateTimePicker;
            MessageBox.Show(dtp.Value.ToLongDateString());
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            var cells = dgv.Rows[e.RowIndex].Cells;
            foreach (DataGridViewCell cell in cells)
            {
                MessageBox.Show(cell.Value.ToString());
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            table.Rows.Add(100, "Asad Khan", "asad.khan@gmail.com", "0300-7659022");
            dataGridViewStudents.DataSource = table;
        }
    }
}
