using System;
using System.Collections.Generic;

namespace CSharpMilestone
{
    public static class Task
    {
        public static Dictionary<string, int> StringToDictionary(string s)
        {
            var dictionary = new Dictionary<string, int>();

            if (s.Trim().Length == 0 || s == ";")
            {
                return dictionary;
            }
            var items = s.Split(';');
            foreach (string item in items)
            {
                if (!dictionary.ContainsKey(item))
                {
                    dictionary.Add(item, 0);

                }
                dictionary[item]++;
            }
            return dictionary;
        }

        public static string GetItemWithGreatestAmount(Dictionary<string, int> dictionary)
        {
            var greatestAmount = 0;
            var itemWithGreatestAmount = "";
            foreach (var item in dictionary)
            {
                if (item.Value > greatestAmount)
                {
                    greatestAmount = item.Value;
                    itemWithGreatestAmount = item.Key;
                }
            }
            return itemWithGreatestAmount;
        }

        public static List<string> GetItemsWithAmountLesserThan(Dictionary<string, int> dictionary, int amount)
        {
            var items = new List<string>();
            foreach (var item in dictionary)
            {
                if (item.Value < amount)
                {
                    items.Add(item.Key);
                }
            }
            return items;
        }
    }
}
