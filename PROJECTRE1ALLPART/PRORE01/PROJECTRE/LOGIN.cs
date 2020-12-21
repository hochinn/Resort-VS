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
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            REGISTER r = new REGISTER();
            r.Show();
            Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM member WHERE USENAME ='" + textBox5.Text + "'AND PASSWORD ='" + textBox6.Text + "'";
            string ConnectString = "datasource = localhost; username= root;" +
                "password=; database = database";

            MySqlConnection con = new MySqlConnection(ConnectString);
            MySqlCommand cmd = new MySqlCommand(sql, con);
         
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
       
            if (reader.Read() == false) 
            {
                MessageBox.Show("คุณกรอก URESNAME หรือ PASSWORD ไม่ถูกต้อง หรือไม่ได้กรอกข้อมูล");
            }
            else
            {
                member mm = new member(textBox5.Text);
                mm.Show();
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

        private void button3_Click(object sender, EventArgs e)
        {
            LOGINADMIN dd = new LOGINADMIN();

            dd.Show();
            Visible = false;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
