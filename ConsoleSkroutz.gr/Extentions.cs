using System;
using System.Collections.Generic;

namespace ConsoleSkroutz.gr
{
    public static class Extensions
    {
        public static T printReflected<T>(this T item) where T : class
        {
            foreach (var prop in item.GetType().GetProperties())
                Console.WriteLine(string.Format("{0,-20} {1}", prop.Name, prop.GetValue(item, null)));

            Console.WriteLine();

            return item;
        }

        public static List<T> printReflected<T>(this List<T> list) where T : class
        {
            foreach (var v in list)
            {
                foreach (var prop in v.GetType().GetProperties())
                    Console.WriteLine(string.Format("{0,-20} {1}", prop.Name, prop.GetValue(v, null)));

                Console.WriteLine();
            }
            return list;
        }
    }
}
