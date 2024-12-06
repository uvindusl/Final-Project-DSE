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
    public partial class Admin_Add_Supplier : Form
    {
        public Admin_Add_Supplier()
        {
            InitializeComponent();
        }

        private void idAutoincrement()
        {
            //Id auto incriment
            try
            {
                //Create a connection

                string cs = "Data Source = LAPTOP-DOH91PI2;Initial Catalog = DSE_FinalProject; Integrated Security = True ";
                SqlConnection con = new SqlConnection(cs);

                con.Open();

                string sql1 = "SELECT MAX(supId) FROM Supplier";
                SqlCommand cmd = new SqlCommand(sql1, con);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    // Extract and increment the numeric part of the ItemId
                    string maxItemId = dr[0].ToString();

                    if (!string.IsNullOrEmpty(maxItemId) && maxItemId.StartsWith("S"))
                    {
                        // Remove the prefix 'S' and parse the numeric part
                        string numericPart = maxItemId.Substring(1);
                        if (int.TryParse(numericPart, out int maxID))
                        {
                            // Increment the numeric part
                            int newID = maxID + 1;
                            // Format the new ID back to string with 'p' prefix
                            this.txtId.Text = "S" + newID.ToString();
                        }
                        else
                        {
                            // Handle the case where the numeric part is not valid
                            this.txtId.Text = "S1";
                        }
                    }
                    else
                    {
                        // Handle the case where there are no records in the table
                        this.txtId.Text = "S1";
                    }
                }
                else
                {
                    // Handle the case where there are no records in the table
                    this.txtId.Text = "S1";
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
            else if (no.Length != 10) //number should be 10 numbers
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

                string cs = "Data Source = LAPTOP-DOH91PI2;Initial Catalog = DSE_FinalProject; Integrated Security = True ";
                SqlConnection con = new SqlConnection(cs);

                con.Open();

                //Define a command

                string sql = "INSERT INTO Supplier (supId,supName,supTel,supEmail,supAddress) VALUES (@supId,@supName,@supTel,@supEmail,@supAddress)";

                SqlCommand com = new SqlCommand(sql, con);

                com.Parameters.AddWithValue("@supId", this.txtId.Text);
                com.Parameters.AddWithValue("@supName", this.txtName.Text);
                com.Parameters.AddWithValue("@supTel", this.txtNo.Text);
                com.Parameters.AddWithValue("@supAddress", this.txtAdd.Text);
                com.Parameters.AddWithValue("@supEmail", this.txtEmail.Text);


                //Execute the command
                com.ExecuteNonQuery();
                MessageBox.Show(" Supplier Added Succesfully ", "Information");


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
            //prevent letters entering

            if (!char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Admin_Add_Supplier_Load(object sender, EventArgs e)
        {
            idAutoincrement();
        }
    }
}
