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
  
    public partial class Form7 : Form
    {
        Database db = new Database();
        DataRow dRow;
        public string user;
        public string employeeposition;

        public Form7()
        {
            InitializeComponent();
            db.connect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("One or more required fields are missing", "STOP RIGHT THERE CRIMINAL SCUM!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            /*
            System.Data.SqlClient.SqlDataAdapter da;
            string sql = string.Format("SELECT * FROM usertable where username = '{0}' AND password = '{1}'", textBox1.Text, textBox2.Text);
            da = new System.Data.SqlClient.SqlDataAdapter(sql, db.con);
            */
            db.selectUserRecords(textBox1.Text, textBox2.Text, db.con);

            if (db.da.Fill(ds, "users") == 0)
            {
                MessageBox.Show("Invalid username or password", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                dRow = ds.Tables["users"].Rows[0];
                this.DialogResult = DialogResult.OK;
                this.employeeposition = dRow.ItemArray.GetValue(3).ToString();
                this.user = dRow.ItemArray.GetValue(1).ToString();
                this.Close();
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
    }
}
