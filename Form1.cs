using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestBrotherPilotsList
{
    public partial class Form1 : Form
    {
        Form2 f2;
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "4";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num;
            bool isNumeri = int.TryParse(textBox1.Text, out num);
            if(isNumeri)
            {
                if(num>1)
                {
                    f2 = new Form2(num);
                    f2.Size = new System.Drawing.Size(num * 30 + 10, num * 30 + 35);
                    f2.Show();
                }
                else { MessageBox.Show("Вы ввели недопустимое значение"); }
                
            }
            else { MessageBox.Show("Пожалуйста, введите число"); }
        }
    }
}
