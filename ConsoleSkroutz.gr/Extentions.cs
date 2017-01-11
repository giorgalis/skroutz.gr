using System;
using System.Collections.Generic;

namespace ConsoleSkroutz.gr
{
    public static class Extensions
    {
        public static T printReflected<T>(this T list) where T : class
        {
            foreach (var prop in list.GetType().GetProperties())
                Console.WriteLine(string.Format("{0,-20} {1}", prop.Name, prop.GetValue(list, null)));

            Console.WriteLine();

            return list;
        }

        public static dynamic printReflected<T>(this List<T> list)
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
