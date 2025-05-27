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
    public partial class Technician_View_Hardware_Product : Form
    {
        public Technician_View_Hardware_Product()
        {
            InitializeComponent();
        }

        private void Technician_View_Hardware_Product_Load(object sender, EventArgs e)
        {
            //connection
            string cs = @"Data Source=HPNotebook; 
                        Initial Catalog=DSE_FinalProject; 
                        Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            //commands
            string sql = "SELECT *From HardwareProduct";
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            Technician_Dashboard technician_Dashboard = new Technician_Dashboard();
            technician_Dashboard.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Technician_Software technician_Software = new Technician_Software();
            technician_Software.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Technician_Add_Customer technician_Add_ = new Technician_Add_Customer();
            technician_Add_.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Technician_View_Hardware_Product technician_View_Hardware_ = new Technician_View_Hardware_Product();
            technician_View_Hardware_.Show();
            this.Hide();
        }
    }
    
}
