# README

Different takes on the roman numerals kata

## Rules

||||||||||
---|---|---|---|---|---|---|---|---
1|2|3|4|5|6|7|8|9
I|II|III|IV|V|VI|VII|VIII|IX

||||||||||
---|---|---|---|---|---|---|---|--- 
10|20|30|40|50|60|70|80|90
X|XX|XXX|XL|L|LX|LXX|LXXX|XC

||||||||||
---|---|---|---|---|---|---|---|---
100|200|300|400|500|600|700|800|900
C|CC|CCC|CD|D|DC|DCC|DCCC|CM
 
* 'M' is the largest symbol.

* The 'base 1' symbols ('I', 'X', 'C', 'M') can be subtracted from the next highest 'base 5' symbol ('V', 'L', 'D') 
or 'base 1' symbol, but only one occurrence is allowed. The symbol cannot be prepended to a symbol that is the 
next decimal order higher. So 'IV', 'IX' is ok but 'IL' or 'IC' are not. 'XL', 'XC' is valid but XD and XM are 
not ('CD' and 'CM' are also valid).

* The symbols 'I' and 'X' can be repeated at most 3 times in a row when the symbol is being appended.

* The 'base 5' symbols 'V', 'L' and 'D' can never be repeated.

## Requirements

Build something that can convert an Arabic number, between 1 and 3999, to its roman numeral representation.

The contract should be:

`string Convert(int amount)`

## Notes

Testing seems quite random. Is it possible to codify the rules following Kelvin Henneys example
in his [Structure and Interpretation of Test Cases YouTube video](https://youtu.be/tWn8RA_DEic)

### Typical solution
Typically, most solutions enumerate over a arabic number:roman numeral map, while the input arabic number
is greater than the current key. Like this solution in JavaScript:

```JavaScript
module.exports = (number) => {

    if (typeof number !== 'number' || number < 0 || !Number.isInteger(number)) {
        throw new Error();
    }

    const numberToRomanTable = {
        1000: "M",
        900: "CM",
        500: "D",
        400: "CD",
        100: "C",
        90: "XC",
        50: "L",
        40: "XL",
        10: "X",
        9: "IX",
        5: "V",
        4: "IV",
        1: "I"
    }, keys = Object.keys(numberToRomanTable).reverse();

    let result = "";

    keys.forEach(key => {
        while (number >= key) {
            number -= key
            result += numberToRomanTable[key]
        }
    });

    return result;
}
```
(Taken from https://github.com/machi1990/num_to_rom/blob/master/numeral_to_roman.js)

### String replacement

Kevlin Henney, in the [Get Kata YouTube video](https://youtu.be/_M4o0ExLQCs?t=3166) demonstrates
a version that uses string replacement.

Scott Wlaschin also demonstrates this same method, but [in fsharp.](https://fsharpforfunandprofit.com/posts/roman-numeral-kata/)

It seems more interesting and clearer to understand.

