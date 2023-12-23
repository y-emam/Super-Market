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


    public partial class Form5 : Form
    {
        public static string SetValueForText1 = "";
        public static string SetValueForText2 = "";
       
        public Form5()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=.;initial catalog=super_market;integrated security=true");
        private void button1_Click(object sender, EventArgs e)
        {
            Form5 product = new Form5();
            string query = "SELECT * FROM customer WHERE username = '" + textBox1.Text + "' AND password = '" + textBox2.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dtb1 = new DataTable();
            sda.Fill(dtb1);
            if (dtb1.Rows.Count == 1)
            {
                SetValueForText1 = textBox1.Text;
                SetValueForText2 = textBox2.Text;
                Form6 objForm1 = new Form6();
                objForm1.Show();
                this.Hide();   
            }
            else
            {
                MessageBox.Show("check your username and password");

            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
