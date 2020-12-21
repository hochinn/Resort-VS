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
using MySqlX.XDevAPI;
using MySqlX.XDevAPI.Relational;
namespace PROJECTRE
{
    public partial class REGISTER : Form
    {
        public REGISTER()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM member WHERE USENAME ='" + textuser.Text + "'AND PASSWORD ='" + textpass.Text + "'";
            string ConnectString = "datasource = localhost; username= root;" +
                "password=; database = database;CharSet=UTF8";
            string ConnectStrin = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
            MySqlConnection co = new MySqlConnection(ConnectStrin);
            MySqlConnection con = new MySqlConnection(ConnectString);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

           
            
            if (textfname.Text == "" || textlname.Text == "" || cbgen.Text == "" || textage.Text == "" || texttel.Text == "" || textemail.Text == "" || textuser.Text == "" || textpass.Text == "")
            {
                MessageBox.Show("กรุณาเลือกข้อมูลในตารางให้ถูกต้องด้วยค่ะ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DataSet ds = new DataSet();
                string dd = "SELECT * FROM member WHERE USENAME ='" + textuser.Text + "'";
                MySqlCommand cm = new MySqlCommand(dd, co);
                MySqlDataAdapter da = new MySqlDataAdapter(cm);
                da.Fill(ds);
                int i = ds.Tables[0].Rows.Count;
                if (i>0){
                    MessageBox.Show("มี USENAME " + textuser.Text + " มีเเล้วค่ะ กรุณาเปลียน");
                    ds.Clear();
                }
                else
                {
                    string sqlT = "INSERT INTO member(MEM_FNAME,MEM_LNAME,MEM_GENDER,MEM_AGE,MEM_TEL,MEM_E_MAIL,USENAME,PASSWORD) VALUES('" + textfname.Text + "','" + textlname.Text + "','" + cbgen.Text + "','" + textage.Text + "','" + texttel.Text + "','" + textemail.Text + "','" + textuser.Text + "','" + textpass.Text + "')";
                    string ConnectStringT = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";

                    MySqlConnection conT = new MySqlConnection(ConnectStringT);
                    MySqlCommand cmdT = new MySqlCommand(sqlT, conT);
                    conT.Open();
                    MySqlDataReader readerT = cmdT.ExecuteReader();
                    MessageBox.Show("ทำการเพิ่มรายการแล้วค่ะ !!");
                    conT.Close();
                }

            }

        }

        private void textfname_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LOGIN l = new LOGIN();
            l.Show();
            Visible = false;
        }
    }
}

