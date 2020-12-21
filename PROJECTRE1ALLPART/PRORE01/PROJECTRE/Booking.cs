using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.Win32;

namespace PROJECTRE
{
    public partial class Booking : Form
    {
        static String people;
        static String ID;
        static String gv; 
        static int price=0;
        static int numday=0;
        static DateTime days ;

        static int total;
        static int numrooms;
        public Booking(string User)
        {
            InitializeComponent();
            label16.Text = "USER :";
            label17.Text = User;

            textBox2.Enabled= false;

            string ConnectStrin = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
            //string ConnectStri = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
            MySqlConnection co = new MySqlConnection(ConnectStrin);
            // MySqlConnection c = new MySqlConnection(ConnectStri);
            co.Open();
            // c.Open();
            MySqlDataAdapter ddd = new MySqlDataAdapter("SELECT ROOMTYPE_NAME,ROOM_PRICEROOM,ROOMTYPE_MAX_PEOPLE FROM roomtype NATURAL JOIN rooms WHERE rooms.ROOMTYPE_ID_ROOMTYPE=roomtype.ID_ROOMTYPE GROUP BY ID_ROOMTYPE", co);
            // MySqlDataAdapter dddd = new MySqlDataAdapter("SELECT * FROM rooms", c);
            co.Close();
            // c.Close();
            MySqlCommandBuilder cbb = new MySqlCommandBuilder(ddd);
            // MySqlCommandBuilder cbbb = new MySqlCommandBuilder(dddd);
            DataTable table1 = new DataTable();
            // DataTable table2 = new DataTable();
            ddd.Fill(table1);
            // ddd.Fill(table2);
            dataGridtype.DataSource = table1;
            //dataGriddetailroom.DataSource = table;

            string ConnectStringgg = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
            MySqlConnection con2 = new MySqlConnection(ConnectStringgg);
            con2.Open();
            MySqlDataAdapter dddd = new MySqlDataAdapter("SELECT * FROM member WHERE USENAME = '" + label17.Text + "'", con2);
            DataSet dss = new DataSet();
            dddd.Fill(dss, "combolist");
            comboBox1.DataSource = dss;
            comboBox1.DisplayMember = "combolist.ID MEMBER";
            comboBox1.ValueMember = "combolist.ID MEMBER";
            con2.Close();


           


        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt1 = Convert.ToDateTime(dateTimePicker1.Text);
            DateTime dt2 = Convert.ToDateTime(dateTimePicker2.Text);
            TimeSpan ts = dt2 - dt1;
            
            if (dt2 < dt1)
            {
                ts = dt2 - dt2;
                textBox2.Text = ts.Days.ToString();
                numday = int.Parse(textBox2.Text);
                textBox2.Enabled = false;
            }
            else
            {
                textBox2.Text = ts.Days.ToString();
                numday = int.Parse(textBox2.Text);
                textBox2.Enabled = false;
                if (price != 0)
                {
                    textBox3.Text = (numday * price).ToString();
                    textBox3.Enabled = false;
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt1 = Convert.ToDateTime(dateTimePicker1.Text);
            DateTime dt2 = Convert.ToDateTime(dateTimePicker2.Text);
            TimeSpan ts = dt2 - dt1;
            if (dt2 < dt1)
            {
                ts = dt2 - dt2;
                textBox2.Text = ts.Days.ToString();
                numday = int.Parse(textBox2.Text);
                textBox2.Enabled = false;
            }
            else
            {
                textBox2.Text = ts.Days.ToString();
                numday = int.Parse(textBox2.Text);
                textBox2.Enabled = false;
                if (price != 0)
                {
                    textBox3.Text = (numday * price).ToString();
                    textBox3.Enabled = false;
                }

            }
        }

        private void label10_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridtype_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //int a, b, c;
            //int rowClick = dataGridtype.CurrentRow.Index;
            //label6.Text = dataGridtype.Rows[rowClick].Cells[0].Value.ToString();
            //gv = dataGridtype.Rows[rowClick].Cells[1].Value.ToString();
            //people = dataGridtype.Rows[rowClick].Cells[2].Value.ToString();
            //if (numday != 0)
            //{
            //    price = int.Parse(gv);
            //    textBox3.Text = (numday * price).ToString();
            //    textBox3.Enabled = false;
            //}
            //else
            //{
            //    price = int.Parse(gv);
            //}
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void buttonBooking_Click(object sender, EventArgs e)
        {
            string sqlT;
            if (textBox4.Text == "")
            {
                sqlT = "INSERT INTO booking (BOOK_DATE,BOOK_DEPOSIT,BOOK_SUMTOTAL,BOOK_EVIDENCE,BOOK_PAY_DATE,BOOK_STATUS,MEMBER_ID_MEMBER) VALUES ('" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + label11.Text + "','" + textBox6.Text + "','" + textBox1.Text + "','" + label19.Text + "','รอตรวจสอบ','" + comboBox1.Text + "')";
            }
            else
            {
                sqlT = "INSERT INTO booking (BOOK_DATE,BOOK_DEPOSIT,BOOK_SUMTOTAL,BOOK_EVIDENCE,BOOK_PAY_DATE,BOOK_STATUS,DETAIL_PROMOTION_ID_DETAIL_PROMOTION,MEMBER_ID_MEMBER) VALUES ('" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + label11.Text + "','" + textBox6.Text + "','" + textBox1.Text + "','" + label19.Text + "','รอตรวจสอบ','" + textBox4.Text + "','" + comboBox1.Text + "')";
            }
            string ConnectStringT = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
            days = Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yyyy"));
            TimeSpan ppp = Convert.ToDateTime(dateTimePicker1.Text) - days;
            if (int.Parse(ppp.Days.ToString()) <= 0 || textBox3.Text ==""|| textBox2.Text == ""|| textBox1.Text == ""|| comboBox1.Text=="")
            {
                MessageBox.Show("กรุณาป้อนข้อมูลให้ถูกต้องด้วยค่ะ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else{
                MySqlConnection conT = new MySqlConnection(ConnectStringT);
                MySqlCommand cmdT = new MySqlCommand(sqlT, conT);
                conT.Open();
                MySqlDataReader readerT = cmdT.ExecuteReader();
                MessageBox.Show("ทำการเพิ่มรายการแล้วค่ะ !!");

                string ConnectStringggg = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
                MySqlConnection con22 = new MySqlConnection(ConnectStringggg);
                MySqlCommand dddd = new MySqlCommand("SELECT * FROM member WHERE USENAME = '" + label17.Text + "'", con22);
                con22.Open();
                MySqlDataReader reader = dddd.ExecuteReader();
                while (reader.Read())
                {
                    ID = (reader["ID MEMBER"].ToString());

                }
                reader.Close();
                con22.Close();
                string id_book="";
                string ConnectStrin = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
                MySqlConnection co = new MySqlConnection(ConnectStrin);
                MySqlCommand ddd = new MySqlCommand("SELECT * FROM booking WHERE MEMBER_ID_MEMBER = '" + ID.ToString() + "' GROUP BY ID_BOOKING order by ID_BOOKING desc limit 0,1", co);
                co.Open();
                MySqlDataReader reader2 = ddd.ExecuteReader();
                while (reader2.Read())
                {
                    id_book = (reader2["ID_BOOKING"].ToString());

                }
                reader2.Close();
                co.Close();
                for (int i=0;i<int.Parse(comboBox2.Text);i++)
                {
                    string add = "INSERT INTO bookdetail (BOOKTAIL_CHECKIN,BOOKTAIL_CHECKOUT,BOOKTAIL_NUMDAY,BOOKTAIL_PRICEROOM,BOOKTAIL_PRICETOTAL,BOOKING_ID_BOOKING) VALUES ('" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "','"+ textBox2.Text + "','"+price.ToString()+"','"+ textBox3.Text+ "','"+id_book.ToString()+"')";
                    string ConnectStringT7 = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
                    MySqlConnection conT7 = new MySqlConnection(ConnectStringT7);
                    MySqlCommand cmdT7 = new MySqlCommand(add, conT7);
                    conT7.Open();
                    MySqlDataReader readerT7 = cmdT7.ExecuteReader();
                }
                MessageBox.Show("ทำการเพิ่มรายการแล้วค่ะ 2!!");



            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = ".jpg";
            ofd.Filter = "jpg|*.jpg";
            DialogResult res = ofd.ShowDialog();
            String filename="";
            if (res == DialogResult.OK)
            {
                filename = ofd.FileName;
                string fileName2 = System.IO.Path.GetFileName(filename);
                textBox1.Text = fileName2;


                /*for (int i=filename.Length-1;i>0;i--)
               {
                   string check = filename.Substring(i-1, i);
                   if (check.Equals("\\")) { 

                       filename = filename.Substring(i, filename.Length);
                       break;
                   }
               }*/
            }
         
            
            label19.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text=="")
            {
                numrooms = int.Parse(comboBox2.Text);

            }
            else
            {
                numrooms = int.Parse(comboBox2.Text);
                total = (numrooms * total);
                textBox6.Text = total.ToString();
                textBox6.Enabled = false;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "")
            {
                total = int.Parse(textBox3.Text);
            }
            else
            {
                total = int.Parse(textBox3.Text);
                total = (numrooms * total);
                textBox6.Text = total.ToString();
                textBox6.Enabled = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Book_detail dd = new Book_detail(label17.Text);

            dd.Show();
            Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            member pp = new member(label17.Text);
            pp.Show();
            Visible = false;
        }

        private void dataGridtype_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int a, b, c;
            int rowClick = dataGridtype.CurrentRow.Index;
             label6.Text = dataGridtype.Rows[e.RowIndex].Cells[0].Value.ToString();
            gv = dataGridtype.Rows[e.RowIndex].Cells[1].Value.ToString();
            people = dataGridtype.Rows[e.RowIndex].Cells[2].Value.ToString();
            if (numday != 0)
            {
                price = int.Parse(gv);
                textBox3.Text = (numday * price).ToString();
                textBox3.Enabled = false;
            }
            else
            {
                price = int.Parse(gv);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                numrooms = int.Parse(comboBox2.Text);

            }
            else
            {
                numrooms = int.Parse(comboBox2.Text);
                total = (numrooms * total);
                textBox6.Text = total.ToString();
                textBox6.Enabled = false;
            }
        }
    }
}
