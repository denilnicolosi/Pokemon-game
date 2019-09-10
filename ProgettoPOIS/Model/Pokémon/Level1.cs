using System;
using ProgettoPOIS.Exceptions;

namespace ProgettoPOIS.Model
{
    /// <summary>
    /// Class that extends <c>Pok�mon</c>.
    /// Represents a Pok�mon on its first evolution.
    /// </summary>
    /// <remarks>
    /// This class adds two skills to the Pok�mon.
    /// </remarks>
    public class Level1 : Pok�mon, ICloneable
    {
        // Definition of private internal attributes.
        #region Private
        protected Skill _s1, _s2;
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
        /// <param name="attribute">Pok�mon attribute.</param>
        /// <param name="name">Pok�mon name.</param>
        /// <param name="attack">Value of the Pok�mon attack.</param>
        /// <param name="defence">Value of the Pok�mon defence.</param>
        /// <param name="s1">Skill number one of the Pok�mon.</param>
        /// <param name="s2">Skill number two of the Pok�mon.</param>
        /// <exception cref="ProgettoPOIS.Exceptions.SkillNotFoundException">Reference to the skill not found.</exception>
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

        /// <summary>
        /// Create a new instance of the class with the same value as an existing instance.
        /// </summary>
        /// <returns>New object which is a copy of the current instance.</returns>
        public override object Clone()
        {
            return new Level1(_attribute, _name, _attack, _defence, _s1, _s2);
        }

        #endregion
    }
}
