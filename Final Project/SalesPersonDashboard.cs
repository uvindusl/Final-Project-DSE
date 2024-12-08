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
    public partial class SalesPersonDashboard : Form
    {
        string username;
        public SalesPersonDashboard()
        {
            InitializeComponent();
        }
        public SalesPersonDashboard(string uname)
        {
            this.username = uname;
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            

        }

        private void SalesPersonDashboard_Load(object sender, EventArgs e)
        {
            double income, totalincome = 0;
            int sales = 0;
            DateTime dt = DateTime.Today;
            this.usernameLBL.Text = this.username;
            SqlConnection conn = connection();
            conn.Open();
            string query = "SELECT totalAmount FROM Order";
            SqlCommand com = new SqlCommand(query, conn);

            
        }

        private SqlConnection connection()
        {
            //This function will be used to establish a connection with Microsoft SQL server
            string cs = @"Data Source=DESKTOP-MFN3B4M; Initial Catalog=DSE_FinalProject;Integrated Security=True";
            SqlConnection conn = new SqlConnection(cs);

            try
            {

                MessageBox.Show("Connection success");
                return conn;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            return null;
        }
    }
}
