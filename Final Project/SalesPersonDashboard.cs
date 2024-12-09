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
    public partial class SalesPersonDashboard : Form
    {
        string username;
        public SalesPersonDashboard()
        {
            InitializeComponent();
        }
        public SalesPersonDashboard(string uname)
        {
            this.username = uname;
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            

        }

        private void SalesPersonDashboard_Load(object sender, EventArgs e)
        {
            

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sales_Person_POS sales_Person_POS = new Sales_Person_POS();
            sales_Person_POS.Show();
            this.Close();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            SalesPersonDashboard salesPersonDashboard = new SalesPersonDashboard();
            salesPersonDashboard.Show();
            this.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Sales_Person_POS sales_Person_POS = new Sales_Person_POS();
            sales_Person_POS.Show();
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Sales_person_Add_customer sales_Person_Add_Customer = new Sales_person_Add_customer();
            sales_Person_Add_Customer.Show();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Sales_Person_Quotation sales_Person_ = new Sales_Person_Quotation();
            sales_Person_.Show();
            this.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            SP_View_Software_Pd sP_View_Software_Pd = new SP_View_Software_Pd();
            sP_View_Software_Pd.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sales_person_Add_customer sales_Person_Add_Customer = new Sales_person_Add_customer();
            sales_Person_Add_Customer.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sales_Person_Quotation sales_Person_ = new Sales_Person_Quotation();
            sales_Person_.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SP_View_Software_Pd sales_Person_ = new SP_View_Software_Pd();
            sales_Person_.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
