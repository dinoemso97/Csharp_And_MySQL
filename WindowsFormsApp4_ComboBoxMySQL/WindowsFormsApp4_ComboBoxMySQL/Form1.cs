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

namespace WindowsFormsApp4_ComboBoxMySQL
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
                string selectQuery = "SELECT * FROM database2.users";
                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) {

                    comboBox1.Items.Add(reader.GetString("fname"));
                
                
                }
            
            }
            catch(Exception ex) {

                MessageBox.Show(ex.Message);
            
            }
        }
    }
}
