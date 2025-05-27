using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Final_Project
{
    public partial class AdminUpdateCustomer : Form
    {
        string cusname, cusaddress, cusemail, cusId;
        int phoneno;

        private void AdminUpdateCustomer_Load(object sender, EventArgs e)
        {
            SqlConnection conn = connection();
            conn.Open();
            string query = "SELECT cusName FROM Customer";
            SqlCommand com = new SqlCommand(query, conn);

            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                CPcmb.Items.Add(dr["cusName"].ToString());
                CPcmb.ValueMember = dr["cusName"].ToString();
                CPcmb.DisplayMember = dr["cusName"].ToString();
            }
            CPcmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            CPcmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CPcmb.AutoCompleteSource = AutoCompleteSource.ListItems;

            //Above code will populate Employee name combo box with employee names
            //and provides auto suggesting feature for user.
            conn.Close();
            loadDataToTable();
        }

        private void CPcmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            CPcmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            CPcmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CPcmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            cusname = Convert.ToString(CPcmb.SelectedItem);
            cusId = "";

            SqlConnection conn = connection();
            conn.Open();
            string query = "SELECT cusId, cusTel, cusAddress, cusEmail FROM Customer WHERE cusName=@cusname";
            SqlCommand com = new SqlCommand(query, conn);
            com.Parameters.AddWithValue("@cusname", cusname);
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();

            cusId = Convert.ToString(dr.GetValue(0));
            this.CIDtxt.Text = cusId;
            this.phonenotxt.Text = Convert.ToString(dr.GetValue(1));
            this.emailtxt.Text = Convert.ToString(dr.GetValue(3));
            this.addresstxt.Text = Convert.ToString(dr.GetValue(2));

            dr.Close();
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            try
            {
                cusname = Convert.ToString(this.CPcmb.SelectedItem);

                SqlConnection conn = connection();
                conn.Open();
                string query = "DELETE FROM Customer WHERE cusName=@name";
                SqlCommand com = new SqlCommand(query, conn);
                com.Parameters.AddWithValue("@name", cusname);

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

        private void Updatebtn_Click(object sender, EventArgs e)
        {
            if (validate() == true)
            {
                SqlConnection conn = connection();
                cusId = Convert.ToString(this.CIDtxt.Text);
                cusname = Convert.ToString(this.nametxt.Text);
                cusaddress = Convert.ToString(this.addresstxt.Text);
                cusemail = Convert.ToString(this.emailtxt.Text);
                phoneno = Convert.ToInt32(this.phonenotxt.Text);


                conn.Open();
                string query = "UPDATE Customer SET cusName=@name, cusTel=@custel, cusEmail=@email, cusAddress=@addr WHERE cusId=@cid";
                SqlCommand com = new SqlCommand(query, conn);
                com.Parameters.AddWithValue("@name", cusname);
                com.Parameters.AddWithValue("@custel", phoneno);
                com.Parameters.AddWithValue("@email", cusemail);
                com.Parameters.AddWithValue("@addr", cusaddress);
                com.Parameters.AddWithValue("@cid", cusId);

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

        public AdminUpdateCustomer()
        {
            InitializeComponent();
        }

        private void CIDtxt_TextChanged(object sender, EventArgs e)
        {
            if (this.CIDtxt.Text != "")
            {
                SqlConnection conn = connection();
                conn.Open();
                cusId = this.CIDtxt.Text;
                string query = "SELECT cusName, cusTel, cusAddress, cusEmail FROM Customer WHERE cusId=@cid";
                SqlCommand com = new SqlCommand(query, conn);
                com.Parameters.AddWithValue("@cid", cusId);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    cusname = Convert.ToString(dr.GetValue(0));
                    this.CPcmb.Text = cusname;
                    this.nametxt.Text = cusname;
                    this.phonenotxt.Text = Convert.ToString(dr.GetValue(1));
                    this.emailtxt.Text = Convert.ToString(dr.GetValue(3));
                    this.addresstxt.Text = Convert.ToString(dr.GetValue(2));
                }
                else
                {
                    MessageBox.Show("Invalid ID");
                }


            }
            else
            {
                this.CPcmb.Text = "";
                this.nametxt.Text = "";
                this.phonenotxt.Text = "";
                this.emailtxt.Text = "";
                this.addresstxt.Text = "";

            }
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

        private void button3_Click(object sender, EventArgs e)
        {
            Admin_view_Product_inventory admin = new Admin_view_Product_inventory();
            admin.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin_Add_Products ad = new Admin_Add_Products();
            ad.Show();
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

        private void button9_Click(object sender, EventArgs e)
        {
            Admin_Dashboard ad = new Admin_Dashboard();
            ad.Show();
            this.Hide();
        }

        private void loadDataToTable()
        {
            SqlConnection conn = connection();
            conn.Open();

            //Define command
            string sql = "SELECT * FROM Customer";
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
            if (this.CPcmb.SelectedItem.ToString() == "")
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
            string em = this.emailtxt.Text;
            int atpos = em.IndexOf("@");
            int dotpos = em.LastIndexOf(".");
            if (atpos < 1 || dotpos < atpos + 2 || dotpos + 2 >= em.Length)
            {
                MessageBox.Show("Please enter a correct email ID");
                return false;
            }
            if (this.phonenotxt.Text == "")
            {
                MessageBox.Show("Please Enter the supplier phone number");
                return false;
            }
            if (this.phonenotxt.Text.Length == 10 || this.phonenotxt.Text.Length == 9)
            {
                
                
            }
            else
            {
                MessageBox.Show("Please Enter valid contact number");
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
