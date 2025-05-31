using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MauiApp1
{
    public static class IEnumerableExtensions
    {
        public static string JoinToString<T>(this IEnumerable<T> collection, char separator = ' ')
        {
            const int ENTRY_LENGTH = 8;
            StringBuilder result = new(ENTRY_LENGTH * collection.Count());
            foreach (var item in collection)
            {
                result.Append(item);
                result.Append(separator);
            }
            return result.ToString();
        }
    }
}