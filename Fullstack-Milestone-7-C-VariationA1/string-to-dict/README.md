# String to Dictionary

Please note, that at the moment, Qualified only supports C# 8 - features from C# 9, 10 and further are not available. If you're unsure whether given language feature is supported or not, please refer to Microsoft's changelogs:
https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9
https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10

In this challenge, you have three functions to implement. At this point, the usage of OOP (classes, instances, etc) isn't required. Due to inconvieniences of Qualified's Web IDE, you may write your code in your IDE of choice (VS, Rider) and then copy-paste it here, so that it can be tested.

1 StringToDictionary - this function receives one parameter: string s. This parameter contains a sequence of items (like sword, axe, etc) that are separated by semicolons (;). The function should return a Dictionary<string, int>, which contains the information on all items in the string, with their amounts. Example:

for string sword;axe;torch;axe;sword the expected return value is:

{
  {"sword", 2},
  {"axe", 2},
  {"torch", 1}
}
2 GetItemWithGreatestAmount - this function receives a parameter, that is a dictionary of the same format, as the result of the StringToDictionary function - it contains item-amount pairs. The function should return the name of the item, that has the greatest amount. If the dictionary is empty, an empty string should be returned.

3 GetItemsWithAmountLesserThan - this function receives one parameter, that is a dictionary of the same format, as the result of the StringToDictionary function - it contains item-amount pairs. The function should return a List<string> of names of the items, that have lesser amounts that the provided amount parameter. If no such items are found, an empty list should be returned.
