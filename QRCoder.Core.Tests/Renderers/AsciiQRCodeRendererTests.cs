using QRCoder.Core.Abstractions;
using QRCoder.Core.Generators;
using QRCoder.Core.Models;
using QRCoder.Core.Renderers;
using QRCoder.Core.Tests.Helpers.XUnitExtenstions;
using Shouldly;
using Xunit;

namespace QRCoder.Core.Tests
{
    public class AsciiQRCodeRendererTests
    {
        [Fact]
        [Category("QRRenderer/AsciiQRCode")]
        public void can_render_ascii_qrcode()
        {
            var targetCode = @"                                                          
                                                          
                                                          
                                                          
        ██████████████  ████  ██    ██████████████        
        ██          ██  ████    ██  ██          ██        
        ██  ██████  ██  ██  ██  ██  ██  ██████  ██        
        ██  ██████  ██  ██      ██  ██  ██████  ██        
        ██  ██████  ██  ██████████  ██  ██████  ██        
        ██          ██              ██          ██        
        ██████████████  ██  ██  ██  ██████████████        
                        ██████████                        
          ████  ██  ████    ██████  ██  ██████████        
        ██        ██        ██      ██    ██  ████        
            ████  ██████  ██████        ██████  ██        
        ████      ██  ██████  ██    ██        ██          
          ████    ████  ██  ██      ██  ██  ████          
                        ██    ██  ██  ██  ██              
        ██████████████  ██  ████  ██████    ██            
        ██          ██    ██    ████  ██████              
        ██  ██████  ██  ██████  ████████    ██  ██        
        ██  ██████  ██    ██        ██      ████          
        ██  ██████  ██  ██████  ██      ██      ██        
        ██          ██  ██  ██      ██      ██████        
        ██████████████    ██    ██  ██  ██  ██  ██        
                                                          
                                                          
                                                          
                                                          ";

            //Create QR code
            var gen = new QRCodeGenerator();
            var data = gen.CreateQrCode("A05", QRCodeGenerator.ECCLevel.Q);
            var asciiCode = new AsciiQRCode(data).GetGraphic(1, drawQuietZones: true);

            asciiCode.ShouldBe(targetCode);
        }

        [Fact]
        [Category("QRRenderer/AsciiQRCode")]
        public void can_render_ascii_qrcode_without_quietzones()
        {
            var targetCode = @"██████████████  ████  ██    ██████████████
██          ██  ████    ██  ██          ██
██  ██████  ██  ██  ██  ██  ██  ██████  ██
██  ██████  ██  ██      ██  ██  ██████  ██
██  ██████  ██  ██████████  ██  ██████  ██
██          ██              ██          ██
██████████████  ██  ██  ██  ██████████████
                ██████████                
  ████  ██  ████    ██████  ██  ██████████
██        ██        ██      ██    ██  ████
    ████  ██████  ██████        ██████  ██
████      ██  ██████  ██    ██        ██  
  ████    ████  ██  ██      ██  ██  ████  
                ██    ██  ██  ██  ██      
██████████████  ██  ████  ██████    ██    
██          ██    ██    ████  ██████      
██  ██████  ██  ██████  ████████    ██  ██
██  ██████  ██    ██        ██      ████  
██  ██████  ██  ██████  ██      ██      ██
██          ██  ██  ██      ██      ██████
██████████████    ██    ██  ██  ██  ██  ██";

            //Create QR code
            var gen = new QRCodeGenerator();
            var data = gen.CreateQrCode("A05", QRCodeGenerator.ECCLevel.Q);
            var asciiCode = new AsciiQRCode(data).GetGraphic(1, drawQuietZones: false);

            asciiCode.ShouldBe(targetCode);
        }

        [Fact]
        [Category("QRRenderer/AsciiQRCode")]
        public void can_render_ascii_qrcode_with_custom_symbols()
        {
            var targetCode = @"                                                          
                                                          
                                                          
                                                          
                                                          
                                                          
                                                          
                                                          
        XXXXXXXXXXXXXX    XX        XXXXXXXXXXXXXX        
        XXXXXXXXXXXXXX    XX        XXXXXXXXXXXXXX        
        XX          XX        XXXX  XX          XX        
        XX          XX        XXXX  XX          XX        
        XX  XXXXXX  XX  XXXX        XX  XXXXXX  XX        
        XX  XXXXXX  XX  XXXX        XX  XXXXXX  XX        
        XX  XXXXXX  XX    XX    XX  XX  XXXXXX  XX        
        XX  XXXXXX  XX    XX    XX  XX  XXXXXX  XX        
        XX  XXXXXX  XX  XXXX    XX  XX  XXXXXX  XX        
        XX  XXXXXX  XX  XXXX    XX  XX  XXXXXX  XX        
        XX          XX  XX      XX  XX          XX        
        XX          XX  XX      XX  XX          XX        
        XXXXXXXXXXXXXX  XX  XX  XX  XXXXXXXXXXXXXX        
        XXXXXXXXXXXXXX  XX  XX  XX  XXXXXXXXXXXXXX        
                          XX  XX                          
                          XX  XX                          
          XX    XX  XX  XXXXXX  XXXX  XXXX  XX            
          XX    XX  XX  XXXXXX  XXXX  XXXX  XX            
          XXXXXX  XX  XXXX      XX    XX  XX  XXXX        
          XXXXXX  XX  XXXX      XX    XX  XX  XXXX        
          XXXXXX    XXXXXXXXXX      XXXXXXXXXX            
          XXXXXX    XXXXXXXXXX      XXXXXXXXXX            
        XX  XX  XX    XX  XX    XXXXXX  XX  XX            
        XX  XX  XX    XX  XX    XXXXXX  XX  XX            
        XXXXXX      XXXX  XX  XX  XXXX      XX  XX        
        XXXXXX      XXXX  XX  XX  XXXX      XX  XX        
                        XXXXXX    XXXX      XX  XX        
                        XXXXXX    XXXX      XX  XX        
        XXXXXXXXXXXXXX        XXXXXX            XX        
        XXXXXXXXXXXXXX        XXXXXX            XX        
        XX          XX          XX    XX  XX              
        XX          XX          XX    XX  XX              
        XX  XXXXXX  XX  XXXXXXXXXX  XXXXXXXXXXXXXX        
        XX  XXXXXX  XX  XXXXXXXXXX  XXXXXXXXXXXXXX        
        XX  XXXXXX  XX    XX  XXXX    XX  XX  XXXX        
        XX  XXXXXX  XX    XX  XXXX    XX  XX  XXXX        
        XX  XXXXXX  XX    XXXXXX    XXXXXXXXXX            
        XX  XXXXXX  XX    XXXXXX    XXXXXXXXXX            
        XX          XX  XX        XXXX  XX  XX  XX        
        XX          XX  XX        XXXX  XX  XX  XX        
        XXXXXXXXXXXXXX    XX    XXXXXX      XXXXXX        
        XXXXXXXXXXXXXX    XX    XXXXXX      XXXXXX        
                                                          
                                                          
                                                          
                                                          
                                                          
                                                          
                                                          
                                                          ";

            //Create QR code
            var gen = new QRCodeGenerator();
            var data = gen.CreateQrCode("A", QRCodeGenerator.ECCLevel.Q);
            var asciiCode = new AsciiQRCode(data).GetGraphic(2, "X", " ", drawQuietZones: true);

            asciiCode.ShouldBe(targetCode);
        }

        [Fact]
        [Category("QRRenderer/AsciiQRCode")]
        public void can_instantate_parameterless()
        {
            var asciiCode = new AsciiQRCode();
            asciiCode.ShouldNotBeNull();
            asciiCode.ShouldBeOfType<AsciiQRCode>();
        }

        [Fact]
        [Category("QRRenderer/AsciiQRCode")]
        public void can_render_ascii_qrcode_from_helper()
        {
            var targetCode = @"                                                          
                                                          
                                                          
                                                          
                                                          
                                                          
                                                          
                                                          
        XXXXXXXXXXXXXX    XX        XXXXXXXXXXXXXX        
        XXXXXXXXXXXXXX    XX        XXXXXXXXXXXXXX        
        XX          XX        XXXX  XX          XX        
        XX          XX        XXXX  XX          XX        
        XX  XXXXXX  XX  XXXX        XX  XXXXXX  XX        
        XX  XXXXXX  XX  XXXX        XX  XXXXXX  XX        
        XX  XXXXXX  XX    XX    XX  XX  XXXXXX  XX        
        XX  XXXXXX  XX    XX    XX  XX  XXXXXX  XX        
        XX  XXXXXX  XX  XXXX    XX  XX  XXXXXX  XX        
        XX  XXXXXX  XX  XXXX    XX  XX  XXXXXX  XX        
        XX          XX  XX      XX  XX          XX        
        XX          XX  XX      XX  XX          XX        
        XXXXXXXXXXXXXX  XX  XX  XX  XXXXXXXXXXXXXX        
        XXXXXXXXXXXXXX  XX  XX  XX  XXXXXXXXXXXXXX        
                          XX  XX                          
                          XX  XX                          
          XX    XX  XX  XXXXXX  XXXX  XXXX  XX            
          XX    XX  XX  XXXXXX  XXXX  XXXX  XX            
          XXXXXX  XX  XXXX      XX    XX  XX  XXXX        
          XXXXXX  XX  XXXX      XX    XX  XX  XXXX        
          XXXXXX    XXXXXXXXXX      XXXXXXXXXX            
          XXXXXX    XXXXXXXXXX      XXXXXXXXXX            
        XX  XX  XX    XX  XX    XXXXXX  XX  XX            
        XX  XX  XX    XX  XX    XXXXXX  XX  XX            
        XXXXXX      XXXX  XX  XX  XXXX      XX  XX        
        XXXXXX      XXXX  XX  XX  XXXX      XX  XX        
                        XXXXXX    XXXX      XX  XX        
                        XXXXXX    XXXX      XX  XX        
        XXXXXXXXXXXXXX        XXXXXX            XX        
        XXXXXXXXXXXXXX        XXXXXX            XX        
        XX          XX          XX    XX  XX              
        XX          XX          XX    XX  XX              
        XX  XXXXXX  XX  XXXXXXXXXX  XXXXXXXXXXXXXX        
        XX  XXXXXX  XX  XXXXXXXXXX  XXXXXXXXXXXXXX        
        XX  XXXXXX  XX    XX  XXXX    XX  XX  XXXX        
        XX  XXXXXX  XX    XX  XXXX    XX  XX  XXXX        
        XX  XXXXXX  XX    XXXXXX    XXXXXXXXXX            
        XX  XXXXXX  XX    XXXXXX    XXXXXXXXXX            
        XX          XX  XX        XXXX  XX  XX  XX        
        XX          XX  XX        XXXX  XX  XX  XX        
        XXXXXXXXXXXXXX    XX    XXXXXX      XXXXXX        
        XXXXXXXXXXXXXX    XX    XXXXXX      XXXXXX        
                                                          
                                                          
                                                          
                                                          
                                                          
                                                          
                                                          
                                                          ";

            var asciiCode = AsciiQRCodeHelper.GetQRCode("A", 2, "X", " ", QRCodeGenerator.ECCLevel.Q);
            asciiCode.ShouldBe(targetCode);
        }

    }
}
