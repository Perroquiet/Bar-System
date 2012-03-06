using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace WindowsFormsApplication1
{
    class Database
    {
        
        System.Data.SqlClient.SqlConnection con;
        /*
        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
        */
        public const string DataFilename = "inventorydb.mdf";
        public const string Location = "E:\\";
        
        public const string ConnectionString1 = "Data Source=.\\SQLEXPRESS;AttachDbFilename=";
        public const string ConnectionString2 = ";Integrated Security=True;Connect Timeout=30;User Instance=True";
        
        public void connect()
        {
            con = new System.Data.SqlClient.SqlConnection();
            con.ConnectionString = ConnectionString1 + Location + DataFilename + ConnectionString2;
            con.Open();
        }
        /* Testing
        private object text1;
        private object text2;
        private object text3;
        private object text4;

        public Database(object textBox1, object textBox2, object textBox3, object textBox4)
        {
            text1 = textBox1;
            text2 = textBox2;
            text3 = textBox3;
            text4 = textBox4;
        }

        public void connect()
        {
            con = new System.Data.SqlClient.SqlConnection();
            con.ConnectionString = ConnectionString1 + Location + DataFilename + ConnectionString2;
            con.Open();
        }
        
        public void queryInsert(string table, object[] data)
        {
            string value = "";
            foreach (object element in data)
            {
                if (element != null)
                {
                    value += element.ToString() + ",";
                }
                value = value.Remove(value.Length - 1, 1);
            }

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT INTO " + table + " VALUES(" + value + ")";
            cmd.Connection = con;      
        }

        public void queryDelete(string table, object[] data)
        { 
            string value = "";
            foreach (object element in data)
            {
                if (element != null)
                {
                    value += element.ToString();
                }
            }
          
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "DELETE FROM " + table + " WHERE " + columnName + "=" + value")";
            cmd.Connection = con; 
        }

        public void queryUpdate()
        { 
        
        }
        */
    }
}
