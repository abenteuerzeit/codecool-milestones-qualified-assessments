# Pets

Please note, that at the moment, Qualified only supports C# 8 - features from C# 9, 10 and further are not available. If you're unsure whether given language feature is supported or not, please refer to Microsoft's changelogs:
https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9
https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10

In this challenge, your task is to write a set of classes, that satisfy the requirements listed below. Please assure, that all your code (except for the using declarations) are within the `CSharpMilestone` namespace, otherwise the unit tests will not work. Pay very close attention to the naming of your classes, fields, properties and methods, as having invalid casing or typos will cause the tests to fail. Follow the standard C# coding conventions: https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions

By default, all classes, methods, fields, properties should be available to access by anyone (other classes, assemblies, etc), unless the requirements state otherwise.

- Write a class called `Pet`, that will serve as a base for all pet types implemented later. This class should contain two string auto-properties: `Name` and `Breed`, that can only be accessed by this class and its deriving classes. This class can't be instantiated. There should be a string method `GetPetSound`, that at this point shouldn't be implemented (but every deriving class must implement it). For every pet class, `GetPetSound` should return the word that represents the sound given pet makes. There should also be a similar method, Feed, that returns an `enum PetFeedingStatus` and receives parameters: `PetFood food`, `int amount`.
- There also should be a method, called `GetDescription`, which returns a description of given pet as a string . Examples of expected return values:

    ```code
    This is a Husky called Zeus, which makes a sound: Woof
    This is a Siamese called Fluffy, which makes a sound: Meow
    ```

1. First child class of `Pet` should be `Dog`, which represents a dog. Dogs make a "Woof" sound and only eat meat - and require at least 5 pieces to be full.
2. Next child class should be `Cat`, which represents a cat. Cats make a Meow sound and only eat meat. They'll be hungry unless given 2 pieces of it.
3. Next child class should be `Parrot`, which represents a parrot. Parrots make a "Squawk" sound and eat both grain and meat. In order to be well fed, a parrot needs to eat either 4 pieces of grain, or 2 pieces of meat.
4. The last pet class should be a `TalkingParrot`, which derives from `Parrot`. Their behaviour differs a bit from regular parrots - since they can talk, the sound they make is Hello, and they don't like meat (the rest of feeding rules are the same as for a regular parrot). Also, since a `TalkingParrot` is already a subgroup of Parrot, please assure that TalkingParrot class cannot be inherited.

The base class `Pet` should define a constructor, which receives name and breed as the parameters. This constructor should be protected at the level of the abstract class, and then public in all of the inheriting classes.
