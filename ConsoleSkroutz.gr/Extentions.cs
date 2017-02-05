// ***********************************************************************
// Assembly         : ConsoleSkroutz.gr
// Author           : giorgalis
// Created          : 01-11-2017
//
// Last Modified By : giorgalis
// Last Modified On : 01-14-2017
// ***********************************************************************
// <copyright file="Extentions.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;

namespace ConsoleSkroutz.gr
{
    /// <summary>
    /// Class Extensions.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Prints the reflected.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <returns>T.</returns>
        public static T printReflected<T>(this T item) where T : class
        {
            if (item == null) throw new NullReferenceException(nameof(item));
            
            foreach (var prop in item.GetType().GetProperties())
                Console.WriteLine(string.Format("{0,-20} {1}", prop.Name, prop.GetValue(item, null)));

            Console.WriteLine();

            return item;
        }

        /// <summary>
        /// Prints the reflected.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <returns>List&lt;T&gt;.</returns>
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
