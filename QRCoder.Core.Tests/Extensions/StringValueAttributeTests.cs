using QRCoder.Core.Extensions;
using Shouldly;
using Xunit;

namespace QRCoder.Core.Tests.Extensions
{
    public class StringValueAttributeTests
    {
        private enum TestEnum
        {
            [StringValue("value_one")]
            One,
            [StringValue("value_two")]
            Two,
            NoAttribute
        }

        [Fact]
        public void string_value_attribute_stores_value()
        {
            var attr = new StringValueAttribute("test");
            attr.StringValue.ShouldBe("test");
        }

        [Fact]
        public void get_string_value_returns_attribute_value()
        {
            TestEnum.One.GetStringValue().ShouldBe("value_one");
            TestEnum.Two.GetStringValue().ShouldBe("value_two");
        }

        [Fact]
        public void get_string_value_returns_null_when_no_attribute()
        {
            TestEnum.NoAttribute.GetStringValue().ShouldBeNull();
        }
    }
}
