using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace project
{
    public partial class Form1 : Form
    {
        static string connectionString = @"Data Source=DESKTOP-Q874OA6\SQLEXPRESS;Initial Catalog=BD_Project;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command;

        bool isUpdate = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = GetDataForDataGridView();

            for (int i = 0; i < GetCmbItemName(1).Rows.Count; i++)
            {
                from_cmb.Items.Add(GetCmbItemName(1).Rows[i][0].ToString());
            }

            for (int i = 0; i < GetCmbItemName(2).Rows.Count; i++)
            {
                to_cmb.Items.Add(GetCmbItemName(2).Rows[i][0].ToString());
            }
        }

        private DataTable GetDataForDataGridView()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            DataTable data = new DataTable();

            command = new SqlCommand("ReadData", connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);

            return data;
        }

        private DataTable GetCmbItemName(int i)
        {
            DataTable data = new DataTable();

            SqlCommand command = new SqlCommand("GetName", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("i", i);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);

            return data;
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                if (isUpdate)
                {
                    UpdateSharedNote();
                }
                else
                {
                    SaveSharedNote();
                }
            }
            else
            {
                MessageBox.Show("Please enter value in all fields", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SaveSharedNote()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand command = new SqlCommand("CreateData", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@fromusername", from_cmb.SelectedItem.ToString());
                command.Parameters.AddWithValue("@tousername", to_cmb.SelectedItem.ToString());
                command.Parameters.AddWithValue("@subject", subject_txt.Text);
                command.Parameters.AddWithValue("@content", content_rtx.Text);

                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Record saved successfully!", "Success");
                    ClearAllData();
                }
                else
                {
                    MessageBox.Show("Please try again", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateSharedNote()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand command = new SqlCommand("UpdateData", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@id", dataGridView.SelectedRows[0].Cells[0].Value);
                command.Parameters.AddWithValue("@fromusername", from_cmb.SelectedItem.ToString());
                command.Parameters.AddWithValue("@tousername", to_cmb.SelectedItem.ToString());
                command.Parameters.AddWithValue("@subject", subject_txt.Text);
                command.Parameters.AddWithValue("@content", content_rtx.Text);

                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Record updated successfully!", "Success");
                    ClearAllData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            save_btn.Text = "Save";
            isUpdate = false;
        }

        private bool CheckFields()
        {
            if (from_cmb.Text == "" || to_cmb.Text == "" || 
                subject_txt.Text == "" || content_rtx.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void dataGridView_Click(object sender, EventArgs e)
        {
            from_cmb.Text = dataGridView.SelectedRows[0].Cells[1].Value.ToString();
            to_cmb.Text = dataGridView.SelectedRows[0].Cells[2].Value.ToString();
            subject_txt.Text = dataGridView.SelectedRows[0].Cells[3].Value.ToString();
            content_rtx.Text = dataGridView.SelectedRows[0].Cells[4].Value.ToString();

            save_btn.Text = "Update";
            isUpdate = true;
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand command = new SqlCommand("DeleteData", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@id", dataGridView.SelectedRows[0].Cells[0].Value);
                int rows = command.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show("Record deleted successfully!", "Success");
                    ClearAllData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void find_btn_Click(object sender, EventArgs e)
        {
            if (from_cmb.Text == "")
            {
                MessageBox.Show("Please enter valid value", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                DataTable data = new DataTable();

                SqlCommand command = new SqlCommand("FindNotes", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@fromusername", from_cmb.Text);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);

                dataGridView.DataSource = data;
            }
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            ClearAllData();
        }

        private void ClearAllData()
        {
            from_cmb.SelectedIndex = -1;
            to_cmb.SelectedIndex = -1;
            subject_txt.Text = "";
            content_rtx.Text = "";

            save_btn.Text = "Save";
            isUpdate = false;

            dataGridView.DataSource = GetDataForDataGridView();
        }
    }
}
