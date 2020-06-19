using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PO_mat_projekt_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private double Value(TextBox tb)
        {
            try
            {
                return Convert.ToDouble(tb.Text);
            }
            catch (FormatException)
            {
                return 0.0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Octonion oct0 = new Octonion(Value(textBox1), Value(textBox2), Value(textBox3), Value(textBox4), Value(textBox5), Value(textBox6), Value(textBox7), Value(textBox8));
            Octonion oct1 = new Octonion(Value(textBox16), Value(textBox15), Value(textBox14), Value(textBox13), Value(textBox12), Value(textBox11), Value(textBox10), Value(textBox9));

            if (comboBox1.SelectedItem!=null)
            {
                if (comboBox1.SelectedItem.ToString() == "+")
                {
                    label17.Text = (oct0 + oct1).ToString();
                }

                if (comboBox1.SelectedItem.ToString() == "-")
                {
                    label17.Text = (oct0 - oct1).ToString();
                }

                if (comboBox1.SelectedItem.ToString() == "*")
                {
                    label17.Text = (oct0 * oct1).ToString();
                }

                if (comboBox1.SelectedItem.ToString() == "/")
                {
                    if (oct1.Modulus() == 0)
                    {
                        label17.Text = "Nie można dzielić przez zerowy oktonion.";
                    }
                    else
                    {
                        label17.Text = (oct0 / oct1).ToString();
                    }

                }
            }
            else
            {
                label17.Text = "Należy wybrać działanie.";
            }

            
            

            
        }
    }
}
