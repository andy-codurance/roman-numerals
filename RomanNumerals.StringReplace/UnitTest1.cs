using System.Text;
using FluentAssertions;
using Xunit;

namespace RomanNumerals.StringReplace
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1, "I")]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        [InlineData(4, "IV")]
        [InlineData(5, "V")]
        [InlineData(6, "VI")]
        [InlineData(7, "VII")]
        [InlineData(8, "VIII")]
        [InlineData(9, "IX")]
        [InlineData(10, "X")]
        [InlineData(11, "XI")]
        [InlineData(13, "XIII")]
        [InlineData(14, "XIV")]
        [InlineData(15, "XV")]
        [InlineData(16, "XVI")]
        [InlineData(19, "XIX")]
        [InlineData(20, "XX")]
        [InlineData(30, "XXX")]
        [InlineData(33, "XXXIII")]
        [InlineData(34, "XXXIV")]
        [InlineData(35, "XXXV")]
        [InlineData(36, "XXXVI")]
        [InlineData(39, "XXXIX")]
        [InlineData(40, "XL")]
        public void Number_should_convert_to_expected_numeral(int input, string expected)
        {
            var actual = Convert(input);

            actual.Should().Be(expected);
        }

        private static string Convert(int input)
        {
            var convert = new StringBuilder()
                .Append('I', input)
                .Replace("IIIIIIIIII", "X")
                .Replace("IIIIIIIII", "IX")
                .Replace("IIIII", "V")
                .Replace("IIII", "IV")
                .Replace("XXXX", "XL")
                .ToString();
            return convert;
        }
    }
}