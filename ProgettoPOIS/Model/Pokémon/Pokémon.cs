

namespace ProgettoPOIS.Model
{
    public abstract class Pokémon
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
        private Pokémon _nextLevel;

        #endregion

        #region Protected 
        public int HealthPoints
        {
            get => _healthPoints;
            set
            {
                if (value > 0)
                    if (value > 100)
                        _healthPoints = 100;
                    else
                        _healthPoints = value;
                else
                    _healthPoints = 0;
            }
        }
        public typeAttribute Attribute { get => _attribute; set => _attribute = value; }
        public string Name { get => _name; set => _name = value; }
        public int Exp { get => _exp; set => _exp = value; }
        public int Attack { get => _attack; set => _attack = value; }
        public int Defence { get => _defence; set => _defence = value; }
        public Pokémon NextLevel { get => _nextLevel; set => _nextLevel = value; }

        #endregion

        #region Methods
        protected Pokémon(typeAttribute attribute, string name, int attack, int defence)
        {
            _attribute = attribute;
            _name = name;
            _healthPoints = 100;
            _exp = 0;
            _attack = attack;
            _defence = defence;                    
        }
        #endregion

    }
}
