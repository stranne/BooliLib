using System.Globalization;

namespace Stranne.BooliLib.Models
{
    /// <summary>
    /// Dimension.
    /// </summary>
    public class Dimension
    {
        /// <summary>
        /// Gets or sets height.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets width.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets create an empty dimension.
        /// </summary>
        public Dimension()
        {
        }

        /// <summary>
        /// Create a predefined dimension.
        /// </summary>
        /// <param name="height">Dimension's height.</param>
        /// <param name="width">Dimension's width.</param>
        public Dimension(int height, int width)
        {
            Height = height;
            Width = width;
        }
    }
}