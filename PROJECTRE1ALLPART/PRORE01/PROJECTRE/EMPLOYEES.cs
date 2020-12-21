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
    public partial class EMPLOYEES : Form
    {
        public EMPLOYEES(string User)
        {///โชตารางนะจ๊ะ
            InitializeComponent();
            label21.Text = "" + User;
            string ConnectString = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";
            MySqlConnection con = new MySqlConnection(ConnectString);
            con.Open();
            MySqlDataAdapter dd = new MySqlDataAdapter("SELECT * FROM employee", con);
            con.Close();
            MySqlCommandBuilder cb = new MySqlCommandBuilder(dd);
            DataTable table = new DataTable();


            dd.Fill(table);
            dataGridView1.DataSource = table;


            //comboboxtypw


            string ConnectStringg = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
            MySqlConnection con1 = new MySqlConnection(ConnectStringg);
            con1.Open();
            MySqlDataAdapter ddd = new MySqlDataAdapter("SELECT * FROM typework", con1);
            DataSet ds = new DataSet();
            ddd.Fill(ds, "combolist");
            typew.DataSource = ds;
            typew.DisplayMember = "combolist.ID_TYPEWORK";
            typew.ValueMember = "combolist.ID_TYPEWORK";
            con1.Close();


            //comboboxpos
            string ConnectStringgg = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
            MySqlConnection con11 = new MySqlConnection(ConnectStringgg);
            con1.Open();
            MySqlDataAdapter ddd1 = new MySqlDataAdapter("SELECT * FROM positions", con1);
            DataSet ds1 = new DataSet();
            ddd1.Fill(ds1, "combolist");
            pos.DataSource = ds1;
            pos.DisplayMember = "combolist.ID_POSITION";
            pos.ValueMember = "combolist.ID_POSITION";
            con1.Close();

            
        }

            

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "ID" && textBox2.Text == "")
            {
                MessageBox.Show("กรุณาป้อนข้อมูลที่จะค้นหาให้ครบด้วยค่ะ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (comboBox1.Text == "NAME" && textBox2.Text == "")
            {
                MessageBox.Show("กรุณาป้อนข้อมูลที่จะค้นหาให้ครบด้วยค่ะ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }


            else if (comboBox1.Text == "ID" && textBox2.Text != "")
            {
                string ConnectString = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";
                MySqlConnection con = new MySqlConnection(ConnectString);

                string dd = "SELECT * FROM employee where ID_EMPLOYEES like '" + textBox2.Text + "%'";
                MySqlCommand cm = new MySqlCommand(dd, con);

                DataTable table = new DataTable();

                MySqlDataAdapter da = new MySqlDataAdapter(cm);
                da.Fill(table);
                dataGridView1.DataSource = table;
                //MessageBox.Show("อัพแล้วโว๊ยยยย!!");
                ClearDataproduct();
                con.Close();
            }
            else if (comboBox1.Text == "NAME" && textBox2.Text != "")
            {
                string ConnectString = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";
                MySqlConnection con = new MySqlConnection(ConnectString);

                string dd = "SELECT * FROM employee where EMP_NAME like '" + textBox2.Text + "%'";
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
        private void ClearDataproduct()
        {
            textBox2.Clear();

        }
        private void ClearDataproduct2()
        {

            ID.Clear();
            name.Clear();
            Lname.Clear();
        
            Ass.Clear();
            Email.Clear();
            Tal.Clear();
            number.Clear();
            Pass.Clear();

        }


        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1) return;
            ID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            name.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            Lname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            Ass.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            FM.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            BB.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            Email.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            Tal.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            number.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            FD.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            //sala.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            pos.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
            typew.Text = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
            // Use.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
            Pass.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
            textBox1.Enabled = false;
            //Pass.Enabled = false;
            //ID.Enabled = false;
            



        }



        private void button3_Click(object sender, EventArgs e)
        //แก้ไข
        {
            if (ID.Text == "" || name.Text == "" || Lname.Text == "" || comboBox2.Text == "" || Ass.Text == "" || FM.Text == "" || BB.Text == "" || Email.Text == "" || Tal.Text == "" || number.Text == "" || FD.Text == "" || pos.Text == "" || typew.Text == "" || Pass.Text == "")
            {
                MessageBox.Show("กรุณาป้อนข้อมูลให้ครบด้วยค่ะ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }
            else if (ID.Text != "" && name.Text != "" && Lname.Text != "" && comboBox2.Text != "" && Ass.Text != "" && FM.Text != "" && BB.Text != "" && Email.Text != "" && Tal.Text != "" && number.Text != "" && FD.Text != "" && pos.Text != "" && typew.Text != "" && Pass.Text != "")
            {
                string sql = "UPDATE employee SET EMP_NAME = '" + name.Text.Trim() + "',EMP_LNAME ='" + Lname.Text.Trim() + "',EMP_AGE ='" + comboBox2.Text.Trim() + "',EMP_ADDRESS ='" + Ass.Text.Trim() + "',EMP_E_MAIL ='" + Email.Text.Trim() + "',EMP_GENDER ='" + FM.Text.Trim() + "',EMP_BIRTHDAYDATE ='" + BB.Text.Trim() + "',EMP_TELE ='" + Tal.Text.Trim() + "',EMP_BANKACCOUNT ='" + number.Text.Trim() + "',EMP_STARTDATE ='" + FD.Text.Trim() + "',EMP_PASSWORD ='" + Pass.Text.Trim() + "',POSITION_ID_POSITION ='" + pos.Text.Trim() + "',TYPEWORK_ID_TYPEWORK ='" + typew.Text.Trim() + "' WHERE ID_EMPLOYEES ='" + ID.Text.Trim() + "'";


                string ConnectString = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";

                MySqlConnection con = new MySqlConnection(ConnectString);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader(); ///ติด
                MessageBox.Show("ทำการแก้ไขแล้วค่ะ !!");

                string ConnectStrin = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";
                MySqlConnection co = new MySqlConnection(ConnectStrin);

                string dd = "SELECT * FROM employee";
                MySqlCommand cm = new MySqlCommand(dd, co);

                DataTable table = new DataTable();

                MySqlDataAdapter da = new MySqlDataAdapter(cm);
                da.Fill(table);
                dataGridView1.DataSource = table;
                //MessageBox.Show("อัพแล้วโว๊ยยยย!!");
               
                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //ปุ่มลบลิ้นค้าาาาาาาา

            if (ID.Text == "" || name.Text == "" || Lname.Text == "" || comboBox2.Text == "" || Ass.Text == "" || FM.Text == "" || BB.Text == "" || Email.Text == "" || Tal.Text == "" || number.Text == "" || FD.Text == "" || pos.Text == "" || typew.Text == "" || Pass.Text == "")
            {
                MessageBox.Show("กรุณาเลือกข้อมูลในตารางให้ถูกต้องด้วยค่ะ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }
            else if (ID.Text != "" && name.Text != "" && Lname.Text != "" && comboBox2.Text != "" && Ass.Text != "" && FM.Text != "" && BB.Text != "" && Email.Text != "" && Tal.Text != "" && number.Text != "" && FD.Text != "" && pos.Text != "" && typew.Text != "" && Pass.Text != "")
            {
                string sql = "DELETE FROM employee WHERE ID_EMPLOYEES ='" + ID.Text.Trim() + "'";

                string ConnectString = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";

                MySqlConnection con = new MySqlConnection(ConnectString);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                MessageBox.Show("ทำการ ลบ รายการแล้วค่ะ !!");

                string ConnectStrin = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";
                MySqlConnection co = new MySqlConnection(ConnectStrin);

                string dd = "SELECT * FROM employee ";
                MySqlCommand cm = new MySqlCommand(dd, co);

                DataTable table = new DataTable();

                MySqlDataAdapter da = new MySqlDataAdapter(cm);
                da.Fill(table);
                dataGridView1.DataSource = table;
                //MessageBox.Show("อัพแล้วโว๊ยยยย!!");
                ClearDataproduct2();
                con.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ClearDataproduct2();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM employee WHERE ID_EMPLOYEES ='" + ID.Text +  "'";
            //string ConnectString = "datasource = localhost; username= root;" +
            //    "password=; database = database;CharSet=UTF8";
            string ConnectStrin = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
            MySqlConnection co = new MySqlConnection(ConnectStrin);
            //MySqlConnection con = new MySqlConnection(ConnectString);
            //MySqlCommand cmd = new MySqlCommand(sql, con);
            //con.Open();
            //MySqlDataReader reader = cmd.ExecuteReader();

            if (ID.Text == "" || name.Text == "" || Lname.Text == "" || comboBox2.Text == "" || Ass.Text == "" || FM.Text == "" || BB.Text == "" || Email.Text == "" || Tal.Text == "" || number.Text == "" || FD.Text == "" || pos.Text == "" || typew.Text == "" || Pass.Text == "")
            {
                MessageBox.Show("กรุณาเลือกข้อมูลในตารางให้ถูกต้องด้วยค่ะ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                DataSet ds = new DataSet();
                //DataSet ds2 = new DataSet();
                string dd = "SELECT * FROM employee WHERE ID_EMPLOYEES ='" + ID.Text + "'";
                //string dd2 = "SELECT * FROM product WHERE PRO_NAME ='" + textName.Text + "'";
                MySqlCommand cm = new MySqlCommand(dd, co);
                MySqlDataAdapter da = new MySqlDataAdapter(cm);
                //MySqlCommand cm2 = new MySqlCommand(dd2, co);
                //MySqlDataAdapter da2 = new MySqlDataAdapter(cm2);
                da.Fill(ds);
                //da2.Fill(ds2);
                int i = ds.Tables[0].Rows.Count;
                //int x = ds2.Tables[0].Rows.Count;
                if (i > 0)
                {
                    MessageBox.Show("มีไอดี " + ID.Text + " มีเเล้วค่ะ กรุณาเปลียน");
                    ds.Clear();
                }
                //else if (x > 0)
                //{
                //    MessageBox.Show("มีสินค้า " + textName.Text + " มีเเล้วค่ะ กรุณาเปลียน");
                //    ds.Clear();
                //}
                else
                {
                    string sqlT = "INSERT INTO employee(ID_EMPLOYEES,EMP_NAME,EMP_LNAME,EMP_AGE,EMP_ADDRESS,EMP_E_MAIL,EMP_GENDER,EMP_BIRTHDAYDATE,EMP_TELE,EMP_BANKACCOUNT,EMP_STARTDATE,EMP_PASSWORD,POSITION_ID_POSITION,TYPEWORK_ID_TYPEWORK) VALUES ('" + ID.Text + "','" + name.Text + "','" + Lname.Text + "','" + comboBox2.Text + "','" + Ass.Text + "','" + Email.Text + "','" + FM.Text + "','" + BB.Text + "','" + Tal.Text + "','" + number.Text + "','" + FD.Text + "','" + Pass.Text + "','" + pos.Text + "','" + typew.Text + "')";

                    string ConnectStringT = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";

                    MySqlConnection conT = new MySqlConnection(ConnectStringT);
                    MySqlCommand cmdT = new MySqlCommand(sqlT, conT);
                    conT.Open();
                    MySqlDataReader readerT = cmdT.ExecuteReader();
                    MessageBox.Show("ทำการเพิ่มรายการแล้วค่ะ !!");


                    //ทำให้ตารางมันอัพเดท
                    string ConnectStrinT = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";
                    MySqlConnection coT = new MySqlConnection(ConnectStrinT);

                    string ddT = "SELECT * FROM employee";
                    MySqlCommand cmT = new MySqlCommand(ddT, coT);

                    DataTable tableT = new DataTable();

                    MySqlDataAdapter daT = new MySqlDataAdapter(cmT);
                    daT.Fill(tableT);
                    dataGridView1.DataSource = tableT;
                    //MessageBox.Show("อัพแล้วโว๊ยยยย!!");
                    ClearDataproduct2();
                    conT.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ConnectStrinn = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";
            MySqlConnection con = new MySqlConnection(ConnectStrinn);

            con.Open();
            MySqlDataAdapter dd = new MySqlDataAdapter("SELECT * FROM employee", con);
            con.Close();
            MySqlCommandBuilder cb = new MySqlCommandBuilder(dd);
            DataTable table = new DataTable();


            dd.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void pos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ConnectStringggg = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
            MySqlConnection con22 = new MySqlConnection(ConnectStringggg);
            MySqlCommand dddd = new MySqlCommand("SELECT * FROM positions WHERE ID_POSITION = '" + pos.Text + "'", con22);
            con22.Open();
            MySqlDataReader reader = dddd.ExecuteReader();
            while (reader.Read())
            {
                textBox1.Text = (reader["NUMSALARY"].ToString());

            }
            reader.Close();

            con22.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ADMIN d = new ADMIN(label21.Text);
            d.Show();
            Visible = false;
        }

        //private void pos_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    if (pos.SelectedIndex != -1)
        //    {
        //        textBox1.Text = pos.SelectedValue.ToString();
        //        // If we also wanted to get the displayed text we could use
        //        // the SelectedItem item property:
        //        // string s = ((USState)ListBox1.SelectedItem).LongName;
        //    }
        //}

        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{
        //    string sql = "SELECT * FROM position WHERE ID_POSITION ='" + pos.Text + "'";

        //    string ConnectStrin = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
        //    MySqlConnection co = new MySqlConnection(ConnectStrin);
        //    DataSet ds = new DataSet();

        //    string dd = "SELECT * FROM position WHERE ID_POSITION ='" + pos.Text + "'";

        //    MySqlCommand cm = new MySqlCommand(dd, co);
        //    MySqlDataAdapter da = new MySqlDataAdapter(cm);
        //   ;
        //    da.Fill(ds);

        //    int i = ds.Tables[0].Rows.Count;

        //    if (i > 0)
        //    {



        //    }
        //}
    }
}

            
    


