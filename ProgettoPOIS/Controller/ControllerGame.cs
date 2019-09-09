using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ProgettoPOIS.Model;
using ProgettoPOIS.View;
using ProgettoPOIS.Exceptions;

namespace ProgettoPOIS.Controller
{
    /// <summary>
    /// Controller for the game.
    /// Contains all the basic attributes and methods to control the game.
    /// </summary>
    class ControllerGame: IController
    {
        // Definition of private internal attributes.
        #region Private 
        private int _numRound;
        private bool _isRoundPlayer1;
        private FormChange change;
        private Pokémon _pokémonSelectedPlayer1;
        private Pokémon _pokémonSelectedPlayer2;
        private List<Pokémon> _pokémonPlayer1;
        private List<Pokémon> _pokémonPlayer2;
        #endregion

        // Definition of public attributes, for the "get/set" methods.
        #region Public 
        public Pokémon PokémonSelectedPlayer1 { get => _pokémonSelectedPlayer1; set => _pokémonSelectedPlayer1 = value; }
        public Pokémon PokémonSelectedPlayer2 { get => _pokémonSelectedPlayer2; set => _pokémonSelectedPlayer2 = value; }
        public int NumRound
        {
            get => _numRound;
            set
            {
                _numRound = value;
                _isRoundPlayer1 = (_numRound % 2 == 0) ? true : false;
            }
        }
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
        /// <typeparam name="Pokémon"><typeparamref name="Pokémon"/>Object of type Pokémon.</typeparam>
        /// <param name="p">Pokémon that will become the main one.</param>
        public void choosePokèmon(Pokémon p)
        {
            if (_isRoundPlayer1)
                _pokémonSelectedPlayer1 = p;
            else
                _pokémonSelectedPlayer2 = p;
        }

        /// <summary>
        /// Show the form for choosing the pokémon to be the main one,
        /// and make it effective.
        /// </summary>
        /// <returns>Boolean for the success of the exchange.</returns>
        public bool changePokémon()
        {
            bool success = false;
            Pokémon selectePokémon;
            
            if (!checkDefeat())
            {
                if (_isRoundPlayer1)
                    change = new FormChange(_pokémonPlayer1);
                else
                    change = new FormChange(_pokémonPlayer2);

                change.ShowDialog();
                selectePokémon = change.SelectedPokémon;

                if (selectePokémon == ((_isRoundPlayer1) ? _pokémonSelectedPlayer1
                                                         : _pokémonSelectedPlayer2))
                    throw new ChangeException();

                if (selectePokémon != null)
                    choosePokèmon(selectePokémon);

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
        public bool checkDefeat()
        {
            bool success = true;

            if (_isRoundPlayer1)
            {
                foreach (Pokémon p in _pokémonPlayer1)
                    if (p.HealthPoints > 0)
                        success = false;
            }
            else
            {
                foreach (Pokémon p in _pokémonPlayer2)
                    if (p.HealthPoints > 0)
                        success = false;
            }
            
            return success;
        }

        /// <summary>
        /// It try to execute the skill.
        /// </summary>
        /// <remarks>
        /// Calculate and make changes to pokémon values.
        /// </remarks>
        /// <typeparam name="Skill"><typeparamref name="Skill"/>Object of type Skill.</typeparam>
        /// <param name="s">Skill to try to perform.</param>
        /// <returns>Boolean for the success of the skill.</returns>
        public bool doSkill(Skill s)
        {
            bool success = calculatesPossibility((_isRoundPlayer1) ? _pokémonSelectedPlayer1 : _pokémonSelectedPlayer2);

            if (success)
                if (s.GetType() == typeof(Attack))
                    if (_isRoundPlayer1)
                    {
                        _pokémonSelectedPlayer2.HealthPoints -= calculatesDamage(_pokémonSelectedPlayer1, _pokémonSelectedPlayer2, (Attack)s);
                        _pokémonSelectedPlayer1.Exp += s.ExpEarned;
                    }
                    else
                    {
                        _pokémonSelectedPlayer1.HealthPoints -= calculatesDamage(_pokémonSelectedPlayer2, _pokémonSelectedPlayer1, (Attack)s);
                        _pokémonSelectedPlayer2.Exp += s.ExpEarned;
                    }
                else if (_isRoundPlayer1)
                    _pokémonSelectedPlayer1.HealthPoints += ((Defence)s).HealthEarned;
                else
                    _pokémonSelectedPlayer2.HealthPoints += ((Defence)s).HealthEarned;

            return success;
        }

        /// <summary>
        /// Try to evolve the current pokémon.
        /// </summary>
        /// <returns>Boolean for the success of evolution.</returns>
        public bool evolve()
        {
            bool success = false;
            Pokémon next;

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
                    success = false;
                }
            }
            return success;
        }

        /// <summary>
        /// Calculate the possibility that a pokémon fails the skill.
        /// </summary>
        /// <typeparam name="Pokémon"><typeparamref name="Pokémon"/>Object of type Pokémon.</typeparam>
        /// <param name="p">Pokémon for which you want to calculate the chance of success.</param>
        /// <returns>Boolean for calculation success.</returns
        private bool calculatesPossibility(Pokémon p)
        {
            bool success = false;
            Random rnd = new Random();

            if (((levelOf(p) == 1) && (rnd.Next(1, 4) < 3)) ||
                ((levelOf(p) == 2) && (rnd.Next(1, 6) < 5)) ||
                ((levelOf(p) == 3) && (rnd.Next(1, 11) < 10)))
                success = true;

            return success;
        }

        /// <summary>
        /// Calculate the damage of an attack.
        /// </summary>
        /// <remarks>
        /// It is calculated based on the attacking pokémon, attacked pokémon and the skill.
        /// </remarks>
        /// <typeparam name="Pokémon"><typeparamref name="Pokémon"/>Object of type Pokémon.</typeparam>
        /// <typeparam name="Skill"><typeparamref name="Attack"/>Object of type Attack (Skill).</typeparam>
        /// <param name="p1">Attacking pokémon.</param>
        /// <param name="p2">Attacked pokémon.</param>
        private int calculatesDamage(Pokémon p1, Pokémon p2, Attack s)
        {
            double bonusAttribute = 1;
            int totalDmg = 0;

            // Check for attribute bonus damage.
            // ...-> Fire -> Grass -> Water -> Fire ->...
            switch (p1.Attribute)
            {
                case Pokémon.typeAttribute.Fire:
                    if (p2.Attribute == Pokémon.typeAttribute.Grass)
                        bonusAttribute = 2;
                    else if (p2.Attribute == Pokémon.typeAttribute.Water)
                        bonusAttribute = 0.5;
                    break;
                case Pokémon.typeAttribute.Water:
                    if (p2.Attribute == Pokémon.typeAttribute.Fire)
                        bonusAttribute = 2;
                    else if (p2.Attribute == Pokémon.typeAttribute.Grass)
                        bonusAttribute = 0.5;
                    break;
                case Pokémon.typeAttribute.Grass:
                    if (p2.Attribute == Pokémon.typeAttribute.Water)
                        bonusAttribute = 2;
                    else if (p2.Attribute == Pokémon.typeAttribute.Fire)
                        bonusAttribute = 0.5;
                    break;
            }

            // Calculation of actual damage.
            totalDmg = (int)((s.Damage + ((s.Damage * p1.Attack) / 100)) * bonusAttribute);

            return totalDmg;
        }

        /// <summary>
        /// Determines the level of a pokémon.
        /// </summary>
        /// <typeparam name="Pokémon"><typeparamref name="Pokémon"/>Object of type Pokémon.</typeparam>
        /// <param name="p">Pokémon that wants to determine the level.</param>
        /// <returns>Level in integer format.</returns>
        public static int levelOf(Pokémon p)
        {
            int level;

            if (p.GetType() == typeof(Level1))
                level = 1;
            else if (p.GetType() == typeof(Level2))
                level = 2;
            else if (p.GetType() == typeof(Level3))
                level = 3;
            else
                level = -1;     // Error.

            return level;
        }

        public void start()
        {
            changePokémon();
            NumRound++;
            changePokémon();
            NumRound++;
        }

        /// <summary>
        /// End program execution.
        /// </summary>
        public void exit()
        {
            Application.Exit();
            Environment.Exit(0);
        }

        /// <summary>
        /// Restart program execution.
        /// </summary>
        public void restart()
        {   
            System.Diagnostics.Process.Start(Application.ExecutablePath);
            exit();
        }

        #endregion
    }
}
