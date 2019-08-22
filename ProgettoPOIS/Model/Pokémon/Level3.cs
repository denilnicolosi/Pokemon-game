

namespace ProgettoPOIS.Model
{
    class Level3 : Level2
    {
        private Skill _s4;

        public Skill S4 { get => _s4; set => _s4 = value; }

        public Level3(Level2 level2, string name, int attack, int defence, Skill s4)
           : base(new Level1(level2.Level, level2.Attribute, name, attack, defence,  level2.S1, level2.S2), name, attack, defence, level2.S3)
        {
            _s4 = s4;
        }

       
    }
}
