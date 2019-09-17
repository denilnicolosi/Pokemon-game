using System;

namespace PokemonGame.Exceptions
{
    /// <summary>
    /// Exception generated when a pokemon is already chosen on the battlefield.
    /// </summary>
    /// <remarks>
    /// The exception extends directly <c>Exception</c>.
    /// </remarks>
    public class ChangeException : Exception
    {
        // Definition of class methods.
        #region Methods

        /// <summary>
        /// Contructor method of the <c>SkillNotFoundException</c> class.
        /// It already includes a standard message.
        /// </summary>
        public ChangeException()
            : base("Pokemon already in the battlefield.") { }

        /// <summary>
        /// Contructor method of the <c>SkillNotFoundException</c> class.
        /// Add a specified message.
        /// </summary>
        /// <param name="message">Error message.</param>
        public ChangeException(string message)
            : base(message) { }

        /// <summary>
        /// Contructor method of the <c>SkillNotFoundException</c> class.
        /// Add a specified message and reference to the internal exception,
        /// which is the cause of the current exception.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <param name="inner">Reference to the internal exception</param>
        public ChangeException(string message, Exception inner)
            : base(message, inner) { }
    }

    #endregion
}
