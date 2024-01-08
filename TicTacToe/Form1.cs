using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        Player currentPlayer;
        Random random = new Random();
        int playerWinScore = 0;
        int CPUWinScore = 0;
        List<Button> buttons;

        // Player Data
        public enum Player
        {
            X, O
        }

        public Form1()
        {
            InitializeComponent();
            RestartGame();
        }

        private void PlayerClickButton(object sender, EventArgs e)
        {
            var button = (Button)sender;

            currentPlayer = Player.X;
            button.Text = currentPlayer.ToString();
            button.Enabled = false;
            button.BackColor = Color.Aqua;
            buttons.Remove(button);
            CheckGame();
            GameTimer.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void CPUMove(object sender, EventArgs e)
        {
            if (buttons.Count > 0)
            {
                int index = random.Next(buttons.Count);
                buttons[index].Enabled = false;
                currentPlayer = Player.O;
                buttons[index].Text = currentPlayer.ToString();
                buttons[index].BackColor = Color.AntiqueWhite;
                buttons.RemoveAt(index);
                CheckGame();
                GameTimer.Stop();
            }
        }

        private void PlayerClick(object sender, EventArgs e)
        {

        }

        private void RestartGameButton(object sender, EventArgs e)
        {
            RestartGame();
        }

        public void CheckGame()
        {
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X" ||
                button4.Text == "X" && button5.Text == "X" && button6.Text == "X" ||
                button7.Text == "X" && button8.Text == "X" && button9.Text == "X" ||
                button1.Text == "X" && button4.Text == "X" && button7.Text == "X" ||
                button2.Text == "X" && button5.Text == "X" && button8.Text == "X" ||
                button3.Text == "X" && button6.Text == "X" && button9.Text == "X" ||
                button1.Text == "X" && button5.Text == "X" && button9.Text == "X" ||
                button3.Text == "X" && button5.Text == "X" && button7.Text == "X")
            {
                GameTimer.Stop();
                MessageBox.Show("You Won!, Congrats!!!");
                playerWinScore++;
                label5.Text = "Player: " + playerWinScore;
                RestartGame();
            }
            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O" ||
                    button4.Text == "O" && button5.Text == "O" && button6.Text == "O" ||
                    button7.Text == "O" && button8.Text == "O" && button9.Text == "O" ||
                    button1.Text == "O" && button4.Text == "O" && button7.Text == "O" ||
                    button2.Text == "O" && button5.Text == "O" && button8.Text == "O" ||
                    button3.Text == "O" && button6.Text == "O" && button9.Text == "O" ||
                    button1.Text == "O" && button5.Text == "O" && button9.Text == "O" ||
                    button3.Text == "O" && button5.Text == "O" && button7.Text == "O")
            {
                GameTimer.Stop();
                MessageBox.Show("You Lose, Better luck next time!");
                CPUWinScore++;
                label6.Text = "CPU: " + CPUWinScore;
                RestartGame();
            }
        }

        public void RestartGame()
        {
            buttons = new List<Button> {button1, button2, button3,
            button4, button5, button6, button7, button8, button9};

            foreach (Button x in buttons)
            {
                x.Enabled = true;
                x.Text = " ";
                x.BackColor = DefaultBackColor;
            }
        }
    }
}
