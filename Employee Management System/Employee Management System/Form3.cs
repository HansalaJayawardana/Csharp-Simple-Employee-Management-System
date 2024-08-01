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

namespace Employee_Management_System
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            Employee_();
            Department_();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }



        private void SearchButton_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=LAPTOP-2OQDL4UR; database=EmpDetails; User Id=LAPTOP-2OQDL4UR Password=;";
            string employeeID = Empcombo.Text;

            if (string.IsNullOrWhiteSpace(employeeID))
            {
                MessageBox.Show("Please enter an EmployeeID to search.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT EmployeeID, FirstName FROM MasterEmployee WHERE EmployeeID = @EmployeeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employeeID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBox1.Text = reader["EmployeeID"].ToString();
                                textBox2.Text = reader["FirstName"].ToString(); 
                            }
                            else
                            {
                                MessageBox.Show("No employee found with the given EmployeeID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                textBox1.Text = string.Empty;
                                textBox2.Text = string.Empty;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void SearchButton1_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=LAPTOP-2OQDL4UR; database=EmpDetails; User Id=LAPTOP-2OQDL4UR Password=;";
            string departmentID = Depcombo.Text;

            if (string.IsNullOrWhiteSpace(departmentID))
            {
                MessageBox.Show("Please enter a DepartmentID to search.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT DepartmentID, DepartmentName " +
                                   "FROM MasterDepartment WHERE DepartmentID = @DepartmentID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DepartmentID", departmentID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBox3.Text = reader["DepartmentID"].ToString();
                                textBox4.Text = reader["DepartmentName"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("No department found with the given DepartmentID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                textBox3.Text = string.Empty;
                                textBox4.Text = string.Empty;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string connectionString = "Server=LAPTOP-2OQDL4UR; database=EmpDetails; User Id=LAPTOP-2OQDL4UR Password=;";
            string EmployeeID = Empcombo.Text;

            if (string.IsNullOrWhiteSpace(EmployeeID))
            {
                MessageBox.Show("Please enter an Employee ID to search.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT EmployeeID FROM MasterEmployee WHERE EmployeeID = @EmployeeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", EmployeeID);


                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            Empcombo.Text = string.Empty;
            Depcombo.Text = string.Empty;

        }

        private void Assign_Click_3(object sender, EventArgs e)
        {
            try
            {
                
                SqlConnection connection = new SqlConnection("Server=LAPTOP-2OQDL4UR; database=EmpDetails; Integrated Security=True;");
                connection.Open();
                SqlCommand cmd = new SqlCommand("Insert into EmployeeDepartment values (@EmployeeID, @DepartmentID)", connection);

                cmd.Parameters.AddWithValue("@EmployeeID", textBox1.Text);
                cmd.Parameters.AddWithValue("@DepartmentID", textBox3.Text);
                cmd.ExecuteNonQuery();

                String EmployeeID = textBox1.Text;
                String DepartmentID = textBox3.Text;

                MessageBox.Show(EmployeeID + "Assigned to" + DepartmentID + "Success");

                connection.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void Remove_Click_1(object sender, EventArgs e)
        {
            try
            {

                string connectionString = "Server=LAPTOP-2OQDL4UR; database=EmpDetails; Integrated Security=True;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM EmployeeDepartment WHERE EmployeeID = @EmployeeID AND DepartmentID = @DepartmentID";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        
                        cmd.Parameters.AddWithValue("@EmployeeID", textBox1.Text);
                        cmd.Parameters.AddWithValue("@DepartmentID", textBox3.Text);

                       
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
    }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Empcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        public void Employee_()
        {
            string connectionString = "Server=LAPTOP-2OQDL4UR; database=EmpDetails; Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string query = "Select EmployeeID From MasterEmployee";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    Empcombo.Items.Clear();
                    while (reader.Read())
                    {
                        Empcombo.Items.Add(reader["EmployeeID"].ToString());
                    }
                    reader.Close();

                }
            }
        }

        private void Depcombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void Department_()
        {
            string connectionString = "Server=LAPTOP-2OQDL4UR; database=EmpDetails; Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string query = "Select DepartmentID From MasterDepartment";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    Depcombo.Items.Clear();
                    while (reader.Read())
                    {
                        Depcombo.Items.Add(reader["DepartmentID"].ToString());
                    }
                    reader.Close();

                }
            }
        }
    }
}
