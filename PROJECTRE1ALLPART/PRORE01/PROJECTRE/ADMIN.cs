using EMPPP;
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
    public partial class ADMIN : Form
    {
        public ADMIN(string User)
        {
            InitializeComponent();
            label3.Text = "" + User;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            detailroom d = new detailroom();
            d.Show();
            Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label3.Text == "ADMIN")
            {
                EMPLOYEES d = new EMPLOYEES(label3.Text);
                d.Show();
                Visible = false;
            }
            else
            {
                MessageBox.Show(" ID ของคุณไม่สามารถเข้าได้");
            }
            
           

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 d = new Form1(label3.Text);
            d.Show();
            Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            POSITYPE d = new POSITYPE(label3.Text);
            d.Show();
            Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PROMOTION d = new PROMOTION (label3.Text);
            d.Show();
            Visible = false;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            PRODUCTSTOCK ao = new PRODUCTSTOCK(label3.Text);
            ao.Show();
            Visible = false;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (label3.Text == "ADMIN")
            {
                ADMINCEO d = new ADMINCEO(label3.Text);
                d.Show();
                Visible = false;
            }
            else
            {
                MessageBox.Show(" ID ของคุณไม่สามารถเข้าได้");
            }
        }
    }
}
