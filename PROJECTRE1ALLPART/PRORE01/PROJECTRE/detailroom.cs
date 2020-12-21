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
    public partial class detailroom : Form
    {
        public detailroom()
        {
            InitializeComponent();


            string ConnectString = "datasource = localhost; username= root;" + "password=; database = database;CharSet=UTF8";
            MySqlConnection con = new MySqlConnection(ConnectString);
            con.Open();
            MySqlDataAdapter dd = new MySqlDataAdapter("SELECT * FROM rooms", con);
            con.Close();
            MySqlCommandBuilder cb = new MySqlCommandBuilder(dd);
            DataTable table = new DataTable();


            dd.Fill(table);
            dataGriddetailroom.DataSource = table;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
    }
}
