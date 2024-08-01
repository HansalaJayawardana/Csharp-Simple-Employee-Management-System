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
    public partial class Form2 : Form
    {
        SqlConnection connection = new SqlConnection("Server=LAPTOP-2OQDL4UR; database=EmpDetails; Integrated Security=True;");
        public Form2()
        {
            InitializeComponent();
            LoadData();
            Gridview1.CellClick += new DataGridViewCellEventHandler(Gridview1_CellClick);
        }
        private void LoadData()
        {
            string query = "SELECT DepartmentID,DepartmentName FROM MasterDepartment";
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection))
            {
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                Gridview1.DataSource = dataTable;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //string connectionString = "Server=NMLDT0300\\SQLSERVER; database=EmpDetails; User Id=sa; Password=next@123;";
            string departmentID = textBox3.Text;

            if (string.IsNullOrWhiteSpace(departmentID))
            {
                MessageBox.Show("Please enter a DepartmentID to search.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //using (SqlConnection connection = new SqlConnection(connectionString))
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
                                textBox1.Text = reader["DepartmentID"].ToString();
                                textBox2.Text = reader["DepartmentName"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("No department found with the given DepartmentID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                
                                textBox1.Text = string.Empty;
                                textBox2.Text = string.Empty;
                            }
                        }
                    }
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //String connectionString = "Server = NMLDT0300\\SQLSERVER; database = EmpDetails; User Id = sa; Password = next@123;";
            //using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    String query = "INSERT INTO MasterDepartment(DepartmentID,DepartmentName)Values(@DepartmentID,@DepartmentName)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DepartmentID", textBox1.Text);
                        command.Parameters.AddWithValue("@DepartmentName", textBox2.Text);


                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Data saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving data: {ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //string connectionString = "Server=NMLDT0300\\SQLSERVER; database=EmpDetails; User Id=sa; Password=next@123;";
            string departmentID = textBox1.Text;

            if (string.IsNullOrWhiteSpace(departmentID))
            {
                MessageBox.Show("Please enter a DepartmentID to edit.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter a new DepartmentName.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "UPDATE MasterDepartment " +
                           "SET DepartmentName = @DepartmentName " +
                           "WHERE DepartmentID = @DepartmentID";

           // using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        
                        command.Parameters.Add(new SqlParameter("@DepartmentID", SqlDbType.VarChar) { Value = departmentID });
                        command.Parameters.Add(new SqlParameter("@DepartmentName", SqlDbType.VarChar) { Value = textBox2.Text });

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Department details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No department found with the given DepartmentID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //string connectionString = "Server=NMLDT0300\\SQLSERVER; database=EmpDetails; User Id=sa; Password=next@123;";
            string departmentID = textBox1.Text;

            if (string.IsNullOrWhiteSpace(departmentID))
            {
                MessageBox.Show("Please enter an DepartmentID to delete.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           // using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM MasterDepartment WHERE DepartmentID = @DepartmentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DepartmentID", departmentID);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Department details deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No department found with the given DepartmentID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void Gridview1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = Gridview1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["DepartmentID"].Value.ToString();
                textBox2.Text = row.Cells["DepartmentName"].Value.ToString();
                
                
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
