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
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT INTO suppliertable VALUES(@suppName,@suppAdd,@suppCN,@suppEmail)";
            cmd.Connection = con;

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("One or more required fields are missing", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            cmd.Parameters.AddWithValue("@suppName", textBox1.Text);
            cmd.Parameters.AddWithValue("@suppAdd", textBox2.Text);
            cmd.Parameters.AddWithValue("@suppCN", textBox3.Text);
            cmd.Parameters.AddWithValue("@suppEmail", textBox4.Text);

            cmd.ExecuteNonQuery();
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
