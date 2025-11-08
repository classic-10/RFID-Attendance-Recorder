using System;
using ClubRegistration_GARCIA.Database;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ClubRegistration_GARCIA
{
    public partial class FrmClubRegistration : Form
    {
        private static DatabaseConnector connector = new DatabaseConnector();
        public string connectionString = connector.GetConnection();

        public FrmClubRegistration()
        {
            InitializeComponent();
        }

        public void SaveRecords()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand("SaveRecords", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@first_name", tbFirstName.Text);
                    command.Parameters.AddWithValue("@middle_name", tbMiddleName.Text);
                    command.Parameters.AddWithValue("@last_name", tbLastName.Text);
                    command.Parameters.AddWithValue("@program", cbPrograms.Text);
                    command.Parameters.AddWithValue("@student_id", tbStudentID.Text);
                    command.Parameters.AddWithValue("@gender", cbGender.Text);
                    command.Parameters.AddWithValue("@age", tbAge.Text);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Sumakses!");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void LoadUserRecords()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand("GetAllRecords", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    connection.Open();
                    adapter.Fill(dataTable);
                    connection.Close();

                    dgvMembers.Rows.Clear();

                    foreach (DataRow row in dataTable.Rows)
                    {
                        dgvMembers.Rows.Add(
                            row["student_id"],
                            row["program"],
                            row["first_name"],
                            row["middle_name"],
                            row["last_name"],
                            row["gender"],
                            row["age"]
                        );
                    }
                }
            }
            catch ( Exception e )
            {
                MessageBox.Show($"Error loading data: {e.Message}");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            SaveRecords();
        }

        private void FrmClubRegistration_Load(object sender, EventArgs e)
        {
            LoadUserRecords();
        }
    }
}
