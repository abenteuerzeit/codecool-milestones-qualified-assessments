using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpMilestone
{
    public enum MealType
    {
        Entree,
        Paroisee,
        PlatPrincipal,
        Dessert
    }

    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MealType MealType { get; set; }
        public double Price { get; set; }

        public Meal(int id, string name, MealType mealType, double price)
        {
            Id = id;
            Name = name;
            MealType = mealType;
            Price = price;
        }
    }

    public class Diner
    {
        public int Id { get; set; }
        public Meal[] Meals { get; set; }
    }

    public static class LinqMethods
    {
        /// <summary>
        ///     Get the meal with given ID
        /// </summary>
        /// <param name="meals"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Meal GetMealById(IEnumerable<Meal> meals, int id)
            => meals.FirstOrDefault(x => x.Id == id);

        /// <summary>
        ///     Return the total amount of money required to pay for all given meals
        /// </summary>
        /// <param name="meals"></param>
        /// <returns></returns>
        public static double GetTotalBill(IEnumerable<Meal> meals)
            => meals.Sum(x => x.Price);

        /// <summary>
        ///     Get the cheapest meal
        /// </summary>
        /// <param name="meals"></param>
        /// <returns></returns>
        public static Meal GetCheapestMeal(IEnumerable<Meal> meals)
            => meals.OrderBy(x => x.Price).FirstOrDefault();

        /// <summary>
        ///     Get names of all meals of given type
        /// </summary>
        /// <param name="meals"></param>
        /// <param name="mealType"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetNamesOfMealsOfType(IEnumerable<Meal> meals, MealType mealType)
            => meals.Where(x => x.MealType == mealType).Select(x => x.Name);

        /// <summary>
        ///     Get the average value of prices of all meals of given role
        /// </summary>
        /// <param name="meals"></param>
        /// <param name="mealType"></param>
        /// <returns></returns>
        public static double GetAveragePriceOfType(IEnumerable<Meal> meals, MealType mealType)
            => meals.Where(x => x.MealType == mealType).Average(x => x.Price);

        /// <summary>
        ///     Get the meal type that has most meals
        /// </summary>
        /// <param name="meals"></param>
        /// <returns></returns>
        public static MealType GetTypeWithMostMeals(IEnumerable<Meal> meals)
            => Enum.GetValues(typeof(MealType)).Cast<MealType>().OrderByDescending(x => meals.Count(y => y.MealType == x)).FirstOrDefault();

        /// <summary>
        ///     Get the most expensive diner
        /// </summary>
        /// <param name="diners"></param>
        /// <returns></returns>
        public static Diner GetMostExpensiveDiner(IEnumerable<Diner> diners)
            => diners.OrderBy(x => x.Meals).FirstOrDefault();

        /// <summary>
        ///     Get the most expensive meal of given type out of all diners
        /// </summary>
        /// <param name="diners"></param>
        /// <param name="mealType"></param>
        /// <returns></returns>
        public static Meal GetMostExpensiveMealOfType(IEnumerable<Diner> diners, MealType mealType)
            => diners.SelectMany(x => x.Meals).Where(y => y.MealType == mealType).OrderByDescending(y => y.Price).FirstOrDefault();
    }
}
