using ProgettoPOIS.Controller;
using ProgettoPOIS.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ProgettoPOIS.View
{
    public partial class FormGame : Form
    {
        private ControllerGame game;
       
        private Pokémon p1, p2;

        public FormGame(List<Pokémon> pokémonPlayer1, List<Pokémon> pokémonPlayer2)
        {
            InitializeComponent();                   

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            labelMessage.Text = "";

            game = new ControllerGame(pokémonPlayer1, pokémonPlayer2);

            game.start(); 

            change_round();
        }

        private void change_round()
        {
            int p1_level, p2_level;

            game.NumRound++;

            if (game.PokémonSelectedPlayer1.HealthPoints == 0)
                changeDeadPokémon(game.PokémonSelectedPlayer1);

            if (game.PokémonSelectedPlayer2.HealthPoints == 0)
                changeDeadPokémon(game.PokémonSelectedPlayer2);
            
            progressBar1.Value = game.PokémonSelectedPlayer1.HealthPoints;
            progressBar4.Value = game.PokémonSelectedPlayer1.HealthPoints;
            progressBar2.Value = game.PokémonSelectedPlayer2.HealthPoints;
            progressBar3.Value = game.PokémonSelectedPlayer2.HealthPoints;                       
            
            if (game.NumRound % 2 == 0)
            {
                labelPlayer.Text = "Player 1";
                p1 = game.PokémonSelectedPlayer1;
                p2 = game.PokémonSelectedPlayer2;
                              
                progressBar1.BringToFront();
                progressBar2.BringToFront();
            }
            else
            {
                labelPlayer.Text = "Player 2";
                p1 = game.PokémonSelectedPlayer2;
                p2 = game.PokémonSelectedPlayer1;
                               
                progressBar3.BringToFront();
                progressBar4.BringToFront();                            
            }

            hp1.Text = p1.HealthPoints.ToString();
            hp2.Text = p2.HealthPoints.ToString();

            p1_level = ControllerGame.levelOf(p1);
            p2_level = ControllerGame.levelOf(p2);

       
            picture1.Image = Image.FromFile(Properties.Settings.Default.pathSprites +
                "/back/" + p1.Name + ".gif");            
            picture2.Image = Image.FromFile(Properties.Settings.Default.pathSprites + 
                "/front/" + p2.Name + ".gif");
                      
            labelLevel1.Text = p1_level.ToString();
            labelLevel2.Text = p2_level.ToString();

            labelName1.Text = p1.Name;
            labelName2.Text = p2.Name;

            labelExp1.Text = p1.Exp.ToString();
            labelExp2.Text = p2.Exp.ToString();

            if (p1_level == 1)
            {
                buttonSkill1.Text = ((Level1)p1).S1.Name;
                buttonSkill2.Text = ((Level1)p1).S2.Name;
                buttonSkill3.Visible = false;
                buttonSkill4.Visible = false;
            }
            else if (p1_level == 2)
            {
                buttonSkill1.Text = ((Level2)p1).S1.Name;
                buttonSkill2.Text = ((Level2)p1).S2.Name;
                buttonSkill3.Text = ((Level2)p1).S3.Name;
                buttonSkill3.Visible = true;
                buttonSkill4.Visible = false;
            }
            else
            {
                buttonSkill1.Text = ((Level3)p1).S1.Name;
                buttonSkill2.Text = ((Level3)p1).S2.Name;
                buttonSkill3.Text = ((Level3)p1).S3.Name;
                buttonSkill4.Text = ((Level3)p1).S4.Name;
                buttonSkill3.Visible = true;
                buttonSkill4.Visible = true;
            }
        }

        public void writeMessage(string message)
        {
            labelMessage.Text = message;                     
        }

        private void changeDeadPokémon(Pokémon p)
        {           
            writeMessage("Pokémon " + p.Name + " died!");
            if (!game.changePokémon())
            {
                if (MessageBox.Show("Player " + ((game.IsRoundPlayer1)?"1":"2") + " win! \n Do you want restart?", "End game",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    game.Restart();
                else
                    game.exit();
            }
        }       

        private void ButtonChangePokémon_Click(object sender, System.EventArgs e)
        {
            game.changePokémon();
            change_round();
        }

        private void FormGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            game.exit();
        }

        #region BUTTON SKILL

        private void ButtonSkill1_Click(object sender, System.EventArgs e)
        {
            Level1 p = (Level1)p1;

            if (!game.doSkill(p.S1))
                writeMessage(p.Name + " failed " + p.S1.Name + "!");
            else
                writeMessage(p.Name + " use " + p.S1.Name + "!");

            if (game.evolve())
                writeMessage(p.Name + " evolved!");

            change_round();
        }

        private void ButtonSkill2_Click(object sender, System.EventArgs e)
        {
            Level1 p = (Level1) p1;
            
            if (!game.doSkill(p.S2))                
                writeMessage(p.Name + " failed " + p.S2.Name + "!");
            else
                writeMessage(p.Name + " use " + p.S2.Name + "!");

            if (game.evolve())
                writeMessage(p.Name + " evolved!");

            change_round();
        }

        private void ButtonSkill3_Click(object sender, System.EventArgs e)
        {
            Level2 p = (Level2) p1;         

            if (!game.doSkill(p.S3))
                writeMessage(p.Name + " failed " + p.S3.Name + "!");
            else
                writeMessage(p.Name + " use " + p.S3.Name + "!");

            if (game.evolve())
                writeMessage(p.Name + " evolved!");

            change_round();
        }     

        private void ButtonSkill4_Click(object sender, System.EventArgs e)
        {
            Level3 p = (Level3) p1;           

            if (!game.doSkill(p.S4))                
                writeMessage(p.Name + " failed " + p.S4.Name + "!");
            else
                writeMessage(p.Name + " use " + p.S4.Name + "!");

            if (game.evolve())            
                writeMessage(p.Name + " evolved!");         
                  
            change_round();
        }

        #endregion

    }
}
