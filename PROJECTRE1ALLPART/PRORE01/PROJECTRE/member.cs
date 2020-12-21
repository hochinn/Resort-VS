using hotal;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJECTRE
{
    public partial class member : Form
    {
        public member(string User)
        {
            InitializeComponent();
            label3.Text = "" + User;

        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Booking aa = new Booking(label3.Text);
            aa.Show();
            Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Book_detail yy = new Book_detail(label3.Text);
            yy.Show();
            Visible = false;
        }
    }
}
