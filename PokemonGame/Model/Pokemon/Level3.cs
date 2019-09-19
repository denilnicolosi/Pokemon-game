using System;
using PokemonGame.Exceptions;

namespace PokemonGame.Model
{
    /// <summary>
    /// Class that extends <c>Level2</c>.
    /// represents a Pokemon on its third evolution.
    /// </summary>
    /// <remarks>
    /// This class adds one skill to the level two pokemon.
    /// </remarks>
    public class Level3 : Level2, ICloneable
    {
        // Definition of private internal attributes.
        #region Private
        private Skill _s4;
        #endregion

        // Definition of public attributes, for the "get/set" methods.
        #region Public
        /// <summary>Reference to skill number three.</summary>
        public Skill S4 { get => _s4; set => _s4 = value; }
        #endregion


        // Definition of class methods.
        #region Methods

        /// <summary>
        /// Constructor method of the <c>Level3</c> class.
        /// </summary>
        /// <param name="attribute">Pokemon attribute.</param>
        /// <param name="name">Pokemon name.</param>
        /// <param name="attack">Value of the Pokemon attack.</param>
        /// <param name="defence">Value of the Pokemon defence.</param>
        /// <param name="s1">Skill number one of the Pokemon.</param>
        /// <param name="s2">Skill number two of the Pokemon.</param>
        /// <param name="s3">Skill number three of the Pokèmon.</param>
        /// <param name="s4">Skill number four of the Pokemon.</param>
        /// <exception cref="SkillNotFoundException">Reference to the skill not found.</exception>
        public Level3(typeAttribute attribute, string name, int attack, int defence, Skill s1, Skill s2, Skill s3, Skill s4)
            : base(attribute, name, attack, defence, s1, s2, s3)
        {
            if (s4 != null)
            {
                _s4 = s4;
            }
            else
            {
                throw new SkillNotFoundException(name + ": skill not found.");
            }
        }

        /// <summary>
        /// Create a new instance of the class with the same value as an existing instance.
        /// </summary>
        /// <returns>New object which is a copy of the current instance.</returns>
        public override object Clone()
        {
            Pokemon p =  new Level3(Attribute, Name, Attack, Defence, S1, S2, S3, _s4);
            p.NextLevel = NextLevel;
            return p;
        }

        #endregion
    }
}
