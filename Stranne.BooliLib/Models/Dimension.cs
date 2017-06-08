using System.Globalization;

namespace Stranne.BooliLib.Models
{
    /// <summary>
    /// Dimension
    /// </summary>
    public class Dimension
    {
        /// <summary>
        /// Height
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Width
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Create an empty dimension
        /// </summary>
        public Dimension()
        {
        }

        /// <summary>
        /// Create a predefined dimension
        /// </summary>
        /// <param name="height">Dimension's height</param>
        /// <param name="width">Dimension's width</param>
        public Dimension(int height, int width)
        {
            Height = height;
            Width = width;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{Height.ToString(new CultureInfo("en-US"))},{Width.ToString(new CultureInfo("en-US"))}";
        }
    }
}