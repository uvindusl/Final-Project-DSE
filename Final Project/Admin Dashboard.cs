using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class Admin_Dashboard : Form
    {
        public Admin_Dashboard()
        {
            InitializeComponent();
        }

        private void Admin_Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Admin_Dashboard ad = new Admin_Dashboard();
            ad.Show();
            this.Hide();
        }

        private void btnEmployeeForm_Click(object sender, EventArgs e)
        {
            Admin_Add_employees adu = new Admin_Add_employees();
            adu.Show();
            this.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            AdminUpdateCustomer adc = new AdminUpdateCustomer();
            adc.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Admin_Add_Products adp = new Admin_Add_Products();
            adp.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Admin_view_Product_inventory advi = new Admin_view_Product_inventory();
            advi.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Admin_View_Purchase_Order advpo = new Admin_View_Purchase_Order();
            advpo.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Admin_View_Search_orders avso = new Admin_View_Search_orders();
            avso.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AdminMakePaysheet admp = new AdminMakePaysheet();
            admp.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Admin_Add_Supplier ads = new Admin_Add_Supplier();
            ads.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_Purchase_Order admin_Purchase_Order = new Admin_Purchase_Order();
            admin_Purchase_Order.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin_Return_Purchase_Order admin_Return_Purchase_Order = new Admin_Return_Purchase_Order();
            admin_Return_Purchase_Order.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin_View_Search_orders admin_View_Search_ = new Admin_View_Search_orders();
            admin_View_Search_.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Admin_View_Search_return_Ordes admin_View_Return_ = new Admin_View_Search_return_Ordes();
            admin_View_Return_.Show();
            this.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            AdminUpdateEmployeeLeaves adminUpdateEmployeeLeaves = new AdminUpdateEmployeeLeaves();
            adminUpdateEmployeeLeaves.Show();
            this.Hide();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Admin_view_service admin_View_Service = new Admin_view_service();
            admin_View_Service.Show();
            this.Hide();
        }
    }
}
