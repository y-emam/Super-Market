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
namespace Super_Market
{
    public partial class Form1 : Form
    {
        public static string user = "";
        public static string pass = "";
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=.;initial catalog=super_market;integrated security=true");
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 product = new Form1();
            string query = "SELECT * FROM admin WHERE username = '" + textBox1.Text.Trim() + "' AND password = '" + textBox2.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dtb1 = new DataTable();
            sda.Fill(dtb1);
            if (dtb1.Rows.Count == 1)
            {
                user = textBox1.Text;
                pass = textBox2.Text;
                Form9 objForm1 = new Form9();
                this.Hide();
                objForm1.Show();
            }
            else
            {
                MessageBox.Show("check your username and password");

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
