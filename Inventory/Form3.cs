using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        System.Data.SqlClient.SqlConnection con;

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("One or more required fields are missing", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }  
            Supplier supplier = new Supplier(con);

            supplier.addSupplier(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            con = new System.Data.SqlClient.SqlConnection();
            con.ConnectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\USER\\Documents\\C# DB\\inventorydb.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";

            con.Open();
        }
    }
}
