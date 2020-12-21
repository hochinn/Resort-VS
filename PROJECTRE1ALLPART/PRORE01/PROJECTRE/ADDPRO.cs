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
    public partial class _2 : Form
    {
       

        public _2(String Admin)
        {
            InitializeComponent();

            label6.Text = Admin;
            textBox9.Enabled = false;
            textBox8.Enabled = false;
            textBox3.Enabled = false;
            //แสดงข้อมูลจากฐานข้อมูลตาราง orders
            string ConnectString = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
            MySqlConnection con = new MySqlConnection(ConnectString);
            con.Open();
            MySqlDataAdapter dd = new MySqlDataAdapter("SELECT * FROM product  ", con);
            con.Close();
            MySqlCommandBuilder cb = new MySqlCommandBuilder(dd);
            DataTable table = new DataTable();
            dd.Fill(table);
            dataGridView1.DataSource = table;

      

            //combobox2
            string ConnectStringgg = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
            MySqlConnection con2 = new MySqlConnection(ConnectStringgg);
            con2.Open();
            MySqlDataAdapter dddd = new MySqlDataAdapter("SELECT * FROM orders WHERE STATUS != 'รับครบถ้วน' && STATUS != 'ส่งเคลม' && STATUS != 'ส่งเคลมเสร็จสิ้น' ", con2);
            DataSet dss = new DataSet();
            dddd.Fill(dss, "combolist");
            comboBox2.DataSource = dss;
            comboBox2.DisplayMember = "combolist.ID_ORDERS";
            comboBox2.ValueMember = "combolist.ID_ORDERS";
            con2.Close();



        }
        DataTable tablee = new DataTable();
        private void _2_Load(object sender, EventArgs e)
        {
           
            // คอลัม์แสดงข้อมูลแบบไม่แอดเข้าฐานข้อมูล
            tablee.Columns.Add("รหัสใบสั่งซื้อ", typeof(string));
            tablee.Columns.Add("รหัสสินค้า", typeof(string));
            tablee.Columns.Add("จำนวนทั้งหมด", typeof(string));
            tablee.Columns.Add("ราคาต่อหน่วย", typeof(string));
            tablee.Columns.Add("ราคาทั้งหมด", typeof(string));
            tablee.Columns.Add("สถานะ", typeof(string));
            dataGridView2.DataSource = tablee;
        }

        private void sumcal_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || textBox8.Text == "")
            {
                MessageBox.Show("กรุณาป้อนข้อมูลให้ครบด้วยค่ะ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                double a, b, c;

                a = double.Parse(comboBox1.Text);
                b = double.Parse(textBox8.Text);
                c = a * b;
                textBox9.Text = c.ToString();

                
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1) return;
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PRODUCTT aa = new PRODUCTT(label6.Text);
            aa.Show();
            Visible = false;
        }



        private void button2_Click(object sender, EventArgs e)
        {

            if (comboBox2.Text == "" || textBox3.Text == "" || comboBox1.Text == "" || textBox8.Text == "" || textBox9.Text == "" || label7.Text == "")
            {
                MessageBox.Show("กรุณาป้อนข้อมูลให้ครบด้วยค่ะ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                string sqlT = "INSERT INTO orders_detail(ORDETAIL_SUM,ORDETAIL_PRICEPIECE,ORDETAIL_PRICEALL,STATUS,ORDERS_ID_ORDERS,PRODUCT_ID_PRODUCT) VALUES ('" + comboBox1.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + label7.Text + "','" + comboBox2.Text + "','" + textBox3.Text + "')";
        
                string ConnectStringT = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";

                MySqlConnection conT = new MySqlConnection(ConnectStringT);
                MySqlCommand cmdT = new MySqlCommand(sqlT, conT);
                conT.Open();
                MySqlDataReader readerT = cmdT.ExecuteReader();
                MessageBox.Show("เพิ่มสินค้าแล้ว ");

                //เพิ่มสถานะ
                string sqp = "UPDATE orders SET STATUS ='" + label7.Text + "' WHERE ID_ORDERS ='" + comboBox2.Text + "'";
                string ConnectStringr = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";
                MySqlConnection conp = new MySqlConnection(ConnectStringr);
                MySqlCommand cmdp = new MySqlCommand(sqp, conp);
                conp.Open();
                MySqlDataReader readerp = cmdp.ExecuteReader();

               
                //แอดเข้าในตารางเพิ่มดูว่าสั่งอะไรไป
                tablee.Rows.Add(comboBox2.Text, textBox3.Text, comboBox1.Text, textBox8.Text, textBox9.Text, label7.Text);
                dataGridView2.DataSource = tablee;

                textBox8.Clear();
                textBox9.Clear();
                textBox3.Clear();


            }




        }

        private void ClearDataproduct()
        {
            textBox3.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
