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
    public partial class AdminUpdateEmployeeLeaves : Form
    {
        string empname, eid;
        double remleave, rem;
        
        public AdminUpdateEmployeeLeaves()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AdminUpdateEmployeeLeaves_Load(object sender, EventArgs e)
        {
            SqlConnection conn = connection();
            conn.Open();
            string query = "SELECT empName FROM Employee";
            SqlCommand com = new SqlCommand(query, conn);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                EmpNamecmb.Items.Add(dr["empName"].ToString());
                EmpNamecmb.ValueMember = dr["empName"].ToString();
                EmpNamecmb.DisplayMember = dr["empName"].ToString();
            }
            EmpNamecmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            EmpNamecmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            EmpNamecmb.AutoCompleteSource = AutoCompleteSource.ListItems;

            //Above code will populate Employee name combo box with employee names
            //and provides auto suggesting feature for user.
            conn.Close();
            rid_auto_increment();
        }

        private SqlConnection connection()
        {
            //This function will be used to establish a connection with Microsoft SQL server
            string cs = @"Data Source=DESKTOP-MFN3B4M; Initial Catalog=DSE_FinalProject;Integrated Security=True";
            SqlConnection conn = new SqlConnection(cs);

            try
            {

                
                return conn;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            return null;
        }

        private void EmpNamecmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = Convert.ToString(EmpNamecmb.SelectedItem);
            SqlConnection conn = connection();
            conn.Open();
            string query = "SELECT empId FROM Employee WHERE empName=@name";
            SqlCommand com = new SqlCommand(query, conn);
            com.Parameters.AddWithValue("@name", name);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                eid = Convert.ToString(dr.GetValue(0));
                EIDtxt.Text = eid;
            }
            else
            {
                EIDtxt.Text = "";
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Admin_Dashboard ad = new Admin_Dashboard();
            ad.Show();
            this.Hide();
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

        private void MarkLeavebtn_Click(object sender, EventArgs e)
        {
            eid = this.EIDtxt.Text;
            string sMonth = DateTime.Now.ToString("MMMM");
            MessageBox.Show(sMonth);
            SqlConnection conn = connection();
            conn.Open();
            string query = "SELECT remaningLeaves FROM Leaves WHERE empId=@eid AND month=@month";
            SqlCommand com = new SqlCommand(query, conn);
            com.Parameters.AddWithValue("@eid", eid);
            com.Parameters.AddWithValue("@month", sMonth);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {

                remleave = Convert.ToDouble(dr.GetValue(0));
                while (dr.Read())
                {
                    remleave = Convert.ToDouble(dr.GetValue(0));
                }
            }
            MessageBox.Show(remleave.ToString());
            dr.Close();
            DateTime leavedate = this.Calender.Value;
            string ltype = Convert.ToString(this.LeaveTypecmb.Text);

            if(ltype.Equals("HalfDays"))
            {
                rem = remleave - 0.5;
            }else if(ltype == "Leaves")
            {
                rem = remleave - 1;
            }else if(ltype == "ShortLeaves")
            {
                
            }



            query = "INSERT INTO Leaves (leaveId, date, leaveLimites, adminId, empId, leaveType, month, remaningLeaves) VALUES(@lid, @date, @limits, @admin, @eid, @ltype, @month, @remleave)";
            com = new SqlCommand(query, conn);
            com.Parameters.AddWithValue("@lid", leaveidlbl.Text);
            com.Parameters.AddWithValue("@date", leavedate);
            com.Parameters.AddWithValue("@limits", 30);
            com.Parameters.AddWithValue("@admin", "A01");
            com.Parameters.AddWithValue("@eid", eid);
            com.Parameters.AddWithValue("@ltype", ltype);
            com.Parameters.AddWithValue("@month", sMonth);
            com.Parameters.AddWithValue("@remleave", rem);

            int ret = com.ExecuteNonQuery();
            MessageBox.Show("No of record Inserted: " + ret, "information");






            rid_auto_increment();

        }

        private void rid_auto_increment()
        {
            //product ID auto increment code
            SqlConnection con = connection();

            try
            {


                using (con)
                {
                    con.Open();

                    string sql1 = "SELECT MAX(leaveId) FROM Leaves";
                    using (SqlCommand cmd = new SqlCommand(sql1, con))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            string maxItemId = dr[0]?.ToString(); // Use the null-conditional operator

                            if (!string.IsNullOrEmpty(maxItemId) && maxItemId.StartsWith("L"))
                            {
                                // Extract the numeric part after the "PO" prefix
                                string numericPart = maxItemId.Substring(2);
                                if (int.TryParse(numericPart, out int maxID))
                                {
                                    // Increment the numeric part
                                    int newID = maxID + 1;
                                    // Format the new ID back to string with 'PO' prefix and leading zeros
                                    this.leaveidlbl.Text = "L" + newID.ToString("D2"); // D2 ensures at least two digits
                                }
                                else
                                {
                                    // Handle the case where the numeric part is not valid
                                    this.leaveidlbl.Text = "L01";
                                }
                            }
                            else
                            {
                                // Handle the case where there are no records in the table or invalid format
                                this.leaveidlbl.Text = "L01";
                            }
                        }
                        else
                        {
                            // Handle the case where there are no records in the table
                            this.leaveidlbl.Text = "L01";
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
    }
}
