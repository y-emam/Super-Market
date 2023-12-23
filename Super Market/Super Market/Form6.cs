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
    public partial class Form6 : Form
    {
        public static int customerID;
        public Form6()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=.;initial catalog=super_market;integrated security=true");
        private void Form6_Load(object sender, EventArgs e)
        {
            conn.Open();
            string sqlseclect = "select cust_id From customer Where username ='" + Form5.SetValueForText1 + "' and password ='" + Form5.SetValueForText2 + "'";
            SqlCommand cmd = new SqlCommand(sqlseclect, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                customerID =Int32.Parse( dr["cust_id"].ToString());
            }
            conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 obj = new Form7();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form8 form = new Form8();
            form.Show();
            this.Hide();
        }
    }
}
