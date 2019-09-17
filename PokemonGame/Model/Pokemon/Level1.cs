using System;
using PokemonGame.Exceptions;

namespace PokemonGame.Model
{
    /// <summary>
    /// Class that extends <c>Pokemon</c>.
    /// Represents a Pokemon on its first evolution.
    /// </summary>
    /// <remarks>
    /// This class adds two skills to the Pokemon.
    /// </remarks>
    public class Level1 : Pokemon, ICloneable
    {
        // Definition of private internal attributes.
        #region Protected
        private Skill _s1;
        private Skill _s2;
        #endregion

        // Definition of public attributes, for the "get/set" methods.
        #region Public 
        /// <summary>Reference to skill number one.</summary>
        public Skill S1 { get => _s1; set => _s1 = value; }
        /// <summary>Reference to skill number two.</summary>
        public Skill S2 { get => _s2; set => _s2 = value; }
        #endregion


        // Definition of class methods.
        #region Methonds

        /// <summary>
        /// Constructor method of the <c>Level</c> class.
        /// </summary>
        /// <param name="attribute">Pokemon attribute.</param>
        /// <param name="name">Pokemon name.</param>
        /// <param name="attack">Value of the Pokemon attack.</param>
        /// <param name="defence">Value of the Pokemon defence.</param>
        /// <param name="s1">Skill number one of the Pokemon.</param>
        /// <param name="s2">Skill number two of the Pokemon.</param>
        /// <exception cref="SkillNotFoundException">Reference to the skill not found.</exception>
        public Level1(typeAttribute attribute, string name, int attack, int defence, Skill s1, Skill s2)
            : base(attribute, name, attack, defence)
        {
            if (s1 != null && s2 != null)
            {
                _s1 = s1;
                _s2 = s2;
            }
            else
            {
                throw new SkillNotFoundException();
            }
        }

        /// <summary>
        /// Create a new instance of the class with the same value as an existing instance.
        /// </summary>
        /// <returns>New object which is a copy of the current instance.</returns>
        public override object Clone()
        {
            Pokemon p = new Level1(Attribute, Name, Attack, Defence, _s1, _s2);
            p.NextLevel = NextLevel;
            return p;
        }

        #endregion
    }
}
