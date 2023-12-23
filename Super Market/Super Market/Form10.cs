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
    public partial class Form10 : Form
    {
        string id=""; 
        public Form10()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=.;initial catalog=super_market;integrated security=true");
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd2 = new SqlCommand("Insert into customer (fname,lname,phone,address_,username,password,ad_id)Values(@firstname,@lastname,@phone,@address,@username,@password,@AdminID)", conn);
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text == "" || textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {
                cmd2.Parameters.AddWithValue("firstname", textBox1.Text);
                cmd2.Parameters.AddWithValue("lastname", textBox2.Text);
                cmd2.Parameters.AddWithValue("phone", textBox3.Text);
                cmd2.Parameters.AddWithValue("address", textBox4.Text);
                cmd2.Parameters.AddWithValue("username", textBox5.Text);
                cmd2.Parameters.AddWithValue("password", textBox6.Text);
                cmd2.Parameters.AddWithValue("AdminID", textBox7.Text);
                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("successful signUp");
                clear();
            }
            else {
                MessageBox.Show("you should fill all fields");
            }
            
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            conn.Open();
            string sqlseclect = "select ad_id From admin Where username ='" + Form1.user + "' and password ='" + Form1.pass + "'";
            SqlCommand cmd = new SqlCommand(sqlseclect, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                textBox7.Text = dr["ad_id"].ToString();

            }
            conn.Close();
            
        }
        private void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }
    }
}
