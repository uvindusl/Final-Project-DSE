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
using System.Xml.Linq;

namespace Final_Project
{
    public partial class Sales_person_Add_customer : Form
    {
        public Sales_person_Add_customer()
        {
            InitializeComponent();
        }

        private void idAutoincrement()
        {
            //Id auto incriment
            try
            {
                //Create a connection

                string cs = @"Data Source=HPNotebook; Initial Catalog=DSE_FinalProject; Integrated Security=True";
                SqlConnection con = new SqlConnection(cs);

                con.Open();

                string sql1 = "SELECT MAX(cusId) FROM Customer";
                SqlCommand cmd = new SqlCommand(sql1, con);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    // Extract and increment the numeric part of the ItemId
                    string maxItemId = dr[0].ToString();

                    if (!string.IsNullOrEmpty(maxItemId) && maxItemId.StartsWith("C"))
                    {
                        // Remove the prefix 'C' and parse the numeric part
                        string numericPart = maxItemId.Substring(1);
                        if (int.TryParse(numericPart, out int maxID))
                        {
                            // Increment the numeric part
                            int newID = maxID + 1;
                            // Format the new ID back to string with 'p' prefix
                            this.txtId.Text = "C" + newID.ToString();
                        }
                        else
                        {
                            // Handle the case where the numeric part is not valid
                            this.txtId.Text = "C1";
                        }
                    }
                    else
                    {
                        // Handle the case where there are no records in the table
                        this.txtId.Text = "C1";
                    }
                }
                else
                {
                    // Handle the case where there are no records in the table
                    this.txtId.Text = "C1";
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

            //checking any empty values

            if (txtName.Text == "")
            {
                MessageBox.Show("Enter a name");
            }
            else if (txtNo.Text == "")
            {
                MessageBox.Show("Enter a phone number");
            }
            else if(no.Length != 10) //number should be 10 numbers
            {
                MessageBox.Show("Enter a valid number");
            }
            else if (txtAdd.Text == "")
            {
                MessageBox.Show("Enter an address");
            }
            else if (txtEmail.Text == "")
            {
                MessageBox.Show("Enter an email");
            }           
            else if (atpos < 1 || dotpos < atpos + 2 || dotpos + 2 >= email.Length) //email must be a valid one
            {
                MessageBox.Show("Please enter a valid email");
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

                string sql = "INSERT INTO Customer (cusId,cusName,cusTel,cusAddress,cusEmail) VALUES (@cusId,@cusName,@cusTel,@cusAddress,@cusEmail)";

                SqlCommand com = new SqlCommand(sql, con);

                com.Parameters.AddWithValue("@cusId", this.txtId.Text);
                com.Parameters.AddWithValue("@cusName", this.txtName.Text);
                com.Parameters.AddWithValue("@cusTel", this.txtNo.Text);
                com.Parameters.AddWithValue("@cusAddress", this.txtAdd.Text);
                com.Parameters.AddWithValue("@cusEmail", this.txtEmail.Text);


                //Execute the command
                com.ExecuteNonQuery();
                MessageBox.Show(" Customer Added Succesfully ", "Information");

                idAutoincrement();

                //Disconnect from the sql server
                con.Close();

                txtName.Text = "";
                txtNo.Text = "";
                txtAdd.Text = "";
                txtEmail.Text = "";
                
                /*}
                catch (SqlException)
                {
                    MessageBox.Show(" Something went wrong ", "Information");
                }*/
            }
        }

        private void txtNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Sales_person_Add_customer_Load(object sender, EventArgs e)
        {
            idAutoincrement();
        }
    }
}
