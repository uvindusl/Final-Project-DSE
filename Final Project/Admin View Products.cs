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
    public partial class Admin_View_Software : Form
    {
        public Admin_View_Software()
        {
            InitializeComponent();
        }

        private void Admin_View_Software_Load(object sender, EventArgs e)
        {
            combospid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            combospid.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            combospid.AutoCompleteSource = AutoCompleteSource.ListItems;

            //connection
            string cs = @"Data Source=HPNotebook; 
                        Initial Catalog=DSE_FinalProject; 
                        Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            //commands
            string sql = "SELECT softwareProductId From SoftwareProduct";
            SqlCommand com = new SqlCommand(sql, con);

            //Access Data
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                this.combospid.Items.Add(dr.GetValue(0));
            }

            con.Close();

            con.Open();
            //commands
            string sql2 = "SELECT * From SoftwareProduct";
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

        private void combospid_SelectedIndexChanged(object sender, EventArgs e)
        {
            combospid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            combospid.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            combospid.AutoCompleteSource = AutoCompleteSource.ListItems;

            //connection
            string cs = @"Data Source=HPNotebook; 
                        Initial Catalog=DSE_FinalProject; 
                        Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            //commands
            string sql = "SELECT * FROM SoftwareProduct WHERE softwareProductId=@id";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@id", this.combospid.Text);

            //access data using data reader method
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();
            this.txtversion.Text = dr.GetValue(1).ToString();
            this.txtlicensetype.Text = dr.GetValue(2).ToString();
            this.txtplatform.Text = dr.GetValue(3).ToString();
            this.txtfilesize.Text = dr.GetValue(4).ToString();
            this.txtsperiod.Text = dr.GetValue(5).ToString();

            con.Close();
        }
    }
}
