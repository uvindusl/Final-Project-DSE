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

namespace Final_Project
{
    public partial class SP_View_Software_Pd : Form
    {
        public SP_View_Software_Pd()
        {
            InitializeComponent();
        }

        private void SP_View_Software_Pd_Load(object sender, EventArgs e)
        {
            //connection
            string cs = @"Data Source=HPNotebook; 
                        Initial Catalog=DSE_FinalProject; 
                        Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            //commands
            string sql = "SELECT *From SoftwareProduct";
            SqlCommand com = new SqlCommand(sql, con);

            //access data using data adapter method
            SqlDataAdapter dap = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            dap.Fill(ds);

            //blind data with controls
            this.dataGridView1.DataSource = ds.Tables[0];

            //disconnect
            con.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            SalesPersonDashboard salesPersonDashboard = new SalesPersonDashboard();
            salesPersonDashboard.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Sales_Person_POS sales_Person_POS = new Sales_Person_POS();
            sales_Person_POS.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Sales_person_Add_customer sa = new Sales_person_Add_customer();
            sa.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Sales_Person_Quotation sa = new Sales_Person_Quotation();
            sa.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            SP_View_Software_Pd sales_Person_ = new SP_View_Software_Pd();
            sales_Person_.Show();
            this.Hide();
        }
    }
}
