using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Color_Wheel
{
    public partial class Form1 : Form
    {

        public List<Button> buttons = new List<Button>();
        List<Color> colors = new List<Color>();
        Button winningButton = new Button();
        int maxShownColors = 2;

        public void arrangeColors(List<Button> buttons, List<Color> colors)
        {
            int blockedColors = 0;
            Random rand = new Random();
            List<Button> thisRoundColors = new List<Button>();
            int maxMod = buttons.Count;
            int iterator = rand.Next(buttons.Count);
            for (int i = 0; i < buttons.Count; i++)//Establish Colors
            {
                buttons[i].BackColor = colors[iterator % maxMod];
                iterator++;
            }
            iterator = rand.Next(buttons.Count);
            winningButton = buttons[iterator];
            pictureBox1.BackColor = winningButton.BackColor;
            buttons[iterator].BackColor = Color.Black;
            while (blockedColors < (buttons.Count-1) - maxShownColors)
            {
                iterator = rand.Next(buttons.Count);
                if (buttons[iterator].BackColor != Color.Black )
                {
                    buttons[iterator].BackColor = Color.Black;
                    blockedColors++;
                }
            }

        }

        public void checkWin(Button button, List<Button> buttons, List<Color> colors)
        {

            if (button == winningButton)
            {
                textBox1.Text = "You Won!";
            }
            else 
            {
                textBox1.Text = "You Lose!";
            }
            arrangeColors(buttons, colors);            
        }




        public Form1()
        {
            InitializeComponent();
            foreach (Button button in Controls.OfType<Button>())
            {
                buttons.Add(button);
            }
            colors.Add(Color.Red);
            colors.Add(Color.Orange);
            colors.Add(Color.Yellow);
            colors.Add(Color.Green);
            colors.Add(Color.LightSeaGreen);
            colors.Add(Color.CornflowerBlue);
            colors.Add(Color.Blue);
            colors.Add(Color.Purple);
            arrangeColors(buttons, colors);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkWin(button1, buttons, colors);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkWin(button2, buttons, colors);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            checkWin(button3, buttons, colors);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            checkWin(button4, buttons, colors);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            checkWin(button5, buttons, colors);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            checkWin(button6, buttons, colors);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            checkWin(button7, buttons, colors);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            checkWin(button8, buttons, colors);
        }
    }
}
