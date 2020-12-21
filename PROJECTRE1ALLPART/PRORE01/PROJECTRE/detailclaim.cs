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
    public partial class detailclaim : Form
    {
        public detailclaim(string Admin)
        {
            InitializeComponent();

            textBox2.Enabled = false;
            textBox3.Enabled = false;

            label6.Text = Admin;

            //dataตาราง
            string ConnectString = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";
            MySqlConnection con = new MySqlConnection(ConnectString);
            con.Open();
            MySqlDataAdapter dd = new MySqlDataAdapter("SELECT ID_DETAIL_BILL,NUMCLAIM,BILL_OF_LADING_ID_BILL,PRODUCT_ID_PRODUCT,STATUS FROM detail_bill_of_lading", con);
            con.Close();
            MySqlCommandBuilder cb = new MySqlCommandBuilder(dd);
            DataTable table = new DataTable();
            dd.Fill(table);
            dataGridView1.DataSource = table;


            //combobox1
            string ConnectStringgg = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
            MySqlConnection con2 = new MySqlConnection(ConnectStringgg);
            con2.Open();
            MySqlDataAdapter dddd = new MySqlDataAdapter("SELECT * FROM claim", con2);
            DataSet dss = new DataSet();
            dddd.Fill(dss, "combolist");
            comboBox2.DataSource = dss;
            comboBox2.DisplayMember = "combolist.ID_CLAIM";
            comboBox2.ValueMember = "combolist.ID_CLAIM";
            con2.Close();



        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1) return;
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            label8.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int plus = 0;

            if (comboBox2.Text == "" || textBox3.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("กรุณาป้อนข้อมูลให้ครบด้วยค่ะ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                string sqlT = "INSERT INTO detail_claim(DETAILPICK_NUM,STATUS,PRODUCT_ID_PRODUCT,CLAIM_ID_CLAIM,DETAIL_BILL_OF_LADING_ID_DETAIL_BILL) VALUES ('" + label8.Text + "','" + label11.Text + "','" + textBox3.Text + "','" + comboBox2.Text + "','" + textBox2.Text + "')";

                string ConnectStringT = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";

                MySqlConnection conT = new MySqlConnection(ConnectStringT);
                MySqlCommand cmdT = new MySqlCommand(sqlT, conT);
                conT.Open();
                MySqlDataReader readerT = cmdT.ExecuteReader();
                MessageBox.Show("เคลมเสร็จสิ้น ");




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
                plus = plus + int.Parse(label8.Text);

                string sqpw = "UPDATE product SET PRO_NUM ='" + plus.ToString() + "'WHERE ID_PRODUCT = '" + textBox3.Text + "'";
                string ConnectStringrw = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";
                MySqlConnection conpw = new MySqlConnection(ConnectStringrw);
                MySqlCommand cmdpw = new MySqlCommand(sqpw, conpw);
                conpw.Open();
                MySqlDataReader readerpw = cmdpw.ExecuteReader();



                //update orders_detail
                string sqpww = "UPDATE orders_detail SET STATUS ='" + label11.Text + "' WHERE ID_ORDERS_DEATAIL ='" + label10.Text + "'";
                string ConnectStringrww = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";
                MySqlConnection conpww = new MySqlConnection(ConnectStringrww);
                MySqlCommand cmdpww = new MySqlCommand(sqpww, conpww);
                conpww.Open();
                MySqlDataReader readerpww = cmdpww.ExecuteReader();

                //update orders
                string sqpwwe = "UPDATE orders SET STATUS ='" + label11.Text + "' WHERE ID_ORDERS ='" + label12.Text + "'";
                string ConnectStringrwwe = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";
                MySqlConnection conpwwe = new MySqlConnection(ConnectStringrwwe);
                MySqlCommand cmdpwwe = new MySqlCommand(sqpwwe, conpwwe);
                conpwwe.Open();
                MySqlDataReader readerpwwe = cmdpwwe.ExecuteReader();

                //update บิล
                string sqpwwey = "UPDATE bill_of_lading SET STATUS ='" + label11.Text + "' WHERE ID_BILL ='" + comboBox2.Text + "'";
                string ConnectStringrwwey = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";
                MySqlConnection conpwwey = new MySqlConnection(ConnectStringrwwey);
                MySqlCommand cmdpwwey = new MySqlCommand(sqpwwey, conpwwey);
                conpwwey.Open();
                MySqlDataReader readerpwwey = cmdpwwey.ExecuteReader();
            }
        }
    }
}
