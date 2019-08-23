

namespace ProgettoPOIS.Model
{
    public class Level2 : Level1
    {
        private Skill _s3;

        public Skill S3 { get => _s3; set => _s3 = value; }

        public Level2(typeAttribute attribute, string name, int attack, int defence, Skill s1, Skill s2, Skill s3)
            : base(attribute, name, attack, defence, s1, s2)
        {
            _s3 = s3;
        }

       

        
    }
}
