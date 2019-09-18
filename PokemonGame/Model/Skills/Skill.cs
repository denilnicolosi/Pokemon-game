using System;

namespace PokemonGame.Model
{
    /// <summary>
    /// The father of all Skills.
    /// contains all the basic attributes and methods of a skill.
    /// </summary>
    public abstract class Skill
    {
        // Definition of private internal attributes.
        #region Private
        private string _name;
        private int _expEarned;
        #endregion

        // Definition of public attributes, for the "get/set" methods.
        #region Public 
        /// <summary>Name of the skill.</summary>
        public string Name { get => _name; set => _name = value; }
        /// <summary>Experience points earned by the skill.</summary>
        public int ExpEarned { get => _expEarned; set => _expEarned = value; }
        #endregion


        // Definition of class methods.
        #region Methods

        /// <summary>
        /// Constructor method of the <c>Pokemon</c> class.
        /// </summary>
        /// <param name="name">Name of the skill.</param>
        /// <param name="expEarned">Experience earned.</param>
        public Skill(string name, int expEarned)
        {
            if (expEarned < 0)
            {
                throw new ArgumentException(name + ": exp. earned must be positive.");
            }
            _name = name;
            _expEarned = expEarned;
        }

        #endregion
    }
}
