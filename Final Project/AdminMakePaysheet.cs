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
    public partial class AdminMakePaysheet : Form
    {
        string empId, ename;
        double remainingleavedays;
        double basicsalary, salary, netsalary, bonus;

        private void rid_auto_increment()
        {
            //product ID auto increment code
            SqlConnection con = connection();

            try
            {
                

                using (con)
                {
                    con.Open();

                    string sql1 = "SELECT MAX(paySheetId) FROM Paysheet";
                    using (SqlCommand cmd = new SqlCommand(sql1, con))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            string maxItemId = dr[0]?.ToString(); // Use the null-conditional operator

                            if (!string.IsNullOrEmpty(maxItemId) && maxItemId.StartsWith("PS"))
                            {
                                // Extract the numeric part after the "PO" prefix
                                string numericPart = maxItemId.Substring(2);
                                if (int.TryParse(numericPart, out int maxID))
                                {
                                    // Increment the numeric part
                                    int newID = maxID + 1;
                                    // Format the new ID back to string with 'PO' prefix and leading zeros
                                    this.paysheetidLBL.Text = "PS" + newID.ToString("D2"); // D2 ensures at least two digits
                                }
                                else
                                {
                                    // Handle the case where the numeric part is not valid
                                    this.paysheetidLBL.Text = "PS01";
                                }
                            }
                            else
                            {
                                // Handle the case where there are no records in the table or invalid format
                                this.paysheetidLBL.Text = "PS01";
                            }
                        }
                        else
                        {
                            // Handle the case where there are no records in the table
                            this.paysheetidLBL.Text = "PS01";
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
        private void EIDtxt_TextChanged(object sender, EventArgs e)
        {
            int halfdays = 0, shortleaves = 0, leaves = 0;
            string sMonth = DateTime.Now.ToString("MMMM");
            if (this.EIDtxt.Text != "")
            {
                SqlConnection conn = connection();
                conn.Open();
                empId = this.EIDtxt.Text;
                string query = "SELECT empName, empSalary FROM Employee WHERE empId=@eid";
                SqlCommand com = new SqlCommand(query, conn);
                com.Parameters.AddWithValue("@eid", empId);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    ename = Convert.ToString(dr.GetValue(0));
                    this.ENcmb.Text = ename;
                    basicsalary = Convert.ToDouble(dr.GetValue(1));
                    this.Basicsalarytxt.Text = basicsalary.ToString();
                    
                    



                }
                else
                {
                    MessageBox.Show("Invalid ID");
                }
                dr.Close();
                query = "SELECT leaveType, remaningLeaves FROM Leaves WHERE empId=@eid AND month=@month";
                com = new SqlCommand(query, conn);
                com.Parameters.AddWithValue("@eid", empId);
                com.Parameters.AddWithValue("@month", sMonth);
                MessageBox.Show(sMonth);
                dr = com.ExecuteReader();
                if (dr.Read())
                {
                    while (dr.Read())
                    {
                        string ltype = Convert.ToString(dr.GetValue(0));
                        MessageBox.Show(ltype);
                        if(ltype == "HalfDay")
                        {
                            halfdays = 1;
                            halfdays = halfdays + 1;
                        }else if(ltype == "ShortLeave")
                        {
                            shortleaves = 0;
                            shortleaves = shortleaves + 1;
                        }else if(ltype == "Leave")
                        {
                            leaves = 0;
                            leaves = leaves + 1;
                        }
                        remainingleavedays = Convert.ToDouble(dr.GetValue(1));
                    }
                    
                }
                dr.Close();
                MessageBox.Show(remainingleavedays.ToString());
                this.NumhalfdaysLBL.Text = halfdays.ToString();
                this.NumLeavesLBL.Text = leaves.ToString();
                this.NumShortleavesLBL.Text = shortleaves.ToString();
            }
            else
            {
                this.ENcmb.Text = "";
                this.Basicsalarytxt.Text = "";

            }
        }

        private void ENcmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ENcmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            ENcmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            ENcmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            ename = Convert.ToString(ENcmb.SelectedItem);
            empId = "";

            SqlConnection conn = connection();
            conn.Open();
            string query = "SELECT empId, empSalary FROM Employee WHERE empName=@ename";
            SqlCommand com = new SqlCommand(query, conn);
            com.Parameters.AddWithValue("@ename", ename);
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();

            empId = Convert.ToString(dr.GetValue(0));
            this.EIDtxt.Text = empId;
            basicsalary = Convert.ToDouble(dr.GetValue(1));
            this.Basicsalarytxt.Text = basicsalary.ToString();

            dr.Close();
        }

        private void Proceedbtn_Click(object sender, EventArgs e)
        {
            string psid = this.paysheetidLBL.Text;
            int noleaves = Convert.ToInt32(this.NumLeavesLBL.Text);
            int noshortleaves = Convert.ToInt32(this.NumShortleavesLBL.Text);
            int nohalfdays = Convert.ToInt32(this.NumhalfdaysLBL.Text);
            int nopays = 0;
            string adminid = "A01";
            if(this.Bonustxt.Text != "")
            {
                bonus = Convert.ToDouble(this.Bonustxt.Text);
            }
            else
            {
                bonus = 0.00;
            }
            


            netsalary = calculateSalary(basicsalary, remainingleavedays, noleaves, nohalfdays);
            SqlConnection conn = connection();
            conn.Open();
            string query = "INSERT INTO Paysheet (paySheetId, numOfLeaves, basicSalary, numOfShortLeaves, numOfHalfDays, numOfNoPays, adminId, empId, bonus, netSalary)" + "VALUES(@psid, @noleaves, @basicsal, @noshortleaves, @nohalfdays, @nopays, @adminid, @empid, @bonus, @netsalary)";
            SqlCommand com = new SqlCommand(query, conn);
            com.Parameters.AddWithValue("@psid", psid);
            com.Parameters.AddWithValue("@noleaves", noleaves);
            com.Parameters.AddWithValue("@basicsal", basicsalary);
            com.Parameters.AddWithValue("@noshortleaves", noshortleaves);
            com.Parameters.AddWithValue("@nohalfdays", nohalfdays);
            com.Parameters.AddWithValue("@nopays", nopays);
            com.Parameters.AddWithValue("@adminid", adminid);
            com.Parameters.AddWithValue("@empid", empId);
            com.Parameters.AddWithValue("@bonus", bonus);
            com.Parameters.AddWithValue("@netsalary", netsalary);

            
            int ret = com.ExecuteNonQuery();
            MessageBox.Show("No of record Deleted: " + ret, "information");
            conn.Close();
            
            rid_auto_increment();
            //PaysheetView view = new PaysheetView();
           // view.Show();

        }

        private void btnEmployeeForm_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Admin_Dashboard ad = new Admin_Dashboard();
            ad.Show();
            this.Hide();
        }

        private void btnEmployeeForm_Click_1(object sender, EventArgs e)
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

        public AdminMakePaysheet()
        {
            InitializeComponent();
        }

        private void AdminMakePaysheet_Load(object sender, EventArgs e)
        {
            rid_auto_increment();
            SqlConnection conn = connection();
            conn.Open();
            string query = "SELECT empName FROM Employee WHERE empType=@tech OR empType=@sales";
            SqlCommand com = new SqlCommand(query, conn);
            com.Parameters.AddWithValue("@tech", "Technician");
            com.Parameters.AddWithValue("@sales", "SalesPerson");
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                ENcmb.Items.Add(dr["empName"].ToString());
                ENcmb.ValueMember = dr["empName"].ToString();
                ENcmb.DisplayMember = dr["empName"].ToString();
            }
            ENcmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            ENcmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            ENcmb.AutoCompleteSource = AutoCompleteSource.ListItems;

            //Above code will populate Employee name combo box with employee names
            //and provides auto suggesting feature for user.
            conn.Close();
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
        private double calculateSalary(double basesalary, double reml, int leaves, int halfdays)
        {
            MessageBox.Show(basesalary.ToString());
            double decrement = 0;
            if(reml < 0.00)
            {
                double dailysal = basesalary / 30;
                if(leaves > 0)
                {
                    decrement = leaves * dailysal;
                }
                if(halfdays > 0)
                {
                    decrement = halfdays * (dailysal/2);
                }

                return basesalary - decrement;
                
            }
            return basesalary;
        }
    }
}
