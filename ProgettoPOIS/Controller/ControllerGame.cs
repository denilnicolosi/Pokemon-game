using ProgettoPOIS.Model;
using ProgettoPOIS.View;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace ProgettoPOIS.Controller
{
    /// <summary>
    /// Controller for the game.
    /// Contains all the basic attributes and methods to control the game.
    /// </summary>
    class ControllerGame
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

        public void choosePokèmon(Pokémon p)
        {
            if (_isRoundPlayer1)
                _pokémonSelectedPlayer1 = p;
            else
                _pokémonSelectedPlayer2 = p;
        }

        public void changePokémon()
        {
            Pokémon p;

            checkVictory();

            if (_isRoundPlayer1)
                change = new FormChange(_pokémonPlayer1);
            else
                change = new FormChange(_pokémonPlayer2);

            change.ShowDialog();
            p = change.SelectedPokémon;

            if(p!=null)
                choosePokèmon(p);
        }

        public void checkVictory()
        {
            int n = 0;
            if (_isRoundPlayer1)
            {
                foreach (Pokémon p in _pokémonPlayer1)
                    if (p.HealthPoints == 0)
                        n++;
                if (n == _pokémonPlayer1.Count)
                {
                    MessageBox.Show("Player 2 win!", "End game", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                    Environment.Exit(-1);
                }
            }
            else
            {
                foreach (Pokémon p in _pokémonPlayer2)
                    if (p.HealthPoints == 0)
                        n++;
                if (n == _pokémonPlayer2.Count)
                {
                    MessageBox.Show("Player 1 win!", "End game", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                    Environment.Exit(-1);
                }
            }
        }

        public bool doSkill(Skill s)
        {
            bool success = calculatesPossibility((_isRoundPlayer1) ? _pokémonSelectedPlayer1 : _pokémonSelectedPlayer2);
            if (success)
            {
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
                
                if ((_pokémonSelectedPlayer1.Exp >= 100) ||
                    (_pokémonSelectedPlayer2.Exp >= 100))
                {
                    evolve();
                }
            }    
            return success;
        }

        public bool evolve()
        {
            bool success = false;
            if (_isRoundPlayer1)
            {
                if (_pokémonSelectedPlayer1.NextLevel != null)
                {
                    _pokémonPlayer1.Remove(_pokémonSelectedPlayer1);
                    _pokémonPlayer1.Add(_pokémonSelectedPlayer1.NextLevel);
                    _pokémonSelectedPlayer1 = _pokémonSelectedPlayer1.NextLevel;
                    MessageBox.Show("Pokémon " + _pokémonSelectedPlayer1.Name + " evolved!","Pokémon evolved",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (_pokémonSelectedPlayer2.NextLevel!= null)
                {
                    _pokémonPlayer2.Remove(_pokémonSelectedPlayer2);
                    _pokémonPlayer2.Add(_pokémonSelectedPlayer2.NextLevel);
                    _pokémonSelectedPlayer2 = _pokémonSelectedPlayer2.NextLevel;
                    MessageBox.Show("Pokémon " + _pokémonSelectedPlayer2.Name + " evolved!", "Pokémon evolved",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return success;
        }

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

        private int calculatesDamage(Pokémon p1, Pokémon p2, Attack s)
        {
            int bonusAttribute = 0;
            int totalDmg = 0;

            // controllo per bonus attributo
            if (p1.Attribute == Pokémon.typeAttribute.Fire)
                if (p2.Attribute == Pokémon.typeAttribute.Earth)
                    bonusAttribute = 10;
                else if (p2.Attribute == Pokémon.typeAttribute.Water)
                    bonusAttribute = -10;

            else if (p1.Attribute == Pokémon.typeAttribute.Water)
                if (p2.Attribute == Pokémon.typeAttribute.Fire)
                    bonusAttribute = 10;
                else if (p2.Attribute == Pokémon.typeAttribute.Earth)
                    bonusAttribute = -10;

            else if (p1.Attribute == Pokémon.typeAttribute.Earth)
                if (p2.Attribute == Pokémon.typeAttribute.Water)
                    bonusAttribute = 10;
                else if (p2.Attribute == Pokémon.typeAttribute.Fire)
                    bonusAttribute = -10;

            totalDmg = s.Damage + ((s.Damage * p1.Attack) / 100);
            totalDmg = totalDmg + ((totalDmg * bonusAttribute) / 100);

            return totalDmg;
        }

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
                level = -1; // error
            return level;
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
