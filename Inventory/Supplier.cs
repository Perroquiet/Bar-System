using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Supplier
    {
        int supplierId;
        string supplierName;
        string supplierContact;

        public int getSupplierId()
        { 
            return supplierId;
        }

        public string getSupplierName()
        { 
            return supplierName;
        }

        public string getSupplierContact()
        {
            return supplierContact;
        }

        public void addSupplier(object textBox1, object textBox2, object textBox3, object textBox4, System.Data.SqlClient.SqlConnection connection)
        {
            Database db = new Database();
            
            db.insertSupplier(textBox1, textBox2, textBox3, textBox4, connection);
        }

        public void removeSupplier(object id, System.Data.SqlClient.SqlConnection connection)
        {
            Database db = new Database();
            
            db.deleteSupplier(id, connection);
        }
    }
}
