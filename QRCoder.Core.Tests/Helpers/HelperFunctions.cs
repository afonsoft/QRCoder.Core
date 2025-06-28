using System;

using System.IO;
using System.Security.Cryptography;
using System.Text;

#if WINDOWS
using SW = System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
#endif

namespace QRCoder.Core.Tests.Helpers
{
    public static class HelperFunctions
    {
#if WINDOWS
        public static BitmapSource ToBitmapSource(DrawingImage source)
        {
            DrawingVisual drawingVisual = new DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();
            drawingContext.DrawImage(source, new SW.Rect(new SW.Point(0, 0), new SW.Size(source.Width, source.Height)));
            drawingContext.Close();

            RenderTargetBitmap bmp = new RenderTargetBitmap((int)source.Width, (int)source.Height, 96, 96, PixelFormats.Pbgra32);
            bmp.Render(drawingVisual);
            return bmp;
        }

        public static Bitmap BitmapSourceToBitmap(DrawingImage xamlImg)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(ToBitmapSource(xamlImg)));
                encoder.Save(ms);

                using (Bitmap bmp = new Bitmap(ms))
                {
                    return new Bitmap(bmp);
                }
            }
        }
#endif

        public static string GetAssemblyPath()
        {
            return
#if NET5_0 || NET6_0_OR_GREATER
            AppDomain.CurrentDomain.BaseDirectory;
#else
            (Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\").Replace("file:\\", "");
#endif
        }

        public static string BitmapToHash(SKBitmap bmp)
        {
            byte[] imgBytes = null;
            using (var ms = new MemoryStream())
            {
                bmp.Encode(SKEncodedImageFormat.Png, 100).SaveTo(ms);
                imgBytes = ms.ToArray();
                ms.Dispose();
            }
            return ByteArrayToHash(imgBytes);
        }

        public static string ByteArrayToHash(byte[] data)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(data);
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }

        public static string StringToHash(string data)
        {
            return ByteArrayToHash(Encoding.UTF8.GetBytes(data));
        }
    }
}