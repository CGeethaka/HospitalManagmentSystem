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
    public partial class DocDetails : Form
    {
        public DocDetails()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        SqlConnection doc_conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\umidu\\OneDrive\\Documents\\DoctorData.mdf;Integrated Security=True;Connect Timeout=30");
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu menu = new Menu();
            menu.Show();
        }

        private void DocDetails_Load(object sender, EventArgs e)
        {

        }

        private void fill(string id)
        {
            try
            {
                doc_conn.Open();
                string query = "select count(*) from Table where Id='" + id + "'";
                SqlCommand cmd = new SqlCommand(query, doc_conn);
                int v = (int)cmd.ExecuteScalar();
                if (v == 0)
                {
                    MessageBox.Show("Invalid Doctor ID");
                }
                else
                {
                    string query1 = "select * from Table where Id = '" + id + "'";
                    SqlDataAdapter da = new SqlDataAdapter(query1, doc_conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    doc_conn.Close();
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
    }
}
