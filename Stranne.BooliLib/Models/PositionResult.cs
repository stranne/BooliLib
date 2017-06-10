namespace Stranne.BooliLib.Models
{
    /// <summary>
    /// Position result.
    /// </summary>
    public class PositionResult : Position
    {
        /// <summary>
        /// Gets or sets if position is approximate.
        /// </summary>
        public bool? IsApproximate { get; set; }
    }
}