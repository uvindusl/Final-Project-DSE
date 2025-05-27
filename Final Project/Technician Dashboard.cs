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
    public partial class Technician_Dashboard : Form
    {
        public Technician_Dashboard()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Technician_Dashboard technician_Dashboard = new Technician_Dashboard();
            technician_Dashboard.Show();
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Technician_Software technician_Software = new Technician_Software();
            technician_Software.Show();
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Technician_Add_Customer add_Customer = new Technician_Add_Customer();
            add_Customer.Show();
            this.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Technician_View_Hardware_Product _Hardware_Product = new Technician_View_Hardware_Product();
            _Hardware_Product.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Technician_View_search_Job_note job_Note = new Technician_View_search_Job_note();
            job_Note.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Technician_Software technician_Software = new Technician_Software();
            technician_Software.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Technician_Add_Customer add_Customer = new Technician_Add_Customer();
            add_Customer.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Technician_Software technician_Software = new Technician_Software();
            technician_Software.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Technician__Jobnotes technician__ = new Technician__Jobnotes();
            technician__.Show();
            this.Close();
        }
    }
}
