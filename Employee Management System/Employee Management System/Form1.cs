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
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection("Server=LAPTOP-2OQDL4UR; database=EmpDetails; Integrated Security=True;");

        public Form1()
        {
            InitializeComponent();
            LoadData();
            Gridview.CellClick += new DataGridViewCellEventHandler(Gridview_CellClick);
        }
        private void LoadData()
        {
            string query = "SELECT EmployeeID, FirstName, LastName, DateOfBirth, Designation, Salary FROM MasterEmployee";
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection))
            {
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                Gridview.DataSource = dataTable;
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //String connectionString = "Server = NMLDT0300\\SQLSERVER; database = EmpDetails; User Id = sa; Password = next@123;";
            //using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    String query = "INSERT INTO MasterEmployee(EmployeeID,FirstName,LastName,DateOfBirth,Designation,Salary)Values(@EmployeeID,@FirstName,@LastName,@DateOfBirth,@Designation,@Salary)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", textBox1.Text);
                        command.Parameters.AddWithValue("@FirstName", textBox2.Text);
                        command.Parameters.AddWithValue("@LastName", textBox3.Text);
                        command.Parameters.AddWithValue("@DateOfBirth", dateTimePicker1.Value);
                        command.Parameters.AddWithValue("@Designation", textBox4.Text);
                        command.Parameters.AddWithValue("@Salary", decimal.Parse(textBox5.Text));

                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Data saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //string connectionString = "Server=NMLDT0300\\SQLSERVER; database=EmpDetails; User Id=sa; Password=next@123;";
            string employeeID = textBox6.Text;

            if (string.IsNullOrWhiteSpace(employeeID))
            {
                MessageBox.Show("Please enter an EmployeeID to search.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT EmployeeID, FirstName, LastName, DateOfBirth, Designation, Salary " +
                                   "FROM MasterEmployee WHERE EmployeeID = @EmployeeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employeeID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBox1.Text = reader["EmployeeID"].ToString();
                                textBox2.Text = reader["FirstName"].ToString();
                                textBox3.Text = reader["LastName"].ToString();
                                dateTimePicker1.Text = Convert.ToDateTime(reader["DateOfBirth"]).ToShortDateString();
                                textBox4.Text = reader["Designation"].ToString();
                                textBox5.Text = Convert.ToDecimal(reader["Salary"]).ToString("");
                            }
                            else
                            {
                                MessageBox.Show("No employee found with the given EmployeeID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }




        private void button3_Click(object sender, EventArgs e)
        {
            //string connectionString = "Server=NMLDT0300\\SQLSERVER; database=EmpDetails; User Id=sa; Password=next@123;";
            string employeeID = textBox6.Text;

            if (string.IsNullOrWhiteSpace(employeeID))
            {
                MessageBox.Show("Please enter an EmployeeID to delete.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM MasterEmployee WHERE EmployeeID = @EmployeeID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", employeeID);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Employee details deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No employee found with the given EmployeeID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        LoadData(); 
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Today;


        }

        private void button2_Click(object sender, EventArgs e)
        {

            //string connectionString = "Server=NMLDT0300\\SQLSERVER; database=EmpDetails; User Id=sa; Password=next@123;";


            string employeeID = textBox6.Text;

            if (string.IsNullOrWhiteSpace(employeeID))
            {
                MessageBox.Show("Please enter an EmployeeID to edit.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string query = "UPDATE MasterEmployee " +
                           "SET FirstName = @FirstName, " +
                           "    LastName = @LastName, " +
                           "    DateOfBirth = @DateOfBirth, " +
                           "    Designation = @Designation, " +
                           "    Salary = @Salary " +
                           "WHERE EmployeeID = @EmployeeID";

            //using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employeeID);
                        command.Parameters.AddWithValue("@FirstName", textBox2.Text);
                        command.Parameters.AddWithValue("@LastName", textBox3.Text);
                        command.Parameters.AddWithValue("@DateOfBirth", dateTimePicker1.Value);
                        command.Parameters.AddWithValue("@Designation", textBox4.Text);
                        command.Parameters.AddWithValue("@Salary", decimal.Parse(textBox5.Text));


                        int rowsAffected = command.ExecuteNonQuery();


                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Employee details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No employee found with the given EmployeeID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    LoadData(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        private void Gridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = Gridview.Rows[e.RowIndex];

                textBox1.Text = row.Cells["EmployeeID"].Value.ToString();
                textBox2.Text = row.Cells["FirstName"].Value.ToString();
                textBox3.Text = row.Cells["LastName"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(row.Cells["DateOfBirth"].Value);
                textBox4.Text = row.Cells["Designation"].Value.ToString();
                textBox5.Text = Convert.ToDecimal(row.Cells["Salary"].Value).ToString();
                textBox6.Text = row.Cells["EmployeeID"].Value.ToString(); 
            }
        }
    


    private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}




