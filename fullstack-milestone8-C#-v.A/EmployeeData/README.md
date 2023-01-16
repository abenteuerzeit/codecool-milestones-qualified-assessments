Employee Data
Please note, that at the moment, Qualified only supports C# 8 - features from C# 9, 10 and further are not available. If you're unsure whether given language feature is supported or not, please refer to Microsoft's changelogs:
https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9
https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10

In this challenge, your task is to implement 8 methods in the LinqMethods class with use of LINQ. Pay very close attention to the naming of your classes, fields, properties and methods, as having invalid casing or typos will cause the tests to fail. Follow the standard C# coding conventions: https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions

Requiremenets:

Do not modify the already existing classes or the method definitions themselves, otherwise the unit tests will not work.
You will find an explanation of the expected result of each methods in their summary comments, above the method definitions.
Throughout the entirety of this task, you must only use LINQ methods and lambda expressions for quering, filtering and sorting the data. Use of loops (while, do-while, for, foreach) and conditionals (if, else, else if, switch) is forbidden.
All methods are defined as expression-body methods and must remain as such. Therefore, when implementing your code, don't use brackets or the return keyword. Keep in mind, that LINQ methods can be chained, one after another, thus allowing you to keep the entire logic in one expression. Here's an example:
Statement-body method (DON'T USE):

public static int CountSpecialEmployees(IEnumerable<Employee> employees)
{
  return employees.GetSpecialEmployees().Count();
}
Expression-body method (USE):

public static int CountSpecialEmployees(IEnumerable<Employee> employees)
  => employees.GetSpecialEmployees().Count();