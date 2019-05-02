using System.Text;
using FluentAssertions;
using Xunit;

namespace RomanNumerals.StringReplace
{
    public class UnitTest1
    {
        private const string TenI  = "IIIIIIIIII";
        private const string NineI = "IIIIIIIII";
        private const string FiveI = "IIIII";
        private const string FourI = "IIII";
        private const string FiveX = "XXXXX";
        private const string FourX = "XXXX";

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
        [InlineData(41, "XLI")]
        [InlineData(42, "XLII")]
        [InlineData(43, "XLIII")]
        [InlineData(44, "XLIV")]
        [InlineData(45, "XLV")]
        [InlineData(46, "XLVI")]
        [InlineData(48, "XLVIII")]
        [InlineData(49, "XLIX")]
        [InlineData(50, "L")]
        [InlineData(51, "LI")]
        [InlineData(52, "LII")]
        [InlineData(53, "LIII")]
        [InlineData(54, "LIV")]
        [InlineData(55, "LV")]
        [InlineData(56, "LVI")]
        [InlineData(57, "LVII")]
        [InlineData(58, "LVIII")]
        [InlineData(59, "LIX")]
        [InlineData(60, "LX")]
        public void Number_should_convert_to_expected_numeral(int input, string expected)
        {
            // TODO - this is getting unmanageable - how can I be sure I don't miss a case?
            // I need to codify the rules as tests.
            var actual = Convert(input);

            actual.Should().Be(expected);
        }

        private static string Convert(int input)
        {
            var convert = new StringBuilder()
                .Append('I', input)
                .Replace(TenI, "X")
                .Replace(NineI, "IX")
                .Replace(FiveI, "V")
                .Replace(FourI, "IV")
                .Replace(FiveX, "L")
                .Replace(FourX, "XL")
                .ToString();
            return convert;
        }
    }
}