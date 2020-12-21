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
    public partial class PRODUCTSTOCK : Form
    {
        public PRODUCTSTOCK(string Admin)
        {
            InitializeComponent();
            label3.Text = Admin;
        }

    

        private void button1_Click(object sender, EventArgs e)
        {
            PRODUCTT aa = new PRODUCTT(label3.Text);
            aa.Show();
            Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BILLOFLADING r = new BILLOFLADING(label3.Text);
            r.Show();
            Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ADMIN aa = new ADMIN(label3.Text);
            aa.Show();
            Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CLAIM ee = new CLAIM(label3.Text);
            ee.Show();
        }
    }
}
