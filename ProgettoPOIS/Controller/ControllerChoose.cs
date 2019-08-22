using ProgettoPOIS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProgettoPOIS.Controller
{
    class ControllerChoose : IController
    {
        private List<Pokémon> pokémonList;
        private List<Pokémon> pokémonPlayer1;
        private List<Pokémon> pokémonPlayer2;

        public List<Pokémon> PokémonPlayer1 { get => pokémonPlayer1; set => pokémonPlayer1 = value; }
        public List<Pokémon> PokémonPlayer2 { get => pokémonPlayer2; set => pokémonPlayer2 = value; }
        public List<Pokémon> PokémonList { get => pokémonList; set => pokémonList = value; }

        public ControllerChoose()
        {
            pokémonPlayer1 = new List<Pokémon>();
            pokémonPlayer2 = new List<Pokémon>();

            pokémonList = loadPokémon(Properties.Settings.Default.pathPokemon,
                                      Properties.Settings.Default.pathSkill);
        }

        public List<Pokémon> loadPokémon(string pathPokémon, string pathSkill)
        {
            Pokémon tmpPokémon, prevPokémon;
            Skill tmpSkill;

            List<Pokémon> listPokémon = new List<Pokémon>();
            List<Skill> listSkill = new List<Skill>();

            StreamReader rPokémon, rSkill;
            Pokémon.typeAttribute t;

            try
            {
                // Lettura delle Skill dal file
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
                // Lettura Pokémon dal file
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
                                //livello;tipoPokemon;nomePokemon;attacco;difesa;nomeSkill1;nomeSkill2
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

                                tmpPokémon = new Level1(Int32.Parse(values[0]), t, values[2], Int32.Parse(values[3]), Int32.Parse(values[4]),
                                    listSkill.Where(s => s.Name == values[5]).FirstOrDefault(),
                                    listSkill.Where(s => s.Name == values[6]).FirstOrDefault());

                                break;
                            case 2:
                                //livello;nomePokemonPrecedente;nuovoNome;nomeSkill
                                prevPokémon = (Level1)listPokémon.Where(p => p.Name == values[1]).FirstOrDefault();

                                tmpPokémon = new Level2((Level1)prevPokémon, values[2], Int32.Parse(values[3]), Int32.Parse(values[4]), listSkill.Where(s => s.Name == values[5]).FirstOrDefault());

                                prevPokémon.NextLevel = tmpPokémon;
                                break;
                            case 3:
                                //livello;nomePokemonPrecedente;nuovoNome;nomeSkill
                                prevPokémon = (Level2)listPokémon.Where(p => p.Name == values[1]).FirstOrDefault();
                                Level3 l= new Level3((Level2)prevPokémon, values[2], Int32.Parse(values[3]), Int32.Parse(values[4]), listSkill.Where(s => s.Name == values[5]).FirstOrDefault());
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
                return null;
            }
        }

        public void startGame()
        {
            throw new NotImplementedException();
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }

        public void Player1Turn()
        {
            throw new NotImplementedException();
        }

        public void Player2Turn()
        {
            throw new NotImplementedException();
        }

    }
}
