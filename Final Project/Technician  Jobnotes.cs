using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Final_Project
{
    public partial class Technician__Jobnotes : Form
    {
        public Technician__Jobnotes()
        {
            InitializeComponent();
        }

        private void IdAutoIncrement()
        {
            try
            {
                // Create a connection
                string cs = @"Data Source=HPNotebook; Initial Catalog=DSE_FinalProject; Integrated Security=True";

                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();

                    string sql1 = "SELECT MAX(jobNoteId) FROM JobNote";
                    using (SqlCommand cmd = new SqlCommand(sql1, con))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            string maxItemId = dr[0]?.ToString(); // Use null-conditional operator to handle null values
                            Console.WriteLine($"maxItemId: {maxItemId}"); // Debug output

                            if (!string.IsNullOrEmpty(maxItemId) && maxItemId.StartsWith("JN"))
                            {
                                // Remove the prefix 'JN' and parse the numeric part
                                string numericPart = maxItemId.Substring(2);
                                if (int.TryParse(numericPart, out int maxID))
                                {
                                    // Increment the numeric part
                                    int newID = maxID + 1;
                                    // Format the new ID back to string with 'JN' prefix
                                    this.txtId.Text = "JN" + newID.ToString();
                                }
                                else
                                {
                                    // Handle the case where the numeric part is not valid
                                    this.txtId.Text = "JN1";
                                }
                            }
                            else
                            {
                                // Handle the case where there are no records in the table or invalid format
                                this.txtId.Text = "JN1";
                            }
                        }
                        else
                        {
                            // Handle the case where there are no records in the table
                            this.txtId.Text = "JN1";
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

        private void getValuesToboxCusId()
        {
            //loading values to the combo box cusid
            try
            {
                //Create a connection

                string cs = @"Data Source=HPNotebook; Initial Catalog=DSE_FinalProject; Integrated Security=True";
                SqlConnection con = new SqlConnection(cs);

                con.Open();

                //Define a command

                String sql = "SELECT cusId FROM Customer";

                SqlCommand cmd = new SqlCommand(sql, con);
               

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    boxCusId.Items.Add(dr["cusId"].ToString());

                }
                dr.Close();
                con.Close();
            }
            catch
            {
                MessageBox.Show(" Something went wrong ", "Information");
            }
        }

        private void getValuesToboxtxtName()
        {
            //loading values to the combo box txtName
            try
            {
                //Create a connection

                string cs = @"Data Source=HPNotebook; Initial Catalog=DSE_FinalProject; Integrated Security=True";
                SqlConnection con = new SqlConnection(cs);

                con.Open();

                //Define a command

                String sql = "SELECT cusName FROM Customer";

                SqlCommand cmd = new SqlCommand(sql, con);


                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txtName.Items.Add(dr["cusName"].ToString());

                }
                dr.Close();
                con.Close();
            }
            catch
            {
                MessageBox.Show(" Something went wrong ", "Information");
            }
        }
        private void Technician__Jobnotes_Load(object sender, EventArgs e)
        {
            IdAutoIncrement();
            this.txtDT.Text = DateTime.Now.ToString();
            getValuesToboxCusId();
            getValuesToboxtxtName();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //checking any empty values
            if (boxCusId.Text == "")
            {
                MessageBox.Show("Select a customer Id");
            }
            else if (txtDesc.Text == "")
            {
                MessageBox.Show("Enter a Description");
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

                string sql = "INSERT INTO JobNote (jobNoteId,description,dateTime,cusId) VALUES (@jobNoteId,@description,@dateTime,@cusId)";

                SqlCommand com = new SqlCommand(sql, con);

                com.Parameters.AddWithValue("@jobNoteId", this.txtId.Text);
                com.Parameters.AddWithValue("@description", this.txtDesc.Text);
                com.Parameters.AddWithValue("@dateTime", this.txtDT.Text);
                com.Parameters.AddWithValue("@cusId", this.boxCusId.Text);


                //Execute the command
                com.ExecuteNonQuery();
                MessageBox.Show("Jobe Note Saved Succesfully ", "Information");


                IdAutoIncrement();
                this.txtDT.Text = DateTime.Now.ToString();

                //Disconnect from the sql server
                con.Close();

                txtDesc.Text = "";
                boxCusId.Text = "";

                btnPrint.Enabled = true;

                /*}
                catch (SqlException)
                {
                    MessageBox.Show(" Something went wrong ", "Information");
                }*/

            }
        }

        private void boxCusId_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* try
            {*/
                //Create a connection

                string cs = @"Data Source=HPNotebook; Initial Catalog=DSE_FinalProject; Integrated Security=True";
                SqlConnection con = new SqlConnection(cs);

                con.Open();

                //Define a command

                String sql = "SELECT cusName FROM Customer Where cusId = @cusId";

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@cusId", this.boxCusId.Text);

                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                this.txtName.Text = dr.GetValue(0).ToString();

                dr.Close();
                con.Close();
            /*}
            catch (SqlException)
            {
                MessageBox.Show(" Something went wrong ", "Information");
            }*/
        }

        private void txtName_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* try
            {*/
            //Create a connection

            string cs = @"Data Source=HPNotebook; Initial Catalog=DSE_FinalProject; Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);

            con.Open();

            //Define a command

            String sql = "SELECT cusId FROM Customer Where cusName = @cusName";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@cusName", this.txtName.Text);

            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            this.boxCusId.Text = dr.GetValue(0).ToString();

            dr.Close();
            con.Close();
            /*}
            catch (SqlException)
            {
                MessageBox.Show(" Something went wrong ", "Information");
            }*/
        }
    }
}
