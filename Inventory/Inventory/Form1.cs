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
    public partial class Form1 : Form
    {
        System.Data.SqlClient.SqlConnection con;
    
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new System.Data.SqlClient.SqlConnection();
            con.ConnectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=E:\\inventorydb.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";

            con.Open();
            MessageBox.Show("Welcome Shadowstrider!\n\nFUS RO DAH!","Log In Successful!",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void generateListToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void upToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                Application.Exit();
            }
        }
   
        private void addItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 additemForm = new Form2();
            if (additemForm.ShowDialog() == DialogResult.OK)
            {
                generateitemlist();
            }
            
        }

        private void itemsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            System.Data.SqlClient.SqlDataAdapter da;

            string sql = "SELECT * FROM itemtable";
            da = new System.Data.SqlClient.SqlDataAdapter(sql, con);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void suppliersToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            System.Data.SqlClient.SqlDataAdapter da;

            string sql = "SELECT * FROM suppliertable";
            da = new System.Data.SqlClient.SqlDataAdapter(sql, con);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void addSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 supplieraddForm = new Form3();
           if (supplieraddForm.ShowDialog() == DialogResult.OK)
            {
                generatesupplierlist();
            }
        }

        private void generateitemlist()
        {
            DataTable dt = new DataTable();
            System.Data.SqlClient.SqlDataAdapter da;

            string sql = "SELECT * FROM itemtable";
            da = new System.Data.SqlClient.SqlDataAdapter(sql, con);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            int rowCount = ((DataTable)this.dataGridView1.DataSource).Rows.Count;
            dataGridView1.Rows[rowCount - 1].Selected = true;
            dataGridView1.FirstDisplayedScrollingRowIndex = rowCount - 1;

        }

        private void generatesupplierlist()
        {
            DataTable dt = new DataTable();
            System.Data.SqlClient.SqlDataAdapter da;

            string sql = "SELECT * FROM suppliertable";
            da = new System.Data.SqlClient.SqlDataAdapter(sql, con);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            int rowCount = ((DataTable)this.dataGridView1.DataSource).Rows.Count;
            dataGridView1.Rows[rowCount - 1].Selected = true;
            dataGridView1.FirstDisplayedScrollingRowIndex = rowCount - 1;
        }

        private void itemsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form4 updateitemform = new Form4();            
            if (updateitemform.ShowDialog() == DialogResult.OK)
            {
                updateitemform.Close();
            }           
            
        }

        private void suppliersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form5 updatesuppform = new Form5();
            if (updatesuppform.ShowDialog() == DialogResult.OK)
            {
                updatesuppform.Close();
            }   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                return;
            }

            DataTable dt = new DataTable();
            System.Data.SqlClient.SqlDataAdapter da;

            string sql = string.Format("SELECT * FROM itemtable where Item_Name LIKE '%{0}%'", textBox1.Text);
            da = new System.Data.SqlClient.SqlDataAdapter(sql, con);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            int rowCount = ((DataTable)this.dataGridView1.DataSource).Rows.Count;
            if (rowCount > 0)
            {
                dataGridView1.Rows[0].Selected = true;
                dataGridView1.FirstDisplayedScrollingRowIndex = 0;
            }
            else return;
        }

       
    }
}
