using MySql.Data.MySqlClient;
using PROJECTRE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMPPP
{
    public partial class Form1 : Form
    {
        public Form1(string Admin)
        {
            InitializeComponent();
            
            label14.Text = "" + Admin;


            //dateTimePicker1.Enabled = false;
            //dateTimePicker5.Enabled = false;
            //dateTimePicker6.Enabled = false;
            //comboBox1.Enabled = false;
            textBox2.Enabled = false;

            label20.Hide();
            //comboBox4.Hide();
            label13.Hide();
            dateTimePicker6.Hide();
            //dateTimePicker5.Hide();
            //button7.Hide();
            button8.Hide();
            textBox1.Hide();
            //label2.Hide();
            dateTimePicker2.Hide();
            label3.Hide();
            dateTimePicker3.Hide();
            button5.Hide();
            textBox2.Hide();
            label4.Hide();
            label5.Hide();
            comboBox1.Hide();
            label2.Hide();

            button6.Hide();


            string ConnectStringgg = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
            MySqlConnection con2 = new MySqlConnection(ConnectStringgg);
            con2.Open();
            MySqlDataAdapter dddd = new MySqlDataAdapter("SELECT * FROM EMPLOYEE", con2);
            MySqlDataAdapter ddd = new MySqlDataAdapter("SELECT * FROM leavetype", con2);

            DataSet dss = new DataSet();
            dddd.Fill(dss, "combolist");
            //comboBox2.DataSource = dss;
            //comboBox2.DisplayMember = "combolist.ID_EMPLOYEES";
            //comboBox2.ValueMember = "combolist.ID_EMPLOYEES";


            //DataSet dd = new DataSet();
            //ddd.Fill(dd, "combolist");
            //comboBox1.DataSource = dd;
            ////comboBox1.DisplayMember = "combolist.ID_LEAVETYPE";
            ////comboBox1.ValueMember = "combolist.ID_LEAVETYPE";
            con2.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void button5_Click(object sender, EventArgs e)
        {
            DateTime d1 = Convert.ToDateTime(dateTimePicker2.Text);
            DateTime d2 = Convert.ToDateTime(dateTimePicker3.Text);
            TimeSpan ts1 = d2 - d1;


            label7.Text = ts1.Days.ToString();

            int a;
            int b, c;
            a = int.Parse(label7.Text);
            b = int.Parse(label6.Text);
            c = b * a;
            textBox2.Text = c.ToString();
        }

       

        private void button6_Click(object sender, EventArgs e)
        {
            //string sql1 = "SELECT * FROM leave";
            string sqlT = "INSERT INTO leaves(LEAVE_CAUSE ,LEAVE_DATE,LEAVE_NUMALL ,LEAVETYPE_ID_LEAVETYPE,EMPLOYEE_ID_EMPLOYEES) VALUES ('" + textBox1.Text + "','" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "','" + textBox2.Text + "','" +label8.Text+ "','" + label14.Text + "')";

            string ConnectStringT = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";

            MySqlConnection conT = new MySqlConnection(ConnectStringT);
            MySqlCommand cmdT = new MySqlCommand(sqlT, conT);
            conT.Open();
            MySqlDataReader readerT = cmdT.ExecuteReader();
            //MessageBox.Show("กรุณาเลือกสินค้าลงรายการสั่งซื้อได้ที่ ' เพิ่มสินค้า ' ");
            if(textBox1.Text == "" || dateTimePicker2.Value.ToString("yyyy-MM-dd")=="" || textBox2.Text=="" || comboBox1.Text=="" || label14.Text == "")
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบ");
            }
            else
            {
                MessageBox.Show("ทำการลาสำเร็จ !!");
                textBox1.Clear();
                textBox2.Clear();



            }

            
            //textBox1.Hide();
            //label2.Hide();
            //dateTimePicker2.Hide();
            //label3.Hide();
            //dateTimePicker3.Hide();
            //button5.Hide();
            //textBox2.Hide();
            //label4.Hide();
            //label5.Hide();
            //comboBox1.Hide();
            //label8.Hide();
            //comboBox2.Hide();
            //button6.Hide();
            



        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            

            string sqlo = "UPDATE recordworks SET REC_OUT_TIME = '" + dateTimePicker6.Value.ToString("HH:mm:ss") + "' where REC_STARTING_DATE = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' AND EMPLOYEE_ID_EMPLOYEES = '" + label14.Text+ "' ";


                string ConnectStringo = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";

                MySqlConnection cono = new MySqlConnection(ConnectStringo);
                MySqlCommand cmdo = new MySqlCommand(sqlo, cono);
                cono.Open();
                MySqlDataReader readero = cmdo.ExecuteReader();

                MessageBox.Show("ขอให้โชคดี !!");
            //---------------------------------------------------------------------------------------------------------------------------------------------------------
            string ConnectStringh = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";
            MySqlConnection conh = new MySqlConnection(ConnectStringh);
            MySqlCommand cmdh = new MySqlCommand("SELECT * FROM recordworks where REC_STARTING_DATE = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' AND EMPLOYEE_ID_EMPLOYEES = '" + label14.Text + "'", conh);
            conh.Open();

            MySqlDataReader readeh = cmdh.ExecuteReader();
            while (readeh.Read())
            {
                label11.Text = (readeh["REC_GET_TIME"].ToString());
                label10.Text = (readeh["REC_OUT_TIME"].ToString());

            }
            readeh.Close();
            conh.Close();
            int r = 1;
            TimeSpan t1 = TimeSpan.Parse(label11.Text);
            TimeSpan t2 = TimeSpan.Parse(label10.Text);
            TimeSpan tt1 = TimeSpan.Parse("01:00:00");
            TimeSpan t3 = (t2 - t1) - tt1 ;
            label15.Text = t3.ToString();
            Console.WriteLine(t3);

            DateTime d1 = DateTime.Parse(label11.Text);
            DateTime d2 = DateTime.Parse(label10.Text);
            DateTime d3 = d1.Add(d2.TimeOfDay);
            label9.Text = t3.ToString();
            Console.WriteLine(d3.TimeOfDay);

            string sqlore= "UPDATE recordworks SET REC_WORKING_HOURS = '" + label9.Text + "' where REC_STARTING_DATE = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' AND EMPLOYEE_ID_EMPLOYEES = '" + label14.Text + "' ";


            string ConnectStringre = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";

            MySqlConnection conre = new MySqlConnection(ConnectStringre);
            MySqlCommand cmdre = new MySqlCommand(sqlore, conre);
            conre.Open();
            MySqlDataReader readerre = cmdre.ExecuteReader();
            //------------------------------------------------------------------------------------------------------------------------------
            //string sql = "SELECT ID_RECORDWORK,REC_STARTING_DATE,REC_GET_TIME,REC_OUT_TIME,EMPLOYEE_ID_EMPLOYEES FROM recordworks";
            //string ConnectString = "datasource = localhost; username= root;" +
            //    "password=; database = database;CharSet=UTF8";
            //MySqlConnection con = new MySqlConnection(ConnectString);
            //MySqlCommand cmd = new MySqlCommand(sql, con);
            //con.Open();
            //DataSet ds = new DataSet();
            //MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            //da.Fill(ds);
            //dataGridView1.DataSource = ds.Tables[0].DefaultView;



        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            string sqlr = "INSERT INTO recordworks(REC_GET_TIME,REC_STARTING_DATE,EMPLOYEE_ID_EMPLOYEES) VALUES ('" + dateTimePicker1.Value.ToString("HH:mm:ss") + "','" + dateTimePicker5.Value.ToString("yyyy-MM-dd") + "','" + label14.Text + "')";

            string ConnectStringr = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";

            MySqlConnection conr = new MySqlConnection(ConnectStringr);
            MySqlCommand cmdr = new MySqlCommand(sqlr, conr);
            conr.Open();
            MySqlDataReader readerr = cmdr.ExecuteReader();
            
            MessageBox.Show("ขอให้โชคดี !!");

            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------
            //string sql = "SELECT ID_RECORDWORK,REC_STARTING_DATE,REC_GET_TIME,REC_OUT_TIME,EMPLOYEE_ID_EMPLOYEES FROM recordworks";
            //string ConnectString = "datasource = localhost; username= root;" +
            //    "password=; database = database;CharSet=UTF8";
            //MySqlConnection con = new MySqlConnection(ConnectString);
            //MySqlCommand cmd = new MySqlCommand(sql, con);
            //con.Open();
            //DataSet ds = new DataSet();
            //MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            //da.Fill(ds);
            //dataGridView1.DataSource = ds.Tables[0].DefaultView;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label13.Show();
            
            dateTimePicker6.Show();
            button8.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            string ConnectStringlt = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";
            MySqlConnection conlt = new MySqlConnection(ConnectStringlt);
            MySqlCommand cmdlt = new MySqlCommand("SELECT * FROM employee where ID_EMPLOYEES = '" + label14.Text + "' AND TYPEWORK_ID_TYPEWORK = 'T0000012'", conlt);
            conlt.Open();
            MySqlDataReader readelt = cmdlt.ExecuteReader();
            while (readelt.Read())
            {
                label16.Text = (readelt["ID_EMPLOYEES"].ToString());
 
            }
            readelt.Close();
            conlt.Close();
            if(label14.Text == label16.Text)
            {
                leavesPart_time lt = new leavesPart_time(label14.Text);
                lt.Show();
                
            }
            else
            {
                //MessageBox.Show("ปกติ");
                textBox1.Show();
                label2.Show();
                dateTimePicker2.Show();
                label3.Show();
                dateTimePicker3.Show();
                button5.Show();
                textBox2.Show();
                label4.Show();
                label5.Show();
                comboBox1.Show();
                button6.Show();
                label2.Show();
                label20.Show();

            }
           
            /*string sql = "SELECT * FROM employee where ID_EMPLOYEES = '"+label14.Text+"' AND TYPEWORK_ID_TYPEWORK = LT000002";
            string ConnectString = "datasource = localhost; username= root;" +
                "password=; database = database;CharSet=UTF8";
            MySqlConnection con = new MySqlConnection(ConnectString);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();*/

            //DataSet ds = new DataSet();
            //MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            //da.Fill(ds);
            //dataGridView1.DataSource = ds.Tables[0].DefaultView;)
            //{

            //}


        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ConnectStringlt = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";
            MySqlConnection conlt = new MySqlConnection(ConnectStringlt);
            MySqlCommand cmdlt = new MySqlCommand("SELECT * FROM employee where ID_EMPLOYEES = '" + label14.Text + "'", conlt);
            conlt.Open();
            MySqlDataReader readelt = cmdlt.ExecuteReader();
            while (readelt.Read())
            {
                label21.Text = (readelt["ID_EMPLOYEES"].ToString());

            }
            readelt.Close();
            conlt.Close();
            if(label21.Text == label14.Text)
            {
                string sql = "SELECT ID_RECORDWORK,REC_STARTING_DATE,REC_GET_TIME,REC_OUT_TIME,EMPLOYEE_ID_EMPLOYEES FROM recordworks where EMPLOYEE_ID_EMPLOYEES = '"+ label21.Text + "'";
                string ConnectString = "datasource = localhost; username= root;" +
                    "password=; database = database;CharSet=UTF8";
                MySqlConnection con = new MySqlConnection(ConnectString);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
            }

            //string sql = "SELECT ID_RECORDWORK,REC_STARTING_DATE,REC_GET_TIME,REC_OUT_TIME,EMPLOYEE_ID_EMPLOYEES FROM recordworks";
            //string ConnectString = "datasource = localhost; username= root;" +
            //    "password=; database = database;CharSet=UTF8";
            //MySqlConnection con = new MySqlConnection(ConnectString);
            //MySqlCommand cmd = new MySqlCommand(sql, con);
            //con.Open();
            //DataSet ds = new DataSet();
            //MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            //da.Fill(ds);
            //dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker6_ValueChanged(object sender, EventArgs e)
        {
            /*string sqle = "SELECT * FROM recordworks REC_STARTING_DATE = '"+label16+"' where ";
            string ConnectStringh = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";
            MySqlConnection conh = new MySqlConnection(ConnectStringh);
            MySqlCommand cmdh = new MySqlCommand("SELECT * FROM recordworks where REC_STARTING_DATE = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' AND EMPLOYEE_ID_EMPLOYEES = '" + label14.Text + "'", conh);
            conh.Open();

            MySqlDataReader readeh = cmdh.ExecuteReader();
            while (readeh.Read())
            {
                label11.Text = (readeh["REC_GET_TIME"].ToString());
                label10.Text = (readeh["REC_OUT_TIME"].ToString());

            }
            readeh.Close();
            conh.Close();

            TimeSpan t1 = TimeSpan.Parse(label11.Text);
            TimeSpan t2 = TimeSpan.Parse(label10.Text);
            TimeSpan t3 = t1.Add(t2);
            label15.Text = t3.ToString();
            Console.WriteLine(t3);

            DateTime d1 = DateTime.Parse(label11.Text);
            DateTime d2 = DateTime.Parse(label10.Text);
            DateTime d3 = d1.Add(d2.TimeOfDay);
            label9.Text = t3.ToString();


            //label9.Text = hs1.Hours.ToString("HH:mm:ss");*/


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

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

        private void dateTimePicker5_ValueChanged(object sender, EventArgs e)
        {
            button7.Show();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
