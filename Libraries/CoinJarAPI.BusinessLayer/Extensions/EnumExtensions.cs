using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace CoinJarAPI.BusinessLayer.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// If it exists, gets the value in the enum's description attribute, otherwise returns the string representation of the enum.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            var attributes = value.GetAttributes<DescriptionAttribute>();
            return attributes.ElementAtOrDefault(0)?.Description ?? value.ToString();
        }

        /// <summary>
        /// Gets the list of attributes assigned to the enum.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetAttributes<T>(this Enum value) where T : Attribute
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            T[] attributes = (T[])fi.GetCustomAttributes(typeof(T), false);

            return attributes;
        }
    }
}
