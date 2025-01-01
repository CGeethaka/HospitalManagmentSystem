using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagmentSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {


        }

        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\umidu\\OneDrive\\Documents\\signup.mdf;Integrated Security=True;Connect Timeout=30");

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (u_name.Text != "" && pass.Text != "")
                {
                    conn.Open();
                    string query = "select count(*) from RegistrationTbl where email='" + u_name.Text + "' and " + "pass='" + pass.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    int v = (int)cmd.ExecuteScalar();
                    if (v != 1)
                    {
                        MessageBox.Show("User Name or Password Wrong");
                    }
                    else
                    {
                        Menu menu = new Menu();
                        this.Hide();
                        menu.Show();
                        u_name.Text = "";
                        pass.Text = "";
                    }
                }
                else
                {
                    

                   MessageBox.Show("Fill All the Blanks");
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }
    }
}
 