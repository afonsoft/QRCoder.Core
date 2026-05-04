using QRCoder.Core.Models;
using Shouldly;
using Xunit;

namespace QRCoder.Core.Tests.Models
{
    public class SizeTests
    {
        [Fact]
        public void constructor_sets_width_and_height()
        {
            var size = new Size(100, 200);
            size.Width.ShouldBe(100);
            size.Height.ShouldBe(200);
        }

        [Fact]
        public void default_constructor_creates_zero_size()
        {
            var size = new Size();
            size.Width.ShouldBe(0);
            size.Height.ShouldBe(0);
        }

        [Fact]
        public void properties_are_settable()
        {
            var size = new Size();
            size.Width = 50.5;
            size.Height = 75.3;
            size.Width.ShouldBe(50.5);
            size.Height.ShouldBe(75.3);
        }

        [Fact]
        public void supports_fractional_values()
        {
            var size = new Size(0.5, 0.25);
            size.Width.ShouldBe(0.5);
            size.Height.ShouldBe(0.25);
        }
    }
}
