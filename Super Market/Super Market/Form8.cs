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
    public partial class Form8 : Form
    {
        public static int product_id;
        int s;
        public static int q;
        public static float total;
        public static string name;
        int price;
        public Form8()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=.;initial catalog=super_market;integrated security=true");
        private void bind_data()
        {
            SqlCommand cmd1 = new SqlCommand("select product_name As Name,product_price As price ,type As Type from product", conn);
            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = cmd1;
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

        private void Form8_Load(object sender, EventArgs e)
        {
            bind_data();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand cmd5 = new SqlCommand("select product_name As Name,product_price As Price,type As Type from product where product_name Like @name +'%'", conn);
            cmd5.Parameters.AddWithValue("name", textBox6.Text);
            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = cmd5;
            DataTable dt = new DataTable();
            dt.Clear();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 14, FontStyle.Bold);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("select product_name As Name,product_price As price ,type As Type from product where product_quantity>'"+0+"'", conn);
            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = cmd1;
            DataTable dt = new DataTable();
            dt.Clear();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 14, FontStyle.Bold);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void dataGridVi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index;
            index = e.RowIndex;
            DataGridViewRow selectedrow = dataGridView1.Rows[index];
            textBox1.Text = selectedrow.Cells[0].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string a=textBox2.Text.ToString();
            q = Int32.Parse(a);
            conn.Open();
            string sqlseclect = "select product_id ,product_quantity,product_price from product Where product_name ='"+textBox1.Text+"'";
            SqlCommand cmd = new SqlCommand(sqlseclect, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                product_id=Int32.Parse(dr["product_id"].ToString());
                s = Int32.Parse(dr["product_quantity"].ToString());
                price= Int32.Parse(dr["product_price"].ToString());
            }
            conn.Close();
            if (s > q)
            {
               name = textBox1.Text.ToString();
               total = q * price;
               Form13 form = new Form13();
               form.Show();
               this.Close();
            }
            else if (s==0) {
                MessageBox.Show("out of stock");
            }
            else {
                MessageBox.Show("out of ranage please choose available quantity");
            }

        }
    }
}
