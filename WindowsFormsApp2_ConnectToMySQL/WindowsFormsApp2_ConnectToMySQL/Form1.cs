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

namespace WindowsFormsApp2_ConnectToMySQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MySqlConnection connection;
        private void Form1_Load(object sender, EventArgs e)
        {

            try {

                connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {

                    label1.Text = "Connected";
                    label1.ForeColor = Color.Green;
                }
                else {

                    label1.Text = "Not Connected";
                    label1.ForeColor = Color.Red; 
                
                
                }

            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message);
              
            
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                label1.Text = "Not Connected";
                label1.ForeColor = Color.Red;
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
                label1.Text = "Connected";
                label1.ForeColor = Color.Green;
            }

        }
    }
}
