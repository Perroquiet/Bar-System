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
        
        public System.Data.SqlClient.SqlConnection con;
        public DataRow[] dRow;


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
        //Form 1
        public void dataGrid(DataTable dt, object table)
        {
            System.Data.SqlClient.SqlDataAdapter da;
            string sql = "SELECT * FROM " + table;
            da = new System.Data.SqlClient.SqlDataAdapter(sql, con);
            da.Fill(dt);
        }

        //Form 1
        public void dataGrid2(DataTable dt, object textbox)
        {
            System.Data.SqlClient.SqlDataAdapter da;
            string sql = string.Format("SELECT * FROM itemtable where Item_Name LIKE '%{0}%'", textbox);
            da = new System.Data.SqlClient.SqlDataAdapter(sql, con);
            da.Fill(dt);
        }

        //Form 2 fail!
        public void dataSet(DataSet ds, string table)
        {
            System.Data.SqlClient.SqlDataAdapter da;
            string sql = string.Format("SELECT * FROM " + table);
            da = new System.Data.SqlClient.SqlDataAdapter(sql, con);
            da.Fill(ds, table);
           
        }

        public void insertItem(object textBox1, object textBox2, object textBox3, object textBox4, System.Data.SqlClient.SqlConnection connection)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();

            cmd.Parameters.AddWithValue("@itemname", textBox1);
            cmd.Parameters.AddWithValue("@itemdesc", textBox2);
            cmd.Parameters.AddWithValue("@itemprice", textBox3);
            cmd.Parameters.AddWithValue("@itemquant", textBox4);

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT INTO itemtable VALUES(@itemname,@itemdesc,@itemprice,@itemquant)";
            cmd.Connection = connection;

            cmd.ExecuteNonQuery();
        }

        public void insertItemDate(object selectedIndex, System.Data.SqlClient.SqlConnection connection)
        {
            DataRow[] dRow;
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();

            System.Data.SqlClient.SqlDataAdapter da;
            string sql = string.Format("SELECT * FROM itemtable");

            DataSet ds = new DataSet();
            da = new System.Data.SqlClient.SqlDataAdapter(sql, connection);
            da.Fill(ds, "items");

            dRow = new DataRow[ds.Tables["items"].Rows.Count];

            for (int i = 0; i < ds.Tables["items"].Rows.Count; i++)
            {
                dRow[i] = ds.Tables["items"].Rows[i];
            }

            cmd.Parameters.AddWithValue("@itemid", dRow[dRow.Length - 1].ItemArray.GetValue(0).ToString());
            cmd.Parameters.AddWithValue("@supplierid", selectedIndex);
            cmd.Parameters.AddWithValue("@dateadded", DateTime.Now);
            cmd.Parameters.AddWithValue("@lastupdated", DateTime.Now);

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT INTO itemtimetable VALUES(@itemid,@supplierid,@dateadded,@lastupdated)";
            cmd.Connection = connection;

            cmd.ExecuteNonQuery();
        }

        public void updateItem(object textBox1, object textBox2, object textBox3, object textBox4, object itemId, System.Data.SqlClient.SqlConnection connection)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "UPDATE itemtable SET Item_Name = @itemname, Item_Description = @itemdesc, Item_Price = @itemprice, Item_Quantity = @itemquant where Item_ID = @itemid";
            cmd.Connection = connection;

            cmd.Parameters.AddWithValue("@itemname", textBox1);
            cmd.Parameters.AddWithValue("@itemdesc", textBox2);
            cmd.Parameters.AddWithValue("@itemprice", textBox3);
            cmd.Parameters.AddWithValue("@itemquant", textBox4);
            cmd.Parameters.AddWithValue("@itemid", itemId);

            cmd.ExecuteNonQuery();
        }
        
        public void deleteItem(object itemId, System.Data.SqlClient.SqlConnection connection)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();

            cmd.Parameters.AddWithValue("@itemid", itemId);

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "DELETE FROM itemtable WHERE item_ID=@itemid";
            cmd.Connection = connection;

            cmd.ExecuteNonQuery();
        }

        public void decQuantityOfItem(object itemId, System.Data.SqlClient.SqlConnection connection)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();

            cmd.Parameters.AddWithValue("@itemid", itemId);

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "UPDATE itemtable SET Item_Quantity = Item_Quantity - 1 WHERE Item_ID = @itemid";
            cmd.Connection = connection;

            cmd.ExecuteNonQuery();
        }

        public void incQuantityOfItem(object itemId, System.Data.SqlClient.SqlConnection connection)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();

            cmd.Parameters.AddWithValue("@itemid", itemId);

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "UPDATE itemtable SET Item_Quantity = Item_Quantity + 1 WHERE Item_ID = @itemid";
            cmd.Connection = connection;

            cmd.ExecuteNonQuery();
        }

        public void checkItemIfExists(object itemName, System.Data.SqlClient.SqlConnection connection)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();

            cmd.Parameters.AddWithValue("@itemname", itemName);

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT itemtable WHERE Item_Name = @itemname";
            cmd.Connection = connection;

            cmd.ExecuteNonQuery();
        }

        public void insertSupplier(object textBox1, object textBox2, object textBox3, object textBox4, System.Data.SqlClient.SqlConnection connection)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();

            cmd.Parameters.AddWithValue("@suppName", textBox1);
            cmd.Parameters.AddWithValue("@suppAdd", textBox2);
            cmd.Parameters.AddWithValue("@suppCN", textBox3);
            cmd.Parameters.AddWithValue("@suppEmail", textBox4);

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT INTO suppliertable VALUES(@suppName,@suppAdd,@suppCN,@suppEmail)";
            cmd.Connection = connection;

            cmd.ExecuteNonQuery();
        }

        public void deleteSupplier(object id, System.Data.SqlClient.SqlConnection connection)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();

            cmd.Parameters.AddWithValue("@suppId", id);

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "DELETE FROM suppliertable WHERE Supplier_ID=@suppId";
            cmd.Connection = connection;

            cmd.ExecuteNonQuery();
        }

        /* Active Record
        
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
