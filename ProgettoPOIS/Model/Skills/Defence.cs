using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoPOIS.Model
{
    /// <summary>
    /// Class that extends Skill.
    /// Represents a defense skill.
    /// </summary>
    public class Defence : Skill
    {
        // Definition of private internal attributes.
        #region Private
        private int _healthEarned;
        #endregion

        // Definition of public attributes, for the "get/set" methods.
        #region Public
        public int HealthEarned { get => _healthEarned; set => _healthEarned = value; }
        #endregion

        // Definition of class methods.
        #region Methods

        /// <summary>
        /// Constructor method of the <c>Defence</c> class.
        /// </summary>
        /// <param name="name">Name of the attack skill.</param>
        /// <param name="healthEarned">Health points that the skill increases.</param>
        /// <param name="expEarned">Experience earned.</param>
        public Defence(string name, int healthEarned, int expEarned) : base(name, expEarned)
        {
            _healthEarned = healthEarned;
        }

        #endregion
    }
}
