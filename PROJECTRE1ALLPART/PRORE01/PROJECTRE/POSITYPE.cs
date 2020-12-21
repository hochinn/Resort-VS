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
    public partial class POSITYPE : Form
    {
        public POSITYPE(string User)
        {
            InitializeComponent();
            label6.Text = "" + User;

            string ConnectString = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
            MySqlConnection con = new MySqlConnection(ConnectString);
            con.Open();
            MySqlDataAdapter dd = new MySqlDataAdapter("SELECT * FROM positions", con);
            con.Close();
            MySqlCommandBuilder cb = new MySqlCommandBuilder(dd);
            DataTable table = new DataTable();


            dd.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1) return;
            ID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            Name.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            Number.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM position WHERE ID_POSITION = '" + ID.Text + "'AND POSI_NAME ='" + Name.Text + "'";
            string ConnectString = "datasource = localhost; username= root;" +
                "password=; database = database;CharSet=UTF8";
            string ConnectStrin = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
            MySqlConnection co = new MySqlConnection(ConnectStrin);
            MySqlConnection con = new MySqlConnection(ConnectString);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            if (ID.Text == "" || Name.Text == "" || Number.Text == "" )
            {
                MessageBox.Show("กรุณาป้อนข้อมูลให้ครบด้วยค่ะ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                DataSet ds = new DataSet();
                DataSet ds2 = new DataSet();
                string dd = "SELECT * FROM position WHERE ID_POSITION ='" + ID.Text + "'";
                string dd2 = "SELECT * FROM position WHERE POSI_NAME ='" + Name.Text + "'";
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
                    MessageBox.Show("มีไอดี " + ID.Text + " มีเเล้วค่ะ กรุณาเปลียน");
                    ds.Clear();
                }
                else if (x > 0)
                {
                    MessageBox.Show("มีสินค้า " + Name.Text + " มีเเล้วค่ะ กรุณาเปลียน");
                    ds.Clear();
                }
                else
                {
                    string sqlT = "INSERT INTO position (ID_POSITION,POSI_NAME,NUMSALARY) VALUES ('" + ID.Text + "','" + Name.Text + "','" + Number.Text + "')";

                    string ConnectStringT = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";

                    MySqlConnection conT = new MySqlConnection(ConnectStringT);
                    MySqlCommand cmdT = new MySqlCommand(sqlT, conT);
                    conT.Open();
                    MySqlDataReader readerT = cmdT.ExecuteReader();
                    MessageBox.Show("ทำการเพิ่มรายการแล้วค่ะ !!");
                    //ทำให้ตารางมันอัพเดท
                    string ConnectStrinT = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
                    MySqlConnection coT = new MySqlConnection(ConnectStrinT);

                    string ddT = "SELECT * FROM position";
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

                
                }
            }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (ID.Text == "" || Name.Text == "" || Number.Text == "")
            {
                MessageBox.Show("กรุณาป้อนข้อมูลให้ครบด้วยค่ะ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (ID.Text != "" && Name.Text != "" && Number.Text != "")
            {
                string sql = "UPDATE position SET POSI_NAME = '" + Name.Text.Trim() + "',NUMSALARY = '" + Number.Text.Trim() + "' WHERE ID_POSITION ='" + ID.Text.Trim() + "'";


                string ConnectString = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";

                MySqlConnection con = new MySqlConnection(ConnectString);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                MessageBox.Show("ทำการแก้ไขแล้วค่ะ !!");

                string ConnectStrin = "datasource = localhost; username= root;" + "password=; database = database";
                MySqlConnection co = new MySqlConnection(ConnectStrin);

                string dd = "SELECT * FROM position";
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

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (ID.Text == "" || Name.Text == "" || Number.Text == "")
            {
                MessageBox.Show("กรุณาป้อนข้อมูลให้ครบด้วยค่ะ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (ID.Text != "" && Name.Text != "" && Number.Text != "")
            {
                string sql = "DELETE FROM position WHERE ID_POSITION = '" + ID.Text.Trim() + "'";

                string ConnectString = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";

                MySqlConnection con = new MySqlConnection(ConnectString);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                MessageBox.Show("ทำการ ลบ รายการแล้วค่ะ !!");

                string ConnectStrin = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
                MySqlConnection co = new MySqlConnection(ConnectStrin);

                string dd = "SELECT * FROM position";
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

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "ID position" && texts.Text == "")
            {
                MessageBox.Show("กรุณาป้อนข้อมูลที่จะค้นหาให้ครบด้วยค่ะ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (comboBox1.Text == "ตำแหน่ง" && texts.Text == "")
            {
                MessageBox.Show("กรุณาป้อนข้อมูลที่จะค้นหาให้ครบด้วยค่ะ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }


            else if (comboBox1.Text == "ID position" && texts.Text != "")
            {
                string ConnectString = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
                MySqlConnection con = new MySqlConnection(ConnectString);

                string dd = "SELECT * FROM position where ID_POSITION like '" + texts.Text + "%'";
                MySqlCommand cm = new MySqlCommand(dd, con);

                DataTable table = new DataTable();

                MySqlDataAdapter da = new MySqlDataAdapter(cm);
                da.Fill(table);
                dataGridView1.DataSource = table;
                //MessageBox.Show("อัพแล้วโว๊ยยยย!!");
                ClearDataproduct();
                con.Close();
            }
            else if (comboBox1.Text == "ตำแหน่ง" && texts.Text != "")
            {
                string ConnectString = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
                MySqlConnection con = new MySqlConnection(ConnectString);

                string dd = "SELECT * FROM position where POSI_NAME like '" + texts.Text + "%'";
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

        private void SearchAll_Click(object sender, EventArgs e)
        {
            string ConnectString = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
            MySqlConnection con = new MySqlConnection(ConnectString);
            con.Open();
            MySqlDataAdapter dd = new MySqlDataAdapter("SELECT * FROM position", con);
            con.Close();
            MySqlCommandBuilder cb = new MySqlCommandBuilder(dd);
            DataTable table = new DataTable();


            dd.Fill(table);
            dataGridView1.DataSource = table;
        }
        private void ClearDataproduct()
        {
            ID.Clear();
            Name.Clear();
            Number.Clear();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearDataproduct();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ADMINCEO d = new ADMINCEO(label6.Text);
            d.Show();
            Visible = false;
        }
    }
}
