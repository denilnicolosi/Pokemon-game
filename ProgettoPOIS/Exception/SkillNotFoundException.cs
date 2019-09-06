using System;

/// <summary>
/// Exception generated when a skill was not found.
/// </summary>
/// <remarks>
/// The exception extends directly <c>Exception</c>.
/// </remarks>
public class SkillNotFoundException : Exception
{
    // Definition of class methods.
    #region Methods

    /// <summary>
    /// Contructor method of the <c>SkillNotFoundException</c> class.
    /// It already includes a standard message.
    /// </summary>
    public SkillNotFoundException()
        : base("Skill not found!") { }

    /// <summary>
    /// Contructor method of the <c>SkillNotFoundException</c> class.
    /// Add a specified message.
    /// </summary>
    /// <param name="message">Error message.</param>
    public SkillNotFoundException(string message)
        : base(message) { }

    /// <summary>
    /// Contructor method of the <c>SkillNotFoundException</c> class.
    /// Add a specified message and reference to the internal exception,
    /// which is the cause of the current exception.
    /// </summary>
    /// <param name="message">Error message.</param>
    /// <param name="inner">Reference to the internal exception</param>
    public SkillNotFoundException(string message, Exception inner)
        : base(message, inner) { }

    #endregion
}