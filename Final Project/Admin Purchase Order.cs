using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class Admin_Purchase_Order : Form
    {
        public Admin_Purchase_Order()
        {
            InitializeComponent();
        }

        private void adminidcombox()
        {
            //getting admin ids to combo box

            comboaid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            comboaid.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboaid.AutoCompleteSource = AutoCompleteSource.ListItems;

            //connection
            string cs = @"Data Source=HPNotebook; 
                        Initial Catalog=DSE_FinalProject; 
                        Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            //commands
            string sql = "SELECT adminId From Admin";
            SqlCommand com = new SqlCommand(sql, con);

            //Access Data
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                this.comboaid.Items.Add(dr.GetValue(0));
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

        private void suppliercombo()
        {
            //getting supplier ids to combobox

            combosname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            combosname.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            combosname.AutoCompleteSource = AutoCompleteSource.ListItems;

            //connection
            string cs = @"Data Source=HPNotebook; 
                        Initial Catalog=DSE_FinalProject; 
                        Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            //commands
            string sql = "SELECT supName From Supplier";
            SqlCommand com = new SqlCommand(sql, con);

            //Access Data
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                this.combosname.Items.Add(dr.GetValue(0));
            }

            con.Close();
        }

        private void pid_auto_incrment()
        {
            //product ID auto increment code

            try
            {
                string cs = @"Data Source=HPNotebook; 
                    Initial Catalog=DSE_FinalProject; 
                    Integrated Security=True";

                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();

                    string sql1 = "SELECT MAX(purschaseOrderId) FROM PurchaseOrder";
                    using (SqlCommand cmd = new SqlCommand(sql1, con))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            string maxItemId = dr[0]?.ToString(); // Use the null-conditional operator

                            if (!string.IsNullOrEmpty(maxItemId) && maxItemId.StartsWith("PO"))
                            {
                                // Extract the numeric part after the "PO" prefix
                                string numericPart = maxItemId.Substring(2);
                                if (int.TryParse(numericPart, out int maxID))
                                {
                                    // Increment the numeric part
                                    int newID = maxID + 1;
                                    // Format the new ID back to string with 'PO' prefix and leading zeros
                                    this.txtpid.Text = "PO" + newID.ToString("D2"); // D2 ensures at least two digits
                                }
                                else
                                {
                                    // Handle the case where the numeric part is not valid
                                    this.txtpid.Text = "PO01";
                                }
                            }
                            else
                            {
                                // Handle the case where there are no records in the table or invalid format
                                this.txtpid.Text = "PO01";
                            }
                        }
                        else
                        {
                            // Handle the case where there are no records in the table
                            this.txtpid.Text = "PO01";
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


        private void Admin_Purchase_Order_Load(object sender, EventArgs e)
        {
            //calling methods
            this.btnsavetodatabse.Enabled = false;
            adminidcombox();
            productcombo();
            suppliercombo();
            pid_auto_incrment();
            btnsavetodatabse.Enabled = false;

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
            string sql = "SELECT pPrice FROM Product WHERE pName=@name";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@name", this.comboproduct.Text);

            //access data using data reader method
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();
            this.txtprice.Text = dr.GetValue(0).ToString();

            con.Close();
        }

        private void data_insert_purchaseorder()
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

                    // First command to get supId
                    string sql1 = "SELECT supId FROM Supplier WHERE supName=@name";
                    using (SqlCommand com1 = new SqlCommand(sql1, con))
                    {
                        com1.Parameters.AddWithValue("@name", this.combosname.Text);

                        using (SqlDataReader dr = com1.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                string sid = dr.GetValue(0).ToString();

                                dr.Close(); // Ensure the data reader is closed

                                // Second command to insert into PurchaseOrder
                                string sql = "INSERT INTO PurchaseOrder(purschaseOrderId, dateTime, totalAmount, totalDiscount, adminId, supId) " +
                                             "VALUES(@poid, @datetime, @tamount, @tdiscount, @aid, @sid)";
                                using (SqlCommand com = new SqlCommand(sql, con))
                                {
                                    com.Parameters.AddWithValue("@poid", this.txtpid.Text);
                                    com.Parameters.AddWithValue("@datetime", DateTime.Now);

                                    if (decimal.TryParse(this.txttotalamount.Text, out decimal totalAmount))
                                    {
                                        com.Parameters.AddWithValue("@tamount", totalAmount);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Invalid total amount.");
                                        return;
                                    }

                                    if (decimal.TryParse(this.txttotaldiscount.Text, out decimal totalDiscount))
                                    {
                                        com.Parameters.AddWithValue("@tdiscount", totalDiscount);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Invalid total discount.");
                                        return;
                                    }

                                    com.Parameters.AddWithValue("@aid", this.comboaid.Text);
                                    com.Parameters.AddWithValue("@sid", sid);

                                    // Execute
                                    int ret = com.ExecuteNonQuery();
                                    MessageBox.Show("Number of records inserted: " + ret, "Information");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Supplier not found.");
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
     


        private void data_insetrt_purchaserderconsists()
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
            string sql = "INSERT INTO PurchaseOrderConsists (PurchaseOrderId,hardwareProductId,quantity,discount,subTotal) VALUES(@poid,@hid,@qty,@discount,@subtotal)";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@poid", this.txtpid.Text);
            com.Parameters.AddWithValue("@hid", hid);
            com.Parameters.AddWithValue("@qty", Convert.ToInt32(this.numaricqunatity.Value));
            com.Parameters.AddWithValue("@discount", this.txttotaldiscount.Text);
            double subtotal = Convert.ToDouble(this.txtprice.Text) * Convert.ToDouble(this.numaricqunatity.Value);
            com.Parameters.AddWithValue("@subtotal", subtotal);

            //Execute
            int ret = com.ExecuteNonQuery();
            MessageBox.Show("Number of records inserted: " + ret, "Information");

            //connecion close
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
            string sql = "SELECT * FROM PurchaseOrderConsists WHERE PurchaseOrderId=@pid";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@pid", this.txtpid.Text);

            //Data Adaptor
            SqlDataAdapter dap = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            dap.Fill(ds);
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void calculate_the_total()
        {
            //total amount
            double price = Convert.ToDouble(this.txtprice.Text);
            double qty = Convert.ToDouble(this.numaricqunatity.Value);
            double total = Convert.ToDouble(this.txttotalamount.Text);

            //calculation
            double subtotal = price * qty;
            total = total+subtotal;

            //total discount
            double discount = Convert.ToDouble(this.txtdicount.Text);
            double totaldis = Convert.ToDouble(this.txttotaldiscount.Text);

            //calculation
            double subdiscount = discount * qty;
            totaldis = totaldis+subdiscount;

            //totalamount
            total = total - totaldis;

            //display totalamount
            this.txttotalamount.Text = total.ToString();

            //display totaldiscount
            this.txttotaldiscount.Text = totaldis.ToString();


        }

        private void textbox_clear()
        {
            //after clicking btnmark textbox and combobox clear

            this.comboproduct.Text = "";
            this.numaricqunatity.Value = 0;
            this.txtprice.Text = "0";
            this.txtdicount.Text = "0.00";

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


                            int newqty = Convert.ToInt32(this.numaricqunatity.Value);
                            in_qty = in_qty + newqty;

                                con.Open();

                                // Update inventory quantity
                                string sql = "UPDATE InventoryProducts SET pQuantity=@pq WHERE hardawareProductId=@hid";
                                using (SqlCommand com = new SqlCommand(sql, con))
                                {
                                    com.Parameters.AddWithValue("@hid", hardwareid());
                                    com.Parameters.AddWithValue("@pq", in_qty);

                                    // Execute the update
                                    int ret = com.ExecuteNonQuery();
                                   
                                }

                                con.Close();

                                
                            


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
            if(this.comboaid.Text == "")
            {
                MessageBox.Show("Select Admin ID");
            }
            else if(this.combosname.Text == "")
            {
                MessageBox.Show("Select Supplier Name");
            }
            else if(this.comboproduct.Text == "")
            {
                MessageBox.Show("Select Product Name");
            }
            else if(this.numaricqunatity.Value == 0)
            {
                MessageBox.Show("Add value more than 0");
            }
            else
            {
                calculate_the_total();
                data_insetrt_purchaserderconsists();
                data_load_to_grid();
                update_inventory_quantity();
                textbox_clear();
                
            }
            
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            

            this.Close();
        }

        private void textclear_for_save()
        {
            this.txtdescription.Text = "";
            this.txtpid.Text = "";
            this.comboaid.Text = "";
            this.combosname.Text = "";
            this.comboproduct.Text = "";
            this.numaricqunatity.Value = 0;
            this.txtprice.Text = "0";
            this.txtdicount.Text = "0";
            this.txttotalamount.Text = "0";
            this.txttotaldiscount.Text = "0";
            this.dataGridView1.DataSource = null;
        }

        private void btnsavetodatabse_Click(object sender, EventArgs e)
        {

            data_insert_purchaseorder();
            textclear_for_save();
            pid_auto_incrment();
            this.btnsavetodatabse.Enabled = false;

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

        private string auto_increment_purchaseInvoiceid()
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

                    string sql1 = "SELECT MAX(purchaseInvoiceId) FROM [PurchaseInvoice]";
                    using (SqlCommand cmd = new SqlCommand(sql1, con))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                string maxItemId = dr[0]?.ToString(); // Use the null-conditional operator

                                if (!string.IsNullOrEmpty(maxItemId) && maxItemId.StartsWith("PI"))
                                {
                                    // Extract the numeric part after the "SI" prefix
                                    string numericPart = maxItemId.Substring(2); // Change to 2 to skip the 'SI' prefix
                                    if (int.TryParse(numericPart, out int maxID))
                                    {
                                        // Increment the numeric part
                                        int newID = maxID + 1;
                                        // Format the new ID back to string with 'SI' prefix and leading zeros
                                        rid = "PI" + newID.ToString("D2"); // D2 ensures at least two digits
                                    }
                                    else
                                    {
                                        // Handle the case where the numeric part is not valid
                                        rid = "PI01";
                                    }
                                }
                                else
                                {
                                    // Handle the case where there are no records in the table or invalid format
                                    rid = "PI01";
                                }
                            }
                            else
                            {
                                // Handle the case where there are no records in the table
                                rid = "PI01";
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

        private void inset_datainto_purchaseinvoice()
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
                    string sql1 = "SELECT supId FROM Supplier WHERE supName=@name";
                    using (SqlCommand com1 = new SqlCommand(sql1, con))
                    {
                        com1.Parameters.AddWithValue("@name", this.combosname.Text);

                        using (SqlDataReader dr = com1.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                string sid = dr.GetValue(0).ToString();

                                dr.Close(); // Ensure the data reader is closed

                                // Command to insert into Order
                                string sql = "INSERT INTO [PurchaseInvoice] (purchaseInvoiceId, subDescription, purchaseOrderId, supId ) " +
                                             "VALUES (@piid,@sd,@pid , @sid)";
                                using (SqlCommand com = new SqlCommand(sql, con))
                                {
                                    com.Parameters.AddWithValue("@piid", auto_increment_purchaseInvoiceid());
                                    com.Parameters.AddWithValue("@sd", this.txtdescription.Text);
                                    com.Parameters.AddWithValue("@pid", this.txtpid.Text);
                                    com.Parameters.AddWithValue("@sid", sid);

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
            inset_datainto_purchaseinvoice();
            this.btnsavetodatabse.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            AdminUpdateEmployee aue = new AdminUpdateEmployee();
            aue.Show();
            this.Hide();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            AdminUpdateCustomer auc = new AdminUpdateCustomer();
            auc.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Admin_View_Products_1 avp = new Admin_View_Products_1();
            avp.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Admin_view_Product_inventory avpi = new Admin_view_Product_inventory();
            avpi.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Admin_View_Purchase_Order avpo = new Admin_View_Purchase_Order();
            avpo.Show();
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
            AdminMakePaysheet amp = new AdminMakePaysheet();
            amp.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AdminUpdateSupplier supplier = new AdminUpdateSupplier();
            supplier.Show();
            this.Hide();
        }
    }
}
