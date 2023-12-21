﻿using System;

namespace QRCoder.Core
{
    /// <summary>
    /// AbstractQRCode
    /// </summary>
    public abstract class AbstractQRCode
    {
        /// <summary>
        /// QRCodeData
        /// </summary>
        protected QRCodeData QrCodeData { get; set; }

        /// <summary>
        /// AbstractQRCode
        /// </summary>
        protected AbstractQRCode()
        {
            //https://learn.microsoft.com/pt-br/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only
            AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
        }

        /// <summary>
        /// AbstractQRCode
        /// </summary>
        /// <param name="data"></param>
        protected AbstractQRCode(QRCodeData data) : this()
        {
            this.QrCodeData = data;
        }

        /// <summary>
        /// Set a QRCodeData object that will be used to generate QR code. Used in COM Objects connections
        /// </summary>
        /// <param name="data">Need a QRCodeData object generated by QRCodeGenerator.CreateQrCode()</param>
        public virtual void SetQRCodeData(QRCodeData data)
        {
            this.QrCodeData = data;
        }

        public void Dispose()
        {
            this.QrCodeData?.Dispose();
            this.QrCodeData = null;
        }
    }
}