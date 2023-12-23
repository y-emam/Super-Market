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
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=.;initial catalog=super_market;integrated security=true");
       

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd5 = new SqlCommand("select top 1 product_id, count(product_id) as total from customerorder group by product_id order by total desc", conn);
            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = cmd5;
            DataTable dt = new DataTable();
            dt.Clear();
            ad.Fill(dt);
            dataGridView2.DataSource = dt;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 14, FontStyle.Bold);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd5 = new SqlCommand("select product_id from product where product_id not in(select product_id from customerorder where monthh=@month)", conn);
            cmd5.Parameters.AddWithValue("month", textBox1.Text);
            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = cmd5;
            DataTable dt = new DataTable();
            dt.Clear();
            ad.Fill(dt);
            dataGridView2.DataSource = dt;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 14, FontStyle.Bold);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd5 = new SqlCommand("select cust_id from customer where cust_id not in(select cust_id from customerorder where yearr>=2021)", conn);
            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = cmd5;
            DataTable dt = new DataTable();
            dt.Clear();
            ad.Fill(dt);
            dataGridView2.DataSource = dt;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 14, FontStyle.Bold);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand cmd5 = new SqlCommand("SELECT top 1 SUM(pay_amount)as Total,cust_id FROM payment group by cust_id order by Total desc", conn);
            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = cmd5;
            DataTable dt = new DataTable();
            dt.Clear();
            ad.Fill(dt);
            dataGridView2.DataSource = dt;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 14, FontStyle.Bold);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand cmd5 = new SqlCommand("select top 1  type,count(type) Total from product group by type order by Total desc", conn);
            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = cmd5;
            DataTable dt = new DataTable();
            dt.Clear();
            ad.Fill(dt);
            dataGridView2.DataSource = dt;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 14, FontStyle.Bold);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlCommand cmd5 = new SqlCommand("SELECT * FROM product LEFT JOIN (SELECT COUNT(DISTINCT cust_id) total ,product_id FROM customerorder group by product_id)  AS newtable ON product.product_id = newtable.product_id", conn);
            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = cmd5;
            DataTable dt = new DataTable();
            dt.Clear();
            ad.Fill(dt);
            dataGridView2.DataSource = dt;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 14, FontStyle.Bold);
        }

     
    }
}
