namespace QRCoder.Core.Models
{
    /// <summary>
    /// Represents the dimensions (width and height) of a QR code rendering area.
    /// </summary>
    public struct Size
    {
        /// <summary>
        /// The width of the rendering area in the target unit (pixels, points, etc.).
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// The height of the rendering area in the target unit (pixels, points, etc.).
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Size"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public Size(double width, double height)
        {
            Width = width;
            Height = height;
        }
    }
}
