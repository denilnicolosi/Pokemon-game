
namespace ProgettoPOIS.Model
{
    class Level1 : Pokémon
    {
        private Skill _s1, _s2;
        public Skill S1 { get => _s1; set => _s1 = value; }
        public Skill S2 { get => _s2; set => _s2 = value; }

        public Level1(int level, typeAttribute attribute, string name, int attack, int defence, Skill s1, Skill s2)
            : base(level, attribute, name, 100, 0, attack, defence)
        {
            _s1 = s1;
            _s2 = s2;
        }


    }
}
