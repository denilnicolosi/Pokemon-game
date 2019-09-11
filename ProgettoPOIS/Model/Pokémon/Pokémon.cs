using System;

namespace ProgettoPOIS.Model
{
    /// <summary>
    /// The father of all Pokémon.
    /// Contains all the basic attributes and methods of a pokémon.
    /// </summary>
    public abstract class Pokémon : ICloneable
    {
        // Definition of public enumerators.
        #region Public Enumerator
        /// <summary>
        /// Enumerator for the Pokémon attribute.
        /// </summary>
        public enum typeAttribute
        {
            /// <summary>Fire attribute.</summary>
            Fire,
            /// <summary>Water attribute.</summary>
            Water,
            /// <summary>Grass attribute.</summary>
            Grass
        }
        #endregion

        // Definition of private internal attributes.
        #region Private
        private typeAttribute _attribute;
        private string _name;
        private int _healthPoints;
        private int _exp;
        private int _attack;
        private int _defence;
        private Pokémon _nextLevel;
        #endregion

        // Definition of public attributes, for the "get/set" methods.
        #region Public
        /// <summary>Pokemon type attribute.</summary>
        public typeAttribute Attribute { get => _attribute; set => _attribute = value; }
        /// <summary>Name of the pokémon.</summary>
        public string Name { get => _name; set => _name = value; }
        /// <summary>Health points of the pokémon.</summary>
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
        /// <summary>Current experience points of the pokémon.</summary>
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
        /// <summary>Points of defence of the pokémon.</summary>
        public int Attack { get => _attack; set => _attack = value; }
        /// <summary>Reference to the evolution of the pokémon.</summary>
        public int Defence { get => _defence; set => _defence = value; }
        /// <summary>Reference to the evolution of the pokémon.</summary>
        public Pokémon NextLevel { get => _nextLevel; set => _nextLevel = value; }
        #endregion


        // Definition of class methods.
        #region Methods

        /// <summary>
        /// Constructor method of the <c>Pokémon</c> class.
        /// </summary>
        /// <param name="attribute">Pokémon attribute.</param>
        /// <param name="name">Pokémon name.</param>
        /// <param name="attack">Value of the Pokémon attack.</param>
        /// <param name="defence">Value of the Pokémon defence.</param>
        /// <exception cref="System.ArgumentException">Negative attack or defense.</exception>
        public Pokémon(typeAttribute attribute, string name, int attack, int defence)
        {
            if (attack < 0 && defence < 0)
                throw new ArgumentException(name + ": attack/defence must be positive.");
            else
            {
                _attribute = attribute;
                _name = name;
                _healthPoints = 100;
                _exp = 0;
                _attack = attack;
                _defence = defence;
            }
        }

        /// <summary>
        /// Create a new instance of the class with the same value as an existing instance.
        /// </summary>
        /// <returns>New object which is a copy of the current instance.</returns>
        public abstract object Clone();
        #endregion
    }
}
