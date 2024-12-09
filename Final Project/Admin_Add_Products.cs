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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Final_Project
{
    public partial class Admin_Add_Products : Form
    {
        public Admin_Add_Products()
        {
            InitializeComponent();
        }

        private void ProductIdAutoIncrement()
        {
            //Id auto incriment
            try
            {
                //Create a connection

                string cs = @"Data Source=HPNotebook; Initial Catalog=DSE_FinalProject; Integrated Security=True";
                SqlConnection con = new SqlConnection(cs);

                con.Open();

                string sql1 = "SELECT MAX(productId) FROM Product";
                SqlCommand cmd = new SqlCommand(sql1, con);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    // Extract and increment the numeric part of the ItemId
                    string maxItemId = dr[0].ToString();

                    if (!string.IsNullOrEmpty(maxItemId) && maxItemId.StartsWith("P"))
                    {
                        // Remove the prefix 'P' and parse the numeric part
                        string numericPart = maxItemId.Substring(1);
                        if (int.TryParse(numericPart, out int maxID))
                        {
                            // Increment the numeric part
                            int newID = maxID + 1;
                            // Format the new ID back to string with 'P' prefix
                            this.txtId.Text = "P" + newID.ToString();
                        }
                        else
                        {
                            // Handle the case where the numeric part is not valid
                            this.txtId.Text = "P1";
                        }
                    }
                    else
                    {
                        // Handle the case where there are no records in the table
                        this.txtId.Text = "P1";
                    }
                }
                else
                {
                    // Handle the case where there are no records in the table
                    this.txtId.Text = "P1";
                }
                dr.Close(); // Ensure the data reader is closed
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message, "Information");
            }
        }

        private void HardwareIdAutoIncrement()
        {
            try
            {
                // Create a connection
                string cs = @"Data Source=HPNotebook; Initial Catalog=DSE_FinalProject; Integrated Security=True";

                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();

                    string sql1 = "SELECT MAX(hardwareProductId) FROM HardwareProduct";
                    using (SqlCommand cmd = new SqlCommand(sql1, con))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            string maxItemId = dr[0]?.ToString(); // Use null-conditional operator to handle null values
                            Console.WriteLine($"maxItemId: {maxItemId}"); // Debug output

                            if (!string.IsNullOrEmpty(maxItemId) && maxItemId.StartsWith("HP"))
                            {
                                // Remove the prefix 'HP' and parse the numeric part
                                string numericPart = maxItemId.Substring(2);
                                if (int.TryParse(numericPart, out int maxID))
                                {
                                    // Increment the numeric part
                                    int newID = maxID + 1;
                                    // Format the new ID back to string with 'HP' prefix
                                    this.txtHId.Text = "HP" + newID.ToString();
                                }
                                else
                                {
                                    // Handle the case where the numeric part is not valid
                                    this.txtHId.Text = "HP1";
                                }
                            }
                            else
                            {
                                // Handle the case where there are no records in the table or invalid format
                                this.txtHId.Text = "HP1";
                            }
                        }
                        else
                        {
                            // Handle the case where there are no records in the table
                            this.txtHId.Text = "HP1";
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

        private void SoftwareIdAutoIncrement()
        {
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
                                    this.txtSId.Text = "SP" + newID.ToString();
                                }
                                else
                                {
                                    // Handle the case where the numeric part is not valid
                                    this.txtSId.Text = "SP1";
                                }
                            }
                            else
                            {
                                // Handle the case where there are no records in the table or invalid format
                                this.txtSId.Text = "SP1";
                            }
                        }
                        else
                        {
                            // Handle the case where there are no records in the table
                            this.txtSId.Text = "SP1";
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
        private void Admin_Add_Products_Load(object sender, EventArgs e)
        {
            //disabling  txt boxes

            this.txtHId.Enabled = false;
            this.txtSerial.Enabled = false;
            this.txtWarranty.Enabled = false;
            this.txtSId.Enabled = false;
            this.txtVersion.Enabled = false;
            this.txtLicense.Enabled = false;
            this.txtPlatform.Enabled = false;
            this.txtFileSize.Enabled = false;
            this.txtSub.Enabled = false;

            ProductIdAutoIncrement();
            HardwareIdAutoIncrement();
            SoftwareIdAutoIncrement();

        }

        private void rdH_CheckedChanged(object sender, EventArgs e)
        {

            //enabling txt boxes

          //  this.txtHId.Enabled = true;
            this.txtSerial.Enabled = true;
            this.txtWarranty.Enabled = true;

            if (!rdH.Checked)
            {
                //disabling  txt boxes

                this.txtHId.Enabled = false;
                this.txtSerial.Enabled = false;
                this.txtWarranty.Enabled = false;

            }
        }

        private void rdS_CheckedChanged(object sender, EventArgs e)
        {
            //enabling txt boxes

            //this.txtSId.Enabled = true;
            this.txtVersion.Enabled = true;
            this.txtLicense.Enabled = true;
            this.txtPlatform.Enabled = true;
            this.txtFileSize.Enabled = true;
            this.txtSub.Enabled = true;

            if (!rdS.Checked)
            {
                //disabling  txt boxes

                this.txtSId.Enabled = false;
                this.txtVersion.Enabled = false;
                this.txtLicense.Enabled = false;
                this.txtPlatform.Enabled = false;
                this.txtFileSize.Enabled = false;
                this.txtSub.Enabled = false;

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            //checking any empty values

            if (txtName.Text == "")
            {
                MessageBox.Show("Enter a name");
            }
            else if (txtPrice.Text == "")
            {
                MessageBox.Show("Enter a price");
            }
            else if (txtSprice.Text == "")
            {
                MessageBox.Show("Enter a Selling price");
            }
            else if (!rdH.Checked && !rdS.Checked)
            {
                MessageBox.Show("Select a type");
            }
            else
            {
                 try
                 {
                    //Create a connection

                    string cs = @"Data Source=HPNotebook; Initial Catalog=DSE_FinalProject; Integrated Security=True";
                    SqlConnection con = new SqlConnection(cs);

                    con.Open();

                    //create an object to execute the both commands at ones.
                    SqlTransaction transaction = con.BeginTransaction();

                    //Define a command

                    string sql = "INSERT INTO Product (productId,pName,pDescription,pType,pPrice,pSellingPrice) VALUES (@productId,@pName,@pDescription,@pType,@pPrice,@pSellingPrice)";

                    SqlCommand com = new SqlCommand(sql, con, transaction);
                    
                    com.Parameters.AddWithValue("@productId", this.txtId.Text);
                    com.Parameters.AddWithValue("@pName", this.txtName.Text);
                    com.Parameters.AddWithValue("@pDescription", this.txtDescription.Text);
                    

                    if (rdH.Checked)
                    {
                        com.Parameters.AddWithValue("@pType","Hardware");
                    }
                    else if (rdS.Checked)
                    {
                        com.Parameters.AddWithValue("@pType", "Software");
                    }
                
                    com.Parameters.AddWithValue("@pPrice", this.txtPrice.Text);
                    com.Parameters.AddWithValue("@pSellingPrice", this.txtSprice.Text);

                    if (rdH.Checked)
                    {
                        if (txtSerial.Text == "")
                        {
                            MessageBox.Show("Enter a Serial number");
                            // Rollback transaction if an error occurs
                            transaction.Rollback();
                        }
                        else if (txtWarranty.Text == "")
                        {
                            MessageBox.Show("Enter a Warranty Period");
                            // Rollback transaction if an error occurs
                            transaction.Rollback();
                        }
                        else
                        {
                            //Define a command

                            string sql1 = "INSERT INTO HardwareProduct (hardwareProductId,serialNumber,WarrantyPeriod,productId) VALUES (@hardwareProductId,@serialNumber,@WarrantyPeriod,@productId)";
                            string sql3 = "INSERT INTO InventoryProducts (inventoryProductId,hardawareProductId)  VALUES (@inventoryProductId,@hwProductId)";

                            SqlCommand com1 = new SqlCommand(sql1, con , transaction);
                            SqlCommand com3 = new SqlCommand(sql3, con, transaction);

                            com1.Parameters.AddWithValue("@productId", this.txtId.Text);
                            com1.Parameters.AddWithValue("@hardwareProductId", this.txtHId.Text);
                            com1.Parameters.AddWithValue("@serialNumber", this.txtSerial.Text);
                            com1.Parameters.AddWithValue("@WarrantyPeriod", this.txtWarranty.Text);
                            com3.Parameters.AddWithValue("@inventoryProductId", this.txtId.Text);
                            com3.Parameters.AddWithValue("@hwProductId", this.txtHId.Text);

                            //Execute the command
                            com.ExecuteNonQuery();
                            com1.ExecuteNonQuery();
                            com3.ExecuteNonQuery();

                            // Commit transaction
                            transaction.Commit();

                            MessageBox.Show("Hardware Product Added Succesfully ", "Information");

                            this.txtId.Text = "";
                            this.txtName.Text = "";
                            this.txtDescription.Text = "";
                            this.txtPrice.Text = "";
                            this.rdH.Checked = false;
                            this.txtHId.Text = "";
                            this.txtSerial.Text = "";
                            this.txtWarranty.Text = "";

                        }
                       
                    }
                    else if (rdS.Checked)
                    {
                        if (txtVersion.Text == "")
                        {
                            MessageBox.Show("Enter a Version");
                            // Rollback transaction if an error occurs
                            transaction.Rollback();
                        }                   
                        else if (txtLicense.Text == "")
                        {
                            MessageBox.Show("Enter a Licence Type");
                            // Rollback transaction if an error occurs
                            transaction.Rollback();
                        }
                        else if (txtPlatform.Text == "")
                        {
                            MessageBox.Show("Enter a PlatForm");
                            // Rollback transaction if an error occurs
                            transaction.Rollback();
                        }
                        else if (txtFileSize.Text == "")
                        {
                            MessageBox.Show("Enter a File Size");
                            // Rollback transaction if an error occurs
                            transaction.Rollback();
                        }
                        else if (txtSub.Text == "")
                        {
                            MessageBox.Show("Enter a SubscriptionPeriod");
                            // Rollback transaction if an error occurs
                            transaction.Rollback();
                        }
                        else
                        {
                            //Define a command

                            string sql2 = "INSERT INTO SoftwareProduct (softwareProductId,version,licenseType,platform,fileSize,subscriptionPeriod,productId) VALUES (@softwareProductId,@version,@licenseType,@platform,@fileSize,@subscriptionPeriod,@productId)";

                            SqlCommand com2 = new SqlCommand(sql2, con, transaction);

                            com2.Parameters.AddWithValue("@productId", this.txtId.Text);
                            com2.Parameters.AddWithValue("@softwareProductId", this.txtSId.Text);
                            com2.Parameters.AddWithValue("@version", this.txtVersion.Text);
                            com2.Parameters.AddWithValue("@licenseType", this.txtLicense.Text);
                            com2.Parameters.AddWithValue("@platform", this.txtPlatform.Text);
                            com2.Parameters.AddWithValue("@fileSize", this.txtFileSize.Text);
                            com2.Parameters.AddWithValue("@subscriptionPeriod", this.txtSub.Text);


                            //Execute the command
                            com.ExecuteNonQuery();
                            com2.ExecuteNonQuery();

                            // Commit transaction
                            transaction.Commit();

                            MessageBox.Show("Software Product added Succesfully ", "Information");

                            this.txtId.Text = "";
                            this.txtName.Text = "";
                            this.txtDescription.Text = "";
                            this.txtPrice.Text = "";
                            this.txtSprice.Text = "";
                            this.rdS.Checked = false;
                            this.txtSId.Text = "";
                            this.txtVersion.Text = "";
                            this.txtLicense.Text = "";
                            this.txtPlatform.Text = "";
                            this.txtFileSize.Text = "";
                            this.txtSub.Text = "";
                            this.txtSprice.Text = "";

                        }
                    }
                    //Disconnect from the sql server
                    con.Close();

                    ProductIdAutoIncrement();
                    HardwareIdAutoIncrement();
                    SoftwareIdAutoIncrement();
                 }
                 catch (SqlException)
                 {
                    
                    MessageBox.Show(" Something went wrong ", "Information");
                 }
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            //prevent letters entering

            if (!char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtWarranty_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFileSize_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSub_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSub_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtFileSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtWarranty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Admin_Dashboard ad = new Admin_Dashboard();
            ad.Show();
            this.Hide();
        }

        private void btnEmployeeForm_Click(object sender, EventArgs e)
        {
            Admin_Add_employees ad = new Admin_Add_employees();
            ad.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminUpdateCustomer ad = new AdminUpdateCustomer();
            ad.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin_View_Products_1 ad = new Admin_View_Products_1();
            ad.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Admin_view_Product_inventory admin = new Admin_view_Product_inventory();
            admin.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin_Purchase_Order admin = new Admin_Purchase_Order();
            admin.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Admin_View_Search_orders admin_View_Search_Orders = new Admin_View_Search_orders();
            admin_View_Search_Orders.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AdminMakePaysheet admin_MakePaysheet = new AdminMakePaysheet();
            admin_MakePaysheet.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Admin_Add_Supplier sup = new Admin_Add_Supplier();
            sup.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AdminUpdateHardware ad = new AdminUpdateHardware();
            ad.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AdminUpdateSoftware ad = new AdminUpdateSoftware();
            ad.Show();
            this.Hide();
        }
    }
}
