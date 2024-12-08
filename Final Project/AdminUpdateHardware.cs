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
using System.Xml.Linq;

namespace Final_Project
{
    public partial class AdminUpdateHardware : Form
    {
        public AdminUpdateHardware()
        {
            InitializeComponent();
        }


        string productname, serialno, description, pid;
        double price, sellingprice;
        int warrenty;
        private void AdminUpdateHardware_Load(object sender, EventArgs e)
        {
            {
                SqlConnection conn = connection();
                conn.Open();
                string query = "SELECT pName FROM Product";
                SqlCommand com = new SqlCommand(query, conn);
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
                loadDataToTable();
            }

        }

        private void warrentytxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this code will stop field from accepting letters
            if (!char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void pricetxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this code will stop field from accepting letters
            if (!char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void sellingpricetxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this code will stop field from accepting letters
            if (!char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                productname = Convert.ToString(this.HPcmb.SelectedItem);
                SqlConnection conn = connection();
                conn.Open();
                string query = "DELETE FROM Product WHERE pName=@name";
                SqlCommand com = new SqlCommand(query, conn);
                com.Parameters.AddWithValue("@name", productname);

                int ret = com.ExecuteNonQuery();
                MessageBox.Show("No of record Deleted: " + ret, "information");
                query = "DELETE FROM HardwareProduct WHERE productId=@pid";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void loadDataToTable()
        {
            SqlConnection conn = connection();
            conn.Open();

            //Define command
            string sql = "SELECT * FROM Product WHERE pType=@type";
            SqlCommand com = new SqlCommand(sql, conn);
            com.Parameters.AddWithValue("@type", "Hardware");

            //Acces data using data Adapter

            SqlDataAdapter dp = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            dp.Fill(ds);


            this.dataGridView1.DataSource = ds.Tables[0];
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
            string query = "SELECT productId, pDescription, pPrice, pSellingPrice FROM Product WHERE pName=@pname";
            SqlCommand com = new SqlCommand(query, conn);
            com.Parameters.AddWithValue("@pname", hardware_name);
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();

            pid = Convert.ToString(dr.GetValue(0));
            this.IDlbl.Text = pid;
            this.desctxt.Text = Convert.ToString(dr.GetValue(1));
            this.pricetxt.Text = Convert.ToString(dr.GetValue(2));
            this.sellingpricetxt.Text = Convert.ToString(dr.GetValue(3));

            dr.Close();

            query = "SELECT serialNumber, WarrantyPeriod FROM HardwareProduct WHERE productId=@pid";
            com = new SqlCommand(query, conn);
            com.Parameters.AddWithValue("@pid", pid);
            dr = com.ExecuteReader();
            if (dr.Read())
            {

                this.serialnotxt.Text = Convert.ToString(dr.GetValue(0));
                this.warrentytxt.Text = Convert.ToString(dr.GetValue(1));

            }



            dr.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            validate();
            SqlConnection conn = connection();
            string name = Convert.ToString(this.HPcmb.SelectedItem);
            serialno = this.serialnotxt.Text;
            description = this.desctxt.Text;
            warrenty = Convert.ToInt32(this.warrentytxt.Text);
            price = Convert.ToDouble(this.pricetxt.Text);
            sellingprice = Convert.ToDouble(this.sellingpricetxt.Text);

            conn.Open();
            string query = "UPDATE Product SET pDescription=@des, pPrice=@price, pSellingPrice=@selling WHERE pName=@name";
            SqlCommand com = new SqlCommand(query, conn);
            com.Parameters.AddWithValue("@des", description);
            com.Parameters.AddWithValue("@price", price);
            com.Parameters.AddWithValue("@selling", sellingprice);
            com.Parameters.AddWithValue("@name", name);

            int ret = com.ExecuteNonQuery();
            MessageBox.Show("No of record Inserted: " + ret, "information");

            query = "UPDATE HardwareProduct SET serialNumber=@serial, WarrantyPeriod=@wp WHERE productId=@pid";
            com = new SqlCommand(query, conn);
            com.Parameters.AddWithValue("@serial", serialno);
            com.Parameters.AddWithValue("@wp", warrenty);
            com.Parameters.AddWithValue("@pid", pid);

            ret = com.ExecuteNonQuery();
            MessageBox.Show("No of record Inserted: " + ret, "information");
            loadDataToTable();
        }

        private void validate()
        {
            if (this.HPcmb.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Please Enter a valid product name");
            }
            if (this.serialnotxt.Text == "")
            {
                MessageBox.Show("Please Enter a serial number");
            }
            if (this.desctxt.Text == "")
            {
                MessageBox.Show("Please Enter description for product");
            }
            if (this.warrentytxt.Text == "")
            {
                MessageBox.Show("Please Enter warrenty period");
            }
            if (this.pricetxt.Text == "")
            {
                MessageBox.Show("Please Enter price");
            }
            if (this.sellingpricetxt.Text == "")
            {
                MessageBox.Show("Please Enter selling price");
            }
        }
    }
}
