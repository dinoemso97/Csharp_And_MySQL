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

namespace WindowsFormsApp7_UpdateDataIntoDB
{

    public partial class Form1 : Form
    {

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string updateQuery = "UPDATE database2.users SET fname = '" + textBox2.Text + "', lname  = '" + textBox3.Text + "', age = " + int.Parse(textBox4.Text) + " WHERE id=" + int.Parse(textBox1.Text);


            connection.Open();

            try {
                MySqlCommand command = new MySqlCommand(updateQuery, connection);

                if (command.ExecuteNonQuery() == 1) {

                    MessageBox.Show("DATA UPDATED");

                }
                else {

                    MessageBox.Show("DATA NOT UPDATED");

                }
            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message);
            
            }

            connection.Close();
        }
    }
}
