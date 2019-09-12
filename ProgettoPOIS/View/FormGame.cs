using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ProgettoPOIS.Controller;
using ProgettoPOIS.Exceptions;
using ProgettoPOIS.Model;


namespace ProgettoPOIS.View
{
    /// <summary>
    /// Form for fighting between the pokémon of the two players.
    /// </summary>
    /// /// <remarks>
    /// Extends the <c>Form</c> class.
    /// <see cref="Form"/>
    /// </remarks>
    public partial class FormGame : Form
    {
        // Definition of private internal attributes.
        #region Private 
        private ControllerGame _game;
        private Pokémon _p1;
        private Pokémon _p2;
        #endregion


        // Definition of class methods.
        #region Methods

        /// <summary>
        /// Constructo method of the <c>FormGame</c> class.
        /// </summary>
        /// <param name="pokémonPlayer1">List of pokémon chosen by player one.</param>
        /// <param name="pokémonPlayer2">List of pokémon chosen by player two.</param>
        public FormGame(List<Pokémon> pokémonPlayer1, List<Pokémon> pokémonPlayer2)
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            labelMessage.Text = "";

            _game = new ControllerGame(pokémonPlayer1, pokémonPlayer2);

            _game.Start();

            Change_round();
        }

        /// <summary>
        /// Change the game round and then the form too.
        /// </summary>
        private void Change_round()
        {
            int p1_level, p2_level;

            _game.NumRound++;

            // If the pokémon has been defeated it will be asked to change it.
            if (_game.PokémonSelectedPlayer1.HealthPoints == 0)
            {
                ChangeDeadPokémon(_game.PokémonSelectedPlayer1);
            }

            if (_game.PokémonSelectedPlayer2.HealthPoints == 0)
            {
                ChangeDeadPokémon(_game.PokémonSelectedPlayer2);
            }

            // The correct values are assigned to the graphic elements based on the round.

            progressBar1.Value = _game.PokémonSelectedPlayer1.HealthPoints;
            progressBar4.Value = _game.PokémonSelectedPlayer1.HealthPoints;
            progressBar2.Value = _game.PokémonSelectedPlayer2.HealthPoints;
            progressBar3.Value = _game.PokémonSelectedPlayer2.HealthPoints;

            if (_game.IsRoundPlayer1)
            {
                labelPlayer.Text = "Player 1";
                _p1 = _game.PokémonSelectedPlayer1;
                _p2 = _game.PokémonSelectedPlayer2;

                progressBar1.BringToFront();
                progressBar2.BringToFront();
            }
            else
            {
                labelPlayer.Text = "Player 2";
                _p1 = _game.PokémonSelectedPlayer2;
                _p2 = _game.PokémonSelectedPlayer1;

                progressBar3.BringToFront();
                progressBar4.BringToFront();
            }

            hp1.Text = _p1.HealthPoints.ToString();
            hp2.Text = _p2.HealthPoints.ToString();

            p1_level = ControllerGame.LevelOf(_p1);
            p2_level = ControllerGame.LevelOf(_p2);


            picture1.Image = Image.FromFile(Properties.Settings.Default.pathSprites +
                "/back/" + _p1.Name + ".gif");
            picture2.Image = Image.FromFile(Properties.Settings.Default.pathSprites +
                "/front/" + _p2.Name + ".gif");

            labelLevel1.Text = p1_level.ToString();
            labelLevel2.Text = p2_level.ToString();

            labelName1.Text = _p1.Name;
            labelName2.Text = _p2.Name;

            labelExp1.Text = _p1.Exp.ToString();
            labelExp2.Text = _p2.Exp.ToString();

            // Different actions are performed based on the level of the pokémon of the indicator.
            if (p1_level == 1)
            {
                buttonSkill1.Text = ((Level1)_p1).S1.Name;
                buttonSkill2.Text = ((Level1)_p1).S2.Name;
                buttonSkill3.Visible = false;
                buttonSkill4.Visible = false;
            }
            else if (p1_level == 2)
            {
                buttonSkill1.Text = ((Level2)_p1).S1.Name;
                buttonSkill2.Text = ((Level2)_p1).S2.Name;
                buttonSkill3.Text = ((Level2)_p1).S3.Name;
                buttonSkill3.Visible = true;
                buttonSkill4.Visible = false;
            }
            else
            {
                buttonSkill1.Text = ((Level3)_p1).S1.Name;
                buttonSkill2.Text = ((Level3)_p1).S2.Name;
                buttonSkill3.Text = ((Level3)_p1).S3.Name;
                buttonSkill4.Text = ((Level3)_p1).S4.Name;
                buttonSkill3.Visible = true;
                buttonSkill4.Visible = true;
            }
        }

        /// <summary>
        /// Write a new message.
        /// </summary>
        /// <param name="message">The new message.</param>
        public void WriteMessage(string message)
        {
            labelMessage.Text = message;
        }

        /// <summary>
        /// Allows you to change the pokémon that was defeated.
        /// </summary>
        /// <param name="p">Pokémon to change.</param>
        private void ChangeDeadPokémon(Pokémon p)
        {
            WriteMessage("Pokémon " + p.Name + " died!");
            if (!_game.ChangePokémon())
            {
                if (MessageBox.Show("Player " + ((_game.IsRoundPlayer1) ? "1" : "2") + " win! \n Do you want restart?", "End game",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    _game.Restart();
                }
                else
                {
                    _game.Exit();
                }
            }
        }

        /// <summary>
        /// Action to take when "ButtonChangePokémon" is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChangePokémon_Click(object sender, System.EventArgs e)
        {
            try
            {
                _game.ChangePokémon();
                Change_round();
            }
            catch (ChangeException ex)
            {
                MessageBox.Show(ex.Message, "Pokémon change", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        /// <summary>
        /// Action to take when the form is closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            _game.Exit();
        }

        #region BUTTON SKILL

        private void ButtonSkill1_Click(object sender, System.EventArgs e)
        {
            Level1 p = (Level1)_p1;

            if (!_game.BoSkill(p.S1))
            {
                WriteMessage(p.Name + " failed " + p.S1.Name + "!");
            }
            else
            {
                WriteMessage(p.Name + " use " + p.S1.Name + "!");
            }

            if (_game.Evolve())
            {
                WriteMessage(p.Name + " evolved!");
            }

            Change_round();
        }

        private void ButtonSkill2_Click(object sender, System.EventArgs e)
        {
            Level1 p = (Level1)_p1;

            if (!_game.BoSkill(p.S2))
            {
                WriteMessage(p.Name + " failed " + p.S2.Name + "!");
            }
            else
            {
                WriteMessage(p.Name + " use " + p.S2.Name + "!");
            }

            if (_game.Evolve())
            {
                WriteMessage(p.Name + " evolved!");
            }

            Change_round();
        }

        private void ButtonSkill3_Click(object sender, System.EventArgs e)
        {
            Level2 p = (Level2)_p1;

            if (!_game.BoSkill(p.S3))
            {
                WriteMessage(p.Name + " failed " + p.S3.Name + "!");
            }
            else
            {
                WriteMessage(p.Name + " use " + p.S3.Name + "!");
            }

            if (_game.Evolve())
            {
                WriteMessage(p.Name + " evolved!");
            }

            Change_round();
        }

        private void ButtonSkill4_Click(object sender, System.EventArgs e)
        {
            Level3 p = (Level3)_p1;

            if (!_game.BoSkill(p.S4))
            {
                WriteMessage(p.Name + " failed " + p.S4.Name + "!");
            }
            else
            {
                WriteMessage(p.Name + " use " + p.S4.Name + "!");
            }

            if (_game.Evolve())
            {
                WriteMessage(p.Name + " evolved!");
            }

            Change_round();
        }

        #endregion

        #endregion
    }
}
