# README

Different takes on the roman numerals kata

## Information

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

## Rules

Build something that can convert an Arabic number, between 1 and 3999, to its roman numeral representation.

The contract should be:

`string Convert(int amount)`