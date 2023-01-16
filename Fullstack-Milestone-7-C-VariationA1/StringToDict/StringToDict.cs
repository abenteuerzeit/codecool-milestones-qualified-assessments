using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpMilestone
{
    public static class StringToDictionaryChallenge
    {
        public static Dictionary<string, int> StringToDictionary(string s)
        {
            var items = s.Split(';');
            var itemDictionary = new Dictionary<string, int>();

            foreach (var item in items)
            {
                if (itemDictionary.ContainsKey(item))
                {
                    itemDictionary[item]++;
                }
                else
                {
                    itemDictionary.Add(item, 1);
                }
            }
            return itemDictionary;
        }

        public static string GetItemWithGreatestAmount(Dictionary<string, int> itemDictionary)
        {
            if (itemDictionary.Count == 0)
            {
                return "";
            }
            var maxItem = itemDictionary.First();
            foreach (var item in itemDictionary)
            {
                if (item.Value > maxItem.Value)
                {
                    maxItem = item;
                }
            }
            return maxItem.Key;
        }

        public static List<string> GetItemsWithAmountLesserThan(Dictionary<string, int> itemDictionary, int amount)
        {
            var result = new List<string>();
            foreach (var item in itemDictionary)
            {
                if (item.Value < amount)
                {
                    result.Add(item.Key);
                }
            }
            return result;
        }
    }
}
