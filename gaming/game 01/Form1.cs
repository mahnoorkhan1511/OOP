using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game_01
{
    public partial class Form1 : Form
    {
        bool goLeft, goRight, jumping, isGameOver;
        int jumpSpeed;
        int force;
        int score = 0;
        int playerSpeed = 7;

        int horizontalSpeed = 5;
        int verticalSpeed = 3;

        int enemy1Speed = 5;
        int enemy2Speed = 3;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void mainGameTimerEvent(object sender, EventArgs e)
        {
            txtscore.Text = "Score : " + score;
            player.Top += jumpSpeed;


            if( goLeft == true)
            {
                player.Left -= playerSpeed;

            }

            if( goRight == true)
            {
                player.Left += playerSpeed;
            }

            if( jumping == true && force < 0)
            {
                jumping = false;
            }

            if( jumping == true)
            {
                jumpSpeed = -8;
                force -= -1;
            }
            else
            {
                jumpSpeed = 10;

            }

            foreach( Control x in this.Controls)
            {
                if( x is PictureBox)
                {
                    if ((string)x.Tag == "platform")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            force = 8;
                            player.Top = x.Top - player.Height;
                            if ((string)x.Name == "horizontalPlatform" && goLeft == false || (string)x.Name == "horizontalPlatform" && goRight == false)
                            {
                                player.Left -= horizontalSpeed;
                            }

                        }

                        

                        x.BringToFront();
                    }

                    if((string)x.Tag == "coin")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                        {
                            x.Visible = false;
                            score++;
                        }
                    }
                    if((string)x.Tag == "enemy")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameTimer.Stop();
                            isGameOver = true;
                            txtscore.Text = "Score : " + score + Environment.NewLine + "You were killed !!" ;

                        }
                    }
                    if ((string)x.Name == "door" && player.Bounds.IntersectsWith(door.Bounds) && score == 21)
                    {
                        gameTimer.Stop();
                        isGameOver = true;
                        txtscore.Text = "Score : " + score + Environment.NewLine + "Your quest is Complete !";
                    }
                    else
                    {
                        txtscore.Text = "Score : " + score + Environment.NewLine + "Collect all the coins !";
                    }
                }
                
            }
            horizontalPlatform.Left -= horizontalSpeed;
            if (horizontalPlatform.Left < 0 || horizontalPlatform.Left + horizontalPlatform.Width > this.ClientSize.Width)
            {
                horizontalSpeed = -horizontalSpeed;
            }

            verticalPlatform.Top += verticalSpeed;
            if(verticalPlatform.Top < 147 || verticalPlatform.Top > 481)
            {
                verticalSpeed = -verticalSpeed;
            }
            enemy1.Left -= enemy1Speed;
            if( enemy1.Left < pictureBox5.Left || enemy1.Left + enemy1.Width > pictureBox5.Left + pictureBox5.Width)
            {
                enemy1Speed = -enemy1Speed;
            }

            enemy2.Left -= enemy2Speed;
            if( enemy2.Left < pictureBox2.Left || enemy2.Left + enemy2.Width > pictureBox2.Left + pictureBox2.Width)
            {
                enemy2Speed = -enemy2Speed;
            }

            if(player.Top + player.Height > this.ClientSize.Height + 50)
            {
                gameTimer.Stop();
                isGameOver = true;
                txtscore.Text = "Score : " + score + Environment.NewLine + "You fell to your death";
            }

            


        }

        private void keyIsDown(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }  
            if( e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
            if( e.KeyCode == Keys.Space && jumping == false )
            {
                jumping = true;
            }
            if( e.KeyCode == Keys.Space && jumping == true)
            {
                jumping = false;
            }

        }

        private void keyIsUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if( jumping == true)
            {
                jumping = false;
            }
            
            if( e.KeyCode == Keys.Enter && isGameOver == true)
            {
                restartGame();
            }




        }
        private void restartGame()
        {
            jumping = false;
            goLeft = false;
            goRight = false;
            isGameOver = false;
            score = 0;

            txtscore.Text = "Score : " + score;

            foreach (Control x in this.Controls )
            {
                if (x is PictureBox && x.Visible == false)
                {
                    x.Visible = true;
                }

                //reset the position of player, platform and enemies

                player.Left = 37;
                player.Top = 581;

                enemy1.Left = 303;
                enemy1.Top = 283;

                enemy2.Left = 439;
                enemy2.Top = 525;

                horizontalPlatform.Left = 158;
                verticalPlatform.Top = 481;

                gameTimer.Start();

            }
        }
    }
}
