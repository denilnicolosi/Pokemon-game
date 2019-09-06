

namespace ProgettoPOIS.Model
{
    /// <summary>
    /// Class that extends <c>Level1</c>.
    /// Represents a Pokémon on its second evolution.
    /// </summary>
    /// <remarks>
    /// This class adds one skill to the level one pokemon.
    /// </remarks>
    public class Level2 : Level1
    {
        // Definition of private internal attributes.
        #region Private
        private Skill _s3;
        #endregion

        // Definition of public attributes, for the "get/set" methods.
        #region Public 
        public Skill S3 { get => _s3; set => _s3 = value; }
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
        public Level2(typeAttribute attribute, string name, int attack, int defence, Skill s1, Skill s2, Skill s3)
            : base(attribute, name, attack, defence, s1, s2)
        {
            if (s1 != null && s2 != null)
            {
                _s3 = s3;
            }
            else
                throw new SkillNotFoundException();
            
        }

        #endregion
    }
}
