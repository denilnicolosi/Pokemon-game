using ProgettoPOIS.Controller;
using ProgettoPOIS.Model;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.CheckedListBox;

namespace ProgettoPOIS.View
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FormChoose : Form
    {
        ControllerChoose choose;

        public FormChoose()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            choose = new ControllerChoose();

            foreach (Pokémon p in choose.PokémonList)
                if (p.GetType() == typeof(Level1))
                    checkedListBox.Items.Add(p.Name, false);

            checkedListBox.SelectedIndex=0;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            CheckedItemCollection checkedPlayer = checkedListBox.CheckedItems;
            
            if (checkedPlayer.Count != 3)
            {
                MessageBox.Show("Select 3 pokémon!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (choose.PokémonPlayer1.Count == 0)
            {
                //select pokémon player 1
                foreach (string pName in checkedPlayer)
                    choose.PokémonPlayer1.Add((Pokémon)choose.PokémonList.Where(p => p.Name == pName).FirstOrDefault().Clone());

                labelPlayer.Text = "Player2";
                buttonStart.Text = "Start game";

                //clear selected
                for (int i = 0; i < checkedListBox.Items.Count; i++)
                    checkedListBox.SetItemCheckState(i, CheckState.Unchecked);
            }
            else
            {
                //select pokémon player 2
                foreach (string pName in checkedPlayer)
                    choose.PokémonPlayer2.Add((Pokémon)choose.PokémonList.Where(p => p.Name == pName).FirstOrDefault().Clone());

                choose.start();
                this.Hide();
            }
        }

        private void CheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //detail pokémon on the right side
            string pokemonName = (string)checkedListBox.SelectedItem;                       
            Level1 pokémonSelected = (Level1)(choose.PokémonList.Where(p => p.Name == pokemonName).FirstOrDefault());

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

        private void FormChoose_FormClosed(object sender, FormClosedEventArgs e)
        {
            choose.exit();
        }
    }
}
