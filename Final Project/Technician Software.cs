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
    public partial class Technician_Software : Form
    {
        public Technician_Software()
        {
            InitializeComponent();
        }

        //data insert order table ekata insert weddi technicain id eka parameters walin yanna hadanna oni

        private void customercombo()
        {
            //getting admin ids to combo box

            combocname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            combocname.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            combocname.AutoCompleteSource = AutoCompleteSource.ListItems;

            //connection
            string cs = @"Data Source=HPNotebook; 
                        Initial Catalog=DSE_FinalProject; 
                        Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            //commands
            string sql = "SELECT cusName From Customer";
            SqlCommand com = new SqlCommand(sql, con);

            //Access Data
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                this.combocname.Items.Add(dr.GetValue(0));
            }

            con.Close();
        }

        private void productcombo()
        {
            //getting product ids to combobox

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
            string sql = "SELECT pName FROM Product WHERE pType='Software'";
            SqlCommand com = new SqlCommand(sql, con);

            //Access Data
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                this.comboproduct.Items.Add(dr.GetValue(0));
            }

            con.Close();
        }

        private void auto_increment_serviceid()
        {
            try
            {
                // Connection string
                string cs = @"Data Source=HPNotebook; 
                      Initial Catalog=DSE_FinalProject; 
                      Integrated Security=True";

                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();

                    string sql1 = "SELECT MAX(serviceId) FROM [Service]";
                    using (SqlCommand cmd = new SqlCommand(sql1, con))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            string maxItemId = dr[0]?.ToString(); // Use the null-conditional operator

                            if (!string.IsNullOrEmpty(maxItemId) && maxItemId.StartsWith("S"))
                            {
                                // Extract the numeric part after the "O" prefix
                                string numericPart = maxItemId.Substring(1);
                                if (int.TryParse(numericPart, out int maxID))
                                {
                                    // Increment the numeric part
                                    int newID = maxID + 1;
                                    // Format the new ID back to string with 'O' prefix and leading zeros
                                    this.txtsid.Text = "S" + newID.ToString("D2"); // D2 ensures at least two digits
                                }
                                else
                                {
                                    // Handle the case where the numeric part is not valid
                                    this.txtsid.Text = "S01";
                                }
                            }
                            else
                            {
                                // Handle the case where there are no records in the table or invalid format
                                this.txtsid.Text = "S01";
                            }
                        }
                        else
                        {
                            // Handle the case where there are no records in the table
                            this.txtsid.Text = "S01";
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

        private void Technician_Software_Load(object sender, EventArgs e)
        {
            customercombo();
            productcombo();
            auto_increment_serviceid();
        }

        private void comboproduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            //connection
            string cs = @"Data Source=HPNotebook; 
                        Initial Catalog=DSE_FinalProject; 
                        Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            //commands
            string sql = "SELECT pSellingPrice FROM Product WHERE pName=@name";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@name", this.comboproduct.Text);

            //access data using data reader method
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();
            this.txtprice.Text = dr.GetValue(0).ToString();

            con.Close();
        }

        private void data_load_to_grid()
        {
            //connection
            string cs = @"Data Source=HPNotebook; 
            Initial Catalog=DSE_FinalProject; 
            Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            //Load Data to GridView
            string sql = "SELECT * FROM ServiceConsists WHERE serviceId=@sid";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@sid", this.txtsid.Text);

            //Data Adaptor
            SqlDataAdapter dap = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            dap.Fill(ds);
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void insert_data_into_QuatationConsists()
        {
            //connection
            string cs = @"Data Source=HPNotebook; 
            Initial Catalog=DSE_FinalProject; 
            Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            //commands
            string sql1 = "SELECT productId FROM Product WHERE pName=@name";
            SqlCommand com1 = new SqlCommand(sql1, con);
            com1.Parameters.AddWithValue("@name", this.comboproduct.Text);

            //access data using data reader method
            SqlDataReader dr = com1.ExecuteReader();
            dr.Read();
            string pid = dr.GetValue(0).ToString();

            con.Close();

            con.Open();

            //commands
            string sql2 = "SELECT softwareProductId FROM SoftwareProduct WHERE productId=@productId";
            SqlCommand com2 = new SqlCommand(sql2, con);
            com2.Parameters.AddWithValue("@productId", pid);

            //access data using data reader method
            SqlDataReader dr2 = com2.ExecuteReader();
            dr2.Read();
            string hid = dr2.GetValue(0).ToString();

            con.Close();

            con.Open();

            //Command
            string sql = "INSERT INTO ServiceConsists (serviceId,softwareProductId) VALUES(@sid,@sod)";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@sid", this.txtsid.Text);
            com.Parameters.AddWithValue("@sod", hid);

            //Execute
            int ret = com.ExecuteNonQuery();


            //connecion close
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            insert_data_into_QuatationConsists();
            data_load_to_grid();

        }
    }
}
