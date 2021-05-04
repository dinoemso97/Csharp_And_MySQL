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

namespace WindowsFormsApp3_MySQLDisplayData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try {

                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM database2.users", connection);

                connection.Open();

                DataSet ds = new DataSet();
                adapter.Fill(ds,"users");
                dataGridView1.DataSource = ds.Tables["users"];
                connection.Close();

            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
