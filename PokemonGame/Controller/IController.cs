namespace PokemonGame.Controller
{
    /// <summary>
    /// Interface for controllers.
    /// </summary>
    public interface IController
    {
        // Definition of class methods.
        #region Methods

        /// <summary>
        /// End program execution.
        /// </summary>
        void Exit();

        /// <summary>
        /// Method that starts the form.
        /// </summary>
        void Start();

        #endregion
    }
}
