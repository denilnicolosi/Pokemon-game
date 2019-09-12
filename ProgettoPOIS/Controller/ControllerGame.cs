using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ProgettoPOIS.Exceptions;
using ProgettoPOIS.Model;
using ProgettoPOIS.View;

namespace ProgettoPOIS.Controller
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
        private Pokémon _pokémonSelectedPlayer1;
        private Pokémon _pokémonSelectedPlayer2;
        private List<Pokémon> _pokémonPlayer1;
        private List<Pokémon> _pokémonPlayer2;
        #endregion

        // Definition of public attributes, for the "get/set" methods.
        #region Public 
        /// <summary>Pokémon selected by player one.</summary>
        public Pokémon PokémonSelectedPlayer1 { get => _pokémonSelectedPlayer1; set => _pokémonSelectedPlayer1 = value; }
        /// <summary>Pokémon selected by player two.</summary>
        public Pokémon PokémonSelectedPlayer2 { get => _pokémonSelectedPlayer2; set => _pokémonSelectedPlayer2 = value; }
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
        /// <param name="pokémonPlayer1">List of <c>Pokémon</c> chosen by player 1.</param>
        /// <param name="pokémonPlayer2">List of <c>Pokémon</c> chosen by player 2.</param>
        public ControllerGame(List<Pokémon> pokémonPlayer1, List<Pokémon> pokémonPlayer2)
        {
            _pokémonPlayer1 = pokémonPlayer1;
            _pokémonPlayer2 = pokémonPlayer2;
            NumRound = 0;
        }

        /// <summary>
        /// Select the main Pokémon of current player.
        /// </summary>
        /// <param name="p">Pokémon that will become the main one.</param>
        public void ChoosePokèmon(Pokémon p)
        {
            if (_isRoundPlayer1)
            {
                _pokémonSelectedPlayer1 = p;
            }
            else
            {
                _pokémonSelectedPlayer2 = p;
            }
        }

        /// <summary>
        /// Show the form for choosing the pokémon to be the main one,
        /// and make it effective.
        /// </summary>
        /// <returns>Boolean for the success of the exchange.</returns>
        /// <exception cref="ProgettoPOIS.Exceptions.ChangeException">
        /// Pokémon already in the battlefield.
        /// </exception>
        public bool ChangePokémon()
        {
            bool success = false;
            Pokémon selectePokémon;

            if (!CheckDefeat())
            {
                if (_isRoundPlayer1)
                {
                    _change = new FormChange(_pokémonPlayer1);
                }
                else
                {
                    _change = new FormChange(_pokémonPlayer2);
                }

                _change.ShowDialog();
                selectePokémon = _change.SelectedPokémon;

                if (selectePokémon == ((_isRoundPlayer1) ? _pokémonSelectedPlayer1
                                                         : _pokémonSelectedPlayer2))
                {
                    throw new ChangeException();
                }

                if (selectePokémon != null)
                {
                    ChoosePokèmon(selectePokémon);
                }

                success = true;
            }
            return success;
        }

        /// <summary>
        /// Check if the current player has been defeated.
        /// </summary>
        /// <remarks>
        /// Check the health points of all pokémon of the current player,
        /// to verify the defeat.
        /// </remarks>
        /// <returns>Boolean for the outcome of the defeat check.</returns>
        public bool CheckDefeat()
        {
            bool success = true;

            if (_isRoundPlayer1)
            {
                foreach (Pokémon p in _pokémonPlayer1)
                {
                    if (p.HealthPoints > 0)
                    {
                        success = false;
                    }
                }
            }
            else
            {
                foreach (Pokémon p in _pokémonPlayer2)
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
        /// Calculate and make changes to pokémon values.
        /// </remarks>
        /// <param name="s">Skill to try to perform.</param>
        /// <returns>Boolean for the success of the skill.</returns>
        public bool DoSkill(Skill s)
        {
            bool success = CalculatesPossibility((_isRoundPlayer1) ? _pokémonSelectedPlayer1 : _pokémonSelectedPlayer2);

            if (success)
            {
                if (s.GetType() == typeof(Attack))
                {
                    if (_isRoundPlayer1)
                    {
                        _pokémonSelectedPlayer2.HealthPoints -= CalculatesDamage(_pokémonSelectedPlayer1,
                                                                                 _pokémonSelectedPlayer2,
                                                                                 (Attack)s);
                        _pokémonSelectedPlayer1.Exp += s.ExpEarned;
                    }
                    else
                    {
                        _pokémonSelectedPlayer1.HealthPoints -= CalculatesDamage(_pokémonSelectedPlayer2,
                                                                                 _pokémonSelectedPlayer1,
                                                                                 (Attack)s);
                        _pokémonSelectedPlayer2.Exp += s.ExpEarned;
                    }
                }
                else if (_isRoundPlayer1)
                {
                    _pokémonSelectedPlayer1.HealthPoints += ((Defence)s).HealthEarned;
                }
                else
                {
                    _pokémonSelectedPlayer2.HealthPoints += ((Defence)s).HealthEarned;
                }
            }

            return success;
        }

        /// <summary>
        /// Try to evolve the current pokémon.
        /// </summary>
        /// <returns>Boolean for the success of evolution.</returns>
        public bool Evolve()
        {
            bool success = false;
            Pokémon next;

            // A pokémon evolves after using a skill, so it is checked
            // if it has the max. experience points on its turn.
            if (_isRoundPlayer1)
            {
                if (_pokémonSelectedPlayer1.Exp == 100 && _pokémonSelectedPlayer1.NextLevel != null)
                {
                    next = (Pokémon)_pokémonSelectedPlayer1.NextLevel.Clone();
                    _pokémonPlayer1.Remove(_pokémonSelectedPlayer1);
                    _pokémonPlayer1.Add(next);
                    _pokémonSelectedPlayer1 = next;
                    success = true;
                }
            }
            else
            {
                if (_pokémonSelectedPlayer2.Exp == 100 && _pokémonSelectedPlayer2.NextLevel != null)
                {
                    next = (Pokémon)_pokémonSelectedPlayer2.NextLevel.Clone();
                    _pokémonPlayer2.Remove(_pokémonSelectedPlayer2);
                    _pokémonPlayer2.Add(next);
                    _pokémonSelectedPlayer2 = next;
                    success = true;
                }
            }
            return success;
        }

        /// <summary>
        /// Calculate the possibility that a pokémon fails the skill.
        /// </summary>
        /// <param name="p">Pokémon for which you want to calculate the chance of success.</param>
        /// <returns>Boolean for calculation success.</returns>
        private bool CalculatesPossibility(Pokémon p)
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
        /// It is calculated based on the attacking pokémon, attacked pokémon and the skill.
        /// </remarks>
        /// <param name="p1">Attacking pokémon.</param>
        /// <param name="p2">Attacked pokémon.</param>
        /// <param name="s">Attack skill used.</param>
        private int CalculatesDamage(Pokémon p1, Pokémon p2, Attack s)
        {
            double bonusAttribute = 1;
            int totalDmg = 0;

            // Check for attribute bonus damage.
            // ...-> Fire -> Grass -> Water -> Fire ->...
            switch (p1.Attribute)
            {
                case Pokémon.typeAttribute.Fire:
                    if (p2.Attribute == Pokémon.typeAttribute.Grass)
                    {
                        bonusAttribute = 2;
                    }
                    else if (p2.Attribute == Pokémon.typeAttribute.Water)
                    {
                        bonusAttribute = 0.5;
                    }

                    break;
                case Pokémon.typeAttribute.Water:
                    if (p2.Attribute == Pokémon.typeAttribute.Fire)
                    {
                        bonusAttribute = 2;
                    }
                    else if (p2.Attribute == Pokémon.typeAttribute.Grass)
                    {
                        bonusAttribute = 0.5;
                    }

                    break;
                case Pokémon.typeAttribute.Grass:
                    if (p2.Attribute == Pokémon.typeAttribute.Water)
                    {
                        bonusAttribute = 2;
                    }
                    else if (p2.Attribute == Pokémon.typeAttribute.Fire)
                    {
                        bonusAttribute = 0.5;
                    }

                    break;
            }

            // Calculation of actual damage.
            totalDmg = (int)((s.Damage + ((s.Damage * p1.Attack) / 100)) * bonusAttribute);
            totalDmg -= totalDmg * p2.Defence / 100;

            return totalDmg;
        }

        /// <summary>
        /// Determines the level of a pokémon.
        /// </summary>
        /// <param name="p">Pokémon that wants to determine the level.</param>
        /// <returns>Level in integer format.</returns>
        public static int LevelOf(Pokémon p)
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
            ChangePokémon();
            NumRound++;
            ChangePokémon();
            NumRound++;
        }

        /// <summary>
        /// End program execution.
        /// </summary>
        public void Exit()
        {
            Application.Exit();
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
