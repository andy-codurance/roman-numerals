using FluentAssertions;
using Xunit;

namespace RomanNumerals.StringReplace
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1, "I")]
        [InlineData(2, "II")]
        public void Number_should_convert_to_expected_numeral(int input, string expected)
        {
            var actual = Convert(input);

            actual.Should().Be(expected);
        }

        private static string Convert(int input)
        {
            var convert = new string('I', input);
            return convert;
        }
    }
}