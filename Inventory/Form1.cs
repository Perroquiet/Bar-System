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
        //System.Data.SqlClient.SqlConnection con;

        Database db = new Database();
        string user;

        public Form1()
        {        
            InitializeComponent();                        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
            Form7 loginform = new Form7();            

            if (loginform.ShowDialog() != DialogResult.OK)
            {
                Application.Exit();
            }
            else
            {
                if(loginform.employeeposition == "attendant")
                 {
                     addItemToolStripMenuItem.Enabled = false;
                     addSupplierToolStripMenuItem.Enabled = false;
                     upToolStripMenuItem.Enabled = false;
                     salesToolStripMenuItem.Enabled = false;
                     addCashierSaleToolStripMenuItem.Enabled = false;
                 }
                if (loginform.employeeposition == "cashier")
                {
                    addItemToolStripMenuItem.Enabled = false;
                    addSupplierToolStripMenuItem.Enabled = false;
                    upToolStripMenuItem.Enabled = false;
                }
                this.user = loginform.user;
                db.connect();
            }
         
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

            /* wala nani xa.
            System.Data.SqlClient.SqlDataAdapter da;

            string sql = "SELECT * FROM itemtable";
            da = new System.Data.SqlClient.SqlDataAdapter(sql, db.con);
            da.Fill(dt);
             */
            db.dataGrid(dt, "itemtable");
            dataGridView1.DataSource = dt;
        }

        private void suppliersToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            /* wala nani xa.
            System.Data.SqlClient.SqlDataAdapter da;

            string sql = "SELECT * FROM suppliertable";
            da = new System.Data.SqlClient.SqlDataAdapter(sql, db.con);
            da.Fill(dt);
             */
            
            db.dataGrid(dt, "suppliertable");
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
            /* wala nani xa.
            System.Data.SqlClient.SqlDataAdapter da;

            string sql = "SELECT * FROM itemtable";
            da = new System.Data.SqlClient.SqlDataAdapter(sql, db.con);
            da.Fill(dt);
             */
            db.dataGrid(dt, "itemtable");
            dataGridView1.DataSource = dt;
            int rowCount = ((DataTable)this.dataGridView1.DataSource).Rows.Count;
            dataGridView1.Rows[rowCount - 1].Selected = true;
            dataGridView1.FirstDisplayedScrollingRowIndex = rowCount - 1;

        }

        private void generatesupplierlist()
        {
            DataTable dt = new DataTable();

            /* wala nani xa.
            System.Data.SqlClient.SqlDataAdapter da;
            string sql = "SELECT * FROM suppliertable";
            da = new System.Data.SqlClient.SqlDataAdapter(sql, db.con);
            da.Fill(dt);
             */

            db.dataGrid(dt, "suppliertable");
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
            /* wala nani xa.
            System.Data.SqlClient.SqlDataAdapter da;

            string sql = string.Format("SELECT * FROM itemtable where Item_Name LIKE '%{0}%'", textBox1.Text);
            da = new System.Data.SqlClient.SqlDataAdapter(sql, db.con);
            da.Fill(dt);
            */
            db.dataGrid2(dt, textBox1.Text);
            dataGridView1.DataSource = dt;
            int rowCount = ((DataTable)this.dataGridView1.DataSource).Rows.Count;
            if (rowCount > 0)
            {
                dataGridView1.Rows[0].Selected = true;
                dataGridView1.FirstDisplayedScrollingRowIndex = 0;
            }
            else return;
        }

        private void addCashierSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Form8 saleform = new Form8();
            saleform.employee = this.user;
            if (saleform.ShowDialog() == DialogResult.OK)
            {                
                db.dataGrid(dt, "sales");
                dataGridView1.DataSource = dt;
                int rowCount = ((DataTable)this.dataGridView1.DataSource).Rows.Count;
                dataGridView1.Rows[rowCount - 1].Selected = true;
                dataGridView1.FirstDisplayedScrollingRowIndex = rowCount - 1;
            }
            
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();          
            db.dataGrid(dt, "sales");
            dataGridView1.DataSource = dt;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        /*
        private void itemHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            db.dataGrid(dt, "itemtimetable");
            dataGridView1.DataSource = dt;
        }
        */
       
    }
}
