using ProgettoPOIS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ProgettoPOIS.View;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace ProgettoPOIS.Controller
{
    /// <summary>
    /// "Controller" class for the pokèmon selection.
    /// Contains methods and attributes used to interact with models.
    /// </summary>
    /// <remarks>
    /// It implements the "IController" interface.
    /// See <see cref="ProgettoPOIS.Controller.IController"/> For more information.
    /// </remarks>
    class ControllerChoose : IController
    {
        // Definition of private internal attributes.
        #region Private 
        private List<Pokémon> pokémonList;
        private List<Pokémon> pokémonPlayer1;
        private List<Pokémon> pokémonPlayer2;
        private FormGame viewGame;
        #endregion

        // Definition of public attributes, for the "get/set" methods.
        #region Public
        public List<Pokémon> PokémonPlayer1 { get => pokémonPlayer1; set => pokémonPlayer1 = value; }
        public List<Pokémon> PokémonPlayer2 { get => pokémonPlayer2; set => pokémonPlayer2 = value; }
        public List<Pokémon> PokémonList { get => pokémonList; set => pokémonList = value; }
        #endregion

        // Definition of class methods.
        #region Methods

        /// <summary>
        /// Constructor method of the <c>ControllerChoose</c> class.
        /// </summary>
        public ControllerChoose()
        {
            pokémonPlayer1 = new List<Pokémon>();
            pokémonPlayer2 = new List<Pokémon>();

            pokémonList = loadPokémon(Properties.Settings.Default.pathPokemon,
                                      Properties.Settings.Default.pathSkill);
        }

        /// <summary>
        /// Method that reads data from files to load pokémon in the list.
        /// </summary>
        /// <remarks>
        /// Reading takes place on two ".csv" files, one for pokémon and one for skills.
        /// </remarks>
        /// <param name="pathPokémon">File path with pokémon data.</param>
        /// <param name="pathSkill">file path with skills data.</param>
        /// <returns>List of pokémon with the appropriate skills.</returns>
        public List<Pokémon> loadPokémon(string pathPokémon, string pathSkill)
        {
            Pokémon tmpPokémon, prevPokémon;
            Skill tmpSkill;

            List<Pokémon> listPokémon = new List<Pokémon>();
            List<Skill> listSkill = new List<Skill>();

            StreamReader rPokémon, rSkill;
            XmlSerializer xmlPokémon, xmlSkill;
            Pokémon.typeAttribute t;

            try
            {
                // Reading skills from file.
                xmlSkill = new XmlSerializer(typeof(List<Skill>), new XmlRootAttribute("SKILL"));
                rSkill = new StreamReader(pathSkill);
                while (!rSkill.EndOfStream)
                {
                    string line = rSkill.ReadLine();
                    string[] values = line.Split(';');
                    if (!string.IsNullOrEmpty(line))
                    {
                        switch (values[0].ToLower().Trim())
                        {
                            case "attack":
                                tmpSkill = new Attack(values[1], Int32.Parse(values[2]), Int32.Parse(values[3]));
                                break;
                            case "defence":
                                tmpSkill = new Defence(values[1], Int32.Parse(values[2]), Int32.Parse(values[3]));
                                break;
                            default:
                                tmpSkill = null;
                                Console.WriteLine("Error: read from skill file.");
                                break;
                        }
                        if (tmpSkill != null)
                            listSkill.Add(tmpSkill);
                    }
                }

                // Reading pokémon from file
                rPokémon = new StreamReader(pathPokémon);
                while (!rPokémon.EndOfStream)
                {
                    string line = rPokémon.ReadLine();
                    string[] values = line.Split(';');

                    if (!string.IsNullOrEmpty(line))
                    {
                        switch (Int32.Parse(values[0]))
                        {
                            case 1:
                                switch (values[1].ToLower().Trim())
                                {
                                    case "earth":
                                        t = Pokémon.typeAttribute.Earth;
                                        break;
                                    case "fire":
                                        t = Pokémon.typeAttribute.Fire;
                                        break;
                                    case "water":
                                        t = Pokémon.typeAttribute.Water;
                                        break;
                                    default:
                                        t = Pokémon.typeAttribute.Earth;
                                        break;
                                }

                                tmpPokémon = new Level1(t, values[2], Int32.Parse(values[3]), Int32.Parse(values[4]),
                                    listSkill.Where(s => s.Name == values[5]).FirstOrDefault(),
                                    listSkill.Where(s => s.Name == values[6]).FirstOrDefault());

                                break;
                            case 2:
                                prevPokémon = (Level1)listPokémon.Where(p => p.Name == values[1]).FirstOrDefault();

                                tmpPokémon = new Level2(prevPokémon.Attribute, values[2], Int32.Parse(values[3]), Int32.Parse(values[4]),
                                    ((Level1)prevPokémon).S1, ((Level1)prevPokémon).S2, listSkill.Where(s => s.Name == values[5]).FirstOrDefault());

                                prevPokémon.NextLevel = tmpPokémon;
                                break;
                            case 3:
                                prevPokémon = (Level2)listPokémon.Where(p => p.Name == values[1]).FirstOrDefault();
                                Level3 l = new Level3(prevPokémon.Attribute, values[2], Int32.Parse(values[3]), Int32.Parse(values[4]),
                                    ((Level2)prevPokémon).S1, ((Level2)prevPokémon).S2, ((Level2)prevPokémon).S3, listSkill.Where(s => s.Name == values[5]).FirstOrDefault());
                                tmpPokémon = l;
                                prevPokémon.NextLevel = tmpPokémon;
                                break;
                            default:
                                Console.WriteLine("Error: read from pokèmon file.");
                                tmpPokémon = null;
                                break;
                        }

                        if (tmpPokémon != null)
                            listPokémon.Add(tmpPokémon);
                    }
                }
                return listPokémon;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Errore: " + ex, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Method that starts the game form.
        /// </summary>
        /// <remarks>
        /// It instantiates a <c>FormGame</c> object and shows it.
        /// </remarks>
        public void startGame()
        {
            viewGame = new FormGame(pokémonPlayer1, pokémonPlayer2);
            viewGame.Show(); 
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }

        public void Player1Shift()
        {
            throw new NotImplementedException();
        }

        public void Player2Shift()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
