using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbcon2
{
    public class BusinessMetaLayer
    {
        static private BusinessMetaLayer m_instance = null;

        private BusinessMetaLayer() { }

        static public BusinessMetaLayer instance()
        {
            if (null == m_instance)
            {
                m_instance = new BusinessMetaLayer();
            }
            return m_instance;
        }

        // Could just have a set of static helper methods rather than a singleton!
        public List<Customer> getCustomers()
        {
            List<Customer> customers = new List<Customer>();

            DbConection con = DbFactory.instance();
            if (con.OpenConnection())
            {
                DbDataReader dr = con.Select("SELECT CUST_ID, cust_name, cust_address, cust_city FROM customers;");

                //Read the data and store them in the list
                while (dr.Read())
                {
                    Customer customer = new Customer();
                    customer.ID = dr.GetInt32(0);
                    customer.Name = dr.GetString(1);
                    customer.Address = dr.GetString(2);
                    customer.City = dr.GetString(3);
                    // etc.....

                    customers.Add(customer);
                }

                //close Data Reader
                dr.Close();
                con.CloseConnection();
            }

            return customers;
        }

       
    }
}
