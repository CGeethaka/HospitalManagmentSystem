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

namespace HospitalManagmentSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\umidu\\OneDrive\\Documents\\signup.mdf;Integrated Security=True;Connect Timeout=30");

        private void label5_Click(object sender, EventArgs e)
        {


        }

      

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (first_name.Text != "" && last_name.Text != "" && email.Text != "" && Id.Text != "" && password.Text != "")
                {
                    int v = check(Id.Text);
                    if (v != 1)
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("insert into RegistrationTbl values(@f_name,@l_name,@email,@ID,@pass)", conn);
                        cmd.Parameters.AddWithValue("@f_name", first_name.Text);
                        cmd.Parameters.AddWithValue("@l_name", last_name.Text);
                        cmd.Parameters.AddWithValue("@email", email.Text);
                        cmd.Parameters.AddWithValue("@ID", Id.Text);
                        cmd.Parameters.AddWithValue("@pass", password.Text);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Registration Successful");
                        first_name.Text = "";
                        last_name.Text = "";
                        email.Text = "";
                        Id.Text = "";
                        password.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("You are Already Registered");
                    }
                }
                else
                {
                    MessageBox.Show("Fill All the Blanks!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        int check(string Id)
        {
            conn.Open();
            string query = "select count(*) from RegistrationTbl where email='" + Id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            int v = (int)cmd.ExecuteScalar();
            conn.Close();
            return v;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }

        
    }
}
