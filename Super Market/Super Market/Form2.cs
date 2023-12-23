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
    public partial class Form2 : Form
    {
        string id;
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=.;initial catalog=super_market;integrated security=true");
        private void Form2_Load(object sender, EventArgs e)
        {
            conn.Open();
            string sqlseclect = "select ad_id From admin Where username ='" + Form1.user + "' and password ='" + Form1.pass + "'";
            SqlCommand cmd = new SqlCommand(sqlseclect, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                id = dr["ad_id"].ToString();
            }
            conn.Close();
            bind_data();
            textBox4.Text = id.ToString();
        }
        private void bind_data()
        {
            SqlCommand cmd1 = new SqlCommand("select ad_id,product_id As ID,product_name As Name,product_price As price ,product_quantity As quantity,type As Type from product", conn);
            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = cmd1;
            DataTable dt = new DataTable();
            dt.Clear();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 14, FontStyle.Bold);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd2 = new SqlCommand("Insert into product (product_name,product_price,product_quantity,ad_id,type)Values(@Name,@price,@quantity,'"+id+"',@type)", conn);
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                cmd2.Parameters.AddWithValue("Name", textBox1.Text);
                cmd2.Parameters.AddWithValue("price", textBox2.Text);
                cmd2.Parameters.AddWithValue("quantity", textBox3.Text);
                textBox4.Text = id.ToString();
                cmd2.Parameters.AddWithValue("type", textBox5.Text);
                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();
                bind_data();
            }
            else {
                MessageBox.Show("you should fill all fields");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd4 = new SqlCommand("Delete from product where product_name=@Name", conn);
            
            cmd4.Parameters.AddWithValue("Name", textBox1.Text);
            conn.Open();
            cmd4.ExecuteNonQuery();
            conn.Close();
            bind_data();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = id.ToString();
            textBox5.Text = "";
        }

        private void dataGridView1_cellclick(object sender, DataGridViewCellEventArgs e)
        {
            int index;
            index = e.RowIndex;
            DataGridViewRow selectedrow = dataGridView1.Rows[index];
            textBox4.Text = id.ToString();
            textBox3.Text = selectedrow.Cells[4].Value.ToString();
            textBox1.Text = selectedrow.Cells[2].Value.ToString();
            textBox2.Text = selectedrow.Cells[3].Value.ToString();
            textBox5.Text = selectedrow.Cells[5].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand cmd3 = new SqlCommand("Update product Set product_price=@price,product_quantity=@quantity where product_name=@Name", conn);
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                cmd3.Parameters.AddWithValue("price", textBox2.Text);
                cmd3.Parameters.AddWithValue("quantity", textBox3.Text);
                cmd3.Parameters.AddWithValue("Name", textBox1.Text);
                conn.Open();
                cmd3.ExecuteNonQuery();
                conn.Close();
                bind_data();
            }
            else {
                MessageBox.Show("you should fill all fields");
            }
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand cmd5 = new SqlCommand("select ad_id,product_id As ID,product_name As Name,product_price As Price,product_quantity As quantity,type As Type from product where product_name Like @name +'%'", conn);
            cmd5.Parameters.AddWithValue("name", textBox6.Text);
            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = cmd5;
            DataTable dt = new DataTable();
            dt.Clear();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 14, FontStyle.Bold);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bind_data();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlCommand cmd6 = new SqlCommand("select ad_id,product_id As ID,product_name As Name,product_price As Price,product_quantity As quantity,type As Type from product where product_quantity='"+0+"'" , conn);
            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = cmd6;
            DataTable dt = new DataTable();
            dt.Clear();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 14, FontStyle.Bold);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlCommand cmd7 = new SqlCommand("select ad_id,product_id As ID,product_name As Name,product_price As Price,product_quantity As quantity,type As Type from product where product_quantity>'" + 0 + "'", conn);
            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = cmd7;
            DataTable dt = new DataTable();
            dt.Clear();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 14, FontStyle.Bold);
        }
    }
}
