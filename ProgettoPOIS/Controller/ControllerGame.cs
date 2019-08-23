﻿using ProgettoPOIS.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProgettoPOIS.Controller
{
    class ControllerGame 
    {
        private int _numRound;
        private Pokémon _pokémonSelectedPlayer1;
        private Pokémon _pokémonSelectedPlayer2;
        private List<Pokémon> _pokémonPlayer1;
        private List<Pokémon> _pokémonPlayer2;

        public Pokémon PokémonSelectedPlayer1 { get => _pokémonSelectedPlayer1; set => _pokémonSelectedPlayer1 = value; }
        public Pokémon PokémonSelectedPlayer2 { get => _pokémonSelectedPlayer2; set => _pokémonSelectedPlayer2 = value; }
        public int NumRound { get => _numRound; set => _numRound = value; }


        public ControllerGame(List<Pokémon> pokémonPlayer1, List<Pokémon> pokémonPlayer2)
        {
            _pokémonPlayer1 = pokémonPlayer1;
            _pokémonPlayer2 = pokémonPlayer2;
            _numRound = 0;

            _pokémonSelectedPlayer1 = _pokémonPlayer1[_pokémonPlayer1.Count-1];
            _pokémonSelectedPlayer2 = _pokémonPlayer2[_pokémonPlayer2.Count-1];

            //game();
        }

        public void game()
        {            
            if(_pokémonPlayer1.Count > 0)
                MessageBox.Show("Player 1 win!", "End game", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Player 2 win!", "End game", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void choosePokèmon(Pokémon p)
        {
            if (_numRound % 2 == 0)
                _pokémonSelectedPlayer1 = p;
            else
                _pokémonSelectedPlayer2 = p;
        }

        public bool doSkill(Skill s)
        {
            bool success = calculatesPossibility((_numRound % 2 == 0) ? _pokémonSelectedPlayer1 : _pokémonSelectedPlayer2);
            if (success)
                if (s.GetType() == typeof(Attack))
                    if (_numRound % 2 == 0)
                    {
                        _pokémonSelectedPlayer2.HealthPoints -= calculatesDamage(_pokémonSelectedPlayer1, _pokémonSelectedPlayer2, (Attack)s);
                        _pokémonSelectedPlayer1.Exp += s.ExpEarned;
                    }
                    else
                    {
                        _pokémonSelectedPlayer1.HealthPoints -= calculatesDamage(_pokémonSelectedPlayer2, _pokémonSelectedPlayer1, (Attack)s);
                        _pokémonSelectedPlayer2.Exp += s.ExpEarned;
                    }
                else
                    if (_numRound % 2 == 0)
                        _pokémonSelectedPlayer1.HealthPoints += ((Defence)s).HealthEarned;
                    else
                        _pokémonSelectedPlayer2.HealthPoints += ((Defence)s).HealthEarned;
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

        public int levelOf(Pokémon p)
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
    }
}
