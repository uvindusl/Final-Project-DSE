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
    public partial class Sales_Person_Quotation : Form
    {
        public Sales_Person_Quotation()
        {
            InitializeComponent();
        }

        //data insert order table ekata insert weddi salespersonge id eka parameters walin yanna hadanna oni

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
            string sql = "SELECT pName FROM Product";
            SqlCommand com = new SqlCommand(sql, con);

            //Access Data
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                this.comboproduct.Items.Add(dr.GetValue(0));
            }

            con.Close();
        }

        private void auto_increment_qutationid()
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

                    string sql1 = "SELECT MAX(qId) FROM [Quotation]";
                    using (SqlCommand cmd = new SqlCommand(sql1, con))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            string maxItemId = dr[0]?.ToString(); // Use the null-conditional operator

                            if (!string.IsNullOrEmpty(maxItemId) && maxItemId.StartsWith("Q"))
                            {
                                // Extract the numeric part after the "O" prefix
                                string numericPart = maxItemId.Substring(1);
                                if (int.TryParse(numericPart, out int maxID))
                                {
                                    // Increment the numeric part
                                    int newID = maxID + 1;
                                    // Format the new ID back to string with 'O' prefix and leading zeros
                                    this.txtqid.Text = "Q" + newID.ToString("D2"); // D2 ensures at least two digits
                                }
                                else
                                {
                                    // Handle the case where the numeric part is not valid
                                    this.txtqid.Text = "Q01";
                                }
                            }
                            else
                            {
                                // Handle the case where there are no records in the table or invalid format
                                this.txtqid.Text = "Q01";
                            }
                        }
                        else
                        {
                            // Handle the case where there are no records in the table
                            this.txtqid.Text = "O01";
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


        private void Sales_Person_Quotation_Load(object sender, EventArgs e)
        {
            customercombo();
            productcombo();
            auto_increment_qutationid();
        }
    }
}
