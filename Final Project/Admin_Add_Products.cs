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
        }

        private void rdH_CheckedChanged(object sender, EventArgs e)
        {

            //enabling txt boxes

            this.txtHId.Enabled = true;
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

            this.txtSId.Enabled = true;
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
            else if (!rdH.Checked && !rdS.Checked)
            {
                MessageBox.Show("Select a type");
            }
            else
            {
                 try
                 {
                    //Create a connection

                    string cs = "Data Source = LAPTOP-DOH91PI2;Initial Catalog = DSE_FinalProject; Integrated Security = True ";
                    SqlConnection con = new SqlConnection(cs);

                    con.Open();

                    //create an object to execute the both commands at ones.
                    SqlTransaction transaction = con.BeginTransaction();

                    //Define a command

                    string sql = "INSERT INTO Product (productId,pName,pDescription,pType,pPrice) VALUES (@productId,@pName,@pDescription,@pType,@pPrice)";

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


                    //Execute the command
                    //com.ExecuteNonQuery();

                    /*  try   //id auto increament
                      {
                            
                          string sql1 = "SELECT MAX(ItemId) FROM Items";
                          SqlCommand cmd = new SqlCommand(sql1, con);

                          SqlDataReader dr = cmd.ExecuteReader();

                          if (dr.Read())
                          {
                              // Check if the value is convertible to int
                              if (int.TryParse(dr[0].ToString(), out int maxID))
                              {
                                  int newID = maxID + 1;
                                  this.txtId.Text = newID.ToString();
                              }
                              else
                              {
                                  // Handle the case where the value is not a valid integer
                                  this.txtId.Text = "1";
                              }
                          }
                          else
                          {
                              // Handle the case where there are no records in the table
                              this.txtId.Text = "1";
                          }

                      }
                      catch (SqlException)
                      {
                          MessageBox.Show(" Something went wrong ", "Information");
                      }*/

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

                            string sql1 = "INSERT INTO HardwareProduct (hardwareProductId,serialNumber,WarrantyPeriod) VALUES (@hardwareProductId,@serialNumber,@WarrantyPeriod)";
                            string sql3 = "INSERT INTO InventoryProducts (inventoryProductId,hardawareProductId)  VALUES (@inventoryProductId,@hwProductId)";

                            SqlCommand com1 = new SqlCommand(sql1, con , transaction);
                            SqlCommand com3 = new SqlCommand(sql3, con, transaction);

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

                            string sql2 = "INSERT INTO SoftwareProduct (softwareProductId,version,licenseType,platform,fileSize,subscriptionPeriod) VALUES (@softwareProductId,@version,@licenseType,@platform,@fileSize,@subscriptionPeriod)";

                            SqlCommand com2 = new SqlCommand(sql2, con, transaction);

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
                            this.rdS.Checked = false;
                            this.txtSId.Text = "";
                            this.txtVersion.Text = "";
                            this.txtLicense.Text = "";
                            this.txtPlatform.Text = "";
                            this.txtFileSize.Text = "";
                            this.txtSub.Text = "";
                        }
                    }
                    //Disconnect from the sql server
                    con.Close();

                    
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
    }
}
