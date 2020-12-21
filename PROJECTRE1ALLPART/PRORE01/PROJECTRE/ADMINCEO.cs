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
    public partial class ADMINCEO : Form
    {
        public ADMINCEO(string Admin)
        {
            InitializeComponent();

            label3.Text = "" + Admin;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EMPLOYEES ff = new EMPLOYEES(label3.Text);
            ff.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            POSITYPE tr = new POSITYPE(label3.Text);
            tr.Show();

        }
    }
}
