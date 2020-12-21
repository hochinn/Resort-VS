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
using System.Globalization;
using System.Threading;
using hotal;

namespace PROJECTRE
{
    public partial class PRODUCTT : Form
    {
        public PRODUCTT(string Admin)
        {
            InitializeComponent();

            textBox2.Text = Admin;
            textBox2.Enabled = false;


            dateTimePicker1.Enabled = false;
            //dataตาราง
            string ConnectString = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";
            MySqlConnection con = new MySqlConnection(ConnectString);
            con.Open();
            MySqlDataAdapter dd = new MySqlDataAdapter("SELECT * FROM orders WHERE STATUS != 'จ่ายแล้ว'", con);
            con.Close();
            MySqlCommandBuilder cb = new MySqlCommandBuilder(dd);
            DataTable table = new DataTable();
            dd.Fill(table);
            dataGridView1.DataSource = table;

        

            //combobox3
            string ConnectStringgg = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
            MySqlConnection con2 = new MySqlConnection(ConnectStringgg);
            con2.Open();
            MySqlDataAdapter dddd = new MySqlDataAdapter("SELECT * FROM company", con2);
            DataSet dss = new DataSet();
            dddd.Fill(dss, "combolist");
            comboBox3.DataSource = dss;
            comboBox3.DisplayMember = "combolist.ID_COMPANY";
            comboBox3.ValueMember = "combolist.ID_COMPANY";
            con2.Close();

          

        }

       

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.RowIndex == -1) return;
            //textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            //textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {
          
        }

      
        private void button3_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "" || dateTimePicker1.Text =="" || label7.Text =="" || comboBox3.Text =="")
            {
                MessageBox.Show("กรุณาป้อนข้อมูลให้ครบด้วยค่ะ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {


                string sql = "SELECT * FROM orders WHERE  ID_ORDERS ='" + textBox1.Text + "'";

                string ConnectStrin = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
                MySqlConnection coq = new MySqlConnection(ConnectStrin);
                MySqlCommand cmdz = new MySqlCommand(sql, coq);


                coq.Open();
                MySqlDataReader reader = cmdz.ExecuteReader();
                DataSet s = new DataSet();
                string ConnectStrinz = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
                string sqlq = "SELECT * FROM orders WHERE  ID_ORDERS ='" + textBox1.Text + "'";
                MySqlConnection coqq = new MySqlConnection(ConnectStrinz);
                MySqlCommand cm = new MySqlCommand(sqlq, coqq);
                MySqlDataAdapter da = new MySqlDataAdapter(cm);
                
                da.Fill(s);
                int i = s.Tables[0].Rows.Count;
                if (i > 0)
                {
                    MessageBox.Show("มีรหัสสั่งซื้อ " + textBox1.Text + " แล้วกรุณาเปลี่ยน");
                    s.Clear();
                }
                else
                {
                    string sqlT = "INSERT INTO orders(ID_ORDERS,ORDER_DATE,STATUS,COMPANY_ID_COMPANY,EMPLOYEE_ID_EMPLOYEES) VALUES ('" + textBox1.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + label7.Text + "','" + comboBox3.Text + "','" + textBox2.Text + "')";

                    string ConnectStringT = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";

                    MySqlConnection conT = new MySqlConnection(ConnectStringT);
                    MySqlCommand cmdT = new MySqlCommand(sqlT, conT);
                    conT.Open();
                    MySqlDataReader readerT = cmdT.ExecuteReader();
              



                    _2 m = new _2(textBox2.Text);
                    m.Show();
                    Visible = false;



                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            viewpro a = new viewpro(textBox2.Text);
            a.Show();
            Visible = false;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            TheProduct TheProduct = new TheProduct();
            TheProduct.Show();
     
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            PRODUCTSTOCK qq = new PRODUCTSTOCK(textBox2.Text);
            qq.Show();
            Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _2 m = new _2(textBox2.Text);
            m.Show();
            Visible = false;
        }
    }
}
