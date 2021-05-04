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

namespace WindowsFormsApp10_NavigationButtons
{
    public partial class Form1 : Form
    {

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlDataAdapter adapter;
        DataTable table = new DataTable();
        int pos = 0; 


        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            adapter = new MySqlDataAdapter("SELECT * FROM database2.users", connection);
            adapter.Fill(table);
            showData(pos);
        }

        public void showData(int index) {

            textBox1.Text = table.Rows[index][0].ToString();
            textBox2.Text = table.Rows[index][1].ToString();
            textBox3.Text = table.Rows[index][2].ToString();
            textBox4.Text = table.Rows[index][3].ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pos = 0;
            showData(pos);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pos++;
            if (pos < table.Rows.Count)
            {


                showData(pos);

            }
            else {

                MessageBox.Show("END");
                pos = table.Rows.Count - 1; 
            
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            pos--;
            if (pos >= 0) {

                showData(pos);

            }
            else {

                MessageBox.Show("END");
            
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            pos = table.Rows.Count - 1;
            showData(pos); 

        }
    }
}
