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

namespace WindowsFormsApp6_InsertDataIntoMySQLDB
{
    public partial class Form1 : Form
    {

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");



        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string insertQuery = "INSERT INTO database2.users(fname,lname,age) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            try {

                if (command.ExecuteNonQuery() == 1)
                {

                    MessageBox.Show("Data Inserted");

                }


                else
                {

                    MessageBox.Show("Data Not Inserted");

                }

            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message);
            
            
            }

            

            connection.Close();


        }
    }
}
