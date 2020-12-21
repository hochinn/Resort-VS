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
    public partial class EMPLOYEES2 : Form
    {
        public EMPLOYEES2(string User)

        {
            InitializeComponent();
            label2.Text = "" + User;

           

            string ConnectStringggg = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
            MySqlConnection con22 = new MySqlConnection(ConnectStringggg);
            MySqlCommand dddd = new MySqlCommand("SELECT * FROM employee WHERE ID_EMPLOYEES = '" + label2.Text + "'", con22);
            con22.Open();
            MySqlDataReader reader = dddd.ExecuteReader();
            while (reader.Read())
            {
                ID.Text = (reader["ID_EMPLOYEES"].ToString());
                name.Text = (reader["EMP_NAME"].ToString());
                Lname.Text = (reader["EMP_LNAME"].ToString());
                Ass.Text = (reader["EMP_ADDRESS"].ToString());
                FM.Text = (reader["EMP_GENDER"].ToString());
                BB.Text = (reader["EMP_BIRTHDAYDATE"].ToString());
                Email.Text = (reader["EMP_E_MAIL"].ToString());
                number.Text = (reader["EMP_BANKACCOUNT"].ToString());
                FD.Text = (reader["EMP_STARTDATE"].ToString());
                pos.Text = (reader["POSITION_ID_POSITION"].ToString());
                typew.Text = (reader["TYPEWORK_ID_TYPEWORK"].ToString());
                Pass.Text = (reader["EMP_PASSWORD"].ToString());
                Tal.Text = (reader["EMP_TELE"].ToString());
                age.Text = (reader["EMP_AGE"].ToString());

                FD.Enabled = false;
                pos.Enabled = false;
                typew.Enabled = false;


            }
            reader.Close();

            con22.Close();

            string ConnectStringgg = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
            MySqlConnection con2 = new MySqlConnection(ConnectStringgg);
            MySqlCommand ddd = new MySqlCommand("SELECT * FROM position WHERE ID_POSITION = '" + pos.Text + "'", con2);
            con2.Open();
            MySqlDataReader readerr = ddd.ExecuteReader();
            while (readerr.Read())
            {
                textBox1.Text = (readerr["NUMSALARY"].ToString());
                textBox1.Enabled = false;

            }
            readerr.Close();

            con2.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (ID.Text == "" || name.Text == "" || Lname.Text == "" || age.Text == "" || Ass.Text == "" || FM.Text == "" || BB.Text == "" || Email.Text == "" || Tal.Text == "" || number.Text == "" || FD.Text == "" || pos.Text == "" || typew.Text == "" || Pass.Text == "")
            {
                MessageBox.Show("กรุณาป้อนข้อมูลให้ครบด้วยค่ะ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }
            else if (ID.Text != "" && name.Text != "" && Lname.Text != "" && age.Text != "" && Ass.Text != "" && FM.Text != "" && BB.Text != "" && Email.Text != "" && Tal.Text != "" && number.Text != "" && FD.Text != "" && pos.Text != "" && typew.Text != "" && Pass.Text != "")
            {
                string sql = "UPDATE employee SET EMP_NAME = '" + name.Text.Trim() + "',EMP_LNAME ='" + Lname.Text.Trim() + "',EMP_AGE ='" + age.Text.Trim() + "',EMP_ADDRESS ='" + Ass.Text.Trim() + "',EMP_E_MAIL ='" + Email.Text.Trim() + "',EMP_GENDER ='" + FM.Text.Trim() + "',EMP_BIRTHDAYDATE ='" + BB.Text.Trim() + "',EMP_TELE ='" + Tal.Text.Trim() + "',EMP_BANKACCOUNT ='" + number.Text.Trim() + "',EMP_PASSWORD ='" + Pass.Text.Trim() + "' WHERE ID_EMPLOYEES ='" + ID.Text.Trim() + "'";


                string ConnectString = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";

                MySqlConnection con = new MySqlConnection(ConnectString);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader(); ///ติด
                MessageBox.Show("ทำการแก้ไขแล้วค่ะ !!");

                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ADMIN d = new ADMIN(label2.Text);
            d.Show();
            Visible = false;
        }
    }
}
