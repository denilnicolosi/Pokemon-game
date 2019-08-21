

namespace ProgettoPOIS.Model
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
        private Pokémon _nextLevel;

        #endregion

        #region Protected 
        public int HealthPoints { get => _healthPoints; set => _healthPoints = value; }
        public typeAttribute Attribute { get => _attribute; set => _attribute = value; }
        public string Name { get => _name; set => _name = value; }
        public int Exp { get => _exp; set => _exp = value; }
        public int Attack { get => _attack; set => _attack = value; }
        public int Defence { get => _defence; set => _defence = value; }
        public int Level { get => _level; set => _level = value; }
        public Pokémon NextLevel { get => _nextLevel; set => _nextLevel = value; }

        #endregion

        #region Methods
        protected Pokémon(int level, typeAttribute attribute, string name, int healthPoints, int exp, int attack, int defence)
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
