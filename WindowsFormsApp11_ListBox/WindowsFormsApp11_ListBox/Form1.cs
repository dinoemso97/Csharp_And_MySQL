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

namespace WindowsFormsApp11_ListBox
{
    public partial class Form1 : Form
    {

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlDataAdapter adapter;
        DataTable table = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            adapter = new MySqlDataAdapter("SELECT * FROM database2.users", connection);
            adapter.Fill(table);
            listBox1.DataSource = table; 
            listBox1.DisplayMember = "fname";
            listBox1.ValueMember = "id";

        }
    }
}
