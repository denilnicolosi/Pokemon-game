using ProgettoPOIS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProgettoPOIS.Controller
{
    class Controller : IController
    {
        private List<Pokémon> pokémonPlayer1;
        private List<Pokémon> pokémonPlayer2;


        public Controller(List<Pokémon> pokémonPlayer1, List<Pokémon> pokémonPlayer2)
        {
            this.pokémonPlayer1 = pokémonPlayer1;
            this.pokémonPlayer2 = pokémonPlayer2;


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
