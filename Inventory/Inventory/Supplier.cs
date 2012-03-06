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

        System.Data.SqlClient.SqlConnection connection;

        public Supplier(System.Data.SqlClient.SqlConnection connection)
        {
            this.connection = connection;
        }

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

        public void addSupplier(object textBox1, object textBox2, object textBox3, object textBox4)
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

        public void removeSupplier(object id)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();

            cmd.Parameters.AddWithValue("@suppId", id);

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "DELETE FROM suppliertable WHERE Supplier_ID=@suppId";
            cmd.Connection = connection;

            cmd.ExecuteNonQuery();
        }
    }
}
