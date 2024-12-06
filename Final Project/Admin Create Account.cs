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
    public partial class Admin_Create_Account : Form
    {
        public Admin_Create_Account()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void EmpIdAutoIncrement()
        {
            //Id auto incriment
            try
            {
                //Create a connection

                string cs = "Data Source = LAPTOP-DOH91PI2;Initial Catalog = DSE_FinalProject; Integrated Security = True ";
                SqlConnection con = new SqlConnection(cs);

                con.Open();

                string sql1 = "SELECT MAX(empId) FROM Employee";
                SqlCommand cmd = new SqlCommand(sql1, con);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    // Extract and increment the numeric part of the ItemId
                    string maxItemId = dr[0].ToString();

                    if (!string.IsNullOrEmpty(maxItemId) && maxItemId.StartsWith("E"))
                    {
                        // Remove the prefix 'E' and parse the numeric part
                        string numericPart = maxItemId.Substring(1);
                        if (int.TryParse(numericPart, out int maxID))
                        {
                            // Increment the numeric part
                            int newID = maxID + 1;
                            // Format the new ID back to string with 'E' prefix
                            this.txtId.Text = "E" + newID.ToString();
                        }
                        else
                        {
                            // Handle the case where the numeric part is not valid
                            this.txtId.Text = "E1";
                        }
                    }
                    else
                    {
                        // Handle the case where there are no records in the table
                        this.txtId.Text = "E1";
                    }
                }
                else
                {
                    // Handle the case where there are no records in the table
                    this.txtId.Text = "E1";
                }
                dr.Close(); // Ensure the data reader is closed
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message, "Information");
            }
        }

        private void AdminIdAutoIncrement()
        {
            //Id auto incriment
            try
            {
                //Create a connection

                string cs = "Data Source = LAPTOP-DOH91PI2;Initial Catalog = DSE_FinalProject; Integrated Security = True ";
                SqlConnection con = new SqlConnection(cs);

                con.Open();

                string sql1 = "SELECT MAX(adminId) FROM Admin";
                SqlCommand cmd = new SqlCommand(sql1, con);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    // Extract and increment the numeric part of the ItemId
                    string maxItemId = dr[0].ToString();

                    if (!string.IsNullOrEmpty(maxItemId) && maxItemId.StartsWith("A"))
                    {
                        // Remove the prefix 'A' and parse the numeric part
                        string numericPart = maxItemId.Substring(1);
                        if (int.TryParse(numericPart, out int maxID))
                        {
                            // Increment the numeric part
                            int newID = maxID + 1;
                            // Format the new ID back to string with 'A' prefix
                            this.txtAid.Text = "A" + newID.ToString();
                        }
                        else
                        {
                            // Handle the case where the numeric part is not valid
                            this.txtAid.Text = "A1";
                        }
                    }
                    else
                    {
                        // Handle the case where there are no records in the table
                        this.txtAid.Text = "A1";
                    }
                }
                else
                {
                    // Handle the case where there are no records in the table
                    this.txtAid.Text = "A1";
                }
                dr.Close(); // Ensure the data reader is closed
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message, "Information");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //varibles for email validation

            String email = this.txtEmail.Text;
            int atpos = email.IndexOf("@");
            int dotpos = email.LastIndexOf(".");

            //varibles for validate phone number

            String no = this.txtNo.Text;
            String no1 = this.txtEcont.Text;

            //checking any empty values

            if (txtName.Text == "")
            {
                MessageBox.Show("Enter a name");
            }
            else if (txtAge.Text == "")
            {
                MessageBox.Show("Enter an age");
            }
            else if (txtNo.Text == "")
            {
                MessageBox.Show("Enter a phone number");
            }
            else if (no.Length != 10) //number should be 10 numbers
            {
                MessageBox.Show("Enter a valid number");
            }
            else if (txtHno.Text == "")
            {
                MessageBox.Show("Enter a House No");
            }
            else if (txtStreet.Text == "")
            {
                MessageBox.Show("Enter a Street");
            }
            else if (txtCity.Text == "")
            {
                MessageBox.Show("Enter a City");
            }
            else if (txtEmail.Text == "")
            {
                MessageBox.Show("Enter an email");
            }
            else if (txtEcont.Text == "")
            {
                MessageBox.Show("Enter an Emergency contact");
            }
            else if (no1.Length != 10) //number should be 10 numbers
            {
                MessageBox.Show("Enter a valid Emergency contact");
            }
            else if (atpos < 1 || dotpos < atpos + 2 || dotpos + 2 >= email.Length) //email must be a valid one
            {
                MessageBox.Show("Please enter a valid email");
            }
            else if (txtUser.Text == "")
            {
                MessageBox.Show("Enter a Username");
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Enter a password");
            }
            else
            {

                /* try
                 {*/
                //Create a connection

                string cs = "Data Source = LAPTOP-DOH91PI2;Initial Catalog = DSE_FinalProject; Integrated Security = True ";
                SqlConnection con = new SqlConnection(cs);

                con.Open();

                //Define a command

                string sql = "INSERT INTO Employee (empId,empName,empUserName,empTel,empAge,empEmail,empType,houseNo,street,city,empEmargancyCont,empPassword) VALUES (@empId,@empName,@empUserName,@empTel,@empAge,@empEmail,@empType,@houseNo,@street,@city,@empEmargancyCont,@empPassword)";
                string sql1 = "INSERT INTO Admin (adminId) Values (@adminId)";

                SqlCommand com = new SqlCommand(sql, con);
                SqlCommand com1 = new SqlCommand(sql1, con);

                com.Parameters.AddWithValue("@empId", this.txtId.Text);
                com.Parameters.AddWithValue("@empName", this.txtName.Text);
                com.Parameters.AddWithValue("@empUserName", this.txtUser.Text);
                com.Parameters.AddWithValue("@empTel", this.txtNo.Text);
                com.Parameters.AddWithValue("@empAge", this.txtAge.Text);
                com.Parameters.AddWithValue("@empEmail", this.txtEmail.Text);
                com.Parameters.AddWithValue("@empType", this.txtType.Text);
                com.Parameters.AddWithValue("@houseNo", this.txtHno.Text);
                com.Parameters.AddWithValue("@street", this.txtStreet.Text);
                com.Parameters.AddWithValue("@city", this.txtCity.Text);
                com.Parameters.AddWithValue("@empEmargancyCont", this.txtEcont.Text);
                com.Parameters.AddWithValue("@empPassword", this.txtPassword.Text);
                com1.Parameters.AddWithValue("@adminId", this.txtAid.Text);


                //Execute the command
                com.ExecuteNonQuery();
                com1.ExecuteNonQuery();
                MessageBox.Show(" Registration Succeed", "Information");


                EmpIdAutoIncrement();
                AdminIdAutoIncrement();

                //Disconnect from the sql server
                con.Close();


                /*}
                catch (SqlException)
                {
                    MessageBox.Show(" Something went wrong ", "Information");
                }*/
            }
        }

        private void Admin_Create_Account_Load(object sender, EventArgs e)
        {
            EmpIdAutoIncrement();
            AdminIdAutoIncrement();
        }

        private void txtEcont_KeyPress(object sender, KeyPressEventArgs e)
        {
            //prevent letters entering

            if (!char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //prevent letters entering

            if (!char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            //prevent letters entering

            if (!char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
