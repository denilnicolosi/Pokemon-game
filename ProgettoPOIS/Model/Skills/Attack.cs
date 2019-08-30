using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoPOIS.Model
{
    /// <summary>
    /// Class that extends Skill.
    /// Represents an attack skill.
    /// </summary>
    public class Attack : Skill
    {
        // Definition of private internal attributes.
        #region Private
        private int _damage;
        #endregion

        // Definition of public attributes, for the "get/set" methods.
        #region Public 
        public int Damage { get => _damage; set => _damage = value; }
        #endregion

        // Definition of class methods.
        #region Methods

        /// <summary>
        /// Constructor method of the <c>Attack</c> class.
        /// </summary>
        /// <param name="name">Name of the attack skill.</param>
        /// <param name="damage">Damage that the skill performs.</param>
        /// <param name="expEarned">Experience earned.</param>
        public Attack(string name, int damage, int expEarned) : base(name, expEarned)
        {
            _damage = damage;
        }

        #endregion
    }
}
