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

namespace PROJECTRE
{
    public partial class PROMOTION : Form
    {
        public PROMOTION(string User)
        {

            InitializeComponent();
            label10.Text = "USER : " + User;
            string ConnectString = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";
            MySqlConnection con = new MySqlConnection(ConnectString);
            con.Open();
            MySqlDataAdapter dd = new MySqlDataAdapter("SELECT * FROM promotion", con);
            con.Close();
            MySqlCommandBuilder cb = new MySqlCommandBuilder(dd);
            DataTable table = new DataTable();


            dd.Fill(table);
            dataGridView1.DataSource = table;
        }
        private void ClearDatapromotion()
        {
            IDpo.Clear();
            TOpo.Clear();
            textpo.Clear();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM promotion WHERE ID_PROMOTION ='" + IDpo.Text + "'AND PRO_NAME ='" + TOpo.Text + "'";
            string ConnectString = "datasource = localhost; username= root;" +
                "password=; database = database;CharSet=UTF8";
            string ConnectStrin = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";

            MySqlConnection co = new MySqlConnection(ConnectStrin);
            MySqlConnection con = new MySqlConnection(ConnectString);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            if (IDpo.Text == "" || TOpo.Text == "" || date1.Text == "" || date2.Text == "" || textpo.Text == "")
            {
                MessageBox.Show("กรุณาป้อนข้อมูลให้ครบด้วยค่ะ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                DataSet ds = new DataSet();
                DataSet ds2 = new DataSet();
                string dd = "SELECT * FROM promotion WHERE ID_PROMOTION ='" + IDpo.Text + "'";
                string dd2 = "SELECT * FROM promotion WHERE PRO_NAME ='" + TOpo.Text + "'";
                MySqlCommand cm = new MySqlCommand(dd, co);
                MySqlDataAdapter da = new MySqlDataAdapter(cm);
                MySqlCommand cm2 = new MySqlCommand(dd2, co);
                MySqlDataAdapter da2 = new MySqlDataAdapter(cm2);
                da.Fill(ds);
                da2.Fill(ds2);
                int i = ds.Tables[0].Rows.Count;
                int x = ds2.Tables[0].Rows.Count;
                if (i > 0)
                {
                    MessageBox.Show("มีไอดี " + IDpo.Text + " มีเเล้วค่ะ กรุณาเปลียน");
                    ds.Clear();
                }
                else if (x > 0)
                {
                    MessageBox.Show("หัวข้อ " + TOpo.Text + " เเล้วค่ะ กรุณาเปลียน");
                    ds.Clear();
                }
                else
                {
                    string sqlT = "INSERT INTO promotion (ID_PROMOTION,PRO_NAME,PRO_DETAIL,DATE_START,DATE_END) VALUES ('" + IDpo.Text + "','" + TOpo.Text + "','" + textpo.Text + "','" + date1.Text + "','" + date2.Text + "')";

                    string ConnectStringT = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";

                    MySqlConnection conT = new MySqlConnection(ConnectStringT);
                    MySqlCommand cmdT = new MySqlCommand(sqlT, conT);
                    conT.Open();
                    MySqlDataReader readerT = cmdT.ExecuteReader();
                    MessageBox.Show("ทำการเพิ่มโปรโมชั่นแล้วค่ะ !!");
                    //ทำให้ตารางมันอัพเดท
                    string ConnectStrinT = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";
                    MySqlConnection coT = new MySqlConnection(ConnectStrinT);

                    string ddT = "SELECT * FROM promotion";
                    MySqlCommand cmT = new MySqlCommand(ddT, coT);

                    DataTable tableT = new DataTable();

                    MySqlDataAdapter daT = new MySqlDataAdapter(cmT);
                    daT.Fill(tableT);
                    dataGridView1.DataSource = tableT;
                    //MessageBox.Show("อัพแล้วโว๊ยยยย!!");
                    ClearDatapromotion();
                    conT.Close();

                }

                //MessageBox.Show("อัพแล้วโว๊ยยยย!!");

                con.Close();

                //this.Hide();
                //Form2 w1 = new Form2();
                //w1.Show();
                //MessageBox.Show("LOGIN PASS");



                /*if ((readere.Read() == true)) <อันนี้คือส่วนของพนักงาน ยังไม่แน่ใจ เพราะยังไม่ได้ลองเชื่อมหน้าพนักงานจริง (เชื่อมแล้วเดี๋ยวแก้ให้)>
                {
                    this.Hide();
                    admin a1 = new admin(textBox1.Text);
                    //w1.Show();
                    //MessageBox.Show("LOGIN PASS");
                }*/
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (IDpo.Text == "" || TOpo.Text == "" || date1.Text == "" || date2.Text == "" || textpo.Text == "" )
            {
                MessageBox.Show("กรุณาป้อนข้อมูลให้ครบด้วยค่ะ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (IDpo.Text != "" && TOpo.Text != "" && textpo.Text != "" && date1.Text != "" && date2.Text != "")
            {
                string sql = "UPDATE promotion SET PRO_NAME = '" + TOpo.Text.Trim() + "',PRO_DETAIL = '" + textpo.Text.Trim() + "',DATE_START ='" + date1.Text.Trim() + "',DATE_END ='" + date2.Text.Trim() + "' WHERE ID_PROMOTION ='" + IDpo.Text.Trim() + "'";


                string ConnectString = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";

                MySqlConnection con = new MySqlConnection(ConnectString);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                MessageBox.Show("ทำการแก้ไข โปรโมชั่น แล้วค่ะ !!");

                string ConnectStrin = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";
                MySqlConnection co = new MySqlConnection(ConnectStrin);

                string dd = "SELECT * FROM promotion";
                MySqlCommand cm = new MySqlCommand(dd, co);

                DataTable table = new DataTable();

                MySqlDataAdapter da = new MySqlDataAdapter(cm);
                da.Fill(table);
                dataGridView1.DataSource = table;
                //MessageBox.Show("อัพแล้วโว๊ยยยย!!");
                ClearDatapromotion();
                con.Close();
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1) return;

            IDpo.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TOpo.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textpo.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            date1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            date2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            //ล็อคtextbox
            //textID.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (IDpo.Text == "" || TOpo.Text == "" || date1.Text == "" || date2.Text == "" || textpo.Text == "")
            {
                MessageBox.Show("กรุณาป้อนข้อมูลให้ครบด้วยค่ะ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (IDpo.Text != "" && TOpo.Text != "" && textpo.Text != "" && date1.Text != "" && date2.Text != "")
            {
                string sql = "DELETE FROM promotion WHERE ID_PROMOTION ='" + IDpo.Text.Trim() + "'";

                string ConnectString = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";

                MySqlConnection con = new MySqlConnection(ConnectString);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                MessageBox.Show("ทำการ ลบ รายการ โปรโมชั่น แล้วค่ะ !!");

                string ConnectStrin = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";
                MySqlConnection co = new MySqlConnection(ConnectStrin);

                string dd = "SELECT * FROM promotion";
                MySqlCommand cm = new MySqlCommand(dd, co);

                DataTable table = new DataTable();

                MySqlDataAdapter da = new MySqlDataAdapter(cm);
                da.Fill(table);
                dataGridView1.DataSource = table;
                //MessageBox.Show("อัพแล้วโว๊ยยยย!!");
                ClearDatapromotion();
                con.Close();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "ID โปรโมชั่น" && IDpo.Text == "")
            {
                MessageBox.Show("กรุณาป้อนข้อมูลที่จะค้นหาให้ครบด้วยค่ะ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (comboBox1.Text == "ชื่อหัวข้อ" && TOpo.Text == "")
            {
                MessageBox.Show("กรุณาป้อนข้อมูลที่จะค้นหาให้ครบด้วยค่ะ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }


            else if (comboBox1.Text == "ID โปรโมชั่น" && IDpo.Text != "")
            {
                string ConnectString = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";
                MySqlConnection con = new MySqlConnection(ConnectString);

                string dd = "SELECT * FROM promotion where ID_PROMOTION	 like '" + IDpo.Text + "%'";
                MySqlCommand cm = new MySqlCommand(dd, con);

                DataTable table = new DataTable();

                MySqlDataAdapter da = new MySqlDataAdapter(cm);
                da.Fill(table);
                dataGridView1.DataSource = table;
                //MessageBox.Show("อัพแล้วโว๊ยยยย!!");
                ClearDatapromotion();
                con.Close();
            }
            else if (comboBox1.Text == "ชื่อหัวข้อ" && TOpo.Text != "")
            {
                string ConnectString = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";
                MySqlConnection con = new MySqlConnection(ConnectString);

                string dd = "SELECT * FROM promotion where PRO_NAME like '" + TOpo.Text + "%'";
                MySqlCommand cm = new MySqlCommand(dd, con);

                DataTable table = new DataTable();

                MySqlDataAdapter da = new MySqlDataAdapter(cm);
                da.Fill(table);
                dataGridView1.DataSource = table;
                //MessageBox.Show("อัพแล้วโว๊ยยยย!!");
                ClearDatapromotion();
                con.Close();
            }

        }

        private void SearchAll_Click(object sender, EventArgs e)
        {
            string ConnectString = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";
            MySqlConnection con = new MySqlConnection(ConnectString);
            con.Open();
            MySqlDataAdapter dd = new MySqlDataAdapter("SELECT * FROM promotion", con);
            con.Close();
            MySqlCommandBuilder cb = new MySqlCommandBuilder(dd);
            DataTable table = new DataTable();


            dd.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ADMIN d = new ADMIN(label10.Text);
            d.Show();
            Visible = false;
        }
    }
}
