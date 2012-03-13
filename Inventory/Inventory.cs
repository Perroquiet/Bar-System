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

        public void addItem(object textBox1, object textBox2, object textBox3, object textBox4, System.Data.SqlClient.SqlConnection connection)
        {
            Database db = new Database();

            db.insertItem(textBox1, textBox2, textBox3, textBox4, connection);
                  
        }

        public void addItemDate(object selectedIndex, System.Data.SqlClient.SqlConnection connection)
        {
            Database db = new Database();

            db.insertItemDate(selectedIndex, connection);
            
        }

        public void updateItem(object textBox1, object textBox2, object textBox3, object textBox4, object itemId, System.Data.SqlClient.SqlConnection connection)
        {
            Database db = new Database();

            db.updateItem(textBox1, textBox2, textBox3, textBox4, itemId, connection);
        }


        public void removeItem(object itemId, System.Data.SqlClient.SqlConnection connection)
        {
            Database db = new Database();

            db.deleteItem(itemId, connection);
        }


        
        public void decQuantityOfItem(object itemId, System.Data.SqlClient.SqlConnection connection)
        {
            Database db = new Database();

            db.decQuantityOfItem(itemId, connection);
        }

        public void incQuantityOfItem(object itemId, System.Data.SqlClient.SqlConnection connection)
        {
            Database db = new Database();

            db.incQuantityOfItem(itemId, connection);
        }

        private void checkItemIfExists(object itemName, System.Data.SqlClient.SqlConnection connection)
        {
            Database db = new Database();

            db.checkItemIfExists(itemName, connection);
        }
        
    }
}
