

namespace ProgettoPOIS.Model
{
    public class Level3 : Level2
    {
        private Skill _s4;

        public Skill S4 { get => _s4; set => _s4 = value; }

        public Level3(typeAttribute attribute, string name, int attack, int defence, Skill s1, Skill s2, Skill s3, Skill s4)
            : base(attribute, name, attack, defence, s1, s2, s3)
        {
            _s4 = s4;
        }


    }
}
