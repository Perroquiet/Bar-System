﻿using System;
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
           
        DataRow[] dRow;
        Database db = new Database();

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            db.connect();
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
            DataSet ds = new DataSet();
            
            db.selectItemUpdateForm(ds, textBox1.Text, db.con);
            
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
            if (MessageBox.Show("Are you sure you want to update this item's information?", "Confirm Update", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;               
            }

            else return;

            Inventory inventory = new Inventory();

            inventory.updateItem(textBox5.Text, textBox2.Text, textBox3.Text, textBox4.Text, dRow[comboBox1.SelectedIndex].ItemArray.GetValue(0).ToString(), db.con);
        }

      
    }
}
