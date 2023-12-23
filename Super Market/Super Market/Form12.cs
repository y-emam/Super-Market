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
    public partial class Form12 : Form
    {
        string id;
        string n;
        int num;
        public Form12()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=.;initial catalog=super_market;integrated security=true");
        private void Form12_Load(object sender, EventArgs e)
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
        }
        private void bind_data()
        {
            SqlCommand cmd1 = new SqlCommand("select  cust_id ,count (cust_id) As total from customerorder group by cust_id order by (total) desc", conn);
            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = cmd1;
            DataTable dt = new DataTable();
            dt.Clear();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 14, FontStyle.Bold);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bind_data();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            n = textBox1.Text.ToString();
            num = Int32.Parse(n);
            SqlCommand cmd1 = new SqlCommand("select Top(" + num + ") cust_id ,count (cust_id) As total from customerorder group by cust_id order by (total) desc", conn);
            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = cmd1;
            DataTable dt = new DataTable();
            dt.Clear();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 14, FontStyle.Bold);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sqlseclect = "Update customer Set ad_id='"+id+"', Discount=@discount From customer where cust_id= @id";
            SqlCommand cmd3 = new SqlCommand(sqlseclect, conn);
            if (textBox2.Text != "" && textBox3.Text != "")
            {

                cmd3.Parameters.AddWithValue("discount", textBox3.Text);
                cmd3.Parameters.AddWithValue("id", textBox2.Text);

                conn.Open();
                cmd3.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Data has been updated");
                bind_data();
                clear();
            }

        }
        private void clear()
        {

            textBox2.Text = "";
            textBox3.Text = "";

        }

        private void dataGridView1_cellclick(object sender, DataGridViewCellEventArgs e)
        {
            int index;
            index = e.RowIndex;
            DataGridViewRow selectedrow = dataGridView1.Rows[index];
            textBox2.Text = selectedrow.Cells[0].Value.ToString();     
        }
    }
}
