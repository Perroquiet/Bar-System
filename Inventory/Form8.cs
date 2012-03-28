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
    public partial class Form8 : Form
    {
        DataRow[] dRow;
        Database db = new Database();
        public string employee;

        public Form8()
        {
            InitializeComponent();
            db.connect();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            
            DataSet ds = new DataSet();
            /*
            System.Data.SqlClient.SqlDataAdapter da;
            string sql = string.Format("SELECT * FROM itemtable");
            da = new System.Data.SqlClient.SqlDataAdapter(sql, db.con);
            da.Fill(ds, "items");
            */
            db.selectAddSale(ds, db.con);

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
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
            textBox2.Text = "0";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            float totalprice;

            textBox1.Text = dRow[comboBox1.SelectedIndex].ItemArray.GetValue(3).ToString();
            textBox2.Text = "0";          
            totalprice = float.Parse(textBox1.Text) * int.Parse(textBox2.Text);
            textBox3.Text = totalprice.ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            float totalprice;
            try
            {
                int temp = Int32.Parse(textBox2.Text);
                totalprice = float.Parse(textBox1.Text) * int.Parse(textBox2.Text);
                textBox3.Text = totalprice.ToString();
            }
            catch (Exception)
            {
                totalprice = 0;
                textBox3.Text = totalprice.ToString();
            }
                
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int temp = Convert.ToInt32(textBox2.Text);
                if (Convert.ToInt32(textBox2.Text) == 0 || Convert.ToInt32(textBox2.Text) < 0)
                {
                    MessageBox.Show("Please provide quantity.");
                    return;
                }
            }
            catch (Exception)
            {
                if (textBox2.Text == string.Empty)
                {
                    MessageBox.Show("Please provide quantity.");
                    return;
                }               
                else
                {
                    MessageBox.Show("Please provide number only.");
                    textBox2.Text = "0";
                    return;
                }
            }
                        
            if (int.Parse(textBox2.Text) > int.Parse(dRow[comboBox1.SelectedIndex].ItemArray.GetValue(4).ToString()))
            {
                MessageBox.Show("Not enough items in inventory", "STOP RIGHT THERE CRIMINAL SCUM!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Inventory inventory = new Inventory();
            inventory.addsale(dRow[comboBox1.SelectedIndex].ItemArray.GetValue(0).ToString(), dRow[comboBox1.SelectedIndex].ItemArray.GetValue(1).ToString(), dRow[comboBox1.SelectedIndex].ItemArray.GetValue(2).ToString(), textBox1.Text, textBox2.Text, textBox3.Text, this.employee, DateTime.Now, db.con);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
