using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProgettoPOIS.Controller;
using ProgettoPOIS.Model;

using static System.Windows.Forms.CheckedListBox;


namespace ProgettoPOIS
{
    public partial class FormChoose : Form
    {
        ControllerChoose choose;
             
        public FormChoose()
        {
            InitializeComponent();

            choose = new ControllerChoose();
         
            foreach (Pokémon p in choose.PokémonList)
                if(p.GetType()==typeof(Level1))
                   checkedListBox.Items.Add(p.Name,false);
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            CheckedItemCollection checkedPlayer = checkedListBox.CheckedItems;

            if (checkedPlayer.Count < 3)
            {
                MessageBox.Show("Select 3 pokémon!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);                
            }
            else if (choose.PokémonPlayer1.Count == 0)
            {
                //select pokémon player 1
                foreach (string pName in checkedPlayer)
                    choose.PokémonPlayer1.Add(choose.PokémonList.Where(p => p.Name == pName).FirstOrDefault()); 


            }
            else
            {
                //select pokémon player 2
                foreach (string pName in checkedPlayer)
                    choose.PokémonPlayer2.Add(choose.PokémonList.Where(p => p.Name == pName).FirstOrDefault());

                choose.startGame();
            }

        }

        private void CheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //detail pokémon on the right side

        }
    }
}
