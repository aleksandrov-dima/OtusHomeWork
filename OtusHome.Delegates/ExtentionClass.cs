using System;
using System.Collections.Generic;

namespace OtusHome.Delegates
{
    public static class ExtentionClass
    {
        /// <summary>
        /// Расширение для коллекции, возвращающее максимальный элемент
        /// </summary>
        /// <param name="list"></param>
        /// <param name="orderBy"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetMax<T>(this IEnumerable<T> list, Func<T, float> orderBy)
        {
            var max = float.MinValue;
            T maxitem = default(T);
            foreach (var item in list)
            {
                var x = orderBy(item);
                if (x > max)
                {
                    max = x;
                    maxitem = item;
                }
            }

            return maxitem;
        }
    }
}