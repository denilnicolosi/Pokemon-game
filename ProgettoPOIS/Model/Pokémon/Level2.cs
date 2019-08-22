

namespace ProgettoPOIS.Model
{
    class Level2 : Level1
    {
        private Skill _s3;

        public Skill S3 { get => _s3; set => _s3 = value; }

        public Level2(Level1 level1, string name, int attack, int defence, Skill s3)
            : base(level1.Level, level1.Attribute, name, attack, defence, level1.S1, level1.S2)
        {            
            _s3 = s3;
        }

        
    }
}
