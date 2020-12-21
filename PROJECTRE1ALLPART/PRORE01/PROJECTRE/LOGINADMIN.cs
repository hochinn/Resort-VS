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
    public partial class LOGINADMIN : Form
    {
        public LOGINADMIN()
        {
            InitializeComponent();

            //textUadd.Text = "ADMIN : " + Admin;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqle = "SELECT * FROM employee WHERE ID_EMPLOYEES ='" + textUadd.Text + "'AND EMP_PASSWORD ='" + textPass.Text + "'";
            string ConnectStringadd = "datasource = localhost; username= root;" +
                "password=; database = database";

            MySqlConnection cona = new MySqlConnection(ConnectStringadd);
            MySqlCommand cmd = new MySqlCommand(sqle, cona);
            cona.Open();
            MySqlDataReader readere = cmd.ExecuteReader();

            if (readere.Read() == false) 
            {
                MessageBox.Show("คุณกรอก ID หรือ PASSWORD ไม่ถูกต้อง หรือไม่ได้กรอกข้อมูล");
            }
            else
            {
                ADMIN p1 = new ADMIN(textUadd.Text);
                p1.Show();
                Visible = false;
                //MessageBox.Show("LOGIN PASS");
                /*if ((readere.Read() == true)) <อันนี้คือส่วนของพนักงาน ยังไม่แน่ใจ เพราะยังไม่ได้ลองเชื่อมหน้าพนักงานจริง (เชื่อมแล้วเดี๋ยวแก้ให้)>
                {
                    this.Hide();
                    admin a1 = new admin(textBox1.Text);
                    //w1.Show();
                    //MessageBox.Show("LOGIN PASS");
                }*/
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
