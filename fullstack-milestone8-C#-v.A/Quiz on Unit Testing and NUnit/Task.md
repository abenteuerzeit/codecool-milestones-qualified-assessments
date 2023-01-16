# Testing

1. **What is Unit Testing?**

    a. It's a software design pattern
    b. It's a programming paradigm
    **&rarr; It's a software testing technique**
    d. It's a software development framework

2. **What does TDD stand for?**

    **&rarr; Test Driven Design**
    b. Test Driven Development
    c. Test Data Domain
    d. Test Data Development

3. **What is NUnit?**
    a. It's a programming language for writing unit tests
    b. It's a C# framework for writing unit tests
    **&rarr; It's a language-agnostic framework for writing unit tests**
    d. It's a visual tool for testing software

4. **What is the `[TestFixture]` attribute used for?**
    **&rarr; It's used for marking classes containing tests**
    b. It's used for marking test methods
    c. It's used for marking classes, that will be tested
    d. It's used for marking methods, that will be tested

5. **What is the `[Test]` attribute used for?**
    a. It's used for marking classes containing tests
    b. It's used for marking test methods
    c. It's used for marking classes, that will be tested
    **&rarr; It's used for marking methods, that will be tested**

6. **What is the `[TestCase]` attribute used for?**
    a. It's used for marking test methods
    b. It's used for marking methods, that will be tested
    c. It's used for defining multiple usages of the same test class, but with different parameters
    **&rarr; It's used for defining multiple usages of the same test method, but with different parameters**

7. **What is the `[SetUp]` attribute used for?**
    a. It's used for marking the test class's constructor
    b. It's used for marking the tested class's constructor
    c. It's used for marking a method that executes before running the tests
    **&rarr; It's used for marking a method that executes before each test is run**

8. **What is the `[TearDown]` attribute used for?**
    a. It's used for marking the test class's destructor
    **&rarr; It's used for marking the tested class's destructor**
    c. It's used for marking a method that executes after each test is run
    d. It's used for marking a method that executes after all tests have been run

9. **Which one is NOT a valid test outcome?**
    a. Ignored
    b. Skipped
    c. Inconclusive
    **&rarr; Unsupported**

10. You have two `List<int>` objects: `expectedList` and `actualList`. You want to test whether the two lists contain the same elements, regardless of their order.

**Which testing method you should use?**
    a. `Assert.AreEqual(expectedList, actualList)`
    b. `Assert.AreSame(expectedList, actualList)`
    c. `CollectionAssert.AreEqual(expectedList, actualList)`
    **&rarr; `CollectionAssert.AreEquivalent(expectedList, actualList)`**
