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
    public partial class Form2 : Form
    {
        const int sizeButton = 25;
        const int distance = 30; 
        int count = 4;
        List<Button> buttons = new List<Button>();
        public Form2(int n)
        {
            count = n;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            bool[,] array=new bool[count,count];
            
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    Button button = new Button();
                    button.Location = new System.Drawing.Point(distance * j, distance * i);
                    button.Size = new System.Drawing.Size(sizeButton, sizeButton);
                    button.Name = "button" + i + "_" + j;
                    button.Text = "|";
                    button.Click += ButtonClicked;
                    buttons.Add(button);                              
                }
            }
            for(int i = 0; i < count*count;i++)
            {
                Controls.Add(buttons[i]);
            }
            //for(int i = 0; i < count;i++) Controls.AddRange(buttons[i]);
            StartGame();
        }
        public void StartGame()
        {
            Random random = new Random();
            int nClick = 5;
            int rnd1=random.Next(0,count);
            int rnd2 = random.Next(0, count);
            ButtonClicked(buttons[0], null);
            ButtonClicked(buttons[count * count - 1], null);
            for (int i = 0; i < nClick;i++)
            {
                rnd1 = random.Next(0, count);
                rnd2 = random.Next(0, count);
                ButtonClicked(buttons[rnd1 + rnd1 * rnd2],null);
            }
        }
        public void ButtonClicked(object sender,EventArgs e)
        {
            Button button = (Button)sender;
            ChangeState(button);
            int x,y,xNew,yNew;
            x = indexButton(button.Name, true);
            y = indexButton(button.Name, false);
            foreach(Button button1 in buttons)
            {
                if(button1!=null)
                {
                    xNew = indexButton(button1.Name, true);
                    yNew = indexButton(button1.Name, false);
                    if (xNew == x)
                    {
                        ChangeState(button1);
                    }
                    if (yNew == y)
                    {
                        ChangeState((Button)button1);
                    }
                }
            }
            bool checkHor = true;
            bool checkVer = true;
            foreach(Button button2 in buttons)
            {
                if ((button2.Text!="|")&&(checkVer==true)) checkVer = false;
                if ((button2.Text!= "—") &&(checkHor==true)) checkHor = false;
            }
            if ((checkHor) || (checkVer)) MessageBox.Show("Холодильник открыт");
        }
        public int indexButton(string name,bool type=false)
            //type==true  - по x 
            //type==false - по y
        {
            int x = -1;
            name = name.Remove(0, 6);
            string[]types=name.Split('_');
            if (type==false)x=int.Parse(types[0]);
            else x=int.Parse(types[1]);
            return x;
        }
        public void ChangeState(Button button)
        {
            if (button.Text == "|") button.Text = "—";
            else button.Text = "|";
        }
    }
}
