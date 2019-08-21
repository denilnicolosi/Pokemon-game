using ProgettoPOIS.Skills;

namespace ProgettoPOIS.Pokémon
{
    class Level1 : Pokémon
    {
        private Skill _s1,_s2;

        public Level1(typeAttribute attribute, string name, int healthPoints, int exp, int attack, int defence, int level, Skill s1, Skill s2)
            : base(attribute, name, healthPoints, exp, attack, defence, level)
        {
            _s1 = s1;
            _s2 = s2;
        }
    }
}
