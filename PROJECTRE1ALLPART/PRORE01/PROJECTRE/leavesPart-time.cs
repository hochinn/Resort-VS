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
    public partial class leavesPart_time : Form
    {
        public leavesPart_time(string Admin)
        {
            InitializeComponent();
            label10.Text = "" + Admin;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void leavesPart_time_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DateTime a1 = Convert.ToDateTime(dateTimePicker2.Text);
            DateTime a2 = Convert.ToDateTime(dateTimePicker3.Text);
            TimeSpan t1 = a2 - a1;


            label7.Text = t1.Days.ToString();

            int aa;
            int bb, cc;
            aa = int.Parse(label9.Text);
            bb = int.Parse(label7.Text);
            cc = bb * aa;
            textBox2.Text = cc.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlT = "INSERT INTO leaves(LEAVE_CAUSE ,LEAVE_DATE,LEAVE_NUMALL ,LEAVETYPE_ID_LEAVETYPE,EMPLOYEE_ID_EMPLOYEES) VALUES ('" + textBox1.Text + "','" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "','" + textBox2.Text + "','" + label8.Text + "','" + label10.Text + "')";

            string ConnectStringT = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";

            MySqlConnection conT = new MySqlConnection(ConnectStringT);
            MySqlCommand cmdT = new MySqlCommand(sqlT, conT);
            conT.Open();
            MySqlDataReader readerT = cmdT.ExecuteReader();
            //MessageBox.Show("กรุณาเลือกสินค้าลงรายการสั่งซื้อได้ที่ ' เพิ่มสินค้า ' ");
            if (textBox1.Text == "" || dateTimePicker2.Value.ToString("yyyy-MM-dd") == "" || textBox2.Text == "" || comboBox1.Text == "" || label10.Text == "")
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบ");
            }
            else
            {
                MessageBox.Show("ทำการลาสำเร็จ !!");
                textBox1.Clear();
                textBox2.Clear();



            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Equals("ลาป่วย"))
            {
                label8.Text = "LT000001";
            }
            if (comboBox1.Text.Equals("ลากิจธุระ"))
            {
                label8.Text = "LT000002";
            }
            if (comboBox1.Text.Equals("ลาคลอด"))
            {
                label8.Text = "LT000003";
            }
            if (comboBox1.Text.Equals("ลาพัก"))
            {
                label8.Text = "LT000004";
            }
        }
    }
}
