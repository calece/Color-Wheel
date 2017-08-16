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
    public partial class ColorWheel : Form
    {

        private List<Button> buttons = new List<Button>();
        private List<Color> colors = new List<Color>();
        private Button winningButton = new Button();
        private int maxShownColors = 2; 

        public ColorWheel()
        {
            InitializeComponent();
            foreach (Button button in this.Controls.OfType<Button>())
            {
                buttons.Add(button);
            }
            colors.AddRange(new List<Color> {Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Blue, Color.Indigo, Color.Violet, Color.Pink});
            arrangeColors(buttons, colors);
            foreach (Button button in buttons)
            {
                button.Click += new EventHandler(assignButton);
            }
        }

        private void assignButton(object sender, EventArgs e)
        {
            checkWin(sender as Button, buttons, colors);
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

        private void arrangeColors(List<Button> buttons, List<Color> colors)
        {
            int blockedColors = 0;
            Random rand = new Random();
            int iterator = rand.Next(buttons.Count);
            //Establish Colors
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].BackColor = colors[iterator % buttons.Count];
                iterator++;
            }
            iterator = rand.Next(buttons.Count);
            winningButton = buttons[iterator];
            winningColorBox.BackColor = winningButton.BackColor;
            //Ensure winning button color is black and proceed to randomly black out colors.
            buttons[iterator].BackColor = Color.Black;
            while (blockedColors < (buttons.Count - 1) - maxShownColors)
            {
                iterator = rand.Next(buttons.Count);
                if (buttons[iterator].BackColor != Color.Black)
                {
                    buttons[iterator].BackColor = Color.Black;
                    blockedColors++;
                }
            }
        }
    }
}
