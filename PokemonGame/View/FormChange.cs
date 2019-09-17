using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PokemonGame.Controller;
using PokemonGame.Model;

namespace PokemonGame.View
{
    /// <summary>
    /// Form for changing the main pokemon.
    /// </summary>
    /// <remarks>
    /// Extends the <c>Form</c> class.
    /// <see cref="Form"/>
    /// </remarks>
    public partial class FormChange : Form
    {
        // Definition of private internal attributes.
        #region Private 
        private List<Pokemon> _pokemonList;
        private Pokemon _selectedPokemon;
        #endregion

        // Definition of public attributes, for the "get/set" methods.
        #region Public
        /// <summary>SPokemon that was selected.</summary>
        public Pokemon SelectedPokemon { get => _selectedPokemon; set => _selectedPokemon = value; }
        #endregion


        // Definition of class methods.
        #region Methods

        /// <summary>
        /// Constructor method of the <c>FormChange</c> class.
        /// </summary>
        /// <param name="pokemonList">List of pokemon of which one can choose.</param>
        /// <param name="isRoundPlayer1">Boolean that identifies if it is the round of the player one.</param>
        public FormChange(List<Pokemon> pokemonList, bool isRoundPlayer1)
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            labelPlayer.Text = (isRoundPlayer1) ? "Player1" : "Player2";

            _pokemonList = pokemonList;

            foreach (Pokemon p in _pokemonList)
            {
                if (p.HealthPoints > 0)
                {
                    comboBox.Items.Add(p.Name);
                }
            }

            comboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Action to take when "ButtonChange" is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChange_Click(object sender, EventArgs e)
        {
            string selected = (string)comboBox.SelectedItem;
            _selectedPokemon = _pokemonList.Where(p => p.Name == selected).FirstOrDefault();
            Close();
        }

        /// <summary>
        /// Action to take when changing a section in the "ComboBox".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Detail pokemon on the right side.
            string pokemonName = (string)comboBox.SelectedItem;
            Level1 pokemonSelected = (Level1)_pokemonList.Where(p => p.Name == pokemonName).FirstOrDefault();
            int level = ControllerGame.LevelOf(pokemonSelected);

            picture.Image = Image.FromFile(Properties.Settings.Default.pathSprites + "/front/" + pokemonSelected.Name + ".gif");
            labelName.Text = pokemonSelected.Name;
            labelAttribute.Text = pokemonSelected.Attribute.ToString();
            labelAttack.Text = pokemonSelected.Attack.ToString();
            labelDefence.Text = pokemonSelected.Defence.ToString();
            labelLevel.Text = level.ToString();
            labelExperience.Text = pokemonSelected.Exp.ToString();
            labelHealtPoints.Text = pokemonSelected.HealthPoints.ToString();
            labelSkill1.Text = pokemonSelected.S1.Name;
            labelSkill2.Text = pokemonSelected.S2.Name;

            if (level == 2)
            {
                labelSkill3.Text = ((Level2)pokemonSelected).S3.Name;
                labelSkill3.Visible = true;
                labelTxtSkill3.Visible = true;
            }
            else if (level == 3)
            {
                labelSkill4.Text = ((Level3)pokemonSelected).S4.Name;
                labelSkill4.Visible = true;
                labelTxtSkill4.Visible = true;
            }
            else
            {
                labelSkill3.Visible = false;
                labelTxtSkill3.Visible = false;
                labelSkill4.Visible = false;
                labelTxtSkill4.Visible = false;
            }
        }

        /// <summary>
        /// Action to take when the form is closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormChange_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_selectedPokemon == null)
            {
                string selected = (string)comboBox.SelectedItem;
                _selectedPokemon = _pokemonList.Where(p => p.Name == selected).FirstOrDefault();
            }
        }

        #endregion
    }
}
