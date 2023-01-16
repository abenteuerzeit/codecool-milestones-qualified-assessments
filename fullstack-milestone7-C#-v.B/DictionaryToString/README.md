# Dictionary to String

Please note, that at the moment, Qualified only supports C# 8 - features from C# 9, 10 and further are not available. If you're unsure whether given language feature is supported or not, please refer to Microsoft's changelogs:
https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9
https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10

In this challenge, you have three functions to implement. At this point, the usage of OOP (classes, instances, etc) isn't required. Due to inconvieniences of Qualified's Web IDE, you may write your code in your IDE of choice (VS, Rider) and then copy-paste it here, so that it can be tested.

1 DictionaryToString - this function receives one parameter: Dictionary<string, int>. This parameter contains a set of items (like sword, axe, etc) along with their amounts. The function should return a string, that is an inventory log, has all items written in one line, separated by just semicolons (;). Example:

For the dictionary:

{
  {"sword", 2},
  {"axe", 2},
  {"torch", 1}
}
the expected return value is "sword;sword;axe;axe;torch" (items can be in any order).

2 GetItemWithSmallestAmount - this function receives a parameter, that is a dictionary of the same format, as the parameter of the DictionaryToString function - it contains item-amount pairs. The function should return the name of the item, that has the smallest amount. If the dictionary is empty, an empty string should be returned.

3 GetItemsWithAmountGreaterThan - this function receives one parameter, that is a dictionary of the same format, as the parameter of the DictionaryToString function - it contains item-amount pairs. The function should return a List<string> of names of the items, that have greater amounts that the provided amount parameter. If no such items are found, an empty list should be returned.