using System;
using System.Collections.Generic;

namespace CSharpMilestone
{
    public static class Task
    {
        /*
        1 StringToDictionary - this function receives one parameter: string s. 
        This parameter contains a sequence of items (like sword, axe, etc) that are separated by semicolons (;). 
        The function should return a Dictionary<string, int>, which contains the information on all items in the string, 
        with their amounts. Example:
                for string sword;axe;torch;axe;sword the expected return value is:
                {
                    {"sword", 2},
                    {"axe", 2},
                    {"torch", 1}
                }
        */ 
        public static Dictionary<string, int> StringToDictionary(string s)
        {
            if (s == ";")
            {
                return new Dictionary<string, int>();
            }

            if (s.Trim().Length == 0)
            {
                return new Dictionary<string, int>();
            }

            var splitString = s.Split(';');
            var dictionary = new Dictionary<string, int>();
            
            foreach (var item in splitString)
            {
                Console.WriteLine(item);
                if (dictionary.ContainsKey(item))
                {
                    dictionary[item]++;
                }
                else
                {
                    dictionary.Add(item, value: 1);
                }
            }
            return dictionary;
        }


        /*
        2 GetItemWithGreatestAmount - this function receives a parameter, 
        that is a dictionary of the same format, 
        as the result of the StringToDictionary function - 
        it contains item-amount pairs. 
        The function should return the name of the item, 
        that has the greatest amount. 
        If the dictionary is empty, an empty string should be returned.
        */
        public static string GetItemWithGreatestAmount(Dictionary<string, int> dictionary)
        {
            if (dictionary.Count == 0)
            {
                return "";
            }

            int greatestAmount = 0;
            string greatestItem = "";
            foreach (var item in dictionary)
            {
                if (item.Value > greatestAmount)
                {
                    greatestAmount = item.Value;
                    greatestItem = item.Key;
                }
            }
            return greatestItem;
        }

        /*
        3 GetItemsWithAmountLesserThan - this function receives one parameter, that is a dictionary of the same format, as the result of the StringToDictionary function - it contains item-amount pairs. The function should return a List<string> of names of the items, that have lesser amounts that the provided amount parameter. If no such items are found, an empty list should be returned.
        */
        public static List<string> GetItemsWithAmountLesserThan(Dictionary<string, int> dictionary, int amount)
        {
            var list = new List<string>();
            foreach (var item in dictionary)
            {
                if (item.Value < amount)
                {
                    list.Add(item.Key);
                }
            }
            return list;
        }
    }
}
