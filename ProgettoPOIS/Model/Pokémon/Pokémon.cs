namespace ProgettoPOIS.Model
{
    /// <summary>
    /// The father of all Pokémon.
    /// Contains all the basic attributes and methods of a pokémon.
    /// </summary>
    public abstract class Pokémon
    {
        // Definition of public enumerators.
        #region Enum
        public enum typeAttribute { Fire, Water, Grass }
        #endregion

        // Definition of private internal attributes.
        #region Private 
        private typeAttribute _attribute;
        private string _name;
        private int _healthPoints = 100;
        private int _exp = 0;
        private int _attack;
        private int _defence;
        private Pokémon _nextLevel;
        #endregion

        // Definition of public attributes, for the "get/set" methods.
        #region Public 
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

        public int Exp {
            get => _exp;
            set
            {
                if (value > 0)
                    if (value > 100)
                        _exp = 100;
                    else
                        _exp = value;
                else
                    _exp = 0;
            }
        }

        public typeAttribute Attribute { get => _attribute; set => _attribute = value; }
        public string Name { get => _name; set => _name = value; }
      
        public int Attack { get => _attack; set => _attack = value; }
        public int Defence { get => _defence; set => _defence = value; }
        public Pokémon NextLevel { get => _nextLevel; set => _nextLevel = value; }
        #endregion

        // Definition of class methods.
        #region Methods

        /// <summary>
        /// Constructor method of the <c>Pokémon</c> class.
        /// </summary>
        /// <typeparam name="typeAttribute">Enumerator for the attributes of Pokémon: Fire, Water, Earth.</typeparam>
        /// <param name="attribute">Pokémon attribute.</param>
        /// <param name="name">Pokémon name.</param>
        /// <param name="attack">Value of the Pokémon attack.</param>
        /// <param name="defence">Value of the Pokémon defence.</param>
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
