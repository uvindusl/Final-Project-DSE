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
            string sql = "SELECT pName From Product";
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
            adminidcombox();
            productcombo();
            suppliercombo();
            pid_auto_incrment();

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

        private void data_insetrt_purchaserder()
        {
            //connection
            string cs = @"Data Source=HPNotebook; 
            Initial Catalog=DSE_FinalProject; 
            Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            //commands
            string sql1 = "SELECT supId FROM Supplier WHERE supName=@name";
            SqlCommand com1 = new SqlCommand(sql1, con);
            com1.Parameters.AddWithValue("@name", this.combosname.Text);

            //access data using data reader method
            SqlDataReader dr = com1.ExecuteReader();
            dr.Read();
            string sid = dr.GetValue(0).ToString();

            con.Close();

            con.Open();

            //Command
            string sql = "INSERT INTO PurchaseOrder(purschaseOrderId,item,quantity,dateTime,totalAmount,totalDiscount,adminId,supId) VALUES(@poid,@item,@qty,@datetime,@tamount,@tdiscount,@aid,@sid)";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@poid", this.txtpid.Text);
            com.Parameters.AddWithValue("@item", this.comboproduct.Text);
            com.Parameters.AddWithValue("@qty", Convert.ToInt32(this.numaricqunatity.Value));
            com.Parameters.AddWithValue("@datetime", DateTime.Now);
            com.Parameters.AddWithValue("@tamount", this.txttotalamount.Text);
            com.Parameters.AddWithValue("@tdiscount", this.txttotaldiscount.Text);
            com.Parameters.AddWithValue("@aid", this.comboaid.Text);
            com.Parameters.AddWithValue("@sid", sid);

            //Execute
            int ret = com.ExecuteNonQuery();
            MessageBox.Show("No of records inserted: " + ret, "Information");

            con.Close();

        }

        private void data_insetrt_purchaserderconsists()
        {
            double price = Convert.ToDouble(this.txtprice.Text);
            int qty = Convert.ToInt32(this.numaricqunatity.Value);
            double total1 = price * qty;

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
            com.Parameters.AddWithValue("@subtotal", total1);

            //Execute
            int ret = com.ExecuteNonQuery();
            MessageBox.Show("No of records inserted: " + ret, "Information");

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
            string sql = "SELECT * FROM PurchaseOrderConsists";
            SqlCommand com = new SqlCommand(sql, con);

            //Data Adaptor
            SqlDataAdapter dap = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            dap.Fill(ds);
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double price = Convert.ToDouble(this.txtprice.Text);
            int qty = Convert.ToInt32(this.numaricqunatity.Value);
            double total1 = price*qty;
            double total = Convert.ToDouble(this.txttotalamount.Text);
            total =+ total1;
            this.txttotalamount.Text = total.ToString();
            this.txttotalamount.Text = total.ToString();
            double discount = Convert.ToDouble(this.txtdicount.Text);
            double totaldis1 = discount*qty;
            double totaldis = Convert.ToDouble(this.txttotaldiscount.Text);
            totaldis = +totaldis1;
            this.txttotaldiscount.Text = totaldis.ToString();


            data_insetrt_purchaserder();
            data_insetrt_purchaserderconsists();
            data_load_to_grid();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            //connection
            string cs = @"Data Source=HPNotebook; 
            Initial Catalog=DSE_FinalProject; 
            Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            //Load Data to GridView
            string sql = "TRUNCATE TABLE PurchaseOrderConsists";
            SqlCommand com = new SqlCommand(sql, con);
            com.ExecuteNonQuery();

            con.Close();
        }
    }
}
