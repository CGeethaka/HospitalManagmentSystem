using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagmentSystem
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Records records = new Records();
            records.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void add_Click(object sender, EventArgs e)
        {
            Doctorap doctorap = new Doctorap();
            this.Hide();
            doctorap.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Info info = new Info();
            this.Hide();
            info.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Meds meds = new Meds(); 
            this.Hide();
            meds.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DocDetails details = new DocDetails();
            this.Hide();
            details.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Rooms rooms = new Rooms();
            this.Hide();
            rooms.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Records records=new Records();
            this.Hide();
            records.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Invoice invoice = new Invoice();
            invoice.Show();
        }
    }
}
