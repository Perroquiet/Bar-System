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
    public partial class Form4 : Form
    {
        System.Data.SqlClient.SqlConnection con;        
        DataRow[] dRow;

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            con = new System.Data.SqlClient.SqlConnection();
            con.ConnectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\USER\\Documents\\C# DB\\inventorydb.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Eneter a search keyword", "Enter Search Keyword", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            
            System.Data.SqlClient.SqlDataAdapter da;

            string sql = string.Format("SELECT * FROM itemtable where Item_Name LIKE '%{0}%'", textBox1.Text);

            DataSet ds = new DataSet();
            da = new System.Data.SqlClient.SqlDataAdapter(sql, con);
            da.Fill(ds,"items");

            dRow = new DataRow[ds.Tables["items"].Rows.Count];

            for (int i = 0; i < ds.Tables["items"].Rows.Count; i++)
            {
                dRow[i] = ds.Tables["items"].Rows[i];
            }

            System.Object[] ItemObject = new System.Object[dRow.Length];

            for (int i = 0; i < dRow.Length; i++)
            {
                ItemObject[i] = dRow[i].ItemArray.GetValue(2).ToString();
            }            
            comboBox1.Items.AddRange(ItemObject);
            if(comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox5.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
          
            textBox5.Text = dRow[comboBox1.SelectedIndex].ItemArray.GetValue(1).ToString();
            textBox2.Text = dRow[comboBox1.SelectedIndex].ItemArray.GetValue(2).ToString();
            textBox3.Text = dRow[comboBox1.SelectedIndex].ItemArray.GetValue(3).ToString();
            textBox4.Text = dRow[comboBox1.SelectedIndex].ItemArray.GetValue(4).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("One or more required fields are missing", "STOP RIGHT THERE CRIMINAL SCUM!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "UPDATE itemtable SET Item_Name = @itemname, Item_Description = @itemdesc, Item_Price = @itemprice, Item_Quantity = @itemquant where Item_ID = @itemid";
            cmd.Connection = con;           

            cmd.Parameters.AddWithValue("@itemname", textBox5.Text);
            cmd.Parameters.AddWithValue("@itemdesc", textBox2.Text);
            cmd.Parameters.AddWithValue("@itemprice", textBox3.Text);
            cmd.Parameters.AddWithValue("@itemquant", textBox4.Text);
            cmd.Parameters.AddWithValue("@itemid", dRow[comboBox1.SelectedIndex].ItemArray.GetValue(0).ToString());

            if (MessageBox.Show("Are you sure you want to update this item's information?", "Confirm Update", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;               
            }

            else return;
            
            cmd.ExecuteNonQuery();
        }

      
    }
}
