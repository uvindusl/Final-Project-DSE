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
    public partial class Sales_Person_POS : Form
    {
        public Sales_Person_POS()
        {
            InitializeComponent();
        }

        //data insert order table ekata insert weddi salespersonge id eka parameters walin yanna hadanna oni

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
            string sql = "SELECT pName FROM Product WHERE pType='Hardware'";
            SqlCommand com = new SqlCommand(sql, con);

            //Access Data
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                this.comboproduct.Items.Add(dr.GetValue(0));
            }

            con.Close();
        }

        private void auto_increment_orderid()
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

                    string sql1 = "SELECT MAX(oderId) FROM [Order]";
                    using (SqlCommand cmd = new SqlCommand(sql1, con))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            string maxItemId = dr[0]?.ToString(); // Use the null-conditional operator

                            if (!string.IsNullOrEmpty(maxItemId) && maxItemId.StartsWith("O"))
                            {
                                // Extract the numeric part after the "O" prefix
                                string numericPart = maxItemId.Substring(1);
                                if (int.TryParse(numericPart, out int maxID))
                                {
                                    // Increment the numeric part
                                    int newID = maxID + 1;
                                    // Format the new ID back to string with 'O' prefix and leading zeros
                                    this.txtoid.Text = "O" + newID.ToString("D2"); // D2 ensures at least two digits
                                }
                                else
                                {
                                    // Handle the case where the numeric part is not valid
                                    this.txtoid.Text = "O01";
                                }
                            }
                            else
                            {
                                // Handle the case where there are no records in the table or invalid format
                                this.txtoid.Text = "O01";
                            }
                        }
                        else
                        {
                            // Handle the case where there are no records in the table
                            this.txtoid.Text = "O01";
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


        private void Sales_Person_POS_Load(object sender, EventArgs e)
        {
            this.btnsavetodatabse.Enabled = false;
            auto_increment_orderid();
            customercombo();
            productcombo();
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

        private void calculations_sub()
        {
            double price = Convert.ToDouble(this.txtprice.Text);
            double dicount = Convert.ToDouble(this.txtdiscount.Text);
            int qty = Convert.ToInt32(this.numaricqunatity.Value);

            double subtotal = price * qty;
            double subdiscount = dicount * qty;

            this.txtsubdicount.Text = subdiscount.ToString();
            this.txtsubtotal.Text = subtotal.ToString();
            
        }

        private void numaricqunatity_ValueChanged(object sender, EventArgs e)
        {
            calculations_sub();
        }

        private void calculations_net()
        {
            double subtotal = Convert.ToDouble(this.txtsubtotal.Text);
            double subdiscount = Convert.ToDouble(this.txtsubdicount.Text);

            double nettotal = Convert.ToDouble(this.txttotalamount.Text);
            double netdiscount = Convert.ToDouble(this.txttotaldiscount.Text);

            nettotal = nettotal + subtotal;
            netdiscount = netdiscount + subdiscount;
            nettotal = nettotal - netdiscount;

            this.txttotalamount.Text = nettotal.ToString();
            this.txttotaldiscount.Text = netdiscount.ToString();
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
            string sql = "SELECT * FROM OrderConsists WHERE orderId=@pid";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@pid", this.txtoid.Text);

            //Data Adaptor
            SqlDataAdapter dap = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            dap.Fill(ds);
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void insert_data_into_orderconsists()
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
            string sql2 = "SELECT hardwareProductId FROM HardwareProduct WHERE productId=@productId";
            SqlCommand com2 = new SqlCommand(sql2, con);
            com2.Parameters.AddWithValue("@productId", pid);

            //access data using data reader method
            SqlDataReader dr2 = com2.ExecuteReader();
            dr2.Read();
            string hid = dr2.GetValue(0).ToString();

            con.Close();

            con.Open();

            //Command
            string sql = "INSERT INTO OrderConsists (orderId,hardwareProductId,quantity,discount,subTotal) VALUES(@oid,@hid,@qty,@dis,@subtotal)";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@oid", this.txtoid.Text);
            com.Parameters.AddWithValue("@hid", hid);
            com.Parameters.AddWithValue("@qty", Convert.ToInt32(this.numaricqunatity.Value));
            com.Parameters.AddWithValue("@dis",this.txtsubdicount.Text);
            com.Parameters.AddWithValue("@subtotal", this.txtsubtotal.Text);

            //Execute
            int ret = com.ExecuteNonQuery();


            //connecion close
            con.Close();
        }

        private void textbox_clear()
        {
            //after clicking btnmark textbox and combobox clear

            this.comboproduct.Text = "";
            this.numaricqunatity.Value = 0;
            this.txtprice.Clear();
            this.txtdiscount.Text = "0";
            this.txtsubdicount.Text = "";
            this.txtsubtotal.Text = "";

        }

        private void update_inventory_quantity()
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

                    // Query to get pQuantity
                    string sql1 = "SELECT pQuantity FROM InventoryProducts WHERE hardawareProductId=@hid";
                    using (SqlCommand com1 = new SqlCommand(sql1, con))
                    {
                        com1.Parameters.AddWithValue("@hid", hardwareid());

                        using (SqlDataReader dr = com1.ExecuteReader())
                        {
                            dr.Read();
                            int in_qty = Convert.ToInt32(dr.GetValue(0).ToString());
                            con.Close();

                                if (in_qty == 0)
                                {
                                    // Show message if inventory quantity is 0
                                    MessageBox.Show("Product Out Of Stock!!!");
                                    textbox_clear();
                                    return;
                                }
                                else
                                {
                                    

                                    int qty = Convert.ToInt32(this.numaricqunatity.Value);
                                    in_qty -= qty;  // Update inventory quantity



                                    con.Open();
     
                                    // Update inventory quantity
                                    string sql = "UPDATE InventoryProducts SET pQuantity=@pq WHERE hardawareProductId=@hid";
                                    using (SqlCommand com = new SqlCommand(sql, con))
                                    {
                                        com.Parameters.AddWithValue("@hid", hardwareid());
                                        com.Parameters.AddWithValue("@pq", in_qty);

                                        // Execute the update
                                        int ret = com.ExecuteNonQuery();
                                        MessageBox.Show("Number of records Added: " + ret, "Information");
                                    }

                                    con.Close();

                                // Perform necessary calculations and data insertion
                                calculations_net();
                                insert_data_into_orderconsists();
                                data_load_to_grid();
                                textbox_clear();
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



        private void button1_Click(object sender, EventArgs e)
        {
            if(this.combocname.Text == "")
            {
                MessageBox.Show("Select Customer");
            }
            else if(this.comboproduct.Text == "")
            {
                MessageBox.Show("Select Product");
            }
            else if(this.numaricqunatity.Value == 0)
            {
                MessageBox.Show("Quantity Should be more than 0");
            }
            else
            {
                update_inventory_quantity();
            }
            
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string hardwareid()
        {
            string hid2 = string.Empty;

            // Connection string
            string cs = @"Data Source=HPNotebook; 
                  Initial Catalog=DSE_FinalProject; 
                  Integrated Security=True";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                // Command to get productId
                string sql1 = "SELECT productId FROM Product WHERE pName=@name";
                using (SqlCommand com1 = new SqlCommand(sql1, con))
                {
                    com1.Parameters.AddWithValue("@name", this.comboproduct.Text);

                    using (SqlDataReader dr1 = com1.ExecuteReader())
                    {
                        if (dr1.Read())
                        {
                            string pid = dr1.GetValue(0).ToString();
                            dr1.Close(); // Ensure the data reader is closed

                            // Command to get hardwareProductId
                            string sql2 = "SELECT hardwareProductId FROM HardwareProduct WHERE productId=@productId";
                            using (SqlCommand com2 = new SqlCommand(sql2, con))
                            {
                                com2.Parameters.AddWithValue("@productId", pid);

                                using (SqlDataReader dr2 = com2.ExecuteReader())
                                {
                                    if (dr2.Read())
                                    {
                                        hid2 = dr2.GetValue(0).ToString();
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return hid2;
        }

        private void inset_datainto_order()
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
                                string sql = "INSERT INTO [Order] (oderId, dateTime, totalAmount, totalDiscount, cusId) " +
                                             "VALUES (@oid, @datetime, @totala, @dis, @cusid)";
                                using (SqlCommand com = new SqlCommand(sql, con))
                                {
                                    com.Parameters.AddWithValue("@oid", this.txtoid.Text);
                                    com.Parameters.AddWithValue("@datetime", DateTime.Now);
                                    com.Parameters.AddWithValue("@totala", this.txttotalamount.Text);
                                    com.Parameters.AddWithValue("@dis", this.txttotaldiscount.Text);
                                    com.Parameters.AddWithValue("@cusid", cusId);

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
            this.txtdescription.Text = "";
            this.txtoid.Text = "";
            this.combocname.Text = "";
            this.comboproduct.Text = "";
            this.numaricqunatity.Value = 0;
            this.txtprice.Clear();
            this.txtdiscount.Text = "0";
            this.txtsubdicount.Text = "";
            this.txtsubtotal.Text = "";
            this.txttotalamount.Text = "0.00";
            this.txttotaldiscount.Text = "0.00";
            this.dataGridView1.DataSource = null;
        }

        private void btnsavetodatabse_Click(object sender, EventArgs e)
        {
            
            inset_datainto_order();
            textclear_for_save();
            auto_increment_orderid();
        }

        private string auto_increment_productInvoiceid()
        {
            string rid = string.Empty;

            try
            {
                // Connection string
                string cs = @"Data Source=HPNotebook; 
                      Initial Catalog=DSE_FinalProject; 
                      Integrated Security=True";

                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();

                    string sql1 = "SELECT MAX(pInvoiceId) FROM [ProductInvoice]";
                    using (SqlCommand cmd = new SqlCommand(sql1, con))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                string maxItemId = dr[0]?.ToString(); // Use the null-conditional operator

                                if (!string.IsNullOrEmpty(maxItemId) && maxItemId.StartsWith("PR"))
                                {
                                    // Extract the numeric part after the "SI" prefix
                                    string numericPart = maxItemId.Substring(2); // Change to 2 to skip the 'SI' prefix
                                    if (int.TryParse(numericPart, out int maxID))
                                    {
                                        // Increment the numeric part
                                        int newID = maxID + 1;
                                        // Format the new ID back to string with 'SI' prefix and leading zeros
                                        rid = "PR" + newID.ToString("D2"); // D2 ensures at least two digits
                                    }
                                    else
                                    {
                                        // Handle the case where the numeric part is not valid
                                        rid = "PR01";
                                    }
                                }
                                else
                                {
                                    // Handle the case where there are no records in the table or invalid format
                                    rid = "PR01";
                                }
                            }
                            else
                            {
                                // Handle the case where there are no records in the table
                                rid = "PR01";
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message, "Information");
            }

            return rid;
        }

        private void inset_datainto_productinvoice()
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
                                string cid = dr.GetValue(0).ToString();

                                dr.Close(); // Ensure the data reader is closed

                                // Command to insert into Order
                                string sql = "INSERT INTO [ProductInvoice] (pInvoiceId, subDescription, orderId, cusId ) " +
                                             "VALUES (@prid,@sd,@oid , @cid)";
                                using (SqlCommand com = new SqlCommand(sql, con))
                                {
                                    com.Parameters.AddWithValue("@prid", auto_increment_productInvoiceid());
                                    com.Parameters.AddWithValue("@sd", this.txtdescription.Text);
                                    com.Parameters.AddWithValue("@oid", this.txtoid.Text);
                                    com.Parameters.AddWithValue("@cid", cid);

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
            inset_datainto_productinvoice();
            this.btnsavetodatabse.Enabled = true;
        }
    }
}
