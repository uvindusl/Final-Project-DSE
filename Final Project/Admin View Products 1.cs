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
    public partial class Admin_View_Products_1 : Form
    {
        public Admin_View_Products_1()
        {
            InitializeComponent();
        }

        private void Admin_View_Products_1_Load(object sender, EventArgs e)
        {
            combospname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            combospname.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            combospname.AutoCompleteSource = AutoCompleteSource.ListItems;

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
                this.combospname.Items.Add(dr.GetValue(0));
            }

            con.Close();

            con.Open();
            //commands
            string sql2 = "SELECT * From Product";
            SqlCommand com2 = new SqlCommand(sql2, con);

            //access data using data adapter method
            SqlDataAdapter dap = new SqlDataAdapter(com2);
            DataSet ds = new DataSet();
            dap.Fill(ds);

            //blind data with controls
            this.dataGridView1.DataSource = ds.Tables[0];

            //disconnect
            con.Close();
        }

        private void combospid_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            combospname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            combospname.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            combospname.AutoCompleteSource = AutoCompleteSource.ListItems;

            //connection
            string cs = @"Data Source=HPNotebook; 
                        Initial Catalog=DSE_FinalProject; 
                        Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            //commands
            string sql = "SELECT * FROM Product WHERE pName=@name";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@name", this.combospname.Text);

            //access data using data reader method
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();
            this.txtpid.Text = dr.GetValue(0).ToString();
            this.txtdescription.Text = dr.GetValue(2).ToString();
            this.txttype.Text = dr.GetValue(3).ToString();
            this.txtprice.Text = dr.GetValue(4).ToString();
            this.txtaid.Text = dr.GetValue(5).ToString();
            this.txtsprice.Text = dr.GetValue(6).ToString();

            con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Admin_Dashboard ad = new Admin_Dashboard();
            ad.Show();
            this.Hide();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            Admin_Add_employees ad = new Admin_Add_employees();
            ad.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            AdminUpdateCustomer ad = new AdminUpdateCustomer();
            ad.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Admin_Add_Products ad = new Admin_Add_Products();
            ad.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Admin_view_Product_inventory admin = new Admin_view_Product_inventory();
            admin.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Admin_Purchase_Order admin = new Admin_Purchase_Order();
            admin.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Admin_View_Search_orders admin_View_Search_Orders = new Admin_View_Search_orders();
            admin_View_Search_Orders.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
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
    }
}
