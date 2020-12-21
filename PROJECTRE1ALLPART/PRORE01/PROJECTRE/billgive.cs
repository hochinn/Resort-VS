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
    public partial class billgive : Form
    {
        int a, b, c;
       
        public billgive(string Admin)
        {
            InitializeComponent();


            textBox2.Enabled = false;
            textBox3.Enabled = false;

            label6.Text = Admin;

            label8.Text = label8.Text;

            //แสดงข้อมูลจากฐานข้อมูลตาราง 
            string ConnectString = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
            MySqlConnection con = new MySqlConnection(ConnectString);
            con.Open();
            //MySqlDataAdapter dd = new MySqlDataAdapter("SELECT * FROM orders_detail WHERE STATUS != 'รับครบถ้วน'", con);
            MySqlDataAdapter dd = new MySqlDataAdapter("SELECT ID_ORDERS_DEATAIL,ORDERS_ID_ORDERS,PRODUCT_ID_PRODUCT,ORDETAIL_SUM,ORDETAIL_PRICEPIECE,ORDETAIL_PRICEALL,STATUS FROM orders_detail WHERE STATUS != 'รับครบถ้วน' && STATUS !='ส่งเคลม'", con);
            con.Close();
            MySqlCommandBuilder cb = new MySqlCommandBuilder(dd);
            DataTable table = new DataTable();
            dd.Fill(table);
            dataGridView1.DataSource = table;

            //combobox2
            string ConnectStringgg = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
            MySqlConnection con2 = new MySqlConnection(ConnectStringgg);
            con2.Open();
            MySqlDataAdapter dddd = new MySqlDataAdapter("SELECT * FROM bill_of_lading WHERE STATUS != 'รับครบถ้วน' && STATUS != 'ส่งเคลม'  ", con2);
            DataSet dss = new DataSet();
            dddd.Fill(dss, "combolist");
            comboBox2.DataSource = dss;
            comboBox2.DisplayMember = "combolist.ID_BILL";
            comboBox2.ValueMember = "combolist.ID_BILL";
            con2.Close();

        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            a = int.Parse(textBox2.Text);
            b = int.Parse(textBox1.Text);
            int plus =0;
            
         
            if (b>a)
            {
                MessageBox.Show("กรุณากรอกรับสินค้าน้อยกว่าจำนวนทั้งหมดด้วยค่ะ");

            }
            if (comboBox3.Text == "" || textBox3.Text == "" || textBox3.Text == "" || textBox2.Text == "" || textBox1.Text == "" || label7.Text == "")
            {
                MessageBox.Show("กรุณาป้อนข้อมูลให้ครบด้วยค่ะ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (a == b && comboBox3.Text != "ส่งเคลม" || b < a && comboBox3.Text != "รับครบถ้วน")
            {
                // ข้อมูลเข้าตาราง  detail_bill_of_lading
                string sqlT = "INSERT INTO detail_bill_of_lading(DETAILBILL_SUM,NUMCLAIM,STATUS,BILL_OF_LADING_ID_BILL,PRODUCT_ID_PRODUCT) VALUES ('" + textBox1.Text + "','" + label8.Text + "','" + comboBox3.Text + "','" + comboBox2.Text + "','" + textBox3.Text + "')";

                string ConnectStringT = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";

                MySqlConnection conT = new MySqlConnection(ConnectStringT);
                MySqlCommand cmdT = new MySqlCommand(sqlT, conT);
                conT.Open();
                MySqlDataReader readerT = cmdT.ExecuteReader();
                MessageBox.Show("รับสินค้าแล้ว ");


                //คำนวนข้อมูลเข้า product
                string sqpwz = "SELECT * FROM product WHERE ID_PRODUCT = '" + textBox3.Text + "'";
                string ConnectStringrwz = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";
                MySqlConnection conpwz = new MySqlConnection(ConnectStringrwz);
                MySqlCommand cmdpwz = new MySqlCommand(sqpwz, conpwz);
                conpwz.Open();
                MySqlDataReader reader = cmdpwz.ExecuteReader();
                while (reader.Read())
                {
                    plus = int.Parse(reader["PRO_NUM"].ToString());

                }
                reader.Close();
                conpwz.Close();
                plus = plus + int.Parse(textBox1.Text);

                string sqpw = "UPDATE product SET PRO_NUM ='" + plus.ToString() + "'WHERE ID_PRODUCT = '" + textBox3.Text + "'";
                string ConnectStringrw = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";
                MySqlConnection conpw = new MySqlConnection(ConnectStringrw);
                MySqlCommand cmdpw = new MySqlCommand(sqpw, conpw);
                conpw.Open();
                MySqlDataReader readerpw = cmdpw.ExecuteReader();



                //update orders_detail
                string sqpww = "UPDATE orders_detail SET STATUS ='" + comboBox3.Text + "' WHERE ID_ORDERS_DEATAIL ='"+label10.Text+"'";
                string ConnectStringrww = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";
                MySqlConnection conpww = new MySqlConnection(ConnectStringrww);
                MySqlCommand cmdpww = new MySqlCommand(sqpww, conpww);
                conpww.Open();
                MySqlDataReader readerpww = cmdpww.ExecuteReader();

                //update orders
                string sqpwwe = "UPDATE orders SET STATUS ='" + comboBox3.Text + "' WHERE ID_ORDERS ='" + label12.Text + "'";
                string ConnectStringrwwe = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";
                MySqlConnection conpwwe = new MySqlConnection(ConnectStringrwwe);
                MySqlCommand cmdpwwe = new MySqlCommand(sqpwwe, conpwwe);
                conpwwe.Open();
                MySqlDataReader readerpwwe = cmdpwwe.ExecuteReader();

                //update บิล
                string sqpwwey = "UPDATE bill_of_lading SET STATUS ='" + comboBox3.Text + "' WHERE ID_BILL ='" + comboBox2.Text + "'";
                string ConnectStringrwwey = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";
                MySqlConnection conpwwey = new MySqlConnection(ConnectStringrwwey);
                MySqlCommand cmdpwwey = new MySqlCommand(sqpwwey, conpwwey);
                conpwwey.Open();
                MySqlDataReader readerpwwey = cmdpwwey.ExecuteReader();


               
                


            }
          
           
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            a = int.Parse(textBox2.Text);
            b = int.Parse(textBox1.Text);
            if (a == b && comboBox3.Text == "ส่งเคลม")
            {
                MessageBox.Show("ไม่ต้องส่งเคลมคะ");
            }
            else if(b<a && comboBox3.Text == "รับครบถ้วน")
            {
                MessageBox.Show("มีการส่งเคลมค่ะ");
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1) return;
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            label12.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            label10.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

        }

       
        private void button3_Click(object sender, EventArgs e)
        {
            //int a, b, c;
            a = int.Parse(textBox2.Text);
            b = int.Parse(textBox1.Text);
            if (textBox2.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("กรุณาป้อนข้อมูลให้ครบด้วยค่ะ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            else if (a < b)
            {

                MessageBox.Show("กรุณาใส่สินค้าที่รับให้น้อยกว่าสินค้าทั้งหมดด้วยคะ");

            }
            else if (a == b || b == 0)
            {
                MessageBox.Show("ไม่ต้องทำการส่งเคลม");
               

            }
            else
            {
                c = a - b;
                label8.Text = c.ToString();
            }
        }

       
       
    }
}
