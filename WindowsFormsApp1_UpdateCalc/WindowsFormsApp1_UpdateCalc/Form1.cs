using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1_UpdateCalc
{
    public partial class Form1 : Form
    {

        float num1 = 0, num2 = 0;
        int oprClickCount = 0;
        bool isOprClick = false, isEqualClick = false;
        string opr;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Control c in Controls) {

                if (c is Button) {

                    if (c.Text != "RESET")
                        c.Click += new System.EventHandler(btn_click);
                }

            }
        }

        public void btn_click(object sender, EventArgs e) {


            Button button = (Button)sender;

            if (!isOperator(button)) {

                if (isOprClick) {

                    num1 = float.Parse(textBox1.Text);
                    textBox1.Text = "";
                
                }

                if (!textBox1.Text.Contains(".")) {

                    if (textBox1.Text.Equals("0") && !button.Text.Equals(".")) {


                        textBox1.Text = button.Text;
                        isOprClick = false; 

                    }
                    else {

                        textBox1.Text += button.Text;
                        isOprClick = false;
                    
                    }

                }
                else if(!button.Text.Equals(".")){

                    textBox1.Text += button.Text;
                    isOprClick = false; 
                
                
                }

            }
            else {

                if (oprClickCount == 0) {

                    oprClickCount++;
                    num1 = float.Parse(textBox1.Text);
                    opr = button.Text;
                    isOprClick = true; 


                }
                else {

                    if (!button.Text.Equals("=")) {

                        if (!isEqualClick) {

                            num2 = float.Parse(textBox1.Text);
                            textBox1.Text = Convert.ToString(calc(opr,num1,num2));
                            num2 = float.Parse(textBox1.Text);
                            opr = button.Text;
                            isOprClick = true;
                            isEqualClick = false; 


                        }
                        else {

                            isEqualClick = false;
                            opr = button.Text; 
                        
                        
                        }

                    }
                    else {

                        num2 = float.Parse(textBox1.Text);
                        textBox1.Text = Convert.ToString(calc(opr,num1,num2));
                        num1 = float.Parse(textBox1.Text);
                        isOprClick = true;
                        isEqualClick = true; 
                    
                    
                    }
                
                
                
                }
            
            }


        }

        private void button17_Click(object sender, EventArgs e)
        {
            num1 = 0;
            num2 = 0;
            opr = "";
            isOprClick = false;
            isEqualClick = false;
            oprClickCount = 0;
            textBox1.Text = "0";
        }

        public bool isOperator(Button button) {

            string buttonText = button.Text;

            if (buttonText.Equals("+") || buttonText.Equals("-") ||
                buttonText.Equals("X") || buttonText.Equals("/") || 
                buttonText.Equals("=")) {

                return true; 

            }
            else {

                return false; 
            
            }
        
        }

        public float calc(string opr, float n1, float n2) {

            float result = 0;


            switch (opr) {


                case "+":
                    result = n1 + n2;
                    break;

                case "-":
                    result = n1 - n2;
                    break;

                case "X":
                    result = n1 * n2;
                    break;

                case "/":
                    if(n2 != 0)
                    result = n1 / n2;
                    break; 
            
            
            }

            return result; 
        }



    }
}
   
