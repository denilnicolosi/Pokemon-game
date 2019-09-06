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

            StreamReader readerPokémon, readerSkill;     
            Pokémon.typeAttribute attribute;

            #region Reading/loading skill
            try
            {
                // Reading skills from file.              
                readerSkill = new StreamReader(pathSkill);
                while (!readerSkill.EndOfStream)
                {
                    string line = readerSkill.ReadLine();
                    string[] values = line.Split(';');
                    if (!string.IsNullOrEmpty(line))
                    {
                        // Switch on skill type.
                        switch (values[0].ToLower().Trim())
                        {
                            case "attack":
                                tmpSkill = new Attack(values[1],
                                                      Int32.Parse(values[2]),
                                                      Int32.Parse(values[3]));
                                break;
                            case "defence":
                                tmpSkill = new Defence(values[1],
                                                       Int32.Parse(values[2]),
                                                       Int32.Parse(values[3]));
                                break;
                            default:
                                throw new FormatException();
                                break;
                        }
                        listSkill.Add(tmpSkill);
                    }
                }
            }
            catch (ArgumentNullException argNullEx)
            {
                Console.WriteLine(argNullEx);
                MessageBox.Show("A value of a skill is missing.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                exit();
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx);
                MessageBox.Show("A value of a skill is incorrect.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                exit();
            }
            catch (OverflowException overfEx)
            {
                Console.WriteLine(overfEx);
                MessageBox.Show("A value of a skill is overflowed.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                exit();
            }
            catch (SystemException sysEx)      // Capture the StreaReader exceptions.
            {
                Console.WriteLine(sysEx);
                MessageBox.Show("Error reading skill.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                exit();
            }

            #endregion

            #region Reading/loading pokémon
            try
            { 
                // Reading pokémon from file
                readerPokémon = new StreamReader(pathPokémon);
                while (!readerPokémon.EndOfStream)
                {
                    string line = readerPokémon.ReadLine();
                    string[] values = line.Split(';');

                    if (!string.IsNullOrEmpty(line))
                    {
                     // Switch on level.
                    switch (Int32.Parse(values[0]))
                    {
                        case 1:
                            // Definition of pokémon attribute.
                            switch (values[1].ToLower().Trim())
                            {
                                case "grass":
                                    attribute = Pokémon.typeAttribute.Grass;
                                    break;
                                case "fire":
                                    attribute = Pokémon.typeAttribute.Fire;
                                    break;
                                case "water":
                                    attribute = Pokémon.typeAttribute.Water;
                                    break;
                                default:
                                        throw new ArgumentException("Attribute not found.");
                            }

                            // Pokémon instance creation.
                            tmpPokémon = new Level1(attribute, values[2],
                                                    Int32.Parse(values[3]),
                                                    Int32.Parse(values[4]),
                                                    listSkill.Where(s => s.Name == values[5]).FirstOrDefault(),
                                                    listSkill.Where(s => s.Name == values[6]).FirstOrDefault());
                            break;

                        case 2:
                            // Creation of links between levels 1 and 2.
                            prevPokémon = (Level1)listPokémon.Where(p => p.Name == values[1]).FirstOrDefault();

                            // Pokémon instance creation.
                            tmpPokémon = new Level2(prevPokémon.Attribute, values[2],
                                                    Int32.Parse(values[3]), Int32.Parse(values[4]),
                                                    ((Level1)prevPokémon).S1, ((Level1)prevPokémon).S2,
                                                    listSkill.Where(s => s.Name == values[5]).FirstOrDefault());

                            prevPokémon.NextLevel = tmpPokémon;
                            break;

                        case 3:
                            // creation of links between levels 2 and 3.
                            prevPokémon = (Level2)listPokémon.Where(p => p.Name == values[1]).FirstOrDefault();

                            // Pokémon instance creation.
                            tmpPokémon = new Level3(prevPokémon.Attribute, values[2],
                                                    Int32.Parse(values[3]), Int32.Parse(values[4]),
                                                    ((Level2)prevPokémon).S1, ((Level2)prevPokémon).S2,
                                                    ((Level2)prevPokémon).S3, 
                                                    listSkill.Where(s => s.Name == values[5]).FirstOrDefault());
 
                            prevPokémon.NextLevel = tmpPokémon;
                            break;

                        default:
                            Console.WriteLine("Error reading from pokèmon file.");
                            tmpPokémon = null;
                            break;
                    }

                    if (tmpPokémon != null)
                        listPokémon.Add(tmpPokémon);
                    }
                }
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx);
                MessageBox.Show(argEx.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SystemException sysEx)      // Capture the StreaReader exceptions.
            {
                Console.WriteLine(sysEx);
                MessageBox.Show("Error reading pokémon.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                exit();
            }

            #endregion

            return listPokémon;
        }

        /// <summary>
        /// Method that starts the game form.
        /// </summary>
        /// <remarks>
        /// It instantiates a <c>FormGame</c> object and shows it.
        /// </remarks>
        public void start()
        {
            viewGame = new FormGame(pokémonPlayer1, pokémonPlayer2);
            viewGame.Show(); 
        }

        public void exit()
        {
            Application.Exit();
            Environment.Exit(0);
        }
        
        #endregion
    }
}
