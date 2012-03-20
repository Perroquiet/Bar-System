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
        System.Data.SqlClient.SqlConnection connection;
        
        string itemName;
        int itemQty;
        string itemDesc;
        float itemPrice;

        public Inventory()
        { 
        }
        //Add Item
        public Inventory(string itemName, string itemDesc, float itemPrice, int itemQty, System.Data.SqlClient.SqlConnection connection)
        {
            this.itemName = itemName;
            this.itemQty = itemQty;
            this.itemDesc = itemDesc;
            this.itemPrice = itemPrice;

            this.connection = connection;
        }

        public void addItem()
        {
            Database db = new Database();

            db.insertItem(this.itemName, this.itemDesc, this.itemPrice, this.itemQty, this.connection);
                  
        }

        public void addItemDate(object selectedIndex, object supplier, System.Data.SqlClient.SqlConnection connection)
        {
            Database db = new Database();

            db.insertItemDate(selectedIndex, supplier, connection);
            
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


        
        public void decQuantityOfItem(object itemId, object quantity, System.Data.SqlClient.SqlConnection connection)
        {
            Database db = new Database();

            db.decQuantityOfItem(itemId, quantity, connection);
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

        public void addsale(object itemid, object itemname, object itemdesc, object itemprice, object itemquant, object totalprice,object employee, object date, System.Data.SqlClient.SqlConnection connection)
        {
            Database db = new Database();
            db.addsale(itemid, itemname, itemdesc, itemprice, itemquant, totalprice, employee, date, connection);
        }
        
    }
}
