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
    public partial class Admin_Purchase_Order : Form
    {
        public Admin_Purchase_Order()
        {
            InitializeComponent();
        }

        public void adminidcombox()
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

        public void productcombo()
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

        public void suppliercombo()
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

        private void Admin_Purchase_Order_Load(object sender, EventArgs e)
        {
            adminidcombox();
            productcombo();
            suppliercombo();
        }
    }
}
