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
        public void Number_should_convert_to_expected_numeral(int input, string expected)
        {
            var actual = Convert(input);

            actual.Should().Be(expected);
        }

        private static string Convert(int input)
        {
            var convert = new StringBuilder()
                .Append('I', input)
                .Replace("IIIII", "V")
                .Replace("IIII", "IV")
                .ToString();
            return convert;
        }
    }
}