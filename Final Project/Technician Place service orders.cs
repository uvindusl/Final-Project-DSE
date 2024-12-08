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
    public partial class Technician_Software : Form
    {
        public Technician_Software()
        {
            InitializeComponent();
        }

        //data insert order table ekata insert weddi technicain id eka parameters walin yanna hadanna oni

        private void customercombo()
        {
            //getting admin ids to combo box

            combocname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            combocname.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            combocname.AutoCompleteSource = AutoCompleteSource.ListItems;

            //connection
            string cs = @"Data Source=HPNotebook; 
                        Initial Catalog=DSE_FinalProject; 
                        Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            //commands
            string sql = "SELECT cusName From Customer";
            SqlCommand com = new SqlCommand(sql, con);

            //Access Data
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                this.combocname.Items.Add(dr.GetValue(0));
            }

            con.Close();
        }

        private void productcombo()
        {
            //getting product ids to combobox

            comboproduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            comboproduct.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboproduct.AutoCompleteSource = AutoCompleteSource.ListItems;

            //connection
            string cs = @"Data Source=HPNotebook; 
                        Initial Catalog=DSE_FinalProject; 
                        Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            //commands
            string sql = "SELECT pName FROM Product WHERE pType='Software'";
            SqlCommand com = new SqlCommand(sql, con);

            //Access Data
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                this.comboproduct.Items.Add(dr.GetValue(0));
            }

            con.Close();
        }

        private void auto_increment_serviceid()
        {
            try
            {
                // Connection string
                string cs = @"Data Source=HPNotebook; 
                      Initial Catalog=DSE_FinalProject; 
                      Integrated Security=True";

                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();

                    string sql1 = "SELECT MAX(serviceId) FROM [Service]";
                    using (SqlCommand cmd = new SqlCommand(sql1, con))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            string maxItemId = dr[0]?.ToString(); // Use the null-conditional operator

                            if (!string.IsNullOrEmpty(maxItemId) && maxItemId.StartsWith("S"))
                            {
                                // Extract the numeric part after the "O" prefix
                                string numericPart = maxItemId.Substring(1);
                                if (int.TryParse(numericPart, out int maxID))
                                {
                                    // Increment the numeric part
                                    int newID = maxID + 1;
                                    // Format the new ID back to string with 'O' prefix and leading zeros
                                    this.txtsid.Text = "S" + newID.ToString("D2"); // D2 ensures at least two digits
                                }
                                else
                                {
                                    // Handle the case where the numeric part is not valid
                                    this.txtsid.Text = "S01";
                                }
                            }
                            else
                            {
                                // Handle the case where there are no records in the table or invalid format
                                this.txtsid.Text = "S01";
                            }
                        }
                        else
                        {
                            // Handle the case where there are no records in the table
                            this.txtsid.Text = "S01";
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

        private void Technician_Software_Load(object sender, EventArgs e)
        {
            this.btnsavetodatabse.Enabled = false;
            this.button1.Enabled = false;
            customercombo();
            productcombo();
            auto_increment_serviceid();
        }

        private void comboproduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            //connection
            string cs = @"Data Source=HPNotebook; 
                        Initial Catalog=DSE_FinalProject; 
                        Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            //commands
            string sql = "SELECT pSellingPrice FROM Product WHERE pName=@name";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@name", this.comboproduct.Text);

            //access data using data reader method
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();
            this.txtprice.Text = dr.GetValue(0).ToString();

            con.Close();
        }

        private void data_load_to_grid()
        {
            //connection
            string cs = @"Data Source=HPNotebook; 
            Initial Catalog=DSE_FinalProject; 
            Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            //Load Data to GridView
            string sql = "SELECT * FROM ServiceConsists WHERE serviceId=@sid";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@sid", this.txtsid.Text);

            //Data Adaptor
            SqlDataAdapter dap = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            dap.Fill(ds);
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void insert_data_into_QuatationConsists()
        {
            //connection
            string cs = @"Data Source=HPNotebook; 
            Initial Catalog=DSE_FinalProject; 
            Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            //commands
            string sql1 = "SELECT productId FROM Product WHERE pName=@name";
            SqlCommand com1 = new SqlCommand(sql1, con);
            com1.Parameters.AddWithValue("@name", this.comboproduct.Text);

            //access data using data reader method
            SqlDataReader dr = com1.ExecuteReader();
            dr.Read();
            string pid = dr.GetValue(0).ToString();

            con.Close();

            con.Open();

            //commands
            string sql2 = "SELECT softwareProductId FROM SoftwareProduct WHERE productId=@productId";
            SqlCommand com2 = new SqlCommand(sql2, con);
            com2.Parameters.AddWithValue("@productId", pid);

            //access data using data reader method
            SqlDataReader dr2 = com2.ExecuteReader();
            dr2.Read();
            string hid = dr2.GetValue(0).ToString();

            con.Close();

            con.Open();

            //Command
            string sql = "INSERT INTO ServiceConsists (serviceId,softwareProductId,subTotal) VALUES(@sid,@sod,@sub)";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@sid", this.txtsid.Text);
            com.Parameters.AddWithValue("@sod", hid);
            com.Parameters.AddWithValue("@sub", this.txtsubtotal.Text);

            //Execute
            int ret = com.ExecuteNonQuery();


            //connecion close
            con.Close();
        }

        private void calcualte()
        {
            
            double price = Convert.ToDouble(this.txtprice.Text);
            this.txtsubtotal.Text = price.ToString(); 
        }

        private void final_cal()
        {
            //double scharge = Convert.ToDouble(this.txtscharge.Text);
            double subtotal = Convert.ToDouble(this.txtsubtotal.Text);
            double totalc = Convert.ToDouble(this.txttcharge.Text);
            double totala = Convert.ToDouble(this.txtnettotal.Text);

            totalc = totalc + subtotal;
            this.txttcharge.Text = totalc.ToString();

            totala = totala + totalc; //+ scharge;
            this.txtnettotal.Text = totala.ToString();
        }
        private void textbox_clear()
        {
            //after clicking btnmark textbox and combobox clear
            this.txtsubtotal.Text = "";
            this.comboproduct.Text = "";
            this.txtprice.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.combocname.Text == "")
            {
                MessageBox.Show("Select Customer");
            }
            else if(this.txtscharge.Text == "")
            {
                MessageBox.Show("Enter the Service Charges");
            }
            else if(this.comboproduct.Text == "")
            {
                MessageBox.Show("Select Software Product");
            }
            else
            {
                this.button2.Enabled = false;
                final_cal();
                insert_data_into_QuatationConsists();
                data_load_to_grid();
                textbox_clear();
            }
            


        }


        private void calculate_servicecharge()
        {
            double scharge = Convert.ToDouble(this.txtscharge.Text);
            double totala = Convert.ToDouble(this.txtnettotal.Text); 
            totala = totala + scharge;
            this.txtnettotal.Text = totala.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(this.txtscharge.Text == "")
            {
                MessageBox.Show("Enter Service Charge");
            }
            else
            {
                calculate_servicecharge();
                this.button1.Enabled = true;
            }
            

        }

        private void txtprice_TextChanged_1(object sender, EventArgs e)
        {
            calcualte();
        }

        private void inset_datainto_service()
        {
            try
            {
                // Connection string
                string cs = @"Data Source=HPNotebook; 
                      Initial Catalog=DSE_FinalProject; 
                      Integrated Security=True";

                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();

                    // Command to get cusId
                    string sql1 = "SELECT cusId FROM Customer WHERE cusName=@name";
                    using (SqlCommand com1 = new SqlCommand(sql1, con))
                    {
                        com1.Parameters.AddWithValue("@name", this.combocname.Text);

                        using (SqlDataReader dr = com1.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                string cusId = dr.GetValue(0).ToString();

                                dr.Close(); // Ensure the data reader is closed

                                // Command to insert into Order
                                string sql = "INSERT INTO [Service] (serviceId, serviceCharge, dateTime, cusId, totalCharge ,netTotal) " +
                                             "VALUES (@sid,@sc,@datetime,@cusid , @tc ,@nt)";
                                using (SqlCommand com = new SqlCommand(sql, con))
                                {
                                    com.Parameters.AddWithValue("@sid", this.txtsid.Text);
                                    com.Parameters.AddWithValue("@sc", this.txttcharge.Text);
                                    com.Parameters.AddWithValue("@datetime", DateTime.Now);
                                    com.Parameters.AddWithValue("@cusid", cusId);
                                    com.Parameters.AddWithValue("@tc", this.txttcharge.Text);
                                    com.Parameters.AddWithValue("@nt", this.txtnettotal.Text);

                                    // Execute the insert
                                    int ret = com.ExecuteNonQuery();
                                    MessageBox.Show("Number of records Inserted: " + ret, "Information");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Customer not found.");
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message, "Information");
            }
        }

        private void textclear_for_save()
        {
            this.txtsid.Text = "";
            this.combocname.Text = "";
            this.txtdescription.Text = "";
            this.comboproduct.Text = "";
            this.txtprice.Text = "0";
            this.txtsubtotal.Text = "";
            this.txtscharge.Text = "";
            this.txtsubtotal.Text = "";
            this.txttcharge.Text = "0.00";
            this.txtnettotal.Text = "0.00";
            this.dataGridView1.DataSource = null;
        }
        private void btnsavetodatabse_Click(object sender, EventArgs e)
        {
            inset_datainto_service();
            textclear_for_save();
            auto_increment_serviceid();
            this.button2.Enabled = true;
            this.button1.Enabled = false;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string auto_increment_serviceinvoiceid()
        {
            string sid = string.Empty;

            try
            {
                // Connection string
                string cs = @"Data Source=HPNotebook; 
                      Initial Catalog=DSE_FinalProject; 
                      Integrated Security=True";

                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();

                    string sql1 = "SELECT MAX(serviceInvoiceId) FROM [ServiceInvoice]";
                    using (SqlCommand cmd = new SqlCommand(sql1, con))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                string maxItemId = dr[0]?.ToString(); // Use the null-conditional operator

                                if (!string.IsNullOrEmpty(maxItemId) && maxItemId.StartsWith("SI"))
                                {
                                    // Extract the numeric part after the "SI" prefix
                                    string numericPart = maxItemId.Substring(2); // Change to 2 to skip the 'SI' prefix
                                    if (int.TryParse(numericPart, out int maxID))
                                    {
                                        // Increment the numeric part
                                        int newID = maxID + 1;
                                        // Format the new ID back to string with 'SI' prefix and leading zeros
                                        sid = "SI" + newID.ToString("D2"); // D2 ensures at least two digits
                                    }
                                    else
                                    {
                                        // Handle the case where the numeric part is not valid
                                        sid = "SI01";
                                    }
                                }
                                else
                                {
                                    // Handle the case where there are no records in the table or invalid format
                                    sid = "SI01";
                                }
                            }
                            else
                            {
                                // Handle the case where there are no records in the table
                                sid = "SI01";
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message, "Information");
            }

            return sid;
        }


        private void inset_datainto_serviceinvoice()
        {
            try
            {
                // Connection string
                string cs = @"Data Source=HPNotebook; 
                      Initial Catalog=DSE_FinalProject; 
                      Integrated Security=True";

                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();

                    // Command to get cusId
                    string sql1 = "SELECT cusId FROM Customer WHERE cusName=@name";
                    using (SqlCommand com1 = new SqlCommand(sql1, con))
                    {
                        com1.Parameters.AddWithValue("@name", this.combocname.Text);

                        using (SqlDataReader dr = com1.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                string cusId = dr.GetValue(0).ToString();

                                dr.Close(); // Ensure the data reader is closed

                                // Command to insert into Order
                                string sql = "INSERT INTO [ServiceInvoice] (serviceInvoiceId, subDescription, cusId, serviceId) " +
                                             "VALUES (@siid,@sd,@cusid , @sid)";
                                using (SqlCommand com = new SqlCommand(sql, con))
                                {
                                    com.Parameters.AddWithValue("@siid", auto_increment_serviceinvoiceid());
                                    com.Parameters.AddWithValue("@sd", this.txtdescription.Text);
                                    com.Parameters.AddWithValue("@cusid", cusId);
                                    com.Parameters.AddWithValue("@sid", this.txtsid.Text);

                                    // Execute the insert
                                    int ret = com.ExecuteNonQuery();
                                    MessageBox.Show("Number of records Inserted: " + ret, "Information");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Customer not found.");
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message, "Information");
            }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            inset_datainto_serviceinvoice();
            this.btnsavetodatabse.Enabled = true;
        }
    }
}
