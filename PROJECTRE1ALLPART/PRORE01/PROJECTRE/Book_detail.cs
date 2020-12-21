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
    public partial class Book_detail : Form
    {
        static string ID;
        static string id_booking;
        public Book_detail(string user)
        {
            InitializeComponent();
            label2.Text = user;

            string ConnectStringggg = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
            MySqlConnection con22 = new MySqlConnection(ConnectStringggg);
            MySqlCommand dddd = new MySqlCommand("SELECT * FROM member WHERE USENAME = '" + label2.Text + "'", con22);
            con22.Open();
            MySqlDataReader reader = dddd.ExecuteReader();
            while (reader.Read())
            {
               ID = (reader["ID MEMBER"].ToString());

            }
            reader.Close();

            con22.Close();
            string ConnectStrin = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
            MySqlConnection co = new MySqlConnection(ConnectStrin);
            co.Open();
            MySqlDataAdapter ddd = new MySqlDataAdapter("SELECT * from booking WHERE MEMBER_ID_MEMBER = '" + ID.ToString() + "' ", co);
            // MySqlDataAdapter dddd = new MySqlDataAdapter("SELECT * FROM rooms", c);
            co.Close();
            // c.Close();
            MySqlCommandBuilder cbb = new MySqlCommandBuilder(ddd);
            // MySqlCommandBuilder cbbb = new MySqlCommandBuilder(dddd);
            DataTable table1 = new DataTable();
            // DataTable table2 = new DataTable();
            ddd.Fill(table1);
            // ddd.Fill(table2);
            dataGridView1.DataSource = table1;
            //dataGriddetailroom.DataSource = table;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowClick = dataGridView1.CurrentRow.Index;
            id_booking = dataGridView1.Rows[rowClick].Cells[0].Value.ToString();

            string ConnectStrin = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
            MySqlConnection co = new MySqlConnection(ConnectStrin);
            co.Open();
            MySqlDataAdapter ddd = new MySqlDataAdapter("SELECT * from bookdetail WHERE BOOKING_ID_BOOKING = '" + id_booking.ToString() + "' ", co);
            // MySqlDataAdapter dddd = new MySqlDataAdapter("SELECT * FROM rooms", c);
            co.Close();
            // c.Close();
            MySqlCommandBuilder cbb = new MySqlCommandBuilder(ddd);
            // MySqlCommandBuilder cbbb = new MySqlCommandBuilder(dddd);
            DataTable table1 = new DataTable();
            // DataTable table2 = new DataTable();
            ddd.Fill(table1);
            // ddd.Fill(table2);
            dataGridView2.DataSource = table1;
            //dataGriddetailroom.DataSource = table;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Booking dd = new Booking(label2.Text);

            dd.Show();
            Visible = false;
        }
    }
}
