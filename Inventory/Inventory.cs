using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace WindowsFormsApplication1
{
    class Inventory
    {
        bool itemExists = false;
        int itemNumber;
        int itemQuantity;
        string itemDescription;

        System.Data.SqlClient.SqlConnection connection;

        public Inventory(System.Data.SqlClient.SqlConnection connection)
        {
            this.connection = connection;
        }

        public void addItem(object textBox1, object textBox2, object textBox3, object textBox4)
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

        public void removeItem(object itemId)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();

            cmd.Parameters.AddWithValue("@itemid", itemId);

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "DELETE FROM itemtable WHERE item_ID=@itemid";
            cmd.Connection = connection;

            cmd.ExecuteNonQuery();

        }

        public void updateItem(object textBox1, object textBox2, object textBox3, object textBox4, object itemId)
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

        public void decQuantityItem(object itemId)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();

            cmd.Parameters.AddWithValue("@itemid", itemId);

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "UPDATE itemtable SET Item_Quantity = Item_Quantity - 1 WHERE Item_ID = @itemid";
            cmd.Connection = connection;

            cmd.ExecuteNonQuery();
        }

        public void incQuantityItem(object itemId)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();

            cmd.Parameters.AddWithValue("@itemid", itemId);

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "UPDATE itemtable SET Item_Quantity = Item_Quantity + 1 WHERE Item_ID = @itemid";
            cmd.Connection = connection;

            cmd.ExecuteNonQuery();
        }

        private void checkItemIfExists(object itemName)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();

            cmd.Parameters.AddWithValue("@itemname", itemName);

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT itemtable WHERE Item_Name = @itemname";
            cmd.Connection = connection;

            cmd.ExecuteNonQuery();
        }
    }
}
