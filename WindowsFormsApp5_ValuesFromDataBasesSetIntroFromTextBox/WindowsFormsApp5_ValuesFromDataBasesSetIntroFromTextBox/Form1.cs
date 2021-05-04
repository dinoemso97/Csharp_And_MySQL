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

namespace WindowsFormsApp5_ValuesFromDataBasesSetIntroFromTextBox
{
    public partial class Form1 : Form
    {

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand command;
        MySqlDataReader mdr; 



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {




        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();

            string selectQuery = "SELECT * FROM database2.users WHERE id =" + int.Parse(textBox1.Text);

            command = new MySqlCommand(selectQuery, connection);

            mdr = command.ExecuteReader();

            if (mdr.Read())
            {

                textBox2.Text = mdr.GetString("fname");
                textBox3.Text = mdr.GetString("lname");
                textBox4.Text = mdr.GetInt32("age").ToString();

            }
            else {

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                MessageBox.Show("No Data For This ID");
            
            
            }

            connection.Close();

        }
    }
}
