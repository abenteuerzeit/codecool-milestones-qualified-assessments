# Citizen

Please note, that at the moment, Qualified only supports C# 8 - features from C# 9, 10 and further are not available. If you're unsure whether given language feature is supported or not, please refer to Microsoft's changelogs:
https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9
https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10

In this challenge, your task is to write a class, that satisfies the requirements listed below. Please assure, that all your code (except for the using declarations) are within the CSharpMilestone namespace, otherwise the unit tests will not work. Pay very close attention to the naming of your classes, fields, properties and methods, as having invalid casing or typos will cause the tests to fail. Follow the standard C# coding conventions: https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions

Write a class called Citizen, that can serve as a represantation of a real-life person.

This class should have properties, that contain the following information: FirstName (citizen's first name), LastName (citizen's last name), BirthYear (citizen's year of birth), BirthCountry (the country in which the citizen was born).

There should be a constructor, that takes all of these information (in this order) as parameters and assigns the values to fields accordingly.

There should be a method called GetDisplayInfo, that receives a parameter currentCountry and then returns a string description of the citizen. Example return values:

If the currentCountry parameter is the same as BirthCountry:

Mateusz Zawistowski born in 1999 - Status: Citizen of Poland
Hideo Kojima born in 1963 - Status: Citizen of Japan

otherwise:

Mateusz Zawistowski born in 1999 - Status: Immigrant from Poland
Hideo Kojima born in 1963 - Status: Immigrant from Japan

There should be a method GetAge, which receives a parameter currentYear and returns an integer value of the citizen's age in given year.

All properties, methods and constructors (and the class itself) should be available to use by anyone - other classes, other libraries, etc.