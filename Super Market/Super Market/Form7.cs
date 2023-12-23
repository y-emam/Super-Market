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
    public partial class Form7 : Form
    {
        string id="";
        string user;
        string pass;
        public Form7()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=.;initial catalog=super_market;integrated security=true");
        private void Form7_Load(object sender, EventArgs e)
        {
            user = Form5.SetValueForText1;
            pass = Form5.SetValueForText2;
            
            conn.Open();
            string sqlseclect = "select cust_id,fname, lname, phone, address_, username, password From customer Where username ='" + user+"' and password ='"+pass+"'"  ;
            SqlCommand cmd = new SqlCommand(sqlseclect, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) {
                textBox1.Text = dr["fname"].ToString();
                textBox2.Text = dr["lname"].ToString();
                textBox3.Text = dr["phone"].ToString();
                textBox4.Text = dr["address_"].ToString();
                textBox5.Text = dr["username"].ToString();
                textBox6.Text = dr["password"].ToString();
                id= dr["cust_id"].ToString();
                
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlseclect = "Update customer Set fname=@firstname,lname=@lastname,phone=@phone,address_=@address,username=@username,password=@password From customer where cust_id='"+id+"'";
            SqlCommand cmd3 = new SqlCommand(sqlseclect, conn);

            cmd3.Parameters.AddWithValue("firstname", textBox1.Text);
            cmd3.Parameters.AddWithValue("phone", textBox3.Text);
            cmd3.Parameters.AddWithValue("lastname", textBox2.Text);
            cmd3.Parameters.AddWithValue("address", textBox4.Text);
            cmd3.Parameters.AddWithValue("username", textBox5.Text);
            cmd3.Parameters.AddWithValue("password", textBox6.Text);
            conn.Open();
            cmd3.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data has been updated");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd4 = new SqlCommand("Delete from customer where cust_id='"+id+"'", conn);
            conn.Open();
            cmd4.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data has been deleted");
            Form4 form = new Form4();
            form.Show();
            this.Hide();
        }
    }
}
