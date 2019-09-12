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
    /// Form for choosing your own pokémon.
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

            foreach (Pokémon p in _choose.PokémonList)
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
                MessageBox.Show("Select 3 pokémon!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (_choose.PokémonPlayer1.Count == 0)
            {
                // Select pokémon player 1.
                foreach (string pName in checkedPlayer)
                {
                    _choose.PokémonPlayer1.Add((Pokémon)_choose.PokémonList.Where(p => p.Name == pName).FirstOrDefault().Clone());
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
                // Select pokémon player 2.
                foreach (string pName in checkedPlayer)
                {
                    _choose.PokémonPlayer2.Add((Pokémon)_choose.PokémonList.Where(p => p.Name == pName).FirstOrDefault().Clone());
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
            //detail pokémon on the right side
            string pokemonName = (string)checkedListBox.SelectedItem;
            Level1 pokémonSelected = (Level1)(_choose.PokémonList.Where(p => p.Name == pokemonName).FirstOrDefault());

            if (pokémonSelected != null)
            {
                labelName.Text = pokémonSelected.Name;
                labelAttribute.Text = pokémonSelected.Attribute.ToString();
                labelAttack.Text = pokémonSelected.Attack.ToString();
                labelDefence.Text = pokémonSelected.Defence.ToString();
                labelSkill1.Text = pokémonSelected.S1.Name;
                labelSkill2.Text = pokémonSelected.S2.Name;
                picture.Image = Image.FromFile(Properties.Settings.Default.pathSprites + "/front/" + pokémonSelected.Name + ".gif");
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
