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

namespace HospitalManagmentSystem
{
    public partial class Records : Form
    {
        public Records()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        SqlConnection pat_conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\umidu\\OneDrive\\Documents\\PatientData.mdf;Integrated Security=True;Connect Timeout=30");
        private void button1_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.Show();
           
        }

        private void quit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void search_Click(object sender, EventArgs e)
        {
            fill(patient_id.Text);
        }

        private void fill(string id)
        {
            try
            {
                pat_conn.Open();
                string query = "select count(*) from Table where Id='" + id + "'";
                SqlCommand cmd = new SqlCommand(query, pat_conn);
                int v = (int)cmd.ExecuteScalar();
                if (v == 0)
                {
                    MessageBox.Show("Invalid Patient ID");
                }
                else
                {
                    string query1 = "select record from Table where patientId = '" + id + "'";
                    SqlDataAdapter da = new SqlDataAdapter(query1, pat_conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    pat_conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void cancel_Click(object sender, EventArgs e)
        {
            patient_id.Text = "";
            record.Text = "";
        }

        private void update_Click(object sender, EventArgs e)
        {
            pat_conn.Open();
            SqlCommand cmd = new SqlCommand("update Table values(@record) where patientId = '" + patient_id.Text + "'", pat_conn);
            cmd.Parameters.AddWithValue("@record", record.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated.");
            pat_conn.Close();
            patient_id.Text = "";
            record.Text = "";
        }

        private void delete_Click(object sender, EventArgs e)
        {
            pat_conn.Open();
            SqlCommand cmd = new SqlCommand("delete Table values(@record) where patientId = '" + patient_id.Text + "'", pat_conn);
            cmd.Parameters.AddWithValue("@meds", record.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Medications Deleted.");
            pat_conn.Close();
            patient_id.Text = "";
            record.Text = "";
        }
    }
}
