using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Market
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 admin=new Form1();
            admin.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 customer = new Form5();
            customer.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 customer = new Form3();
            customer.Show();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
