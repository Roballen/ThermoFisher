using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThermoFisherScientificCodeSamples
{
    public class Examples
    {
        //Write a function string RemoveSpaces(string value) that removes all space characters from a given string.
        //You can’t use the string API and should process the string on your own.

        /// <summary>
        /// Will remove all spaces from a given string without using the string API and I must process the string on my own.
        /// uses a char array and for loop rather than string builder and a foreach loop, unsure of the performance hit with Array.Resize, it seems unecessary
        /// </summary>
        /// <param name="value">a string with potential spaces</param>
        /// <returns>a string without spaces</returns>
        public static string RemoveSpaces(string value)
        {
            if (value == null)
                return null;

            char[] array = null;
            
            for(int x = 0; x < value.Length; x++) //is length part of the string api?
            {
                if (value[x] != ' ')
                {
                    if (array == null)
                        array = new char[1];
                    else
                        Array.Resize(ref array, array.Length + 1);

                    array[array.Length -1] = value[x];
                }
            }
            return new string(array);
        }

        /// <summary>
        /// Will remove all spaces from a given string without using the string API and I must process the string on my own.
        /// uses a for loop but replaces the char array with a stringbuilder
        /// </summary>
        /// <param name="value">a string with potential spaces</param>
        /// <returns>a string without spaces</returns>
        public static string RemoveSpacesStringBuilder(string value)
        {
            if (value == null)
                return null;

            var sb = new StringBuilder();

            for (int x = 0; x < value.Length; x++) //is length part of the string api?
            {
                if (value[x] != ' ')
                    sb.Append(value[x]);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Will remove all spaces from a given string without using the string API and I must process the string on my own.
        /// uses a foreach loop and a stringbuilder
        /// </summary>
        /// <param name="value">a string with potential spaces</param>
        /// <returns>a string without spaces</returns>
        public static string RemoveSpacesStringbuilderForeach(string value)
        {
            if (value == null)
                return null;

            var sb = new StringBuilder(value.Length);

            foreach (char c in value)
            {
                if (c != ' ')
                    sb.Append(c);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Will remove all spaces from a given string without using the string API and I must process the string on my own.
        /// uses linq
        /// </summary>
        /// <param name="value">a string with potential spaces</param>
        /// <returns>a string without spaces</returns>
        public static string RemoveSpacesLinq(string value)
        {
            if (value == null)
                return null;

            return new string((from c in value where c != ' ' select c).ToArray());
        }

        /// <summary>
        /// will remove all spaces fron the given string.  testing a custom replace, do not expect to be fast than original
        /// </summary>
        /// <param name="value">the string</param>
        /// <returns>a string without spaces</returns>
        public static string RemoveSpacesCustomReplace(string value)
        {
            return FastReplace(value, " ", "", StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Fasts the replace.
        /// </summary>
        /// <param name="original">The original.</param>
        /// <param name="pattern">The pattern.</param>
        /// <param name="replacement">The replacement.</param>
        /// <param name="comparisonType">Type of the comparison.</param>
        /// <returns></returns>
        public static string FastReplace(string original,string pattern, string replacement,
                                         StringComparison comparisonType)
        {
            if (original == null)
                return null;

            if (String.IsNullOrEmpty(pattern))
                return original;

            int lenPattern = pattern.Length;
            int idxPattern = -1;
            int idxLast = 0;

            StringBuilder result = new StringBuilder();

            while (true)
            {
                idxPattern = original.IndexOf(pattern, idxPattern + 1, comparisonType);

                if (idxPattern < 0)
                {
                    result.Append(original, idxLast, original.Length - idxLast);
                    break;
                }

                result.Append(original, idxLast, idxPattern - idxLast);
                result.Append(replacement);

                idxLast = idxPattern + lenPattern;
            }

            return result.ToString();
        }
    }
}
