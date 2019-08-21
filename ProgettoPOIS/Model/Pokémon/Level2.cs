using ProgettoPOIS.Skills;

namespace ProgettoPOIS.Pokémon
{
    class Level2 : Pokémon
    {
        private Skill _s3;

        public Level2(typeAttribute attribute, string name, int healthPoints, int exp, int attack, int defence, int level, Skill s3)
            : base(attribute, name, healthPoints, exp, attack, defence, level)
        {
            _s3 = s3;            
        }
    }
}
