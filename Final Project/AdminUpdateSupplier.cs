using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class AdminUpdateSupplier : Form
    {
        string supname, supaddress, supemail, supId;
        int phoneno;
        public AdminUpdateSupplier()
        {
            InitializeComponent();
        }

        private void SPcmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            SPcmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            SPcmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            SPcmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            supname = Convert.ToString(SPcmb.SelectedItem);
            supId = "";

            SqlConnection conn = connection();
            conn.Open();
            string query = "SELECT supId, supTel, supEmail, supAddress FROM Supplier WHERE supName=@supname";
            SqlCommand com = new SqlCommand(query, conn);
            com.Parameters.AddWithValue("@supname", supname);
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();

            supId = Convert.ToString(dr.GetValue(0));
            this.SIDtxt.Text = supId;
            this.phonenotxt.Text = Convert.ToString(dr.GetValue(1));
            this.emailtxt.Text = Convert.ToString(dr.GetValue(2));
            this.addresstxt.Text = Convert.ToString(dr.GetValue(3));

            dr.Close();
        }

        private void Updatebtn_Click(object sender, EventArgs e)
        {
            if (validate() == true)
            {
                SqlConnection conn = connection();
                supId = Convert.ToString(this.SIDtxt.Text);
                supname = Convert.ToString(this.nametxt.Text);
                supaddress = Convert.ToString(this.addresstxt.Text);
                supemail = Convert.ToString(this.emailtxt.Text);
                phoneno = Convert.ToInt32(this.phonenotxt.Text);


                conn.Open();
                string query = "UPDATE Supplier SET supName=@name, supTel=@suptel, supEmail=@email, supAddress=@addr WHERE supId=@sid";
                SqlCommand com = new SqlCommand(query, conn);
                com.Parameters.AddWithValue("@name", supname);
                com.Parameters.AddWithValue("@suptel", phoneno);
                com.Parameters.AddWithValue("@email", supemail);
                com.Parameters.AddWithValue("@addr", supaddress);
                com.Parameters.AddWithValue("@sid", supId);

                int ret = com.ExecuteNonQuery();
                MessageBox.Show("No of record Inserted: " + ret, "information");
                conn.Close();
            }
            else
            {
                MessageBox.Show("try again");
            }
            loadDataToTable();
        }

        private void AdminUpdateSupplier_Load(object sender, EventArgs e)
        {

            SqlConnection conn = connection();
            conn.Open();
            string query = "SELECT supName FROM Supplier";
            SqlCommand com = new SqlCommand(query, conn);
            
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                SPcmb.Items.Add(dr["supName"].ToString());
                SPcmb.ValueMember = dr["supName"].ToString();
                SPcmb.DisplayMember = dr["supName"].ToString();
            }
            SPcmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            SPcmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            SPcmb.AutoCompleteSource = AutoCompleteSource.ListItems;

            //Above code will populate Employee name combo box with employee names
            //and provides auto suggesting feature for user.
            conn.Close();
            loadDataToTable();
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            try
            {
                supname = Convert.ToString(this.SPcmb.SelectedItem);
                
                SqlConnection conn = connection();
                conn.Open();
                string query = "DELETE FROM Supplier WHERE supName=@name";
                SqlCommand com = new SqlCommand(query, conn);
                com.Parameters.AddWithValue("@name", supname);

                int ret = com.ExecuteNonQuery();
                MessageBox.Show("No of record Deleted: " + ret, "information");
                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error occured" + ex.ToString());
            }
            loadDataToTable();
        }

        private void SIDtxt_TextChanged(object sender, EventArgs e)
        {
            if (this.SIDtxt.Text != "")
            {
                SqlConnection conn = connection();
                conn.Open();
                supId = this.SIDtxt.Text;
                string query = "SELECT supName, supTel, supEmail, supAddress FROM Supplier WHERE supId=@sid";
                SqlCommand com = new SqlCommand(query, conn);
                com.Parameters.AddWithValue("@sid", supId);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    supname = Convert.ToString(dr.GetValue(0));
                    this.SPcmb.Text = supname;
                    this.nametxt.Text = supname;
                    this.phonenotxt.Text = Convert.ToString(dr.GetValue(1));
                    this.emailtxt.Text = Convert.ToString(dr.GetValue(2));
                    this.addresstxt.Text = Convert.ToString(dr.GetValue(3));
                }
                else
                {
                    MessageBox.Show("Invalid ID");
                }

                
            }
            else
            {
                this.nametxt.Text = "";
                this.phonenotxt.Text = "";
                this.emailtxt.Text = "";
                this.addresstxt.Text = "";

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

        private void loadDataToTable()
        {
            SqlConnection conn = connection();
            conn.Open();

            //Define command
            string sql = "SELECT * FROM Supplier";
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
        private bool validate()
        {
            if (this.SPcmb.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Please Enter a valid supplier name");
                return false;
            }
            if (this.addresstxt.Text == "")
            {
                MessageBox.Show("Please Enter an address");
                return false;
            }
            if (this.emailtxt.Text == "")
            {
                MessageBox.Show("Please Enter the supplier email");
                return false;
            }
            if (this.phonenotxt.Text == "")
            {
                MessageBox.Show("Please Enter the supplier phone number");
                return false;
            }
            if (this.nametxt.Text == "")
            {
                MessageBox.Show("Dont Leave this field empty");
                return false;
            }
            
            return true;
        }
    }
}
