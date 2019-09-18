using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PokemonGame.Exceptions;
using PokemonGame.Model;
using PokemonGame.View;

namespace PokemonGame.Controller
{
    /// <summary>
    /// Controller for the game.
    /// Contains all the basic attributes and methods to control the game.
    /// </summary>
    /// <remarks>
    /// It implements the "IController" interface.
    /// See <see cref="IController"/> For more information.
    /// </remarks>
    public class ControllerGame : IController
    {
        // Definition of private internal attributes.
        #region Private 
        private int _numRound;
        private bool _isRoundPlayer1;
        private FormChange _change;
        private Pokemon _pokemonSelectedPlayer1;
        private Pokemon _pokemonSelectedPlayer2;
        private List<Pokemon> _pokemonPlayer1;
        private List<Pokemon> _pokemonPlayer2;
        #endregion

        // Definition of public attributes, for the "get/set" methods.
        #region Public 
        /// <summary>Pokemon selected by player one.</summary>
        public Pokemon PokemonSelectedPlayer1 { get => _pokemonSelectedPlayer1; set => _pokemonSelectedPlayer1 = value; }
        /// <summary>Pokemon selected by player two.</summary>
        public Pokemon PokemonSelectedPlayer2 { get => _pokemonSelectedPlayer2; set => _pokemonSelectedPlayer2 = value; }
        /// <summary>Number of the current round.</summary>
        public int NumRound
        {
            get => _numRound;
            set
            {
                _numRound = value;
                _isRoundPlayer1 = (_numRound % 2 == 0) ? true : false;
            }
        }
        /// <summary>Boolean that identifies if it is the round of the player one.</summary>
        public bool IsRoundPlayer1 { get => _isRoundPlayer1; set => _isRoundPlayer1 = value; }
        #endregion


        // Definition of class methods.
        #region Methods

        /// <summary>
        /// Constructor method of the <c>ControllerGame</c> class.
        /// </summary>
        /// <param name="pokemonPlayer1">List of <c>Pokemon</c> chosen by player 1.</param>
        /// <param name="pokemonPlayer2">List of <c>Pokemon</c> chosen by player 2.</param>
        public ControllerGame(List<Pokemon> pokemonPlayer1, List<Pokemon> pokemonPlayer2)
        {
            _pokemonPlayer1 = pokemonPlayer1;
            _pokemonPlayer2 = pokemonPlayer2;
            NumRound = -1;
        }

        /// <summary>
        /// Select the main Pokemon of current player.
        /// </summary>
        /// <param name="p">Pokemon that will become the main one.</param>
        public void ChoosePokèmon(Pokemon p)
        {
            if (_isRoundPlayer1)
            {
                _pokemonSelectedPlayer1 = p;
            }
            else
            {
                _pokemonSelectedPlayer2 = p;
            }
        }

        /// <summary>
        /// Show the form for choosing the pokemon to be the main one,
        /// and make it effective.
        /// </summary>
        /// <returns>Boolean for the success of the exchange.</returns>
        /// <exception cref="PokemonGame.Exceptions.ChangeException">
        /// Pokemon already in the battlefield.
        /// </exception>
        public bool ChangePokemon()
        {
            bool success = false;
            Pokemon selectePokemon;

            if (!CheckDefeat())
            {
                if (_isRoundPlayer1)
                {
                    _change = new FormChange(_pokemonPlayer1, _isRoundPlayer1);
                }
                else
                {
                    _change = new FormChange(_pokemonPlayer2, _isRoundPlayer1);
                }

                _change.ShowDialog();
                selectePokemon = _change.SelectedPokemon;

                if (selectePokemon == ((_isRoundPlayer1) ? _pokemonSelectedPlayer1
                                                         : _pokemonSelectedPlayer2))
                {
                    throw new ChangeException();
                }

                if (selectePokemon != null)
                {
                    ChoosePokèmon(selectePokemon);
                }

                success = true;
            }
            return success;
        }

        /// <summary>
        /// Check if the current player has been defeated.
        /// </summary>
        /// <remarks>
        /// Check the health points of all pokemon of the current player,
        /// to verify the defeat.
        /// </remarks>
        /// <returns>Boolean for the outcome of the defeat check.</returns>
        public bool CheckDefeat()
        {
            bool success = true;

            if (_isRoundPlayer1)
            {
                foreach (Pokemon p in _pokemonPlayer1)
                {
                    if (p.HealthPoints > 0)
                    {
                        success = false;
                    }
                }
            }
            else
            {
                foreach (Pokemon p in _pokemonPlayer2)
                {
                    if (p.HealthPoints > 0)
                    {
                        success = false;
                    }
                }
            }

            return success;
        }

        /// <summary>
        /// It try to execute the skill.
        /// </summary>
        /// <remarks>
        /// Calculate and make changes to pokemon values.
        /// </remarks>
        /// <param name="s">Skill to try to perform.</param>
        /// <returns>Boolean for the success of the skill.</returns>
        public bool DoSkill(Skill s)
        {
            bool success = CalculatesPossibility((_isRoundPlayer1) ? _pokemonSelectedPlayer1 : _pokemonSelectedPlayer2);

            if (success)
            {
                if (s.GetType() == typeof(Attack))
                {
                    if (_isRoundPlayer1)
                    {
                        _pokemonSelectedPlayer2.HealthPoints -= CalculatesDamage(_pokemonSelectedPlayer1,
                                                                                 _pokemonSelectedPlayer2,
                                                                                 (Attack)s);
                        _pokemonSelectedPlayer1.Exp += s.ExpEarned;
                    }
                    else
                    {
                        _pokemonSelectedPlayer1.HealthPoints -= CalculatesDamage(_pokemonSelectedPlayer2,
                                                                                 _pokemonSelectedPlayer1,
                                                                                 (Attack)s);
                        _pokemonSelectedPlayer2.Exp += s.ExpEarned;
                    }
                }
                else if (_isRoundPlayer1)
                {
                    _pokemonSelectedPlayer1.HealthPoints += ((Defence)s).HealthEarned;
                }
                else
                {
                    _pokemonSelectedPlayer2.HealthPoints += ((Defence)s).HealthEarned;
                }
            }

            return success;
        }

        /// <summary>
        /// Try to evolve the current pokemon.
        /// </summary>
        /// <returns>Boolean for the success of evolution.</returns>
        public bool Evolve()
        {
            bool success = false;
            Pokemon next;

            // A pokemon evolves after using a skill, so it is checked
            // if it has the max. experience points on its turn.
            if (_isRoundPlayer1)
            {
                if (_pokemonSelectedPlayer1.Exp == 100 && _pokemonSelectedPlayer1.NextLevel != null)
                {
                    next = (Pokemon)_pokemonSelectedPlayer1.NextLevel.Clone();
                    _pokemonPlayer1.Remove(_pokemonSelectedPlayer1);
                    _pokemonPlayer1.Add(next);
                    _pokemonSelectedPlayer1 = next;
                    success = true;
                }
            }
            else
            {
                if (_pokemonSelectedPlayer2.Exp == 100 && _pokemonSelectedPlayer2.NextLevel != null)
                {
                    next = (Pokemon)_pokemonSelectedPlayer2.NextLevel.Clone();
                    _pokemonPlayer2.Remove(_pokemonSelectedPlayer2);
                    _pokemonPlayer2.Add(next);
                    _pokemonSelectedPlayer2 = next;
                    success = true;
                }
            }
            return success;
        }

        /// <summary>
        /// Calculate the possibility that a pokemon fails the skill.
        /// </summary>
        /// <param name="p">Pokemon for which you want to calculate the chance of success.</param>
        /// <returns>Boolean for calculation success.</returns>
        private bool CalculatesPossibility(Pokemon p)
        {
            bool success = false;
            Random rnd = new Random();

            if (((LevelOf(p) == 1) && (rnd.Next(1, 4) < 3)) ||
                ((LevelOf(p) == 2) && (rnd.Next(1, 6) < 5)) ||
                ((LevelOf(p) == 3) && (rnd.Next(1, 11) < 10)))
            {
                success = true;
            }

            return success;
        }

        /// <summary>
        /// Calculate the damage of an attack.
        /// </summary>
        /// <remarks>
        /// It is calculated based on the attacking pokemon, attacked pokemon and the skill.
        /// </remarks>
        /// <param name="p1">Attacking pokemon.</param>
        /// <param name="p2">Attacked pokemon.</param>
        /// <param name="s">Attack skill used.</param>
        private int CalculatesDamage(Pokemon p1, Pokemon p2, Attack s)
        {
            double bonusAttribute = 1;
            double totalDmg = 0;

            // Check for attribute bonus damage.
            // ...-> Fire -> Grass -> Water -> Fire ->...
            switch (p1.Attribute)
            {
                case Pokemon.typeAttribute.Fire:
                    if (p2.Attribute == Pokemon.typeAttribute.Grass)
                    {
                        bonusAttribute = 2;
                    }
                    else if (p2.Attribute == Pokemon.typeAttribute.Water)
                    {
                        bonusAttribute = 0.5;
                    }
                    break;

                case Pokemon.typeAttribute.Water:
                    if (p2.Attribute == Pokemon.typeAttribute.Fire)
                    {
                        bonusAttribute = 2;
                    }
                    else if (p2.Attribute == Pokemon.typeAttribute.Grass)
                    {
                        bonusAttribute = 0.5;
                    }
                    break;

                case Pokemon.typeAttribute.Grass:
                    if (p2.Attribute == Pokemon.typeAttribute.Water)
                    {
                        bonusAttribute = 2;
                    }
                    else if (p2.Attribute == Pokemon.typeAttribute.Fire)
                    {
                        bonusAttribute = 0.5;
                    }
                    break;
            }

            // Calculation of actual damage.
            totalDmg = (s.Damage + (s.Damage * p1.Attack / 100)) * bonusAttribute;
            totalDmg -= totalDmg * p2.Defence / 100;

            return (int)totalDmg;
        }

        /// <summary>
        /// Determines the level of a pokemon.
        /// </summary>
        /// <param name="p">Pokemon that wants to determine the level.</param>
        /// <returns>Level in integer format.</returns>
        public static int LevelOf(Pokemon p)
        {
            int level;

            if (p.GetType() == typeof(Level1))
            {
                level = 1;
            }
            else if (p.GetType() == typeof(Level2))
            {
                level = 2;
            }
            else if (p.GetType() == typeof(Level3))
            {
                level = 3;
            }
            else
            {
                level = -1;     // Error.
            }

            return level;
        }

        /// <summary>
        /// Method that starts the form.
        /// </summary>
        public void Start()
        {
            NumRound++;
            ChangePokemon();
            NumRound++;
            ChangePokemon();
        }

        /// <summary>
        /// End program execution.
        /// </summary>
        public void Exit()
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// Restart program execution.
        /// </summary>
        public void Restart()
        {
            System.Diagnostics.Process.Start(Application.ExecutablePath);
            Exit();
        }

        #endregion
    }
}
