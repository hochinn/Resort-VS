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

namespace hotal
{
    public partial class TheProduct : Form
    {
        public TheProduct()
        {
            InitializeComponent();
            //แสดงหน้าจอรายการproduct
      
            string ConnectString = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
            MySqlConnection con = new MySqlConnection(ConnectString);
            con.Open();
            MySqlDataAdapter dd = new MySqlDataAdapter("SELECT * FROM product", con);
            con.Close();
            MySqlCommandBuilder cb = new MySqlCommandBuilder(dd);
            DataTable table = new DataTable();


            dd.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        ///ปุ่มเพิ่มข้อมูลลงไปในตารางข้อมูล 
        {
            string sql = "SELECT * FROM product WHERE ID_PRODUCT ='" + textID.Text + "'AND PRO_NAME ='" + textName.Text + "'";
            string ConnectString = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
            string ConnectStrin = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
            MySqlConnection co = new MySqlConnection(ConnectStrin);
            MySqlConnection con = new MySqlConnection(ConnectString);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            
            if (textID.Text == "" || textName.Text == "" || textNumber.Text == "" || textPrice.Text == "")
            {
                MessageBox.Show("กรุณาป้อนข้อมูลให้ครบด้วยค่ะ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          
            }
            else
            {
                DataSet ds = new DataSet();
                DataSet ds2 = new DataSet();
                string dd = "SELECT * FROM product WHERE ID_PRODUCT ='" + textID.Text + "'";
                string dd2 = "SELECT * FROM product WHERE PRO_NAME ='" + textName.Text + "'";
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
                    MessageBox.Show("มีไอดี " + textID.Text + " มีเเล้วค่ะ กรุณาเปลียน");
                    ds.Clear();
                }
                else if (x > 0)
                {
                    MessageBox.Show("มีสินค้า " + textName.Text + " มีเเล้วค่ะ กรุณาเปลียน");
                    ds.Clear();
                }
                else
                {
                    string sqlT = "INSERT INTO product (ID_PRODUCT,PRO_NAME,PRO_NUM,PRO_PRICEPIECE) VALUES ('" + textID.Text + "','" + textName.Text + "','" + textNumber.Text + "','" + textPrice.Text + "')";

                    string ConnectStringT = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";

                    MySqlConnection conT = new MySqlConnection(ConnectStringT);
                    MySqlCommand cmdT = new MySqlCommand(sqlT, conT);
                    conT.Open();
                    MySqlDataReader readerT = cmdT.ExecuteReader();
                    MessageBox.Show("ทำการเพิ่มรายการแล้วค่ะ !!");
                    //ทำให้ตารางมันอัพเดท
                    string ConnectStrinT = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
                    MySqlConnection coT = new MySqlConnection(ConnectStrinT);

                    string ddT = "SELECT * FROM product";
                    MySqlCommand cmT = new MySqlCommand(ddT, coT);

                    DataTable tableT = new DataTable();

                    MySqlDataAdapter daT = new MySqlDataAdapter(cmT);
                    daT.Fill(tableT);
                    dataGridView1.DataSource = tableT;
                    //MessageBox.Show("อัพแล้วโว๊ยยยย!!");
                    ClearDataproduct();
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



            private void buttonSearch_Click(object sender, EventArgs e)
            //ปุ่มค้าหาข้อมูลแบบ แยก ID กับ Name
        {
            if (comboBox1.Text == "ID Product" && texts.Text == "")
            {
               MessageBox.Show("กรุณาป้อนข้อมูลที่จะค้นหาให้ครบด้วยค่ะ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (comboBox1.Text == "Name" && texts.Text == "")
            {
                MessageBox.Show("กรุณาป้อนข้อมูลที่จะค้นหาให้ครบด้วยค่ะ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }


            else if (comboBox1.Text == "ID Product" && texts.Text != "")
            {
                string ConnectString = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
                MySqlConnection con = new MySqlConnection(ConnectString);

                string dd = "SELECT * FROM product where ID_PRODUCT like '"+texts.Text+"%'";
                MySqlCommand cm = new MySqlCommand(dd, con);

                DataTable table = new DataTable();

                MySqlDataAdapter da = new MySqlDataAdapter(cm);
                da.Fill(table);
                dataGridView1.DataSource = table;
                //MessageBox.Show("อัพแล้วโว๊ยยยย!!");
                ClearDataproduct();
                con.Close();
            }
            else if (comboBox1.Text == "Name" && texts.Text != "")
            {
                string ConnectString = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
                MySqlConnection con = new MySqlConnection(ConnectString);

                string dd = "SELECT * FROM product where PRO_NAME like '" + texts.Text + "%'";
                MySqlCommand cm = new MySqlCommand(dd, con);

                DataTable table = new DataTable();

                MySqlDataAdapter da = new MySqlDataAdapter(cm);
                da.Fill(table);
                dataGridView1.DataSource = table;
                //MessageBox.Show("อัพแล้วโว๊ยยยย!!");
                ClearDataproduct();
                con.Close();
            }


        }

        private void buttonUpdate_Click(object sender, EventArgs e)
            //ปุ่มกดอัพเดทข้อมูลหรือการเปลียนแปลง

        {
            if (textID.Text == "" || textName.Text == "" || textNumber.Text == "" || textPrice.Text == "")
            {
                MessageBox.Show("กรุณาป้อนข้อมูลให้ครบด้วยค่ะ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }
            else if (textID.Text != "" && textName.Text != "" && textNumber.Text != "" && textPrice.Text != "")
            {
                string sql = "UPDATE product SET PRO_NAME = '" + textName.Text.Trim() + "',PRO_NUM = '" + textNumber.Text.Trim() + "',PRO_PRICEPIECE ='" + textPrice.Text.Trim() + "' WHERE ID_PRODUCT ='" + textID.Text.Trim() + "'";


                string ConnectString = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";

                MySqlConnection con = new MySqlConnection(ConnectString);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                MessageBox.Show("ทำการแก้ไขแล้วค่ะ !!");

                string ConnectStrin = "datasource = localhost; username= root;" + "password=; database = database";
                MySqlConnection co = new MySqlConnection(ConnectStrin);

                string dd = "SELECT * FROM product";
                MySqlCommand cm = new MySqlCommand(dd, co);

                DataTable table = new DataTable();

                MySqlDataAdapter da = new MySqlDataAdapter(cm);
                da.Fill(table);
                dataGridView1.DataSource = table;
                //MessageBox.Show("อัพแล้วโว๊ยยยย!!");
                ClearDataproduct();
                con.Close();
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
            //การส่งค่าคืนไปที่ textbox จากในตาราง
        {
            if (e.RowIndex == -1) return;
            textID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textPrice.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            //ล็อคtextbox
            //textID.Enabled = false;
            
        }
        //ฟังชั้นเครียร์ข้อมูลลบสินค้า
        private void ClearDataproduct()
        {
            textID.Clear();
            textName.Clear();
            textNumber.Clear();
            textPrice.Clear();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
            //ปุ่มลบลิ้นค้าาาาาาาา
        {
            if (textID.Text == "" || textName.Text == "" || textNumber.Text == "" || textPrice.Text == "")
            {
                MessageBox.Show("กรุณาเลือกข้อมูลในตารางให้ถูกต้องด้วยค่ะ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }
            else if (textID.Text != "" && textName.Text != "" && textNumber.Text != "" && textPrice.Text != "")
            {
                string sql = "DELETE FROM product WHERE ID_PRODUCT ='" + textID.Text.Trim() + "'";

                string ConnectString = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";

                MySqlConnection con = new MySqlConnection(ConnectString);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                MessageBox.Show("ทำการ ลบ รายการแล้วค่ะ !!");

                string ConnectStrin = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
                MySqlConnection co = new MySqlConnection(ConnectStrin);

                string dd = "SELECT * FROM product";
                MySqlCommand cm = new MySqlCommand(dd, co);

                DataTable table = new DataTable();

                MySqlDataAdapter da = new MySqlDataAdapter(cm);
                da.Fill(table);
                dataGridView1.DataSource = table;
                //MessageBox.Show("อัพแล้วโว๊ยยยย!!");
                ClearDataproduct();
                con.Close();
            }
        }

        private void SearchAll_Click(object sender, EventArgs e)
        {
            string ConnectString = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
            MySqlConnection con = new MySqlConnection(ConnectString);
            con.Open();
            MySqlDataAdapter dd = new MySqlDataAdapter("SELECT * FROM product", con);
            con.Close();
            MySqlCommandBuilder cb = new MySqlCommandBuilder(dd);
            DataTable table = new DataTable();


            dd.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
