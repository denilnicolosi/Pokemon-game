using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgettoPOIS.Skills;

namespace ProgettoPOIS.Pokémon
{
    class Bulbasaur : Pokémon
    {
        public Bulbasaur()
        {
            this.Name = "Bulbasaur";
            this.Defence = 10;
            this.Attack = 5;
            this.Attribute = Pokémon.typeAttribute.Earth;
            this.S1 = new Skill("Kick", 10, 12);


        }

        public void doSkill1() { }
        public void doSkill2() { }

    }
}
