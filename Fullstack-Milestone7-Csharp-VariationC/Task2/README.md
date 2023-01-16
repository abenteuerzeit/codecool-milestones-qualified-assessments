Book
Please note, that at the moment, Qualified only supports C# 8 - features from C# 9, 10 and further are not available. If you're unsure whether given language feature is supported or not, please refer to Microsoft's changelogs:
https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9
https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10

In this challenge, your task is to write a class, that satisfies the requirements listed below. Please assure, that all your code (except for the using declarations) are within the CSharpMilestone namespace, otherwise the unit tests will not work. Pay very close attention to the naming of your classes, fields, properties and methods, as having invalid casing or typos will cause the tests to fail. Follow the standard C# coding conventions: https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions

Write a class called Book, that can serve as a representation of a real-life book.

This class should have auto-properties, that contain the following information: Title (the book's title), Author (the book's author's name), Pages (the amount of pages this book has), StarRating (the amount of star points this book has received in an online rating).

There should be a constructor, that takes all of these information (in this order) as parameters and assigns the values to fields accordingly.

There should be a method called GetDisplayInfo, that returns a string description of the book. Example return values:

Game of Thrones by George R. R. Martin - 800 pages - Rating: *****
Surrounded by Idiots by Thomas Erikson - 300 pages - Rating: ***

There should be a method called GetReadTime, that receives a parameter int pagesPerMinute, that represents a reading pace, and then returns a double value of time required to read this book (in minutes).

All properties, methods and constructors (and the class itself) should be available to use by anyone - other classes, other libraries, etc.