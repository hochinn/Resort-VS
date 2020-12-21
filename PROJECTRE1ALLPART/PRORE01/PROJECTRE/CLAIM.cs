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
    public partial class CLAIM : Form
    {
        public CLAIM(string Admin)
        {
            InitializeComponent();


            label6.Text = Admin;

            //dataตาราง
            string ConnectString = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";
            MySqlConnection con = new MySqlConnection(ConnectString);
            con.Open();
            MySqlDataAdapter dd = new MySqlDataAdapter("SELECT * FROM claim", con);
            con.Close();
            MySqlCommandBuilder cb = new MySqlCommandBuilder(dd);
            DataTable table = new DataTable();
            dd.Fill(table);
            dataGridView1.DataSource = table;



            //combobox1
            string ConnectStringgg = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
            MySqlConnection con2 = new MySqlConnection(ConnectStringgg);
            con2.Open();
            MySqlDataAdapter dddd = new MySqlDataAdapter("SELECT * FROM bill_of_lading", con2);
            DataSet dss = new DataSet();
            dddd.Fill(dss, "combolist");
            comboBox1.DataSource = dss;
            comboBox1.DisplayMember = "combolist.ID_BILL";
            comboBox1.ValueMember = "combolist.ID_BILL";
            con2.Close();

            //combobox2
            string ConnectStringggg = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
            MySqlConnection con2g = new MySqlConnection(ConnectStringggg);
            con2g.Open();
            MySqlDataAdapter ddddg = new MySqlDataAdapter("SELECT * FROM orders", con2g);
            DataSet dssg = new DataSet();
            ddddg.Fill(dssg, "combolist");
            comboBox2.DataSource = dssg;
            comboBox2.DisplayMember = "combolist.ID_ORDERS";
            comboBox2.ValueMember = "combolist.ID_ORDERS";
            con2g.Close();

            //combobox3
            string ConnectStringggq = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
            MySqlConnection con2q = new MySqlConnection(ConnectStringggq);
            con2q.Open();
            MySqlDataAdapter ddddq = new MySqlDataAdapter("SELECT * FROM company ", con2q);
            DataSet dssq = new DataSet();
            ddddq.Fill(dssq, "combolist");
            comboBox3.DataSource = dssq;
            comboBox3.DisplayMember = "combolist.ID_COMPANY";
            comboBox3.ValueMember = "combolist.ID_COMPANY";
            con2q.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || dateTimePicker1.Text == "" ||comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "")
            {
                MessageBox.Show("กรุณาป้อนข้อมูลให้ครบด้วยค่ะ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {

                string sql = "SELECT * FROM claim WHERE  ID_CLAIM ='" + textBox1.Text + "'";

                string ConnectStrin = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
                MySqlConnection coq = new MySqlConnection(ConnectStrin);
                MySqlCommand cmdz = new MySqlCommand(sql, coq);

                coq.Open();
                MySqlDataReader reader = cmdz.ExecuteReader();
                DataSet s = new DataSet();
                string ConnectStrinz = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
                string sqlq = "SELECT * FROM claim WHERE  ID_CLAIM ='" + textBox1.Text + "'";
                MySqlConnection coqq = new MySqlConnection(ConnectStrinz);
                MySqlCommand cm = new MySqlCommand(sqlq, coqq);
                MySqlDataAdapter da = new MySqlDataAdapter(cm);

                da.Fill(s);
                int i = s.Tables[0].Rows.Count;
                if (i > 0)
                {
                    MessageBox.Show("มีรหัสการเคลม " + textBox1.Text + " แล้วกรุณาเปลี่ยน");
                    s.Clear();
                }
                else
                {
                    string sqlT = "INSERT INTO claim(ID_CLAIM,CLAIM_DATE,STATUS,BILL_OF_LADING_ID_BILL,ORDERS_ID_ORDERS,EMPLOYEE_ID_EMPLOYEES,COMPANY_ID_COMPANY) VALUES ('" + textBox1.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + label7.Text + "','" + comboBox2.Text + "','" + comboBox1.Text + "','" + label6.Text + "','" + comboBox3.Text + "')";

                    string ConnectStringT = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";

                    MySqlConnection conT = new MySqlConnection(ConnectStringT);
                    MySqlCommand cmdT = new MySqlCommand(sqlT, conT);
                    conT.Open();
                    MySqlDataReader readerT = cmdT.ExecuteReader();
                    MessageBox.Show("เพิ่มการเคลมแล้ว");

                    detailclaim uy = new detailclaim(label6.Text);
                    uy.Show();

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            detailclaim uy = new detailclaim(label6.Text);
            uy.Show();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
    }
}
