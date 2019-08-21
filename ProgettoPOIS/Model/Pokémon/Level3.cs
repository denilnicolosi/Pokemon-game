

namespace ProgettoPOIS.Model
{
    class Level3 : Level2
    {
        private Skill _s4;

        public Level3(Level2 level2, string name, Skill s4)
           : base(new Level1(level2.Level, level2.Attribute, name, level2.HealthPoints, level2.Exp, level2.Attack, level2.Defence,  level2.S1, level2.S2),name,level2.S3)
        {
            _s4 = s4;
        }

    }
}
