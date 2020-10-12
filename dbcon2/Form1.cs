using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbcon2
{
    public partial class Form1 : Form
    {
        List<Customer> m_customers;
        BindingSource m_bs;
        DataSet dataSet = null;

        public Form1()
        {
            InitializeComponent();
            m_bs = new BindingSource();
            m_bs.DataSource = m_customers;
            cmbCustomers.DataSource = m_bs;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            btnTest.Enabled = false;
            BusinessMetaLayer ml = BusinessMetaLayer.instance();
            m_customers = ml.getCustomers();
            m_bs.DataSource = m_customers;
            m_bs.ResetBindings(false);

            // Fill data grid
            DbConection con = DbFactory.instance();
            con.OpenConnection();
            dataSet = con.getDataSet("Select * from customers");
            DataTable table = dataSet.Tables[0];
            //FillInTextFields(table, 1);
            //set up the data grid view
            this.dataGridView1.DataSource = table;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (null != dataSet)
            {
                dataSet.AcceptChanges();
            }
        }
    }
}
