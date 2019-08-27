using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProgettoPOIS.Model;
using ProgettoPOIS.Controller;

namespace ProgettoPOIS.View
{
    public partial class FormChange : Form
    {
        private List<Pokémon> _pokémonList;

        private Pokémon selectedPokémon;

        public Pokémon SelectedPokémon { get => selectedPokémon; set => selectedPokémon = value; }

        public FormChange(List<Pokémon> _pokémonPlayer)
        {
            InitializeComponent();
            
            _pokémonList = _pokémonPlayer;

            foreach (Pokémon p in _pokémonList)
                if(p.HealthPoints>0)
                    comboBox.Items.Add(p.Name);

            comboBox.SelectedIndex = 0;
        }

        private void ButtonChange_Click(object sender, EventArgs e)
        {
            string selected = (string)comboBox.SelectedItem;
            selectedPokémon = _pokémonList.Where(p => p.Name == selected).FirstOrDefault();
            Close();
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //detail pokémon on the right side
            string pokemonName = (string)comboBox.SelectedItem;
            Level1 pokémonSelected = (Level1)_pokémonList.Where(p => p.Name == pokemonName).FirstOrDefault();
            int level = ControllerGame.levelOf(pokémonSelected);

            picture.Image = Image.FromFile(Properties.Settings.Default.pathSprites + pokémonSelected.Name.ToLower() + ".png");
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
    }
}
