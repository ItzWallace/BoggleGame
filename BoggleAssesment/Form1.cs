using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BoggleAssesment
{
    public partial class Form1 : Form
    {
        public string word1; // Stores word entered by user
        public int score; // Variable to track player score

        
        // Event handler for "Enter" button click to validate and process the input word
        private void EnterStoffanddat_Click_1(object sender, EventArgs e)
        {
            // Reads a list of valid words from the text file
            string[] DieList = System.IO.File.ReadAllLines(@"wordsList.txt");
            word1 = txtInputBox.Text;

           
            // Checks if the entered word exists in the DieList array
            if (DieList.Contains(word1))
            {
                // Displays a pop up message confirming the word is valid to the user
                MessageBox.Show("Valid word", "Result");

                // Resets the color of the labels to reset the selection after a correct word is entered
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is Label label && label.Name.StartsWith("label"))
                    {
                        label.Enabled = true;
                        label.ForeColor = Color.Black;
                    }
                }

                // Update score based on the word length and display it
                score = word1.Length + score;
                lblScore.Text = "Score : " + score.ToString();

            }
            else
            {

                // Update score based on the word length and display it
                MessageBox.Show("Not valid", "Result");
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is Label label && label.Name.StartsWith("label"))
                    {
                        label.Enabled = true;
                        label.ForeColor = Color.Black;
                    }
                }

            }
            // Cleares the input box after the word is processed
            txtInputBox.Clear();
        }

        public Form1()
        {
            InitializeComponent();
            // Initialize the timer and remaining time
            remainingTime = 180; // 3 minutes in seconds
            timer1.Interval = 1000; // 1 second interval
            timer1.Tick += Timer1_Tick;
            timer1.Start();
        }
        private int remainingTime; // Time in seconds (3 minutes = 180 seconds)
        private void Timer1_Tick(object sender, EventArgs e)
        {
            // Decrease remaining time by 1 second
            remainingTime--;

            // Update the label to show remaining time in minutes and seconds
            int minutes = remainingTime / 60;
            int seconds = remainingTime % 60;
            label100.Text = $"{minutes:D2}:{seconds:D2}";

            // Check if time is up
            if (remainingTime <= 0)
            {
                timer1.Stop();  // Stop the timer when time runs out
                MessageBox.Show("Time's up! Game Over!");  // Show a message to the player

                // Disable further label interactions
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is Label label && label.Name.StartsWith("label"))
                    {
                        label.Enabled = false; // Disable all labels (stops users selecting letters)
                        label.ForeColor = Color.Gray; // Colour change to indicate a disabled state of the letters
                    }
                }

                // Disables textbox input
                txtInputBox.Enabled = false;
            }
        }

        // Function to return a random number between 0 and 5 (used in the dice selection)
        private int random()
        {
            Random rnd = new Random();
            int num = rnd.Next(0, 6);
            return num;
        }

        // Event handler for the form load event. Triggerd on start
        private void Form1_Load(object sender, EventArgs e)
        {

            // Arrays representing the dice faces for each dice
            string[] DIE0 = new string[] { "R", "I", "F", "O", "B", "X" };
            string[] DIE1 = new string[] { "I", "F", "E", "H", "E", "Y" };
            string[] DIE2 = new string[] { "D", "E", "N", "O", "W", "S" };
            string[] DIE3 = new string[] { "U", "T", "O", "K", "N", "D" };
            string[] DIE4 = new string[] { "H", "M", "S", "R", "A", "O" };
            string[] DIE5 = new string[] { "L", "U", "P", "E", "T", "S" };
            string[] DIE6 = new string[] { "A", "C", "I", "T", "O", "A" };
            string[] DIE7 = new string[] { "Y", "L", "G", "K", "U", "E" };
            string[] DIE8 = new string[] { "Qu", "B", "M", "J", "O", "A" };
            string[] DIE9 = new string[] { "E", "H", "I", "S", "P", "N" };
            string[] DIE10 = new string[] { "V", "E", "T", "I", "G", "N" };
            string[] DIE11 = new string[] { "B", "A", "L", "I", "Y", "T" };
            string[] DIE12 = new string[] { "E", "Z", "A", "V", "N", "D" };
            string[] DIE13 = new string[] { "R", "A", "L", "E", "S", "C" };
            string[] DIE14 = new string[] { "U", "W", "I", "L", "R", "G" };
            string[] DIE15 = new string[] { "P", "A", "C", "E", "M", "D" };

            // Randomly assign each label with a character from the dice array.
            label1.Text = DIE0[random()];
            label2.Text = DIE1[random()];
            label3.Text = DIE2[random()];
            label4.Text = DIE3[random()];
            label5.Text = DIE4[random()];
            label6.Text = DIE5[random()];
            label7.Text = DIE6[random()];
            label8.Text = DIE7[random()];
            label9.Text = DIE8[random()];
            label10.Text = DIE9[random()];
            label11.Text = DIE10[random()];
            label12.Text = DIE11[random()];
            label13.Text = DIE12[random()];
            label14.Text = DIE13[random()];
            label15.Text = DIE14[random()];
            label16.Text = DIE15[random()];
        }

        // Refresh button functionality to reset the game
        private void Button1_Click(object sender, EventArgs e)
        {
            // Arrays representing the possible letters on each dice
            string[] DIE0 = new string[] { "R", "I", "F", "O", "B", "X" };
            string[] DIE1 = new string[] { "I", "F", "E", "H", "E", "Y" };
            string[] DIE2 = new string[] { "D", "E", "N", "O", "W", "S" };
            string[] DIE3 = new string[] { "U", "T", "O", "K", "N", "D" };
            string[] DIE4 = new string[] { "H", "M", "S", "R", "A", "O" };
            string[] DIE5 = new string[] { "L", "U", "P", "E", "T", "S" };
            string[] DIE6 = new string[] { "A", "C", "I", "T", "O", "A" };
            string[] DIE7 = new string[] { "Y", "L", "G", "K", "U", "E" };
            string[] DIE8 = new string[] { "Qu", "B", "M", "J", "O", "A" };
            string[] DIE9 = new string[] { "E", "H", "I", "S", "P", "N" };
            string[] DIE10 = new string[] { "V", "E", "T", "I", "G", "N" };
            string[] DIE11 = new string[] { "B", "A", "L", "I", "Y", "T" };
            string[] DIE12 = new string[] { "E", "Z", "A", "V", "N", "D" };
            string[] DIE13 = new string[] { "R", "A", "L", "E", "S", "C" };
            string[] DIE14 = new string[] { "U", "W", "I", "L", "R", "G" };
            string[] DIE15 = new string[] { "P", "A", "C", "E", "M", "D" };

            // Randomly assign a letter from each dice to the labels (the ui dice)  (1 - 16)
            label1.Text = DIE0[random()];
            label2.Text = DIE1[random()];
            label3.Text = DIE2[random()];
            label4.Text = DIE3[random()];
            label5.Text = DIE4[random()];
            label6.Text = DIE5[random()];
            label7.Text = DIE6[random()];
            label8.Text = DIE7[random()];
            label9.Text = DIE8[random()];
            label10.Text = DIE9[random()];
            label11.Text = DIE10[random()];
            label12.Text = DIE11[random()];
            label13.Text = DIE12[random()];
            label14.Text = DIE13[random()];
            label15.Text = DIE14[random()];
            label16.Text = DIE15[random()];

            // Restarts score
            score = 0;
            lblScore.Text = "Score: 0";

            // Rests the timer and updates label
            remainingTime = 180; 
            label100.Text = "03:00"; 

            // Starts the timer
            timer1.Start(); 




            txtInputBox.Text = "";
            // Clear the input box (if needed)
            txtInputBox.Clear();

            // Enable all labels and set their color to black
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label label && label.Name.StartsWith("label"))
                {
                    label.Enabled = true;
                    label.ForeColor = Color.Black;

                }
            }
        }

        // This function handles the click event for label1. When clicked, the text of label1 is appended to the input box,
        // and adjacent labels are enabled for further selection. Non-adjacent labels are disabled to ensure the player only 
        // selects neighboring dice. Enabled labels are highlighted in orange.
        private void Label1_Click(object sender, EventArgs e)
        {
            // Add label1's text to the input box when clicked
            txtInputBox.Text += label1.Text;

            // Disable all labels and enable only those that are adjacent to label1
            for (int i = 1; i <= 17; i++)
            {
                string labelName = "label" + i.ToString();

                Label label = this.Controls[labelName] as Label;

                // Check if the label is found before trying to access its properties
                if (label != null)
                {
                    // Enable adjacent labels (orange color) and disable others
                    if (i == 2 || i == 5 || i == 6)
                    {
                        label.Enabled = true;
                        // Highlight enabled labels in orange
                        label.ForeColor = Color.Orange;
                    }
                    else
                    {
                        // Disable non-adjacent labels
                        label.Enabled = false;  
                    }
                }
            }
        }


        private void Label2_Click(object sender, EventArgs e)
        {
            txtInputBox.Text += label2.Text;
            for (int i = 1; i <= 17; i++)
            {
                string labelName = "label" + i.ToString();

                Label label = this.Controls[labelName] as Label;

                
                if (label != null)
                {
                    if (i == 1 || i == 3 || i == 5 || i == 6 || i == 7)
                    {
                        label.Enabled = true;
                        label.ForeColor = Color.Orange;
                    }
                    else
                    {
                        label.Enabled = false;  
                    }
                }
            }
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            txtInputBox.Text += label3.Text;
            for (int i = 1; i <= 17; i++)
            {
                string labelName = "label" + i.ToString();

                Label label = this.Controls[labelName] as Label;

               
                if (label != null)
                {
                    if (i == 2 || i == 4 || i == 6 || i == 7 || i == 8)
                    {
                        label.Enabled = true;
                        label.ForeColor = Color.Orange;
                    }
                    else
                    {
                        label.Enabled = false; 
                    }
                }
            }
        }

        private void Label4_Click(object sender, EventArgs e)
        {
            txtInputBox.Text += label4.Text;
            for (int i = 1; i <= 17; i++)
            {
                string labelName = "label" + i.ToString();

                Label label = this.Controls[labelName] as Label;

               
                if (label != null)
                {
                    if (i == 3 || i == 7 || i == 8 )
                    {
                        label.Enabled = true;
                        label.ForeColor = Color.Orange;
                    }
                    else
                    {
                        label.Enabled = false;  
                    }
                }
            }
        }

        private void Label5_Click(object sender, EventArgs e)
        {
            txtInputBox.Text += label5.Text;
            for (int i = 1; i <= 17; i++)
            {
                string labelName = "label" + i.ToString();

                Label label = this.Controls[labelName] as Label;

                
                if (label != null)
                {
                    if (i == 1 || i == 2 || i == 6 || i == 9 || i == 10) 
                    {
                        label.Enabled = true;
                        label.ForeColor = Color.Orange;
                    }
                    else
                    {
                        label.Enabled = false;  
                    }
                }
            }
        }

        private void Label6_Click(object sender, EventArgs e)
        {
            txtInputBox.Text += label6.Text;
            for (int i = 1; i <= 17; i++)
            {
                string labelName = "label" + i.ToString();

                Label label = this.Controls[labelName] as Label;

                
                if (label != null)
                {
                    if (i == 5 || i == 1 || i == 2 || i == 3 || i == 7|| i == 9 || i == 10 || i == 11)
                    {
                        label.Enabled = true;
                        label.ForeColor = Color.Orange;
                    }
                    else
                    {
                        label.Enabled = false;  
                    }
                }
            }
        }

        private void Label7_Click(object sender, EventArgs e)
        {
            txtInputBox.Text += label7.Text;
            for (int i = 1; i <= 17; i++)
            {
                string labelName = "label" + i.ToString();

                Label label = this.Controls[labelName] as Label;

                
                if (label != null)
                {
                    if (i == 6 || i ==2 || i == 3 || i == 4 || i == 8 || i ==10 || i ==11 || i == 12)
                    {
                        label.Enabled = true;
                        label.ForeColor = Color.Orange;
                    }
                    else
                    {
                        label.Enabled = false;  
                    }
                }
            }
        }

        private void Label8_Click(object sender, EventArgs e)
        {
            txtInputBox.Text += label8.Text;
            for (int i = 1; i <= 17; i++)
            {
                string labelName = "label" + i.ToString();

                Label label = this.Controls[labelName] as Label;

                
                if (label != null)
                {
                    if (i == 3 || i == 4 || i == 7 || i == 11 || i == 12)
                    {
                        label.Enabled = true;
                        label.ForeColor = Color.Orange;
                    }
                    else
                    {
                        label.Enabled = false;  
                    }
                }
            }
        }

        private void Label9_Click(object sender, EventArgs e)
        {
            txtInputBox.Text += label9.Text;
            for (int i = 1; i <= 17; i++)
            {
                string labelName = "label" + i.ToString();

                Label label = this.Controls[labelName] as Label;

                
                if (label != null)
                {
                    if (i == 5 || i == 6 || i == 10 || i == 13 || i == 14)
                    {
                        label.Enabled = true;
                        label.ForeColor = Color.Orange;
                    }
                    else
                    {
                        label.Enabled = false;  
                    }
                }
            }
        }

        private void Label10_Click(object sender, EventArgs e)
        {
            txtInputBox.Text += label10.Text;
            for (int i = 1; i <= 17; i++)
            {
                string labelName = "label" + i.ToString();

                Label label = this.Controls[labelName] as Label;

                
                if (label != null)
                {
                    if (i == 9 || i == 5 || i == 6 || i == 7 || i == 11 || i == 13 || i == 14 || i == 15)
                    {
                        label.Enabled = true;
                        label.ForeColor = Color.Orange;
                    }
                    else
                    {
                        label.Enabled = false;  
                    }
                }
            }
        }

        private void Label11_Click(object sender, EventArgs e)
        {
            txtInputBox.Text += label11.Text;
            for (int i = 1; i <= 17; i++)
            {
                string labelName = "label" + i.ToString();

                Label label = this.Controls[labelName] as Label;

                
                if (label != null)
                {
                    if (i == 10 || i == 12 || i == 6 || i == 7 || i == 8 || i == 14 || i == 15 || i == 16)
                    {
                        label.Enabled = true;
                        label.ForeColor = Color.Orange;
                    }
                    else
                    {
                        label.Enabled = false;  
                    }
                }
            }
        }

        private void Label12_Click(object sender, EventArgs e)
        {
            txtInputBox.Text += label12.Text;
            for (int i = 1; i <= 17; i++)
            {
                string labelName = "label" + i.ToString();

                Label label = this.Controls[labelName] as Label;

                if (label != null)
                {
                    if (i == 7 || i == 8 || i == 11 || i == 15 || i == 16)
                    {
                        label.Enabled = true;
                        label.ForeColor = Color.Orange;
                    }
                    else
                    {
                        label.Enabled = false;  
                    }
                }
            }
        }

        private void Label13_Click(object sender, EventArgs e)
        {
            txtInputBox.Text += label13.Text;
            for (int i = 1; i <= 17; i++)
            {
                string labelName = "label" + i.ToString();

                Label label = this.Controls[labelName] as Label;

               
                if (label != null)
                {
                    if (i == 9 || i == 10 || i == 14)
                    {
                        label.Enabled = true;
                        label.ForeColor = Color.Orange;
                    }
                    else
                    {
                        label.Enabled = false; 
                    }
                }
            }
        }

        private void Label14_Click(object sender, EventArgs e)
        {
            txtInputBox.Text += label14.Text;
            for (int i = 1; i <= 17; i++)
            {
                string labelName = "label" + i.ToString();

                Label label = this.Controls[labelName] as Label;

               
                if (label != null)
                {
                    if (i == 13 || i == 9 || i == 10 || i == 11 || i == 16)
                    {
                        label.Enabled = true;
                        label.ForeColor = Color.Orange;
                    }
                    else
                    {
                        label.Enabled = false;  
                    }
                }
            }
        }

        private void Label15_Click(object sender, EventArgs e)
        {
            txtInputBox.Text += label15.Text;
            for (int i = 1; i <= 17; i++)
            {
                string labelName = "label" + i.ToString();

                Label label = this.Controls[labelName] as Label;

                
                if (label != null)
                {
                    if (i == 10 || i == 11 || i == 12 || i == 14 || i == 16)
                    {
                        label.Enabled = true;
                        label.ForeColor = Color.Orange;
                    }
                    else
                    {
                        label.Enabled = false;  
                    }
                }
            }
        }

        private void Label16_Click(object sender, EventArgs e)
        {
            txtInputBox.Text += label16.Text;
            for (int i = 1; i <= 17; i++)
            {
                string labelName = "label" + i.ToString();

                Label label = this.Controls[labelName] as Label;

                
                if (label != null)
                {
                    if (i == 11 || i == 12 || i == 15)
                    {
                        label.Enabled = true;
                        label.ForeColor = Color.Orange;
                    }
                    else
                    {
                        label.Enabled = false;  
                    }
                }
            }
        }

        // Exits the application when the Quit button is clicked
        private void Quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
                 