using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbcon2
{
    public class Customer
    {
        private int m_id;
        public int ID { get { return m_id; } set { m_id = value; } }

        private String m_name;
        public String Name { get { return m_name; } set { m_name = value; } }

        private String m_address;
        public String Address { get { return m_address; } set { m_address = value; } }

        private String m_city;
        public String City { get { return m_city; } set { m_city = value; } }

        private String m_state;
        public String State { get { return m_state; } set { m_state = value; } }

        private String m_zip;
        public String Zip { get { return m_zip; } set { m_zip = value; } }

        private String m_country;
        public String Country { get { return m_country; } set { m_country = value; } }

        private String m_contact;
        public String Contact { get { return m_contact; } set { m_contact = value; } }

        private String m_email;
        public String Email { get { return m_email; } set { m_email = value; } }

        public override string ToString()
        {
            return m_name + ", " + m_city;
        }
    }
}
