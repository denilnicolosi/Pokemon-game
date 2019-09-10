using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ProgettoPOIS.Model;
using ProgettoPOIS.Controller;

namespace ProgettoPOIS.View
{
    /// <summary>
    /// Form for changing the main pokémon.
    /// </summary>
    /// <remarks>
    /// Extends the <c>Form</c> class.
    /// <see cref="Form"/>
    /// </remarks>
    public partial class FormChange : Form
    {
        // Definition of private internal attributes.
        #region Private 
        private List<Pokémon> _pokémonList;
        private Pokémon _selectedPokémon;
        #endregion

        // Definition of public attributes, for the "get/set" methods.
        #region Public 
        public Pokémon SelectedPokémon { get => _selectedPokémon; set => _selectedPokémon = value; }
        #endregion

        // Definition of class methods.
        #region Methods

        /// <summary>
        /// Constructor method of the <c>FormChange</c> class.
        /// </summary>
        /// <param name="pokémonList">List of pokémon of which one can choose.</param>
        public FormChange(List<Pokémon> pokémonList)
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            _pokémonList = pokémonList;

            foreach (Pokémon p in _pokémonList)
                if(p.HealthPoints>0)
                    comboBox.Items.Add(p.Name);

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
            _selectedPokémon = _pokémonList.Where(p => p.Name == selected).FirstOrDefault();
            Close();
        }

        /// <summary>
        /// Action to take when changing a section in the "ComboBox".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Detail pokémon on the right side.
            string pokemonName = (string)comboBox.SelectedItem;
            Level1 pokémonSelected = (Level1)_pokémonList.Where(p => p.Name == pokemonName).FirstOrDefault();
            int level = ControllerGame.levelOf(pokémonSelected);

            picture.Image = Image.FromFile(Properties.Settings.Default.pathSprites + "/front/" + pokémonSelected.Name + ".gif");
            labelName.Text = pokémonSelected.Name;
            labelAttribute.Text = pokémonSelected.Attribute.ToString();
            labelAttack.Text = pokémonSelected.Attack.ToString();
            labelDefence.Text = pokémonSelected.Defence.ToString();
            labelLevel.Text = level.ToString();
            labelExperience.Text = pokémonSelected.Exp.ToString();
            labelHealtPoints.Text = pokémonSelected.HealthPoints.ToString();
            labelSkill1.Text = pokémonSelected.S1.Name;
            labelSkill2.Text = pokémonSelected.S2.Name;

            if (level == 2)
            {
                labelSkill3.Text = ((Level2)pokémonSelected).S3.Name;
                labelSkill3.Visible = true;
                labelTxtSkill3.Visible = true;
            }
            else if(level == 3)
            {
                labelSkill4.Text = ((Level3)pokémonSelected).S4.Name;
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
            if (_selectedPokémon == null)
            {
                string selected = (string)comboBox.SelectedItem;
                _selectedPokémon = _pokémonList.Where(p => p.Name == selected).FirstOrDefault();
            }
        }

        #endregion
    }
}
