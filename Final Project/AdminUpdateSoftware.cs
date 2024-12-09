using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class AdminUpdateSoftware : Form
    {
        public AdminUpdateSoftware()
        {
            InitializeComponent();
        }
        string pid, description, licencetype, version, platform, product;
        int subscriptionperiod;
        double price, sellingprice, filesize;

        private void BtnCustomerForm_Click(object sender, EventArgs e)
        {

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
            Admin_Add_Products ad = new Admin_Add_Products();
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

        private void button7_Click(object sender, EventArgs e)
        {
            Admin_Add_Supplier sup = new Admin_Add_Supplier();
            sup.Show();
            this.Hide();
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            try
            {
                product = Convert.ToString(this.SPcmb.SelectedItem);
                SqlConnection conn = connection();
                conn.Open();
                string query = "DELETE FROM Product WHERE pName=@name";
                SqlCommand com = new SqlCommand(query, conn);
                com.Parameters.AddWithValue("@name", product);

                int ret = com.ExecuteNonQuery();
                MessageBox.Show("No of record Deleted: " + ret, "information");
                query = "DELETE FROM SoftwareProduct WHERE productId=@pid";
                com = new SqlCommand(query, conn);
                com.Parameters.AddWithValue("@pid", pid);
                ret = com.ExecuteNonQuery();
                MessageBox.Show("No of record Deleted: " + ret, "information");
                conn.Close();
                loadDataToTable();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error occured" + ex.ToString());
            }
        }

        

        private void AdminUpdateSoftware_Load(object sender, EventArgs e)
        {
            SqlConnection conn = connection();
            conn.Open();
            string query = "SELECT pName FROM Product WHERE pType=@type";
            SqlCommand com = new SqlCommand(query, conn);
            com.Parameters.AddWithValue("@type", "Software");
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                SPcmb.Items.Add(dr["pName"].ToString());
                SPcmb.ValueMember = dr["pName"].ToString();
                SPcmb.DisplayMember = dr["pName"].ToString();
            }
            SPcmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            SPcmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            SPcmb.AutoCompleteSource = AutoCompleteSource.ListItems;

            //Above code will populate Employee name combo box with employee names
            //and provides auto suggesting feature for user.
            conn.Close();
            loadDataToTable();
        }
        private void loadDataToTable()
        {
            SqlConnection conn = connection();
            conn.Open();

            //Define command
            string sql = "SELECT * FROM Product WHERE pType=@type";
            SqlCommand com = new SqlCommand(sql, conn);
            com.Parameters.AddWithValue("@type", "Software");

            //Acces data using data Adapter

            SqlDataAdapter dp = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            dp.Fill(ds);


            this.dataGridView1.DataSource = ds.Tables[0];
        }
        private SqlConnection connection()
        {
            //This function will be used to establish a connection with Microsoft SQL server
            string cs = @"Data Source=HPNotebook; Initial Catalog=DSE_FinalProject; Integrated Security=True";
            SqlConnection conn = new SqlConnection(cs);

            try
            {

                
                return conn;
            }
            catch (Exception ex)
            {
                
                return null;
            }
            return null;
        }

        private void SPcmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            SPcmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            SPcmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            SPcmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            string hardware_name = Convert.ToString(SPcmb.SelectedItem);
            pid = "";

            SqlConnection conn = connection();
            conn.Open();
            string query = "SELECT productId, pDescription, pPrice, pSellingPrice FROM Product WHERE pName=@pname";
            SqlCommand com = new SqlCommand(query, conn);
            com.Parameters.AddWithValue("@pname", hardware_name);
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();

            pid = Convert.ToString(dr.GetValue(0));
            this.IDlbl.Text = pid;
            this.descriptxt.Text = Convert.ToString(dr.GetValue(1));
            this.pricetxt.Text = Convert.ToString(dr.GetValue(2));
            this.sellingpricetxt.Text = Convert.ToString(dr.GetValue(3));

            dr.Close();

            query = "SELECT version, licenseType, platform, fileSize, subscriptionPeriod FROM SoftwareProduct WHERE productId=@pid";
            com = new SqlCommand(query, conn);
            com.Parameters.AddWithValue("@pid", pid);
            dr = com.ExecuteReader();
            dr.Read();

            this.versiontxt.Text = Convert.ToString(dr.GetValue(0));
            this.licencetypetxt.Text = Convert.ToString(dr.GetValue(1));
            this.platformtxt.Text = Convert.ToString(dr.GetValue(2));
            this.filesizetxt.Text = Convert.ToString(dr.GetValue(3));
            this.subscriptiontxt.Text = Convert.ToString(dr.GetValue(4));


            dr.Close();
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            if(validate() == true)
            {
                SqlConnection conn = connection();
                product = Convert.ToString(this.SPcmb.SelectedItem);
                description = Convert.ToString(this.descriptxt.Text);
                subscriptionperiod = Convert.ToInt32(this.subscriptiontxt.Text);
                filesize = Convert.ToDouble(this.filesizetxt.Text);
                licencetype = Convert.ToString(this.licencetypetxt.Text);
                version = Convert.ToString(this.versiontxt.Text);
                platform = Convert.ToString(this.platformtxt.Text);
                price = Convert.ToDouble(this.pricetxt.Text);
                sellingprice = Convert.ToDouble(this.sellingpricetxt.Text);

                conn.Open();
                string query = "UPDATE Product SET pDescription=@des, pPrice=@price, pSellingPrice=@selling WHERE pName=@name";
                SqlCommand com = new SqlCommand(query, conn);
                com.Parameters.AddWithValue("@des", description);
                com.Parameters.AddWithValue("@price", price);
                com.Parameters.AddWithValue("@selling", sellingprice);
                com.Parameters.AddWithValue("@name", product);

                int ret = com.ExecuteNonQuery();
                MessageBox.Show("No of record Inserted: " + ret, "information");

                query = "UPDATE SoftwareProduct SET version=@vrs, licenseType=@ltype, platform=@plt, fileSize=@filesize, subscriptionPeriod=@speriod WHERE productId=@pid";
                com = new SqlCommand(query, conn);
                com.Parameters.AddWithValue("@vrs", version);
                com.Parameters.AddWithValue("@ltype", licencetype);
                com.Parameters.AddWithValue("@plt", platform);
                com.Parameters.AddWithValue("@filesize", filesize);
                com.Parameters.AddWithValue("@speriod", subscriptionperiod);
                com.Parameters.AddWithValue("@pid", pid);

                ret = com.ExecuteNonQuery();
                MessageBox.Show("No of record Inserted: " + ret, "information");
            }
            else
            {
                MessageBox.Show("try again");
            }
            loadDataToTable();
            
        }

        private bool validate()
        {
            if (this.SPcmb.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Please Enter a valid product name");
                return false;
            }
            if (this.descriptxt.Text == "")
            {
                MessageBox.Show("Please Enter a description");
                return false;
            }
            if (this.subscriptiontxt.Text == "")
            {
                MessageBox.Show("Please Enter the subscription period");
                return false;
            }
            if (this.filesizetxt.Text == "")
            {
                MessageBox.Show("Please Enter the file size of setup");
                return false;
            }
            if (this.licencetypetxt.Text == "")
            {
                MessageBox.Show("Please Enter the licence type");
                return false;
            }
            if (this.versiontxt.Text == "")
            {
                MessageBox.Show("Please Enter version number");
                return false;
            }
            if (this.platformtxt.Text == "")
            {
                MessageBox.Show("Please Enter the platform");
                return false;
            }
            if (this.pricetxt.Text == "")
            {
                MessageBox.Show("Please Enter the price");
                return false;
            }
            if (this.sellingpricetxt.Text == "")
            {
                MessageBox.Show("Please Enter the selling price");
                return false;
            }
            return true;
        }
    }
}
