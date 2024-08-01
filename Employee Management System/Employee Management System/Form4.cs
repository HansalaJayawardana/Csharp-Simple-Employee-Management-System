using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Management_System
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Emp_Click(object sender, EventArgs e)
        {
            Form1 Emp = new Form1();
            Emp.Show();
        }

        private void Dep_Click(object sender, EventArgs e)
        {
            Form2 Dep = new Form2();
            Dep.Show();
        }

        private void Assign_Click(object sender, EventArgs e)
        {
            Form3 Assign = new Form3();
            Assign.Show();
        }
    }
}
