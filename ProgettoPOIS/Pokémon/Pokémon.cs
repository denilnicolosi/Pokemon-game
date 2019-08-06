using ProgettoPOIS.Skills;

namespace ProgettoPOIS.Pokémon
{
    abstract class Pokémon 
    {
        #region Attribute

        #region Public
        public enum typeAttribute { Fire, Water, Earth }
        #endregion

        #region Private 
        private typeAttribute _attribute;
        private string _name;
        private int _healthPoints = 100;
        private int _exp = 0;
        private int _attack;
        private int _defence;
        private int _level;
        private Skill _s1, _s2, _s3, _s4;
        #endregion

        #region Protected 
        protected int HealthPoints { get => _healthPoints; set => _healthPoints = value; }
        protected typeAttribute Attribute { get => _attribute; set => _attribute = value; }
        protected string Name { get => _name; set => _name = value; }
        protected int Exp { get => _exp; set => _exp = value; }
        protected int Attack { get => _attack; set => _attack = value; }
        protected int Defence { get => _defence; set => _defence = value; }
        protected int Level { get => _level; set => _level = value; }
        protected Skill S1 { get => _s1; set => _s1 = value; }
        protected Skill S2 { get => _s2; set => _s2 = value; }
        protected Skill S3 { get => _s3; set => _s3 = value; }
        protected Skill S4 { get => _s4; set => _s4 = value; }
        #endregion
        #endregion

        #region Abstract method
        public abstract void doSkill1();
        public abstract void doSkill2();
        #endregion
    }
}
