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
    public partial class Form2 : Form
    {
        DataRow[] dRow;
        Database db = new Database();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            db.connect();
            DataSet ds = new DataSet();
            
            /*
            System.Data.SqlClient.SqlDataAdapter da;
            string sql = string.Format("SELECT * FROM suppliertable");
            
            
            da = new System.Data.SqlClient.SqlDataAdapter(sql, db.con);
            da.Fill(ds, "suppliers");
            */
           
            
            db.dataSet(ds, "suppliertable", db.con);
            
            dRow = new DataRow[ds.Tables["suppliers"].Rows.Count];

            for (int i = 0; i < ds.Tables["suppliers"].Rows.Count; i++)
            {
                dRow[i] = ds.Tables["suppliers"].Rows[i];
            }
            
            System.Object[] SupplierObject = new System.Object[dRow.Length];

            for (int i = 0; i < dRow.Length; i++)
            {
                SupplierObject[i] = dRow[i].ItemArray.GetValue(1).ToString();
            }
            comboBox1.Items.AddRange(SupplierObject);
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }     
        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("One or more required fields are missing", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Inventory inventory = new Inventory(textBox1.Text, textBox2.Text, float.Parse(textBox3.Text), int.Parse(textBox4.Text), db.con);
        
            inventory.addItem();

            inventory.addItemDate(dRow[comboBox1.SelectedIndex].ItemArray.GetValue(0).ToString(), dRow[comboBox1.SelectedIndex].ItemArray.GetValue(1).ToString(), db.con);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 supplieraddForm = new Form3();
            if (supplieraddForm.ShowDialog() == DialogResult.OK)
            {
                
                //generatesupplierlist();
            }
        }

  }
}
