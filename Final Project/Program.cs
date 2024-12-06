using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Admin_Add_Products());
            //Application.Run(new Sales_person_Add_customer());
            // Application.Run(new Admin_Add_Supplier());
            // Application.Run(new Admin_Create_Account());
            //Application.Run(new Technician_Add_Customer());
             //Application.Run(new Admin_Add_employees());




        }
    }
}
