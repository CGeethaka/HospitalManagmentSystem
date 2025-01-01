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
    public partial class Rooms : Form
    {
        public Rooms()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\umidu\\OneDrive\\Documents\\RoomsAndTheaters.mdf;Integrated Security=True;Connect Timeout=30");
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
        }

        private void search_Click(object sender, EventArgs e)
        {
            fill(room_id.Text);
        }

        private void fill(string id)
        {
            try
            {
                conn.Open();
                string query = "select count(*) from Table where Id='" + id + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                int v = (int)cmd.ExecuteScalar();
                if (v == 0)
                {
                    MessageBox.Show("Invalid Room ID");
                }
                else
                {
                    string query1 = "select time from Table where Id = '" + id + "'";
                    SqlDataAdapter da = new SqlDataAdapter(query1, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void update_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("update Table values(@time) where Id = '" + room_id.Text + "'", conn);
            cmd.Parameters.AddWithValue("@time", time.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Medications Updated.");
            conn.Close();
            room_id.Text = "";
            time.Text = "";
        }
    }
}
