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
    public partial class Form11 : Form
    {
        string id = "";
        public Form11()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=.;initial catalog=super_market;integrated security=true");
        private void Form11_Load(object sender, EventArgs e)
        {
            conn.Open();
            string sqlseclect = "select ad_id From admin Where username ='" + Form1.user + "' and password ='" +Form1.pass+ "'";
            SqlCommand cmd = new SqlCommand(sqlseclect, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                id = dr["ad_id"].ToString();
            }
            conn.Close();
            bind_data();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index;
            index = e.RowIndex;
            DataGridViewRow selectedrow = dataGridView1.Rows[index];
            textBox4.Text = selectedrow.Cells[5].Value.ToString();
            textBox3.Text = selectedrow.Cells[4].Value.ToString();
            textBox1.Text = selectedrow.Cells[2].Value.ToString();
            textBox2.Text = selectedrow.Cells[3].Value.ToString();
            textBox6.Text = selectedrow.Cells[7].Value.ToString();
            textBox5.Text = selectedrow.Cells[6].Value.ToString();
            textBox7.Text = id.ToString();
            textBox8.Text = selectedrow.Cells[1].Value.ToString();

        }
        private void bind_data()
        {
            SqlCommand cmd1 = new SqlCommand("select ad_id As AdminID,cust_id AS ID,fname AS firstname, lname AS lastname, phone, address_ AS Address, username, password,Discount As Discount From customer" , conn);
            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = cmd1;
            DataTable dt = new DataTable();
            dt.Clear();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 14, FontStyle.Bold);

        }
        private void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {

            string sqlseclect = "Update customer Set ad_id=@adminid, fname=@firstname,lname=@lastname,phone=@phone,address_=@address,username=@username,password=@password From customer where cust_id= @customerid";
            SqlCommand cmd3 = new SqlCommand(sqlseclect, conn);
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {
                cmd3.Parameters.AddWithValue("firstname", textBox1.Text);
                cmd3.Parameters.AddWithValue("phone", textBox3.Text);
                cmd3.Parameters.AddWithValue("lastname", textBox2.Text);
                cmd3.Parameters.AddWithValue("address", textBox4.Text);
                cmd3.Parameters.AddWithValue("username", textBox5.Text);
                cmd3.Parameters.AddWithValue("password", textBox6.Text);
                cmd3.Parameters.AddWithValue("customerid", textBox8.Text);
                cmd3.Parameters.AddWithValue("adminid", textBox7.Text);
                conn.Open();
                cmd3.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Data has been updated");
                bind_data();
                clear();
            }
            else {
                MessageBox.Show("you should fill all fields");
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd4 = new SqlCommand("Delete from customer where cust_id=@customerid", conn);
            cmd4.Parameters.AddWithValue("customerid", textBox8.Text);
            conn.Open();
            cmd4.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data has been deleted");
            clear();
            bind_data();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
