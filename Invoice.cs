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
    public partial class Invoice : Form
    {
        public Invoice()
        {
            InitializeComponent();
        }

        private void Invoice_Load(object sender, EventArgs e)
        {

        }

        SqlConnection pat_conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\umidu\\OneDrive\\Documents\\PatientData.mdf;Integrated Security=True;Connect Timeout=30");
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu menu = new Menu();
            menu.Show();
        }

        private void fill(string id)
        {
            try
            {
                pat_conn.Open();
                string query = "select count(*) from Table where patientId='" + id + "'";
                SqlCommand cmd = new SqlCommand(query, pat_conn);
                int v = (int)cmd.ExecuteScalar();
                if (v == 0)
                {
                    MessageBox.Show("Invalid Patient ID");
                }
                else
                {
                    string query1 = "select reason,charges from Table where patientId = '" + id + "'";
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

        private void search_Click(object sender, EventArgs e)
        {
            fill(patient_id.Text);
        }

        private void add_Click(object sender, EventArgs e)
        {
            pat_conn.Open();

            string query2 = "select count(*) from Table where patientId='" + patient_id.Text + "'";
            SqlCommand cmd2 = new SqlCommand(query2, pat_conn);
            int W = (int)cmd2.ExecuteScalar();

            if (W == 0)
            {
                MessageBox.Show("Invalid Patient ID");
            }
            else
            {
                SqlCommand cmd3 = new SqlCommand("insert into Table values(@charges,@reason) where patientId = '" + patient_id.Text + "'", pat_conn);
                cmd3.Parameters.AddWithValue("@charges", charge.Text);
                cmd3.Parameters.AddWithValue("@reason", reason.Text);
                cmd3.ExecuteNonQuery();
                MessageBox.Show("New Charge Added.");
                pat_conn.Close();
                patient_id.Text = "";
                charge.Text = "";
                reason.Text = "";
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            patient_id.Text = "";
            charge.Text = "";
            reason.Text = "";
        }

        private void quit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void update_Click(object sender, EventArgs e)
        {
            pat_conn.Open();
            SqlCommand cmd = new SqlCommand("update Table values(@charges,@reason) where patientId = '" + patient_id.Text + "'", pat_conn);
            cmd.Parameters.AddWithValue("@charges", charge.Text);
            cmd.Parameters.AddWithValue("@reason", charge.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Charges Updated.");
            pat_conn.Close();
            patient_id.Text = "";
            reason.Text = "";
            charge.Text = "";
        }

        private void delete_Click(object sender, EventArgs e)
        {
            pat_conn.Open();
            SqlCommand cmd = new SqlCommand("delete Table values(@charges,@reason) where patientId = '" + patient_id.Text + "'", pat_conn);
            cmd.Parameters.AddWithValue("@charges", charge.Text);
            cmd.Parameters.AddWithValue("@reason", charge.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Charges Deleted.");
            pat_conn.Close();
            patient_id.Text = "";
            reason.Text = "";
            charge.Text = "";
        }
    }
}
