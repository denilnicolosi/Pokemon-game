using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ProgettoPOIS.Controller;
using ProgettoPOIS.Model;
using static System.Windows.Forms.CheckedListBox;

namespace ProgettoPOIS.View
{
    /// <summary>
    /// Form for choosing your own pokemon.
    /// </summary>
    /// <remarks>
    /// Extends the <c>Form</c> class.
    /// <see cref="Form"/>
    /// </remarks>
    public partial class FormChoose : Form
    {
        // Definition of private internal attributes.
        #region Private 
        private ControllerChoose _choose;
        #endregion


        // Definition of class methods.
        #region Methods

        /// <summary>
        /// Constructor method pf the <c>FormChange</c> class.
        /// </summary>
        public FormChoose()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            _choose = new ControllerChoose();

            foreach (Pokemon p in _choose.PokemonList)
            {
                if (p.GetType() == typeof(Level1))
                {
                    checkedListBox.Items.Add(p.Name, false);
                }
            }

            checkedListBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Action to take when "Button1" is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            CheckedItemCollection checkedPlayer = checkedListBox.CheckedItems;

            if (checkedPlayer.Count != 3)
            {
                MessageBox.Show("Select 3 pokemon!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (_choose.PokemonPlayer1.Count == 0)
            {
                // Select pokemon player 1.
                foreach (string pName in checkedPlayer)
                {
                    _choose.PokemonPlayer1.Add((Pokemon)_choose.PokemonList.Where(p => p.Name == pName).FirstOrDefault().Clone());
                }

                labelPlayer.Text = "Player2";
                buttonStart.Text = "Start game";

                // Clear selected.
                for (int i = 0; i < checkedListBox.Items.Count; i++)
                {
                    checkedListBox.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
            else
            {
                // Select pokemon player 2.
                foreach (string pName in checkedPlayer)
                {
                    _choose.PokemonPlayer2.Add((Pokemon)_choose.PokemonList.Where(p => p.Name == pName).FirstOrDefault().Clone());
                }

                _choose.Start();
                this.Hide();
            }
        }

        /// <summary>
        /// Action to take when changing a selection in the "CheckedListBox".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //detail pokemon on the right side
            string pokemonName = (string)checkedListBox.SelectedItem;
            Level1 pokemonSelected = (Level1)(_choose.PokemonList.Where(p => p.Name == pokemonName).FirstOrDefault());

            if (pokemonSelected != null)
            {
                labelName.Text = pokemonSelected.Name;
                labelAttribute.Text = pokemonSelected.Attribute.ToString();
                labelAttack.Text = pokemonSelected.Attack.ToString();
                labelDefence.Text = pokemonSelected.Defence.ToString();
                labelSkill1.Text = pokemonSelected.S1.Name;
                labelSkill2.Text = pokemonSelected.S2.Name;
                picture.Image = Image.FromFile(Properties.Settings.Default.pathSprites + "/front/" + pokemonSelected.Name + ".gif");
            }
        }

        /// <summary>
        /// Action to take when the form is closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormChoose_FormClosed(object sender, FormClosedEventArgs e)
        {
            _choose.Exit();
        }

        #endregion
    }
}
