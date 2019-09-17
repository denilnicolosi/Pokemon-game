using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PokemonGame.Exceptions;
using PokemonGame.Model;
using PokemonGame.View;

namespace PokemonGame.Controller
{
    /// <summary>
    /// Controller class for the pokemon selection.
    /// Contains methods and attributes used to interact with models.
    /// </summary>
    /// <remarks>
    /// It implements the "IController" interface.
    /// See <see cref="IController"/> For more information.
    /// </remarks>
    public class ControllerChoose : IController
    {
        // Definition of private internal attributes.
        #region Private 
        private List<Pokemon> _pokemonList;
        private List<Pokemon> _pokemonPlayer1;
        private List<Pokemon> _pokemonPlayer2;
        private FormGame _viewGame;
        #endregion

        // Definition of public attributes, for the "get/set" methods.
        #region Public
        /// <summary>List of pokemon chosen by player one.</summary>
        public List<Pokemon> PokemonPlayer1 { get => _pokemonPlayer1; set => _pokemonPlayer1 = value; }
        /// <summary>List of pokemon chosen by player one.</summary>
        public List<Pokemon> PokemonPlayer2 { get => _pokemonPlayer2; set => _pokemonPlayer2 = value; }
        /// <summary>List of pokemon to choose.</summary>
        public List<Pokemon> PokemonList { get => _pokemonList; set => _pokemonList = value; }
        #endregion


        // Definition of class methods.
        #region Methods

        /// <summary>
        /// Constructor method of the <c>ControllerChoose</c> class.
        /// </summary>
        public ControllerChoose()
        {
            _pokemonPlayer1 = new List<Pokemon>();
            _pokemonPlayer2 = new List<Pokemon>();

            _pokemonList = LoadPokemon(Properties.Settings.Default.pathPokemon,
                                      Properties.Settings.Default.pathSkill);
        }

        /// <summary>
        /// Method that reads data from files to load pokemon in the list.
        /// </summary>
        /// <remarks>
        /// Reading takes place on two ".csv" files, one for pokemon and one for skills.
        /// </remarks>
        /// <param name="pathPokemon">File path with pokemon data.</param>
        /// <param name="pathSkill">file path with skills data.</param>
        /// <returns>List of pokemon with the appropriate skills.</returns>
        public List<Pokemon> LoadPokemon(string pathPokemon, string pathSkill)
        {
            Pokemon tmpPokemon, prevPokemon;
            Skill tmpSkill;

            List<Pokemon> listPokemon = new List<Pokemon>();
            List<Skill> listSkill = new List<Skill>();

            StreamReader readerPokemon, readerSkill;
            Pokemon.typeAttribute attribute;

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
                        }
                        listSkill.Add(tmpSkill);
                    }
                }
            }
            catch (ArgumentNullException argNullEx)     // A value is missing.
            {
                Console.WriteLine(argNullEx);
                MessageBox.Show("A value of a skill is missing.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Exit();
            }
            catch (ArgumentException argEx)     // A value is incorrect.
            {
                Console.WriteLine(argEx);
                MessageBox.Show("A value of a skill is incorrect.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Exit();
            }
            catch (OverflowException overfEx)       // A value is overflowed.
            {
                Console.WriteLine(overfEx);
                MessageBox.Show("A value of a skill is overflowed.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Exit();
            }
            catch (SystemException sysEx)      // Capture the StreamReader exceptions.
            {
                Console.WriteLine(sysEx);
                MessageBox.Show("Error reading skill.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Exit();
            }

            #endregion

            #region Reading/loading pokemon
            try
            {
                // Reading pokemon from file
                readerPokemon = new StreamReader(pathPokemon);
                while (!readerPokemon.EndOfStream)
                {
                    string line = readerPokemon.ReadLine();
                    string[] values = line.Split(';');

                    if (!string.IsNullOrEmpty(line))
                    {
                        // Switch on level.
                        switch (Int32.Parse(values[0]))
                        {
                            case 1:
                                // Definition of pokemon attribute.
                                switch (values[1].ToLower().Trim())
                                {
                                    case "grass":
                                        attribute = Pokemon.typeAttribute.Grass;
                                        break;
                                    case "fire":
                                        attribute = Pokemon.typeAttribute.Fire;
                                        break;
                                    case "water":
                                        attribute = Pokemon.typeAttribute.Water;
                                        break;
                                    default:
                                        throw new ArgumentException("Attribute not found.");
                                }

                                // Pokemon instance creation.
                                tmpPokemon = new Level1(attribute, values[2],
                                                        Int32.Parse(values[3]),
                                                        Int32.Parse(values[4]),
                                                        listSkill.Where(s => s.Name == values[5]).FirstOrDefault(),
                                                        listSkill.Where(s => s.Name == values[6]).FirstOrDefault());
                                break;

                            case 2:
                                // Creation of links between levels 1 and 2.
                                prevPokemon = (Level1)listPokemon.Where(p => p.Name == values[1]).FirstOrDefault();

                                if (prevPokemon == null)
                                {
                                    throw new PokemonNotFoundException("Prev. pokemon not found for level 2.");
                                }

                                // Pokemon instance creation.
                                tmpPokemon = new Level2(prevPokemon.Attribute, values[2],
                                                    Int32.Parse(values[3]), Int32.Parse(values[4]),
                                                    ((Level1)prevPokemon).S1, ((Level1)prevPokemon).S2,
                                                    listSkill.Where(s => s.Name == values[5]).FirstOrDefault());

                                prevPokemon.NextLevel = tmpPokemon;
                                break;

                            case 3:
                                // creation of links between levels 2 and 3.
                                prevPokemon = (Level2)listPokemon.Where(p => p.Name == values[1]).FirstOrDefault();

                                if (prevPokemon == null)
                                {
                                    throw new PokemonNotFoundException("Prev. pokemon not found for level 3.");
                                }

                                // Pokemon instance creation.
                                tmpPokemon = new Level3(prevPokemon.Attribute, values[2],
                                                    Int32.Parse(values[3]), Int32.Parse(values[4]),
                                                    ((Level2)prevPokemon).S1, ((Level2)prevPokemon).S2,
                                                    ((Level2)prevPokemon).S3,
                                                    listSkill.Where(s => s.Name == values[5]).FirstOrDefault());

                                prevPokemon.NextLevel = tmpPokemon;
                                break;

                            default:
                                Console.WriteLine("Error reading from pokèmon file.");
                                tmpPokemon = null;
                                break;
                        }

                        if (tmpPokemon != null)
                        {
                            listPokemon.Add(tmpPokemon);
                        }
                    }
                }
            }
            catch (PokemonNotFoundException pnfEx)      // Pokemon not found.
            {
                Console.WriteLine(pnfEx);
                MessageBox.Show(pnfEx.Message, "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            catch (ArgumentNullException argNullEx)     // Missing argument.
            {
                Console.WriteLine(argNullEx);
                MessageBox.Show("A value of a pokemon is missing.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Exit();
            }
            catch (ArgumentException argEx)     // Errors during instance creation.
            {
                Console.WriteLine(argEx);
                MessageBox.Show(argEx.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Exit();
            }
            catch (SystemException sysEx)      // Capture the StreamReader exceptions.
            {
                Console.WriteLine(sysEx);
                MessageBox.Show("Error reading pokemon.\n" + sysEx.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Exit();
            }

            #endregion

            return listPokemon;
        }

        /// <summary>
        /// Method that starts the choose form.
        /// </summary>
        /// <remarks>
        /// It instantiates a <c>FormGame</c> object and shows it.
        /// </remarks>
        public void Start()
        {
            _viewGame = new FormGame(_pokemonPlayer1, _pokemonPlayer2);
            _viewGame.Show();
        }

        /// <summary>
        /// End program execution.
        /// </summary>
        public void Exit()
        {
            Application.Exit();
        }

        #endregion
    }
}
