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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace HospitalManagmentSystem
{
    public partial class Doctorap : Form
    {
        public Doctorap()
        {
            InitializeComponent();
        }

        SqlConnection doc_conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\umidu\\OneDrive\\Documents\\DoctorData.mdf;Integrated Security=True;Connect Timeout=30");
        SqlConnection pat_conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\umidu\\OneDrive\\Documents\\PatientData.mdf;Integrated Security=True;Connect Timeout=30");
        SqlConnection app_conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\umidu\\OneDrive\\Documents\\appointments.mdf;Integrated Security=True;Connect Timeout=30");
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Doctorap_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            doctor_id.Text = "";
            patient_id.Text = "";
            time.Text = "";

        }

        private void add_Click(object sender, EventArgs e)
        {
            app_conn.Open();
            doc_conn.Open();
            pat_conn.Open();

            string query = "select count(*) from Table where Id='" + doctor_id.Text + "'";
            SqlCommand cmd = new SqlCommand(query, doc_conn);
            int v = (int)cmd.ExecuteScalar();
            doc_conn.Close();
         
            string query2 = "select count(*) from Table where Id='" + patient_id.Text + "'";
            SqlCommand cmd2 = new SqlCommand(query2, pat_conn);
            int W = (int)cmd2.ExecuteScalar();
            pat_conn.Close();

            if (v == 0)
            {
                MessageBox.Show("Invalid Doctor ID");
            }
            else if (W == 0)
            {
                MessageBox.Show("Invalid Patient ID");
            }
            else
            {
                SqlCommand cmd3 = new SqlCommand("insert into Table values(@doc_id,@pat_id,@time)", app_conn);
                cmd3.Parameters.AddWithValue("@doc_id", doctor_id.Text);
                cmd3.Parameters.AddWithValue("@pat_id", patient_id.Text);
                cmd3.Parameters.AddWithValue("@time", time.Text);
                cmd3.ExecuteNonQuery();
                MessageBox.Show("New Appointment Added.");
                app_conn.Close();
                doctor_id.Text = "";
                patient_id.Text = "";
                time.Text = "";
            }
        }

        private void fill(string id)
        {
            try
            {
                doc_conn.Open();
                string query = "select count(*) from Table where Id='" + doctor_id.Text + "'";
                SqlCommand cmd = new SqlCommand(query, doc_conn);
                int v = (int)cmd.ExecuteScalar();
                doc_conn.Close();
                if (v == 0)
                {
                    MessageBox.Show("Invalid Doctor ID");
                }
                else
                {
                    app_conn.Open();
                    string query1 = "select pat_id,time from Table where doc_id = '" + id + "'";
                    SqlDataAdapter da = new SqlDataAdapter(query1, app_conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    app_conn.Close();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void search_Click(object sender, EventArgs e)
        {
            fill(doctor_id.Text);
        }

        private void quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void update_Click(object sender, EventArgs e)
        {
            app_conn.Open();
            SqlCommand cmd = new SqlCommand("update Table values(@time) where pat_id = '" + patient_id.Text + "'" , app_conn);
            cmd.Parameters.AddWithValue("@time", time.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Appointment Updated.");
            app_conn.Close();
            doctor_id.Text = "";
            patient_id.Text = "";
            time.Text = "";
        }

        private void delete_Click(object sender, EventArgs e)
        {
            app_conn.Open();
            SqlCommand cmd = new SqlCommand("delete Table values(@doc_id,@pat_id,@time) where pat_id = '" + patient_id.Text + 
                "', doc_id = '" + doctor_id.Text + "', time = '" + time.Text + "'", app_conn);
            cmd.Parameters.AddWithValue("@doc_id", doctor_id.Text);
            cmd.Parameters.AddWithValue("@pat_id", patient_id.Text);
            cmd.Parameters.AddWithValue("@time", time.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Appointment Deleted.");
            app_conn.Close();
            doctor_id.Text = "";
            patient_id.Text = "";
            time.Text = "";
        }
    }
}
