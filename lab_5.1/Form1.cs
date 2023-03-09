using System;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_5._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private bool validMail(string email)
        {
            Regex myRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return myRegex.IsMatch(email);
        }
        private string removeSpaces(string myString)
        {
            myString = Regex.Replace(myString, @"([\s]+)", " ");
            return myString;
            
        }
        private string removeLetters(string myText)
        {
            myText = Regex.Replace(myText, @"a|A|b|B|c|C|d|D", "");
            return myText;
        }
        private bool validPostal(string postal)
        {
            Regex myRegex = new Regex(@"^([A-Z][0-9][A-Z])([\s]|[\-])?([0-9][A-Z][0-9])$");
            return myRegex.IsMatch(postal);
        }
        private string[] Splitter(string chaine)
        {
            string[] ArrText;
            Regex myRegex = new Regex(@"([\s]+)");
            ArrText = myRegex.Split(textBox1.Text);
            return ArrText;
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            if (validMail(textBox1.Text) == false)
            {
                MessageBox.Show("Enter with a valid email");
                textBox1.Focus();
            }
            else
            {
                MessageBox.Show("E-mail valid!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string new_text = removeSpaces(textBox1.Text);
            textBox1.Text = new_text.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string[] new_text = Splitter(textBox1.Text);
            string textToDisplay = "";
            
            foreach(string s in new_text)
            {
                textToDisplay += s + "\n";
                
            }
            MessageBox.Show(textToDisplay);
          
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close the App.? ", "Exit", MessageBoxButtons.YesNo).ToString() == "Yes")
            {
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (validPostal(textBox1.Text) == false)
            {
                MessageBox.Show("Enter with a valid Postal Code in the format X1X 1X1 or X1X-1X1");
                textBox1.Focus();
            }
            else
            {
                MessageBox.Show("Postal Code valid!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string new_text = removeLetters(textBox1.Text);
            textBox1.Text = new_text.ToString();
        }
    }
}
