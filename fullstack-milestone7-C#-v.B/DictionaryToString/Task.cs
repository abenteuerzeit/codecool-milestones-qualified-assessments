using System.Collections.Generic;
using System.Linq;

namespace CSharpMilestone
{
    public static class Task
    {
        public static string DictionaryToString(Dictionary<string, int> dictionary)
        {
            var res = "";
            foreach(var e in dictionary)
            {
             for (int i = 0; i < e.Value; i++ )
             {
             res += $"{e.Key};";
             }
            }
            return res;
        }

        public static string GetItemWithSmallestAmount(Dictionary<string, int> dictionary)
        {
        if (dictionary.Count == 0)
        {
         return "";
        }
        return dictionary.OrderBy(x => x.Value).FirstOrDefault().Key;

        }

        public static List<string> GetItemsWithAmountGreaterThan(Dictionary<string, int> dictionary, int amount)
        {
        var list = new List<string>();
        foreach(var e in dictionary)
        {
        if (e.Value > amount)
        {
        list.Add(e.Key);
        }
        }
        return list;
        }
    }
}