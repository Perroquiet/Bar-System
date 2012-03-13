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
        System.Data.SqlClient.SqlConnection con;
        DataRow[] dRow;
        //Database con;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //con = Database.connect();
            con = new System.Data.SqlClient.SqlConnection();
            con.ConnectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\USER\\Documents\\C# DB\\inventorydb.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";

            con.Open();

            System.Data.SqlClient.SqlDataAdapter da;
            string sql = string.Format("SELECT * FROM suppliertable");

            DataSet ds = new DataSet();
            da = new System.Data.SqlClient.SqlDataAdapter(sql, con);
            da.Fill(ds, "suppliers");

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
            Inventory inventory = new Inventory(con);

            inventory.addItem(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);

            inventory.addItemDate(dRow[comboBox1.SelectedIndex].ItemArray.GetValue(0).ToString());

            this.DialogResult = DialogResult.OK;
            this.Close();
        }


    }
}
