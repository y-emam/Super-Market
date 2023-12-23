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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=.;initial catalog=super_market;integrated security=true");
        private void Form3_Load(object sender, EventArgs e)
        {

        }
        private void clear() {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd2 = new SqlCommand("Insert into customer (fname,lname,phone,address_,username,password)Values(@firstname,@lastname,@phone,@address,@username,@password)", conn);
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text == "" || textBox5.Text != "" && textBox6.Text != "")
            {
                cmd2.Parameters.AddWithValue("firstname", textBox1.Text);
                cmd2.Parameters.AddWithValue("lastname", textBox2.Text);
                cmd2.Parameters.AddWithValue("phone", textBox3.Text);
                cmd2.Parameters.AddWithValue("address", textBox4.Text);
                cmd2.Parameters.AddWithValue("username", textBox5.Text);
                cmd2.Parameters.AddWithValue("password", textBox6.Text);
                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("successful signUp");
                clear();
                Form4 form = new Form4();
                form.Show();
                this.Hide();
            }
            else {
                MessageBox.Show("you should fill all fields");
            }
            

        }
    }
}
