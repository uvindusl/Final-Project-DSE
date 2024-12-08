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
    public partial class AdminSetConfigurableAlerts : Form
    {
        string pid, hpid;
        public AdminSetConfigurableAlerts()
        {
            InitializeComponent();
        }

        private void AdminSetConfigurableAlerts_Load(object sender, EventArgs e)
        {
            SqlConnection conn = connection();
            conn.Open();
            string query = "SELECT pName FROM Product WHERE pType=@type";
            SqlCommand com = new SqlCommand(query, conn);
            com.Parameters.AddWithValue("@type", "Hardware");
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                HPcmb.Items.Add(dr["pName"].ToString());
                HPcmb.ValueMember = dr["pName"].ToString();
                HPcmb.DisplayMember = dr["pName"].ToString();
            }
            HPcmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            HPcmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            HPcmb.AutoCompleteSource = AutoCompleteSource.ListItems;

            //Above code will populate Employee name combo box with employee names
            //and provides auto suggesting feature for user.
            conn.Close();
        }
        private SqlConnection connection()
        {
            //This function will be used to establish a connection with Microsoft SQL server
            string cs = @"Data Source=DESKTOP-MFN3B4M; Initial Catalog=DSE_FinalProject;Integrated Security=True";
            SqlConnection conn = new SqlConnection(cs);

            try
            {

                MessageBox.Show("Connection success");
                return conn;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            return null;
        }

        private void setlimitbtn_Click(object sender, EventArgs e)
        {
            int limit = Convert.ToInt32(this.minleveltxt.Text);

            SqlConnection conn = connection();
            conn.Open();
            string query = "UPDATE InventoryProducts SET alertLevel=@al WHERE hardawareProductId=@pid";
            SqlCommand com = new SqlCommand(query, conn);
            com.Parameters.AddWithValue("@al", limit);
            com.Parameters.AddWithValue("@pid", this.pidLBL.Text);
            int ret = com.ExecuteNonQuery();
            conn.Close();
        }

        private void gensetlimitbtn_Click(object sender, EventArgs e)
        {
            int limit = Convert.ToInt32(this.genminleveltxt.Text);
            SqlConnection conn = connection();
            conn.Open();
            string query = "UPDATE InventoryProducts SET alertLevel=@al";
            SqlCommand com = new SqlCommand(query, conn);
            com.Parameters.AddWithValue("@al", limit);
            
            int ret = com.ExecuteNonQuery();
            conn.Close();

        }

        private void HPcmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            HPcmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            HPcmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            HPcmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            string hardware_name = Convert.ToString(HPcmb.SelectedItem);
            pid = "";

            SqlConnection conn = connection();
            conn.Open();
            string query = "SELECT productId FROM Product WHERE pName=@pname";
            SqlCommand com = new SqlCommand(query, conn);
            com.Parameters.AddWithValue("@pname", hardware_name);
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();

            pid = Convert.ToString(dr.GetValue(0));
            
            

            dr.Close();
            query = "SELECT hardwareProductId FROM HardwareProduct WHERE productId=@pid";
            com = new SqlCommand(query, conn);
            com.Parameters.AddWithValue("@pid", pid);
            dr = com.ExecuteReader();
            dr.Read();
            hpid = Convert.ToString(dr.GetValue(0));
            dr.Close();

            this.pidLBL.Text = hpid;
            
        }
    }
}
