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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if(txtusername.Text == "")
            {
                MessageBox.Show("Enter the Username");
            }
            else if(txtpassword.Text == "")
            {
                MessageBox.Show("Enter the Password");
            }
            else
            {
                //attributes
                string usertype;

                //connection string
                string cs = @"Data Source=HPNotebook; Initial Catalog=DSE_FinalProject; Integrated Security=True";
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    try
                    {
                        // Open connection
                        conn.Open();

                        // command
                        string sql = "SELECT empType FROM Employee WHERE empUserName=@username AND empPassword=@password";
                        SqlCommand com = new SqlCommand(sql, conn);
                        com.Parameters.AddWithValue("@username", this.txtusername.Text);
                        com.Parameters.AddWithValue("@password", this.txtpassword.Text);

                        // access Data 
                        SqlDataReader dr = com.ExecuteReader();

                        if (dr.Read())
                        {
                            usertype = dr.GetValue(0).ToString();

                            // Validate user type and open respective dashboard
                            if (usertype == "Admin")
                            {
                                // open admin dashboard
                                Admin_Dashboard ad = new Admin_Dashboard();
                                ad.Show();
                                this.Hide();
                            }
                            else if (usertype == "SalesPerson")
                            {
                                // open salesperson dashboard
                                SalesPersonDashboard ad = new SalesPersonDashboard();
                                ad.Show();
                                this.Hide();
                            }
                            else if (usertype == "Technician")
                            {
                                // open technician dashboard
                                Technician_Dashboard ad = new Technician_Dashboard();
                                ad.Show();
                                this.Hide();
                            }
                            else
                            {
                                // Handle unknown user type
                                MessageBox.Show("Unknown user type");
                            }
                        }
                        else
                        {

                            MessageBox.Show("Invalid username or password");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                    finally
                    {
                        //close connection
                        conn.Close();
                    }
                }
            }
        }
    }
}
