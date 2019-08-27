
namespace ProgettoPOIS.Model
{
    /// <summary>
    /// Class that extends Pok�mon.
    /// Represents a Pok�mon on its first evolution.
    /// </summary>
    /// <remarks>
    /// This class adds 2 skills to the Pok�mon.
    /// </remarks>
    public class Level1 : Pok�mon
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
        /// <typeparam name="typeAttribute"> Enumerator for the attributes of Pok�mon: fire, water, earth. </typeparam> 
        /// <typeparam name="Skill"> <typeparamref name"Skill"/> Object </typeParam>
        /// <param name="attribute"> Pok�mon attribute. </param>
        /// <param name="name"> Pok�mon name. </param>
        /// <param name="attack"> Value of the Pok�mon attack. </param>
        /// <param name="defence"> Value of the Pok�mon defence. </param>
        /// <param name="s1"> Skill number one of the Pok�mon. </param>
        /// <param name="s2"> Skill number two of the Pok�mon. </param>
        public Level1(typeAttribute attribute, string name, int attack, int defence, Skill s1, Skill s2)
            : base(attribute, name, attack, defence)
        {
            _s1 = s1;
            _s2 = s2;
        }

        #endregion
    }
}
