

namespace ProgettoPOIS.Model
{
    class Level2 : Level1
    {
        private Skill _s3;

        public Skill S3 { get => _s3; set => _s3 = value; }

        public Level2(Level1 level1, string name, Skill s3)
            : base(level1.Level, level1.Attribute, name, level1.HealthPoints, level1.Exp, level1.Attack, level1.Defence, level1.S1, level1.S2)
        {            
            _s3 = s3;
        }

        
    }
}
