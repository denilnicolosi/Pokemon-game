using System;
using ProgettoPOIS.Exceptions;

namespace ProgettoPOIS.Model
{
    /// <summary>
    /// Class that extends <c>Level2</c>.
    /// represents a Pokémon on its third evolution.
    /// </summary>
    /// <remarks>
    /// This class adds one skill to the level two pokémon.
    /// </remarks>
    public class Level3 : Level2, ICloneable
    {
        // Definition of private internal attributes.
        #region Private
        private Skill _s4;
        #endregion

        // Definition of public attributes, for the "get/set" methods.
        #region Public
        public Skill S4 { get => _s4; set => _s4 = value; }
        #endregion

        // Definition of class methods.
        #region Methonds

        /// <summary>
        /// Constructor method of the <c>Leve2</c> class.
        /// </summary>
        /// <typeparam name="typeAttribute">Enumerator for the attributes of Pokémon: Fire, Water, Earth.</typeparam> 
        /// <typeparam name="Skill"><typeparamref name"Skill"/>Object of type Skill.</typeParam>
        /// <param name="attribute">Pokémon attribute.</param>
        /// <param name="name">Pokémon name.</param>
        /// <param name="attack">Value of the Pokémon attack.</param>
        /// <param name="defence">Value of the Pokémon defence.</param>
        /// <param name="s1">Skill number one of the Pokémon.</param>
        /// <param name="s2">Skill number two of the Pokémon.</param>
        /// <param name="s3">Skill number three of the Pokèmon.</param>
        /// <param name="s4">Skill number four of the Pokémon.</param>
        public Level3(typeAttribute attribute, string name, int attack, int defence, Skill s1, Skill s2, Skill s3, Skill s4)
            : base(attribute, name, attack, defence, s1, s2, s3)
        {
            if (s1 != null && s2 != null)
            {
                _s4 = s4;
            }
            else
                throw new SkillNotFoundException();
        }

        public override object Clone()
        {
            return new Level3(_attribute, _name, _attack, _defence, _s1, _s2, _s3, _s4);
            //return this.MemberwiseClone();
        }

        #endregion
    }
}
