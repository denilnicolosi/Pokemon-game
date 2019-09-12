using System;
using ProgettoPOIS.Exceptions;

namespace ProgettoPOIS.Model
{
    /// <summary>
    /// Class that extends <c>Level1</c>.
    /// Represents a Pokémon on its second evolution.
    /// </summary>
    /// <remarks>
    /// This class adds one skill to the level one pokemon.
    /// </remarks>
    public class Level2 : Level1, ICloneable
    {
        // Definition of private internal attributes.
        #region Protected
        private Skill _s3;
        #endregion

        // Definition of public attributes, for the "get/set" methods.
        #region Public 
        /// <summary>Reference to skill number three.</summary>
        public Skill S3 { get => _s3; set => _s3 = value; }
        #endregion


        // Definition of class methods.
        #region Methonds

        /// <summary>
        /// Constructor method of the <c>Level2</c> class.
        /// </summary>
        /// <param name="attribute">Pokémon attribute.</param>
        /// <param name="name">Pokémon name.</param>
        /// <param name="attack">Value of the Pokémon attack.</param>
        /// <param name="defence">Value of the Pokémon defence.</param>
        /// <param name="s1">Skill number one of the Pokémon.</param>
        /// <param name="s2">Skill number two of the Pokémon.</param>
        /// <param name="s3">Skill number three of the Pokèmon.</param>
        /// <exception cref="SkillNotFoundException">Reference to the skill not found.</exception>
        public Level2(typeAttribute attribute, string name, int attack, int defence, Skill s1, Skill s2, Skill s3)
            : base(attribute, name, attack, defence, s1, s2)
        {
            if (s1 != null && s2 != null)
            {
                _s3 = s3;
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
            Pokémon p = new Level2(Attribute, Name, Attack, Defence, S1, S2, _s3);
            p.NextLevel = NextLevel;
            return p;
        }

        #endregion
    }
}
