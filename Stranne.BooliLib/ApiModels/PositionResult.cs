namespace Stranne.BooliLib.ApiModels
{
    /// <summary>
    /// Position result
    /// </summary>
    public class PositionResult : Position
    {
        /// <summary>
        /// Is approximate
        /// </summary>
        public bool? IsApproximate { get; set; } // TODO test
    }
}