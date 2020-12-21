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
    public partial class viewpro : Form
    {
        public viewpro(String Admin)
        {
            InitializeComponent();

            label3.Text = Admin;

            string ConnectString = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";
            MySqlConnection con = new MySqlConnection(ConnectString);
            con.Open();
            MySqlDataAdapter dd = new MySqlDataAdapter("SELECT ORDERS_ID_ORDERS,ORDER_DATE,PRODUCT_ID_PRODUCT,ORDETAIL_SUM,ORDETAIL_PRICEPIECE,ORDETAIL_PRICEALL FROM orders_detail INNER JOIN orders  ON orders_detail.ORDERS_ID_ORDERS=orders.ID_ORDERS", con);
            con.Close();
            MySqlCommandBuilder cb = new MySqlCommandBuilder(dd);
            DataTable table = new DataTable();
            dd.Fill(table);
            dataGridView1.DataSource = table;


            //cpmbo1
            string ConnectStringgg = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
            MySqlConnection con2 = new MySqlConnection(ConnectStringgg);
            con2.Open();
            MySqlDataAdapter dddd = new MySqlDataAdapter("SELECT * FROM ORDERS ", con2);
            DataSet dss = new DataSet();
            dddd.Fill(dss, "combolist");
            comboBox1.DataSource = dss;
            comboBox1.DisplayMember = "combolist.ID_ORDERS";
            comboBox1.ValueMember = "combolist.ID_ORDERS";
            con2.Close();
            
            
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" )
            {
                MessageBox.Show("กรุณาป้อนข้อมูลที่จะค้นหาให้ครบด้วยค่ะ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                string ConnectStringq = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
                MySqlConnection cona = new MySqlConnection(ConnectStringq);

                string dd = "SELECT ORDERS_ID_ORDERS,ORDER_DATE,PRODUCT_ID_PRODUCT,ORDETAIL_SUM,ORDETAIL_PRICEPIECE,ORDETAIL_PRICEALL FROM orders_detail INNER JOIN orders ON orders_detail.ORDERS_ID_ORDERS=orders.ID_ORDERS WHERE ORDERS_ID_ORDERS like '" + comboBox1.Text + "%'";
                MySqlCommand cm = new MySqlCommand(dd, cona);

                DataTable table = new DataTable();

                MySqlDataAdapter da = new MySqlDataAdapter(cm);
                da.Fill(table);
                dataGridView1.DataSource = table;
                //MessageBox.Show("อัพแล้วโว๊ยยยย!!");
              
                cona.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PRODUCTT a = new PRODUCTT(label3.Text);
            a.Show();
            Visible = false;
        }

        private void SearchAll_Click(object sender, EventArgs e)
        {
            string ConnectString = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
            MySqlConnection con = new MySqlConnection(ConnectString);
            con.Open();
            MySqlDataAdapter dd = new MySqlDataAdapter("SELECT ORDERS_ID_ORDERS,ORDER_DATE,PRODUCT_ID_PRODUCT,ORDETAIL_SUM,ORDETAIL_PRICEPIECE,ORDETAIL_PRICEALL FROM orders_detail INNER JOIN orders ON orders_detail.ORDERS_ID_ORDERS=orders.ID_ORDERS ", con);
            con.Close();
            MySqlCommandBuilder cb = new MySqlCommandBuilder(dd);
            DataTable table = new DataTable();


            dd.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
