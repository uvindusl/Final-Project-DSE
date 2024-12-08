using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Final_Project
{
    public partial class AdminUpdateEmployee : Form
    {

        string employeefullname, email, housenumber, street, city, employeetype, username, password;
        
        private void BasicSalarytxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this code will stop field from accepting letters
            if (!char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void Agetxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this code will stop field from accepting letters
            if (!char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            try
            {
                employeefullname = Convert.ToString(this.EmpNamecmb.SelectedItem);
                SqlConnection conn = connection();
                conn.Open();
                string query = "DELETE FROM Employee WHERE empName=@name";
                SqlCommand com = new SqlCommand(query, conn);
                com.Parameters.AddWithValue("@name", employeefullname);

                int ret = com.ExecuteNonQuery();
                MessageBox.Show("No of record Deleted: " + ret, "information");
                conn.Close();
            }
            catch (Exception ex) 
            {

                MessageBox.Show("Error occured" + ex.ToString());
            }
            loadDataToTable();
        }

        private void EmContactNotxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this code will stop field from accepting letters
            if (!char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void EmpNametxt_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void AdminUpdateEmployee_Load(object sender, EventArgs e)
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

            loadDataToTable();
        }

        private void EmpNamecmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmpNamecmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            EmpNamecmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            EmpNamecmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            EmpNamecmb.DisplayMember = "Select Employee";
            //Above code will auto suggest employee name considering given letters of name.
            string name = EmpNamecmb.SelectedItem.ToString();
            SqlConnection conn = connection();
            conn.Open();
            string query = "SELECT empId, empUserName, empTel, empAge, empEmail, empType, houseNo, street, city, empEmargancyCont, empPassword, empSalary FROM Employee WHERE empName=@name";
            SqlCommand com = new SqlCommand(query, conn);
            com.Parameters.AddWithValue("@name", name);
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();

            this.EID.Text = dr.GetValue(0).ToString();
            this.Agetxt.Text = dr.GetValue(3).ToString();
            this.ContactNotxt.Text = dr.GetValue(2).ToString();
            this.Emailtxt.Text = dr.GetValue(4).ToString();
            this.EmContactNotxt.Text=dr.GetValue(9).ToString();
            this.HouseNotxt.Text =(dr.GetValue(6).ToString());
            this.StreetNotxt.Text = dr.GetValue(7).ToString();
            this.Citytxt.Text = dr.GetValue(8).ToString();
            
            this.BasicSalarytxt.Text = dr.GetValue(11).ToString();
            this.Usernametxt.Text = dr.GetValue(1).ToString();
            this.Passwordtxt.Text = dr.GetValue(10).ToString();

            conn.Close();
            
        }

        private void ContactNotxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this code will stop field from accepting letters
            if (!char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        int age, contactnumber, emegcontactno, employeeid;
        double basicsalary;
        public AdminUpdateEmployee()
        {
            InitializeComponent();
        }

        private void Updatebtn_Click(object sender, EventArgs e)
        {
            validate();
            SqlConnection conn = connection();
            conn.Open();

            employeefullname = Convert.ToString(this.EmpNamecmb.SelectedItem);
            age = Convert.ToInt32(this.Agetxt.Text);
            contactnumber = Convert.ToInt32(this.ContactNotxt.Text);
            email = this.Emailtxt.Text;
            emegcontactno = Convert.ToInt32(this.EmContactNotxt.Text);
            housenumber = this.HouseNotxt.Text;
            street = this.StreetNotxt.Text;
            city = this.Citytxt.Text;
            employeetype = Convert.ToString(this.EmpTypecmb.SelectedItem);
            basicsalary = Convert.ToDouble(this.BasicSalarytxt.Text);
            username = this.Usernametxt.Text;
            password = this.Passwordtxt.Text;

            string query = "UPDATE Employee SET empUserName=@uname, empTel=@tel, empAge=@age, empEmail=@email, empType=@type, houseNo=@hno, street=@str, city=@city, empEmargancyCont=@ecnt, empPassword=@empp, empSalary=@sal WHERE empName=@name";
            SqlCommand com = new SqlCommand(query, conn);
            com.Parameters.AddWithValue("@uname", username);
            com.Parameters.AddWithValue("@tel", contactnumber);
            com.Parameters.AddWithValue("@age", age);
            com.Parameters.AddWithValue("@email", email);
            com.Parameters.AddWithValue("@type", employeetype);
            com.Parameters.AddWithValue("@hno", housenumber);
            com.Parameters.AddWithValue("@str", street);
            com.Parameters.AddWithValue("@city", city);
            com.Parameters.AddWithValue("@ecnt", emegcontactno);
            com.Parameters.AddWithValue("@empp", password);
            com.Parameters.AddWithValue("@sal", basicsalary);
            com.Parameters.AddWithValue("@name", employeefullname);

            int ret = com.ExecuteNonQuery();
            MessageBox.Show("No of record Inserted: " + ret, "information");
            loadDataToTable();

        }

        private void validate()
        {
            //This function is used to validate all input fields in AdminUpdateEmployee Form.
            //Empty fields will be notified. 
            //Number's only fields wont accept any letter input from keyboard
            //Email addresses will be validated
            
            if(this.EmpNamecmb.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Please Enter a valid name");
            }
            if(this.Agetxt.Text == "")
            {
                MessageBox.Show("Please Enter valid age");
            }
            if(this.ContactNotxt.Text == "")
            {
                MessageBox.Show("Please Enter Contact Number");
            }
            if (this.ContactNotxt.Text.Length == 10 || this.ContactNotxt.Text.Length == 9) 
            {


            }
            else
            {
                MessageBox.Show("Please Enter valid contact number");
            }
            if(this.Emailtxt.Text == "")
            {
                MessageBox.Show("Please Enter an email");
            }
            string em = this.Emailtxt.Text;
            int atpos = em.IndexOf("@");
            int dotpos = em.LastIndexOf(".");
            if (atpos < 1 || dotpos < atpos + 2 || dotpos + 2 >= em.Length)
            {
                MessageBox.Show("Please enter a correct email ID");
            }
            if (this.EmContactNotxt.Text == "")
            {
                MessageBox.Show("Please Enter an emergency contact no");
            }
            if (this.EmContactNotxt.Text.Length == 10 || this.EmContactNotxt.Text.Length == 9)
            {


            }
            else
            {
                MessageBox.Show("Please Enter valid emergency contact number");
            }
            if (this.HouseNotxt.Text == "")
            {
                MessageBox.Show("Please Enter valid House Number");
            }
            if(this.StreetNotxt.Text == "")
            {
                MessageBox.Show("Please Enter a street name");
            }
            if(this.Citytxt.Text == "")
            {
                MessageBox.Show("Please Enter a city name");
            }
            if(this.BasicSalarytxt.Text == "")
            {
                MessageBox.Show("Please Enter valid basic salary");
            }
            if(this.Usernametxt.Text == "")
            {
                MessageBox.Show("Please Enter valid username");
            }
            if(this.Passwordtxt.Text == "")
            {
                MessageBox.Show("Please Enter valid  password");
            }
        }
        private void loadDataToTable()
        {
            SqlConnection conn = connection();
            conn.Open();

            //Define command
            string sql = "SELECT * FROM Employee";
            SqlCommand com = new SqlCommand(sql, conn);

            //Acces data using data Adapter

            SqlDataAdapter dp = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            dp.Fill(ds);


            this.dataGridView1.DataSource = ds.Tables[0];
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
    }
}
