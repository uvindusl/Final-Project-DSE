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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            //connection
            string cs = @"Data Source=HPNotebook;
                        Initial Catalog=DSE_FinalProject;
                        Integrated Security=True";
            SqlConnection conn = new SqlConnection(cs);
            conn.Open();

            //command
            string sql = "SELECT Employee FROM "
        }
    }
}
