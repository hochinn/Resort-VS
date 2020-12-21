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
    public partial class Form2 : Form
    {
     
        public Form2()
        {
            InitializeComponent();

           

            //dataตาราง
            string ConnectString = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8;Convert Zero Datetime=True";
            MySqlConnection con = new MySqlConnection(ConnectString);
            con.Open();
            MySqlDataAdapter dd = new MySqlDataAdapter("SELECT * FROM claim ", con);
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
    }
}
