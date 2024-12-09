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
    public partial class Admin_Add_employees : Form
    {
        public Admin_Add_employees()
        {
            InitializeComponent();
        }

        private void EmpIdAutoIncrement()
        {
            //Id auto incriment
            try
            {
                //Create a connection

                string cs = @"Data Source=HPNotebook; Initial Catalog=DSE_FinalProject; Integrated Security=True";
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

                string cs = @"Data Source=HPNotebook; Initial Catalog=DSE_FinalProject; Integrated Security=True";
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

        private void SalesPersonIdAutoIncrement()
        {
            //Id auto incriment
            try
            {
                // Create a connection
                string cs = @"Data Source=HPNotebook; Initial Catalog=DSE_FinalProject; Integrated Security=True";

                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();

                    string sql1 = "SELECT MAX(softwareProductId) FROM SoftwareProduct";
                    using (SqlCommand cmd = new SqlCommand(sql1, con))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            string maxItemId = dr[0]?.ToString(); // Use null-conditional operator to handle null values

                            if (!string.IsNullOrEmpty(maxItemId) && maxItemId.StartsWith("SP"))
                            {
                                // Remove the prefix 'SP' and parse the numeric part
                                string numericPart = maxItemId.Substring(2);
                                if (int.TryParse(numericPart, out int maxID))
                                {
                                    // Increment the numeric part
                                    int newID = maxID + 1;
                                    // Format the new ID back to string with 'SP' prefix
                                    this.txtAid.Text = "SP" + newID.ToString();
                                }
                                else
                                {
                                    // Handle the case where the numeric part is not valid
                                    this.txtAid.Text = "SP1";
                                }
                            }
                            else
                            {
                                // Handle the case where there are no records in the table or invalid format
                                this.txtAid.Text = "SP1";
                            }
                        }
                        else
                        {
                            // Handle the case where there are no records in the table
                            this.txtAid.Text = "SP1";
                        }
                        dr.Close(); // Ensure the data reader is closed
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message, "Information");
            }
        }

        private void TechIdAutoIncrement()
        {
            //Id auto incriment
            try
            {
                //Create a connection

                string cs = @"Data Source=HPNotebook; Initial Catalog=DSE_FinalProject; Integrated Security=True";
                SqlConnection con = new SqlConnection(cs);

                con.Open();

                string sql1 = "SELECT MAX(technicianId) FROM Technician";
                SqlCommand cmd = new SqlCommand(sql1, con);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    // Extract and increment the numeric part of the ItemId
                    string maxItemId = dr[0].ToString();

                    if (!string.IsNullOrEmpty(maxItemId) && maxItemId.StartsWith("T"))
                    {
                        // Remove the prefix 'T' and parse the numeric part
                        string numericPart = maxItemId.Substring(1);
                        if (int.TryParse(numericPart, out int maxID))
                        {
                            // Increment the numeric part
                            int newID = maxID + 1;
                            // Format the new ID back to string with 'T' prefix
                            this.txtAid.Text = "T" + newID.ToString();
                        }
                        else
                        {
                            // Handle the case where the numeric part is not valid
                            this.txtAid.Text = "T1";
                        }
                    }
                    else
                    {
                        // Handle the case where there are no records in the table
                        this.txtAid.Text = "T1";
                    }
                }
                else
                {
                    // Handle the case where there are no records in the table
                    this.txtAid.Text = "T1";
                }
                dr.Close(); // Ensure the data reader is closed
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message, "Information");
            }
        }

        private void Admin_Add_employees_Load(object sender, EventArgs e)
        {
            EmpIdAutoIncrement();
        }

        private void txtType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtType.Text == "Admin")
            {
                AdminIdAutoIncrement();
                this.lblid.Text = "Admin Id";
                this.txtSpecial.Enabled = false;
            }
            else if(txtType.Text == "SalesPerson")
            {
                SalesPersonIdAutoIncrement();
                this.lblid.Text = "Sales Person Id";
                this.txtSpecial.Enabled = false;
            }

            else if (txtType.Text == "Technician")
            {
                TechIdAutoIncrement();
                this.lblid.Text = "Technician Id";
                this.txtSpecial.Enabled = true;
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
            else if (txtType.Text == "")
            {
                MessageBox.Show("Select an employee Type");
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
                MessageBox.Show("Enter a valid contact number");
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
            else if (txtSalary.Text == "")
            {
                MessageBox.Show("Enter a Salary");
            }
            else
            {

                /* try
                 {*/
                //Create a connection

                string cs = @"Data Source=HPNotebook; Initial Catalog=DSE_FinalProject; Integrated Security=True";
                SqlConnection con = new SqlConnection(cs);

                con.Open();


                //Define a command

                string sql = "INSERT INTO Employee (empId,empName,empUserName,empTel,empAge,empEmail,empType,houseNo,street,city,empEmargancyCont,empPassword,empSalary) VALUES (@empId,@empName,@empUserName,@empTel,@empAge,@empEmail,@empType,@houseNo,@street,@city,@empEmargancyCont,@empPassword,@empSalary)";
                

                SqlCommand com = new SqlCommand(sql, con);

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
                com.Parameters.AddWithValue("@empSalary", this.txtSalary.Text);
                

                if (txtType.Text == "Admin")
                {
                    string sql1 = "INSERT INTO Admin (adminId,empId) Values (@adminId,@eId)";

                    SqlCommand com1 = new SqlCommand(sql1, con);

                    com1.Parameters.AddWithValue("@adminId", this.txtAid.Text);
                    com1.Parameters.AddWithValue("@eId", this.txtId.Text);

                    com1.ExecuteNonQuery();
                }
                else if (txtType.Text == "SalesPerson")
                {
                    string sql1 = "INSERT INTO Salesperson (sPersonId,empId) Values (@sPersonId,@eId)";

                    SqlCommand com1 = new SqlCommand(sql1, con);

                    com1.Parameters.AddWithValue("@sPersonId", this.txtAid.Text);
                    com1.Parameters.AddWithValue("@eId", this.txtId.Text);

                    com1.ExecuteNonQuery(); 
                }

                else if (txtType.Text == "Technician")
                {
                    string sql1 = "INSERT INTO Technician (technicianId,specialization,empId) Values (@technicianId,@specialization,@eId)";

                    SqlCommand com1 = new SqlCommand(sql1, con);

                    com1.Parameters.AddWithValue("@technicianId", this.txtAid.Text);
                    com1.Parameters.AddWithValue("@specialization", this.txtSpecial.Text);
                    com1.Parameters.AddWithValue("@eId", this.txtId.Text);

                    com1.ExecuteNonQuery();
                }

                //Execute the command
                com.ExecuteNonQuery();

                MessageBox.Show("Emploree added Succesfully", "Information");


                this.txtType.Text = "";
                this.txtAid.Text = "";
                this.txtName.Text = "";
                this.txtAge.Text = "";
                this.txtNo.Text = "";
                this.txtStreet.Text = "";
                this.txtHno.Text = "";
                this.txtCity.Text = "";
                this.txtEmail.Text = "";
                this.txtEcont.Text = "";
                this.txtUser.Text = "";
                this.txtPassword.Text = "";
                this.txtSalary.Text = "";
                this.txtSpecial.Text = "";

                this.txtSpecial.Enabled = false;

                EmpIdAutoIncrement();

                //Disconnect from the sql server
                con.Close();


                /*}
                catch (SqlException)
                {
                    MessageBox.Show(" Something went wrong ", "Information");
                }*/
            }
        }

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminUpdateCustomer adc = new AdminUpdateCustomer();
            adc.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin_Add_Products adp = new Admin_Add_Products();
            adp.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Admin_view_Product_inventory advi = new Admin_view_Product_inventory();
            advi.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin_View_Purchase_Order advpo = new Admin_View_Purchase_Order();
            advpo.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Admin_View_Search_orders avso = new Admin_View_Search_orders();
            avso.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AdminMakePaysheet admp = new AdminMakePaysheet();
            admp.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Admin_Add_Supplier ads = new Admin_Add_Supplier();
            ads.Show();
            this.Hide();
        }

        private void btnEmployeeForm_Click(object sender, EventArgs e)
        {
            AdminUpdateEmployee adu = new AdminUpdateEmployee();
            adu.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AdminUpdateEmployee adu = new AdminUpdateEmployee();
            adu.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Admin_Dashboard ad = new Admin_Dashboard();
            ad.Show();
            this.Hide();
        }
    }
}
