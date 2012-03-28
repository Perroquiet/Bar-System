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
        string pos, user, squery;

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
                     toolStripButton5.Enabled = false;
                     toolStripButton4.Enabled = false;
                     toolStripButton6.Enabled = false;
                     toolStripButton3.Enabled = false;
                 }
                if (loginform.employeeposition == "cashier")
                {
                    addItemToolStripMenuItem.Enabled = false;
                    addSupplierToolStripMenuItem.Enabled = false;
                    upToolStripMenuItem.Enabled = false;
                    toolStripButton4.Enabled = false;
                    toolStripButton3.Enabled = false;
                }
                this.user = loginform.user;                 
                this.pos = loginform.employeeposition;  
                this.label1.Text = String.Format("Position: {0}", pos.ToUpper());
                this.label2.Text = String.Format("Username: {0}", user);
                this.squery = "items";
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
            db.dataGrid(dt, "itemtable");
            dataGridView1.DataSource = dt;
            this.squery = "items";
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.Font = new Font(textBox1.Font, FontStyle.Italic);
            textBox1.ForeColor = Color.Gray;
            textBox1.Text = "Items";
            textBox1.Enabled = false;
            textBox1.Enabled = true;
        }

        private void suppliersToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();       
            db.dataGrid(dt, "suppliertable");
            dataGridView1.DataSource = dt;
            this.squery = "suppliers";
            textBox1.Font = new Font(textBox1.Font, FontStyle.Italic);
            textBox1.ForeColor = Color.Gray;
            textBox1.Text = "Suppliers";
            textBox1.Enabled = false;
            textBox1.Enabled = true;
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
            db.dataGrid(dt, "itemtable");
            dataGridView1.DataSource = dt;
            int rowCount = ((DataTable)this.dataGridView1.DataSource).Rows.Count;
            dataGridView1.Rows[rowCount - 1].Selected = true;
            dataGridView1.FirstDisplayedScrollingRowIndex = rowCount - 1;
            this.squery = "items";            
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.Font = new Font(textBox1.Font, FontStyle.Italic);
            textBox1.ForeColor = Color.Gray;
            textBox1.Text = "Items";
            textBox1.Enabled = false;
            textBox1.Enabled = true;


        }

        private void generatesupplierlist()
        {
            DataTable dt = new DataTable();    

            db.dataGrid(dt, "suppliertable");
            dataGridView1.DataSource = dt;
            int rowCount = ((DataTable)this.dataGridView1.DataSource).Rows.Count;
            dataGridView1.Rows[rowCount - 1].Selected = true;
            dataGridView1.FirstDisplayedScrollingRowIndex = rowCount - 1; this.squery = "suppliers";
            textBox1.Font = new Font(textBox1.Font, FontStyle.Italic);
            textBox1.ForeColor = Color.Gray;
            textBox1.Text = "Suppliers";
            textBox1.Enabled = false;
            textBox1.Enabled = true;

        }

        private void itemsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form4 updateitemform = new Form4();            
            if (updateitemform.ShowDialog() == DialogResult.OK)
            {
                updateitemform.Close();
                DataTable dt = new DataTable();
                db.dataGrid(dt, "itemtable");
                dataGridView1.DataSource = dt;
                this.squery = "items";
                textBox1.SelectionStart = textBox1.Text.Length;
                textBox1.Font = new Font(textBox1.Font, FontStyle.Italic);
                textBox1.ForeColor = Color.Gray;
                textBox1.Text = "Items";
                textBox1.Enabled = false;
                textBox1.Enabled = true;
            }           
            
        }

        private void suppliersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form5 updatesuppform = new Form5();
            if (updatesuppform.ShowDialog() == DialogResult.OK)
            {
                updatesuppform.Close();
                DataTable dt = new DataTable();
                db.dataGrid(dt, "suppliertable");
                dataGridView1.DataSource = dt;
                this.squery = "suppliers";
                textBox1.Font = new Font(textBox1.Font, FontStyle.Italic);
                textBox1.ForeColor = Color.Gray;
                textBox1.Text = "Suppliers";
                textBox1.Enabled = false;
                textBox1.Enabled = true;
            }   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                return;
            }

            DataTable dt = new DataTable();
            if (squery == "items")
                db.dataGrid2(dt, textBox1.Text);
            else if (squery == "sales")
                db.dataGrid4(dt, textBox1.Text);
            else db.dataGrid3(dt, textBox1.Text);
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
            this.squery = "sales";
            textBox1.Font = new Font(textBox1.Font, FontStyle.Italic);
            textBox1.ForeColor = Color.Gray;
            textBox1.Text = "Sales";
            textBox1.Enabled = false;
            textBox1.Enabled = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {          
            DataTable dt = new DataTable();
            db.dataGrid(dt, "itemtable");
            dataGridView1.DataSource = dt;
            this.squery = "items";            
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.Font = new Font(textBox1.Font, FontStyle.Italic);
            textBox1.ForeColor = Color.Gray;
            textBox1.Text = "Items";
            textBox1.Enabled = false;
            textBox1.Enabled = true;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {            
            DataTable dt = new DataTable();
            db.dataGrid(dt, "suppliertable");
            dataGridView1.DataSource = dt;
            this.squery = "suppliers";
            textBox1.Font = new Font(textBox1.Font, FontStyle.Italic);
            textBox1.ForeColor = Color.Gray;
            textBox1.Text = "Suppliers";
            textBox1.Enabled = false;
            textBox1.Enabled = true;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Form2 additemForm = new Form2();
            if (additemForm.ShowDialog() == DialogResult.OK)
            {
                generateitemlist();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Form3 supplieraddForm = new Form3();
            if (supplieraddForm.ShowDialog() == DialogResult.OK)
            {
                generatesupplierlist();
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {            
            squery = "sales";
            DataTable dt = new DataTable();
            db.dataGrid(dt, "sales");
            dataGridView1.DataSource = dt;
            this.squery = "sales";
            textBox1.Font = new Font(textBox1.Font, FontStyle.Italic);
            textBox1.ForeColor = Color.Gray;
            textBox1.Text = "Sales";
            textBox1.Enabled = false;
            textBox1.Enabled = true;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
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

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Items" || textBox1.Text == "Suppliers" || textBox1.Text == "Sales")
            {
                textBox1.Font = new Font(textBox1.Font, FontStyle.Regular);
                textBox1.ForeColor = Color.Black;
                textBox1.Text = "";
            }
            else return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "Confirm Log Out", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                Application.Restart();
            }
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
