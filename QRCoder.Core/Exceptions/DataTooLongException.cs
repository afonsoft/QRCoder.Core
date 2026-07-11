using System;

namespace QRCoder.Core.Exceptions
{
    /// <summary>
    /// Thrown when the input data exceeds the maximum capacity allowed by the QR code standard
    /// for the specified error correction level, encoding mode, and optional fixed version.
    /// </summary>
    public class DataTooLongException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataTooLongException"/> class.
        /// </summary>
        /// <param name="eccLevel">The ecc level.</param>
        /// <param name="encodingMode">The encoding mode.</param>
        /// <param name="maxSizeByte">The max size byte.</param>
        public DataTooLongException(string eccLevel, string encodingMode, int maxSizeByte) : base(
            $"The given payload exceeds the maximum size of the QR code standard. The maximum size allowed for the choosen paramters (ECC level={eccLevel}, EncodingMode={encodingMode}) is {maxSizeByte} byte."
        )
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataTooLongException"/> class.
        /// </summary>
        /// <param name="eccLevel">The ecc level.</param>
        /// <param name="encodingMode">The encoding mode.</param>
        /// <param name="version">The version.</param>
        /// <param name="maxSizeByte">The max size byte.</param>
        public DataTooLongException(string eccLevel, string encodingMode, int version, int maxSizeByte) : base(
            $"The given payload exceeds the maximum size of the QR code standard. The maximum size allowed for the choosen paramters (ECC level={eccLevel}, EncodingMode={encodingMode}, FixedVersion={version}) is {maxSizeByte} byte."
        )
        { }
    }
}
