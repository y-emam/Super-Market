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
    public partial class Form13 : Form
    {
        string order_id;
        string pay_id;
      
        public Form13()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=.;initial catalog=super_market;integrated security=true");
        private void Form13_Load(object sender, EventArgs e)
        {
            textBox1.Text = Form8.name;
            textBox2.Text = Form8.q.ToString();
            textBox3.Text = Form8.total.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Show();
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dt = this.dateTimePicker1.Value.Date;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.ShowUpDown = true;
            string da = dateTimePicker1.Value.ToString("dd");
            string ma = dateTimePicker1.Value.ToString("MM");
            string ya = dateTimePicker1.Value.ToString("yyyy");




            SqlCommand cmd3 = new SqlCommand("Update product Set product_quantity=product_quantity-" + Form8.q + "where product_name=@Name", conn);
            cmd3.Parameters.AddWithValue("price", textBox2.Text);
            cmd3.Parameters.AddWithValue("quantity", textBox3.Text);
            cmd3.Parameters.AddWithValue("Name", textBox1.Text);
            conn.Open();
            cmd3.ExecuteNonQuery();
            conn.Close();




           
            int x = genrate_ID();
            SqlCommand cmd2 = new SqlCommand("Insert into customerorder (order_id,cust_id,dayy,monthh,yearr,product_id)Values(" + x + "," + Form6.customerID + ", '" + da + "' ,  '" + ma + "',  '" + ya + "' , " + Form8.product_id + ")", conn);
            conn.Open();
            cmd2.ExecuteNonQuery();
            conn.Close();






            int y = genrate_payID();
            SqlCommand cmd4 = new SqlCommand("Insert into payment (pay_id,cust_id,pay_amount,day,month,year)Values(" + y + "," + Form6.customerID + "," + Form8.total + ", '" + da + "' ,  '" + ma + "',  '" + da + "' )", conn);
            conn.Open();
            cmd4.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("order has been confirmed ");
            Form8 formm = new Form8();
            formm.Show();
            this.Close();


        }
        public int genrate_ID() {
            conn.Open();
            string sqlseclect = "select max(order_id) From customerorder";
            SqlCommand cmd = new SqlCommand(sqlseclect, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                order_id = dr[0].ToString();
              
            }
            conn.Close();

            if (order_id == "")
            {
                return 1;
            }
            return (Int32.Parse(order_id )+1); 
        }
        public int genrate_payID()
        {
            conn.Open();
            string sqlseclect = "select max(pay_id) From payment  ";
            SqlCommand cmd = new SqlCommand(sqlseclect, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                pay_id = dr[0].ToString();
               
            }
            conn.Close();
            if (pay_id == "")
            {
                return 1;
            }
            return (Int32.Parse(pay_id) + 1);

        }
    }
} 
