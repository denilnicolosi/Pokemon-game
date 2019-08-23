using ProgettoPOIS.Controller;
using ProgettoPOIS.Model;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ProgettoPOIS
{
    public partial class FormGame : Form
    {
        private ControllerGame game;
        private Pokémon p1, p2;

        public FormGame(List<Pokémon> pokémonPlayer1, List<Pokémon> pokémonPlayer2)
        {
            InitializeComponent();

            game = new ControllerGame(pokémonPlayer1, pokémonPlayer2);

            change_round();
        }

        private void change_round()
        {
            int p1_level, p2_level;

            game.NumRound++;

            if (game.NumRound % 2 == 0)
            {
                p1 = game.PokémonSelectedPlayer1;
                p2 = game.PokémonSelectedPlayer2;
            }
            else
            {
                p1 = game.PokémonSelectedPlayer2;
                p2 = game.PokémonSelectedPlayer1;
            }

            p1_level = game.levelOf(p1);
            p2_level = game.levelOf(p2);

            picture1.Image = Image.FromFile(Properties.Settings.Default.pathSprites + p1.Name + ".png");
            picture2.Image = Image.FromFile(Properties.Settings.Default.pathSprites + p2.Name + ".png");

            progressBar1.Value = p1.HealthPoints;
            progressBar2.Value = p2.HealthPoints;

            labelLevel1.Text = p1_level.ToString();
            labelLevel2.Text = p2_level.ToString();

            labelName1.Text = p1.Name;
            labelName2.Text = p2.Name;

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

        private void change_pokémon()
        {

        }

        private void ButtonChangePokémon_Click(object sender, System.EventArgs e)
        {

        }

        #region BUTTON SKILL

        private void ButtonSkill1_Click(object sender, System.EventArgs e)
        {
            Level1 p;

            if (game.NumRound % 2 == 0)
                p = (Level1)game.PokémonSelectedPlayer1;
            else
                p = (Level1)game.PokémonSelectedPlayer2;

            game.doSkill(p.S1);

            change_round();
        }

        private void ButtonSkill2_Click(object sender, System.EventArgs e)
        {
            Level1 p;

            if (game.NumRound % 2 == 0)
                p = (Level1)game.PokémonSelectedPlayer1;
            else
                p = (Level1)game.PokémonSelectedPlayer2;

            game.doSkill(p.S1);

            change_round();
        }
        private void ButtonSkill3_Click(object sender, System.EventArgs e)
        {
            Level2 p;

            if (game.NumRound % 2 == 0)
                p = (Level2)game.PokémonSelectedPlayer1;
            else
                p = (Level2)game.PokémonSelectedPlayer2;

            game.doSkill(p.S1);

            change_round();
        }

        private void ButtonSkill4_Click(object sender, System.EventArgs e)
        {
            Level3 p;

            if (game.NumRound % 2 == 0)
                p = (Level3)game.PokémonSelectedPlayer1;
            else
                p = (Level3)game.PokémonSelectedPlayer2;

            game.doSkill(p.S1);

            change_round();
        }

        #endregion



    }
}
