using ProgettoPOIS.Skills;

namespace ProgettoPOIS.Pokémon
{
    abstract class Pokémon
    {

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
        #endregion

        #region Protected 
        protected int HealthPoints { get => _healthPoints; set => _healthPoints = value; }
        protected typeAttribute Attribute { get => _attribute; set => _attribute = value; }
        protected string Name { get => _name; set => _name = value; }
        protected int Exp { get => _exp; set => _exp = value; }
        protected int Attack { get => _attack; set => _attack = value; }
        protected int Defence { get => _defence; set => _defence = value; }
        protected int Level { get => _level; set => _level = value; }
      
        #endregion

        #region Methods
        protected Pokémon(typeAttribute attribute, string name, int healthPoints, int exp, int attack, int defence, int level)
        {
            _attribute = attribute;
            _name = name;
            _healthPoints = healthPoints;
            _exp = exp;
            _attack = attack;
            _defence = defence;
            _level = 1;
        }
        #endregion

    }
}
