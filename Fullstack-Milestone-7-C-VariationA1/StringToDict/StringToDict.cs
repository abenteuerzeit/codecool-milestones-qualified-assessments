using System.Collections.Generic;
using System.Linq;

namespace CSharpMilestone
{
    public static class ItemFunctions
    {
        public static Dictionary<string, int> StringToDictionary(string s) => 
            s.Split(';')
            .GroupBy(i => i)
            .ToDictionary(g => g.Key, g => g.Count());

        public static string GetItemWithGreatestAmount(Dictionary<string, int> itemDictionary) =>
            itemDictionary.Count == 0 ? "" : itemDictionary.OrderByDescending(i => i.Value).First().Key;

        public static List<string> GetItemsWithAmountLesserThan(Dictionary<string, int> itemDictionary, int amount) =>
            itemDictionary.Where(i => i.Value < amount).Select(i => i.Key).ToList();
    }
}
