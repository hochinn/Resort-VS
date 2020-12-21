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
    public partial class BILLOFLADING : Form
    {
        public BILLOFLADING(string Admin)
        {
            InitializeComponent();
            label4.Text = Admin;

            dateTimePicker1.Enabled = false;

            //โชว์ตาราง
            string ConnectString = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";
            MySqlConnection con = new MySqlConnection(ConnectString);
            con.Open();
            MySqlDataAdapter dd = new MySqlDataAdapter("SELECT * FROM bill_of_lading ", con);
            con.Close();
            MySqlCommandBuilder cb = new MySqlCommandBuilder(dd);
            DataTable table = new DataTable();
            dd.Fill(table);
            dataGridView1.DataSource = table;


            //combobox3
            string ConnectStringgg = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
            MySqlConnection con2 = new MySqlConnection(ConnectStringgg);
            con2.Open();
            MySqlDataAdapter dddd = new MySqlDataAdapter("SELECT * FROM orders WHERE STATUS != 'รับครบถ้วน'  && STATUS != 'ส่งเคลม'", con2);
            DataSet dss = new DataSet();
            dddd.Fill(dss, "combolist");
            comboBox3.DataSource = dss;
            comboBox3.DisplayMember = "combolist.ID_ORDERS";
            comboBox3.ValueMember = "combolist.ID_ORDERS";
            con2.Close();




        }

        private void button1_Click(object sender, EventArgs e)
        {
            PRODUCTSTOCK aa = new PRODUCTSTOCK(label4.Text);
            aa.Show();
            Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
            if (textBox1.Text == "" || label4.Text=="" || label7.Text==""|| dateTimePicker1.Text == ""|| comboBox3.Text=="")
            {
                MessageBox.Show("กรุณาป้อนข้อมูลให้ครบด้วยค่ะ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                string sql = "SELECT * FROM bill_of_lading WHERE  ID_BILL ='" + textBox1.Text + "'";

                string ConnectStrin = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
                MySqlConnection coq = new MySqlConnection(ConnectStrin);
                MySqlCommand cmdz = new MySqlCommand(sql, coq);


                coq.Open();
                MySqlDataReader reader = cmdz.ExecuteReader();


                DataSet s = new DataSet();
                string ConnectStrinz = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
                string sqlq = "SELECT * FROM bill_of_lading WHERE  ID_BILL ='" + textBox1.Text + "'";
                MySqlConnection coqq = new MySqlConnection(ConnectStrinz);
                MySqlCommand cm = new MySqlCommand(sqlq, coqq);
                MySqlDataAdapter da = new MySqlDataAdapter(cm);

                da.Fill(s);
                int i = s.Tables[0].Rows.Count;
                if (i > 0)
                {
                    MessageBox.Show("มีรหัสรับสินค้า " + textBox1.Text + " แล้วกรุณาเปลี่ยน");
                    s.Clear();
                }
                else
                {
                    string sqlT = "INSERT INTO bill_of_lading(ID_BILL,BILL_DATE,STATUS,EMPLOYEE_ID_EMPLOYEES,ORDERS_ID_ORDERS) VALUES ('" + textBox1.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + label7.Text + "','" + label4.Text + "','" + comboBox3.Text + "')";

                    string ConnectStringT = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";

                    MySqlConnection conT = new MySqlConnection(ConnectStringT);
                    MySqlCommand cmdT = new MySqlCommand(sqlT, conT);
                    conT.Open();
                    MySqlDataReader readerT = cmdT.ExecuteReader();
                    MessageBox.Show("กดปุ่มรับสินค้าเพื่อทำการรับเข้าสต็อคสินค้า");             

                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
           
                billgive y = new billgive(label4.Text);
                y.Show();
      
        }

        private void BILLOFLADING_Load(object sender, EventArgs e)
        {

        }
    }
}
