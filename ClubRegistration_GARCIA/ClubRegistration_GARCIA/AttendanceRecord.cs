using ClubRegistration_GARCIA.Database;
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

namespace ClubRegistration_GARCIA
{
    public partial class AttendanceRecord : Form
    {
        private static DatabaseConnector connector = new DatabaseConnector();
        public string connectionString = connector.GetConnection();

        public AttendanceRecord()
        {
            InitializeComponent();
        }

        public void GetAllRecords(string student_id)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand("TimeInRecord", connection)) 
                {
                   command.CommandType = CommandType.StoredProcedure;
                   command.Parameters.AddWithValue("@id",student_id); 

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        
                        MessageBox.Show(reader["student_id"].ToString());

                        if (!string.IsNullOrEmpty(reader["student_id"].ToString()))
                        {
                            TimeIn(DateTime.Now.ToString(), student_id);
                            studentName.Text = $"{reader["first_name"].ToString()} {reader["last_name"].ToString()}"; 

                            textBox1.Clear();


                        }

                    } 
                    reader.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            GetAllRecords(textBox1.Text);
        }
        public void TimeIn(string date, string student_id)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand("TimeInStudentNow", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@timein", date);
                    command.Parameters.AddWithValue("@student_id", student_id);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Sumakses!");               }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
          

        }
    }
}
