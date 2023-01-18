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
            => meals.FirstOrDefault(m => m.Id == id) ?? throw new ArgumentException("No meal with given ID");

        /// <summary>
        ///     Return the total amount of money required to pay for all given meals
        /// </summary>
        /// <param name="meals"></param>
        /// <returns></returns>
        public static double GetTotalBill(IEnumerable<Meal> meals)
            => meals.Sum(m => m.Price);

        /// <summary>
        ///     Get the cheapest meal
        /// </summary>
        /// <param name="meals"></param>
        /// <returns></returns>
        public static Meal GetCheapestMeal(IEnumerable<Meal> meals)
            => meals.OrderBy(m => m.Price).First();

        /// <summary>
        ///     Get names of all meals of given type
        /// </summary>
        /// <param name="meals"></param>
        /// <param name="mealType"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetNamesOfMealsOfType(IEnumerable<Meal> meals, MealType mealType)
            => meals.Where(m => m.MealType == mealType).Select(m => m.Name);

        /// <summary>
        ///     Get the average value of prices of all meals of given role
        /// </summary>
        /// <param name="meals"></param>
        /// <param name="mealType"></param>
        /// <returns></returns>
        public static double GetAveragePriceOfType(IEnumerable<Meal> meals, MealType mealType)
            => meals.Where(m => m.MealType == mealType).Average(m => m.Price);

        /// <summary>
        ///     return the meal type meal that has the greatest number of meals 
        /// </summary>
        /// <param name="meals"></param>
        /// <returns></returns>
        public static MealType GetTypeWithMostMeals(IEnumerable<Meal> meals) =>
            Enum.GetValues(typeof(MealType)).Cast<MealType>()
            .ToDictionary(mt => mt, mt => meals.Count(m => m.MealType == mt))
            .OrderByDescending(kvp => kvp.Value).First().Key;

        /// <summary>
        ///     Get the most expensive diner
        /// </summary>
        /// <param name="diners"></param>
        /// <returns></returns>
        public static Diner GetMostExpensiveDiner(IEnumerable<Diner> diners)
            => diners.OrderByDescending(d => d.Meals.Sum(m => m.Price)).First();

        /// <summary>
        ///     Get the most expensive meal of given type out of all diners
        /// </summary>
        /// <param name="diners"></param>
        /// <param name="mealType"></param>
        /// <returns></returns>
        public static Meal GetMostExpensiveMealOfType(IEnumerable<Diner> diners, MealType mealType)
            => diners.SelectMany(d => d.Meals).Where(m => m.MealType == mealType).OrderByDescending(m => m.Price).FirstOrDefault();
    }
}
