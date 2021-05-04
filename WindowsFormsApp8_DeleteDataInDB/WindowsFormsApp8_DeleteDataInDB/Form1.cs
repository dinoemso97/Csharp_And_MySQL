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

namespace WindowsFormsApp8_DeleteDataInDB
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

            

            try {

                string deleteQuery = "DELETE FROM database2.users WHERE id = " + textBox1.Text;

                connection.Open();

                MySqlCommand command = new MySqlCommand(deleteQuery, connection);

                if (command.ExecuteNonQuery() == 1) {

                    MessageBox.Show("USER DELETED");

                }
                else {

                    MessageBox.Show("USER NOT DELETED");
                
                }
            
            }
            catch (Exception ex) {


                MessageBox.Show(ex.Message);
            
            }

            connection.Close();


        }
    }
}
