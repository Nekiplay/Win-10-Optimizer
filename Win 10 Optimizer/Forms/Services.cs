using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win_10_Optimizer.Forms
{
    public partial class Services : Form
    {
        public Services()
        {
            InitializeComponent();
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Services_Load(object sender, EventArgs e)
        {
            GetComponent("Win32_Processor", "Name");
            GetComponent("Win32_Processor", "CurrentVoltage");
        }
        public static void GetComponent(string hwclass, string syntax)
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM " + hwclass);
            foreach (ManagementObject mo in mos.Get())
            {
                Console.WriteLine(mo[syntax].ToString());
            }
        }
    }
}
