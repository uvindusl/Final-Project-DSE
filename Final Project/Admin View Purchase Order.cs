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
    public partial class Admin_View_Purchase_Order : Form
    {
        public Admin_View_Purchase_Order()
        {
            InitializeComponent();
        }

        private void Admin_View_Purchase_Order_Load(object sender, EventArgs e)
        {
            combopoid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            combopoid.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            combopoid.AutoCompleteSource = AutoCompleteSource.ListItems;

            //connection
            string cs = @"Data Source=HPNotebook; 
                        Initial Catalog=DSE_FinalProject; 
                        Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            //commands
            string sql = "SELECT purschaseOrderId From PurchaseOrder";
            SqlCommand com = new SqlCommand(sql, con);

            //Access Data
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                this.combopoid.Items.Add(dr.GetValue(0));
            }

            con.Close();

            con.Open();
            //commands
            string sql2 = "SELECT * From PurchaseOrder";
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

        private void comboinvoiceid_SelectedIndexChanged(object sender, EventArgs e)
        {
            combopoid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            combopoid.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            combopoid.AutoCompleteSource = AutoCompleteSource.ListItems;

            //connection
            string cs = @"Data Source=HPNotebook; 
                        Initial Catalog=DSE_FinalProject; 
                        Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            //commands
            string sql = "SELECT * FROM PurchaseOrder WHERE purschaseOrderId=@id";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@id",this.combopoid.Text);

            //access data using data reader method
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();
            this.txtitem.Text = dr.GetValue(1).ToString();
            this.txtquantity.Text = dr.GetValue(2).ToString();
            this.txtdateandtime.Text = dr.GetValue(3).ToString();
            this.txttotalamount.Text = dr.GetValue(4).ToString();
            this.txtdiscount.Text = dr.GetValue(5).ToString();
            this.txtadminid.Text = dr.GetValue(6).ToString();
            this.txtsupplierid.Text = dr.GetValue(7).ToString();

            con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Admin_Dashboard ad = new Admin_Dashboard();
            ad.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            AdminUpdateCustomer aduc = new AdminUpdateCustomer();
            aduc.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            Admin_Add_Products adap = new Admin_Add_Products();
            adap.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Admin_Add_Products adap = new Admin_Add_Products();
            adap.Show();
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
