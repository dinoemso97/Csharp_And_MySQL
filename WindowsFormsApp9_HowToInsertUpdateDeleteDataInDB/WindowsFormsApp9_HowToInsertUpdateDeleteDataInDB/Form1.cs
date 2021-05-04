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

namespace WindowsFormsApp9_HowToInsertUpdateDeleteDataInDB
{
    public partial class Form1 : Form
    {

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");

        MySqlCommand command;


        public Form1()
        {
            InitializeComponent();
        }



        public void openConnection() {

            if (connection.State == ConnectionState.Closed) {


                connection.Open(); 

            }
     
        }

        public void closeConnection() {

            if (connection.State == ConnectionState.Open) {


                connection.Close();
            }
        
 
        }

        public void executeQuery(String query) {

            try {

                openConnection();
                command = new MySqlCommand(query, connection);
                if (command.ExecuteNonQuery() == 1)
                {

                    MessageBox.Show("Query Executed");

                }
                else {


                    MessageBox.Show("Query Not Executed");
                
                }
            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message);

            }
            finally {


                closeConnection();
            }
       
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string insertQuery = "INSERT INTO database2.users(fname,lname,age) VALUES('"+textBox2.Text+"','"+textBox3.Text+"',"+ textBox4.Text +")";
            executeQuery(insertQuery);


        }

        private void button2_Click(object sender, EventArgs e)
        {

            string updateQuery = "UPDATE database2.users SET fname='"+textBox2.Text+"' , lname = '"+textBox3.Text+"' , age ="+textBox4.Text+" WHERE id ="+ textBox1.Text;
            executeQuery(updateQuery);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string deleteQuery = "DELETE FROM database2.users WHERE id = "+ textBox1.Text;
            executeQuery(deleteQuery);
        }
    }
}
