using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PokemonGame.Controller;
using PokemonGame.Exceptions;
using PokemonGame.Model;


namespace PokemonGame.View
{
    /// <summary>
    /// Form for fighting between the pokemon of the two players.
    /// </summary>
    /// <remarks>
    /// Extends the <c>Form</c> class.
    /// <see cref="Form"/>
    /// </remarks>
    public partial class FormGame : Form
    {
        // Definition of private internal attributes.
        #region Private 
        private ControllerGame _game;
        private Pokemon _p1;
        private Pokemon _p2;
        #endregion


        // Definition of class methods.
        #region Methods

        /// <summary>
        /// Constructor method of the <c>FormGame</c> class.
        /// </summary>
        /// <param name="pokemonPlayer1">List of pokemon chosen by player one.</param>
        /// <param name="pokemonPlayer2">List of pokemon chosen by player two.</param>
        public FormGame(List<Pokemon> pokemonPlayer1, List<Pokemon> pokemonPlayer2)
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            labelMessage.Text = "";

            _game = new ControllerGame(pokemonPlayer1, pokemonPlayer2);

            _game.Start();

            Change_round();
        }

        /// <summary>
        /// Update view items.
        /// </summary>
        private void UpdateGraphics()
        {
            int p1_level, p2_level;

            // The correct values are assigned to the graphic elements based on the round.

            progressBar1.Value = _game.PokemonSelectedPlayer1.HealthPoints;
            progressBar4.Value = _game.PokemonSelectedPlayer1.HealthPoints;
            progressBar2.Value = _game.PokemonSelectedPlayer2.HealthPoints;
            progressBar3.Value = _game.PokemonSelectedPlayer2.HealthPoints;

            if (_game.IsRoundPlayer1)
            {
                labelPlayer.Text = "Player 1";
                _p1 = _game.PokemonSelectedPlayer1;
                _p2 = _game.PokemonSelectedPlayer2;

                progressBar1.BringToFront();
                progressBar2.BringToFront();
            }
            else
            {
                labelPlayer.Text = "Player 2";
                _p1 = _game.PokemonSelectedPlayer2;
                _p2 = _game.PokemonSelectedPlayer1;

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

            // Different actions are performed based on the level of the pokemon of the indicator.
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
        /// Change the game round and then the form too.
        /// </summary>
        private void Change_round()
        {
            
            _game.NumRound++;

            // If the pokemon has been defeated it will be asked to change it.
            if (_game.PokemonSelectedPlayer1.HealthPoints == 0)
            {
                ChangeDeadPokemon(_game.PokemonSelectedPlayer1);
            }

            if (_game.PokemonSelectedPlayer2.HealthPoints == 0)
            {
                ChangeDeadPokemon(_game.PokemonSelectedPlayer2);
            }

            UpdateGraphics();
        }

        /// <summary>
        /// Write a new message.
        /// </summary>
        /// <param name="message">The new message.</param>
        private void WriteMessage(string message)
        {
            labelMessage.Text = message;
        }

        /// <summary>
        /// Allows you to change the pokemon that was defeated.
        /// </summary>
        /// <param name="p">Pokemon to change.</param>
        private void ChangeDeadPokemon(Pokemon p)
        {
            WriteMessage("Pokemon " + p.Name + " died!");
            UpdateGraphics();

            if (!_game.ChangePokemon())
            {
                if (MessageBox.Show("Player " + ((_game.IsRoundPlayer1) ? "2" : "1") + " win! \n Do you want restart?", "End game",
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
        /// Action to do when "ButtonChangePokemon" is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChangePokemon_Click(object sender, System.EventArgs e)
        {
            try
            {
                _game.ChangePokemon();
                Change_round();
            }
            catch (ChangeException ex)
            {
                MessageBox.Show(ex.Message, "Pokemon change", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Action to do when the form is closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            _game.Exit();
        }

        #region BUTTON SKILL

        /// <summary>
        /// Action to do when the skill button one was clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSkill1_Click(object sender, System.EventArgs e)
        {
            Level1 p = (Level1)_p1;

            if (!_game.DoSkill(p.S1))
            {
                WriteMessage(p.Name + " failed " + p.S1.Name + "!");
            }
            else
            {
                WriteMessage(p.Name + " uses " + p.S1.Name + "!");
            }

            if (_game.Evolve())
            {
                WriteMessage(p.Name + " evolved!");
            }

            Change_round();
        }

        /// <summary>
        /// Action to do when the skill button two was clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSkill2_Click(object sender, System.EventArgs e)
        {
            Level1 p = (Level1)_p1;

            if (!_game.DoSkill(p.S2))
            {
                WriteMessage(p.Name + " failed " + p.S2.Name + "!");
            }
            else
            {
                WriteMessage(p.Name + " uses " + p.S2.Name + "!");
            }

            if (_game.Evolve())
            {
                WriteMessage(p.Name + " evolved!");
            }

            Change_round();
        }

        /// <summary>
        /// Action to do when the skill button three was clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSkill3_Click(object sender, System.EventArgs e)
        {
            Level2 p = (Level2)_p1;

            if (!_game.DoSkill(p.S3))
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

        /// <summary>
        /// Action to do when the skill button four was clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSkill4_Click(object sender, System.EventArgs e)
        {
            Level3 p = (Level3)_p1;

            if (!_game.DoSkill(p.S4))
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
