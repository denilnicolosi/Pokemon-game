using ProgettoPOIS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProgettoPOIS.Controller
{
    class Controller : IController
    {
        private List<Pokémon> pokémonList;

        public Controller()
        {
            pokémonList = loadPokémon(Properties.Settings.Default.pathPokemon,
                                      Properties.Settings.Default.pathSkill);


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

        public List<Pokémon> loadPokémon(string pathPokémon, string pathSkill)
        {
            Pokémon tmpPokémon;
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
                    switch (values[0])
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

                // Lettura Pokémon dal file
                rPokémon = new StreamReader(pathPokémon);
                while (!rPokémon.EndOfStream)
                {
                    string line = rPokémon.ReadLine();
                    string[] values = line.Split(';');

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

                            tmpPokémon = new Level1(Int32.Parse(values[0]), t, values[2],
                                Int32.Parse(values[3]), Int32.Parse(values[4]), Int32.Parse(values[5]), Int32.Parse(values[6]),
                                listSkill.Where(s => s.Name == values[7]).FirstOrDefault(),
                                listSkill.Where(s => s.Name == values[8]).FirstOrDefault());

                            tmpPokémon.NextLevel = listPokémon.Where(x => x.Name == values[9]).FirstOrDefault();
                            break;

                        case 2:
                            tmpPokémon = new Level2((Level1)listPokémon.Where(p => p.Name == values[1]).FirstOrDefault(),
                                values[2], listSkill.Where(s => s.Name == values[3]).FirstOrDefault());

                            tmpPokémon.NextLevel = listPokémon.Where(x => x.Name == values[4]).FirstOrDefault();

                            break;

                        case 3:
                            tmpPokémon = new Level3((Level2)listPokémon.Where(p => p.Name == values[1]).FirstOrDefault(),
                                values[2], listSkill.Where(s => s.Name == values[3]).FirstOrDefault());
                            break;

                        default:
                            Console.WriteLine("Error: read from pokèmon file.");
                            break;
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

    }
}
