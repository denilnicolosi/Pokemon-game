using ProgettoPOIS.Skills;

namespace ProgettoPOIS.Pokémon
{
    class Level3 : Pokémon
    {
        private Skill _s4;
        public Level3(typeAttribute attribute, string name, int healthPoints, int exp, int attack, int defence, int level, Skill s4)
            : base(attribute, name, healthPoints, exp, attack, defence, level)
        {
            _s4 = s4;            
        }
    }
}
