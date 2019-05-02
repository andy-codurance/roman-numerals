using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace RomanNumerals.Tests
{
    /*
    
    1   2   3   4   5   6   7   8    9
    I   II  III IV  V   VI  VII VIII IX
     
    10  20  30  40  50  60  70  80   90
    X   XX  XXX XL  L   LX  LXX LXXX XC
     
    100 200 300 400 500 600 700 800  900
    C   CC  CCC CD  D   DC  DCC DCCC CM
     
    'M' is the largest symbol

    The 'base 1' symbols ('I', 'X', 'C', 'M') can be subtracted from the next highest 'base 5' symbol ('V', 'L', 'D') 
    or 'base 1' symbol, but only one occurrence is allowed. The symbol cannot be prepended to a symbol that is the 
    next decimal order higher. So 'IV', 'IX' is ok but 'IL' or 'IC' are not. 'XL', 'XC' is valid but XD and XM are 
    not ('CD' and 'CM' are also valid)

    The symbols 'I' and 'X' can be repeated at most 3 times in a row when the symbol is being appended
    
    The 'base 5' symbols 'V', 'L' and 'D' can never be repeated 
      
    */
    
    
    /*
     * The contract should be:
     *
     *    string Convert(int amount)
     *
     * Here, amount represents the Arabic number, between 1 and 3999, and the value this method returns is the string of Roman numerals.
     * 
     */
    
    public class UnitTest1
    {
        private readonly Dictionary<int, string> map = new Dictionary<int, string>
        {
            [1] = "I",
            [4] = "IV",
            [5] = "V",
            [9] = "IX",
            [10] = "X",
            [50] = "L",
            [100] = "C",
            [500] = "D",
            [1000] = "M"
        };

        private string Convert(int input)
        {
            var convert = map.TryGetValue(input, out var n) ? n : "";
            return convert;
        }

        [Theory]
        [InlineData(1, "I")]
        [InlineData(4, "IV")]
        [InlineData(5, "V")]
        [InlineData(9, "IX")]
        [InlineData(10, "X")]
        [InlineData(50, "L")]
        [InlineData(100, "C")]
        [InlineData(500, "D")]
        [InlineData(1000, "M")]
        public void Number_should_convert_to_numeral(int input, string expected)
        {
            var actual = Convert(input);

            actual.Should().Be(expected);
        }

        [Fact]
        public void Number_two_should_convert_to_numeral_II()
        {
            var input = 2;

            var s = "";
            int remainder = input;
            do
            {
                var key = map.Keys.Min(x => Math.Min(x, input));
                s += map[key];
                remainder -= key;
            } 
            while (remainder > 0);

            var actual = s;
            var expected = "II";
            
            actual.Should().Be(expected);
        }

        [Fact]
        public void Number_three_should_convert_to_numeral_III()
        {
            var input = 3;

            var s = "";
            int remainder = input;
            do
            {
                var key = map.Keys.Min(x => Math.Min(x, input));
                s += map[key];
                remainder -= key;
            } 
            while (remainder > 0);

            var actual = s;
            var expected = "III";

            actual.Should().Be(expected);
        }
    }
}