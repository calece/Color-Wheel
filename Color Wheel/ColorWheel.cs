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
        Random rand = new Random();
        private int maxShownColors = 2; 

        public ColorWheel()
        {
            InitializeComponent();
            buttons = this.Controls.OfType<Button>().ToList();
            foreach (Button button in buttons)
            {
                button.Click += new EventHandler(checkWin);
            }
            colors.AddRange(new List<Color> {Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Blue, Color.Indigo, Color.Violet, Color.Pink});
            arrangeButtonColors();
        }

        private void checkWin(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            resultText.Text = clickedButton == winningButton ? "You Win!" : "You Lost!";
            arrangeButtonColors();
        }

        private void arrangeButtonColors()
        {                 
            assignNewColors();
            assignWinningButton();
            blackoutButtons();            
        }

        private void assignNewColors()
        {
            int iterator = rand.Next(buttons.Count);
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].BackColor = colors[iterator % buttons.Count];
                iterator++;
            }
        }

        private void assignWinningButton()
        {
            int winningButtonIndex = rand.Next(buttons.Count);
            winningButton = buttons[winningButtonIndex];
            winningColorBox.BackColor = winningButton.BackColor;
            winningButton.BackColor = Color.Black;
        }
        
        private void blackoutButtons()
        {
            int currentBlockedColors = 0;
            while (currentBlockedColors < (buttons.Count - 1) - maxShownColors)
            {
                int iterator = rand.Next(buttons.Count);
                if (buttons[iterator].BackColor != Color.Black)
                {
                    buttons[iterator].BackColor = Color.Black;
                    currentBlockedColors++;
                }
            }
        }
    }
}
