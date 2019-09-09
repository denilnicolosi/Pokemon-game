using System;
using ProgettoPOIS.Exceptions;

namespace ProgettoPOIS.Model
{
    /// <summary>
    /// Class that extends <c>Pokémon</c>.
    /// Represents a Pokémon on its first evolution.
    /// </summary>
    /// <remarks>
    /// This class adds two skills to the Pokémon.
    /// </remarks>
    public class Level1 : Pokémon
    {
        // Definition of private internal attributes.
        #region Private
        private Skill _s1, _s2;
        #endregion

        // Definition of public attributes, for the "get/set" methods.
        #region Public 
        public Skill S1 { get => _s1; set => _s1 = value; }
        public Skill S2 { get => _s2; set => _s2 = value; }
        #endregion

        // Definition of class methods.
        #region Methonds

        /// <summary>
        /// Constructor method of the <c>Level</c> class.
        /// </summary>
        /// <typeparam name="typeAttribute">Enumerator for the attributes of Pokémon: Fire, Water, Earth.</typeparam> 
        /// <typeparam name="Skill"><typeparamref name="Skill"/>Object of type Skill.</typeparam>
        /// <param name="attribute">Pokémon attribute.</param>
        /// <param name="name">Pokémon name.</param>
        /// <param name="attack">Value of the Pokémon attack.</param>
        /// <param name="defence">Value of the Pokémon defence.</param>
        /// <param name="s1">Skill number one of the Pokémon.</param>
        /// <param name="s2">Skill number two of the Pokémon.</param>
        public Level1(typeAttribute attribute, string name, int attack, int defence, Skill s1, Skill s2)
            : base(attribute, name, attack, defence)
        {
            if (s1 != null && s2 != null)
            {
                _s1 = s1;
                _s2 = s2;
            }
            else
                throw new SkillNotFoundException();
        }

        #endregion
    }
}
