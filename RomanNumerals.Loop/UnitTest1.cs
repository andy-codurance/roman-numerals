using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace RomanNumerals.Loop
{
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