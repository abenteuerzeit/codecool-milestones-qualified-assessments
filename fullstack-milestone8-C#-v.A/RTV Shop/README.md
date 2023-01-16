# RTV Shop

Please note, that at the moment, Qualified only supports C# 8 - features from C# 9, 10 and further are not available. If you're unsure whether given language feature is supported or not, please refer to Microsoft's changelogs:
https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9
https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10

In this challenge, your task is to implement a Data Access Layer for an online RTV shop. The shop sells TVs, soundbars and cables and its backend should allow accessing and filtering these items. The selected architecture is DAO (Data Access Object).
Please assure, that all your code (except for the using declarations) are within the CSharpMilestone namespace, otherwise the unit tests will not work. Pay very close attention to the naming of your classes, fields, properties and methods, as having invalid casing or typos will cause the tests to fail. Follow the standard C# coding conventions: https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions
By default, all classes, methods, fields, properties should be available to access by anyone (other classes, assemblies, etc), unless the requirements state otherwise.

IDAO interface requirements:

Implement a generic interface IDAO which will serve as a template for all Data Access Objects.
IDAO should only be allowed to use with Item objects or its derived classes. In the requirements below, all mentions of "object" or "collection" refer to given DAO's target type.
IDAO should define the following CRUD methods:
Seed - takes an IEnumerable collection to initialize the database. Doesn't return anything.
Create - accepts an object that is then added to the collection (unless it's already in it). Returns a bool value, whether the object has been successfully added to the database.
Read - accepts an int id that is used to search for an object in the database, and then returns it. If not found, should return null.
ReadAll - returns an IEnumerable collection of all objects in the database.
Update - accepts an object that is supposed to replace an object already existing in the database, that has the same id. Returns a bool value, whether the object has been successfully updated in the database.
Delete - accepts an int id that is used to search for an object in the database and then deleted from it. Returns a bool value, whether the object has been successfully deleted from the database.
ITVDAO interface requirements:

Implement an interface ITVDAO which will serve as a base of a DAO, that supplies TV items.
ITVDAO should inherit from IDAO<TV>
ITVDAO should define a method GetTVs, that returns an IEnumerable collection of TVs after filtering them with the following criteria (in this order): minimum size (int), maximum size (int), screen type (ScreenType) and minimum resolution (int).
ISoundbarDAO interface requirements:

Implement an interface ISoundbarDAO which will serve as a base of a DAO, that supplies soundbar items.
ISoundbarDAO should inherit from IDAO<Soundbar>
ISoundbarDAO should define a method GetSoundbars, that return an IEnumerable collection of soundbars after filtering then with the following criteria (in this order): minimum channels (int), maximum channels (int), has subwoofer (bool).
DAO fake database classes:

Create two DAO classes, that will simulate a database behaviour with use of a HashSet (which must be encapsulated from external access, therefore set as private, and initialized as empty upon instantiation of the class).
TVDAO should implement the ITVDAO interface
SoundbarDAO should implement the ISoundbarDAO interface
Implement all interface methods in all classes, according to the logic descriptions above.