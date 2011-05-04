using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThermoFisherScientificCodeSamples
{

    public enum BaseType
    {
        Two = 2, Eight = 8, Ten = 10, Sixteen = 16
    }

    public class BinaryTools
    {
        private static char[] _stadardChars;
        private static char[] _base64Chars;
        /// <summary>
        /// converts a decimal value into its binary representation, the simple way
        /// </summary>
        /// <param name="value">the integer: max of 1023</param>
        /// <returns>the binary integer, if error return 0</returns>
        public static int DecimalToBinary(int value)
        {
            if (value > 1023)
                return 0; //could throw an exception depending on what we are doing

            return Convert.ToInt32(Convert.ToString(value, (int)BaseType.Two));
        }

        /// <summary>
        /// convert a decimal to any base
        /// </summary>
        /// <param name="value">the decimal</param>
        /// <param name="thebase">the base</param>
        /// <returns>the converted number as a string</returns>
        public static string DecimalFromBaseType(int value, BaseType thebase)
        {
            //can use the upper here since basetype limits us to 16
             return Convert.ToString(value, (int) thebase).ToUpper();
        }

        /// <summary>
        /// custom implementation for converting decimal to binary
        /// </summary>
        /// <param name="value">the decimal</param>
        /// <returns>the binary int</returns>
        public static int DecimalToBinaryCustom(int value)
        {
            return DecimalToAnyBaseCustom(value, 2);
        }

        /// <summary>
        /// converts a decimal to a binary represented as an int, no leading zeros
        /// </summary>
        /// <param name="value">the decimal</param>
        /// <param name="thebase">the base number 1-10</param>
        /// <returns>the binary</returns>
        public static int DecimalToAnyBaseCustom(int value, int thebase )
        {
            if (thebase == 10)
                return value;

            if (thebase < 2 || thebase > 10)
                return 0;//throw new ArgumentOutOfRangeException("thebase","must be between 1 and 10"); //could return 0, depends

                //23 = 10111
                int result = 0;
                int pow = 0;

                while (value > 0)
                {
                    //  1,1,1,0,1
                    // 11,5,2,1,0
                    result += (value%thebase)*(int) Math.Pow(10, pow); //use the 10 because the result is coming back as an int
                    value /= thebase;
                    pow++;
                }
                return result;
        }

        /// <summary>
        /// convert a decimal to any base from 1-64
        /// </summary>
        /// <param name="value">the decimal</param>
        /// <param name="encodingtable">the character representing the encoding</param>
        /// <param name="padchar">if we need to fill to make even bits use this char eg; '=' for base64</param>
        /// <returns></returns>
        public static string DecimalToAnyBaseExpanded(int value, char[] encodingtable, char padchar = '=')
        {
            //assume encoding table does not have invalid characters and is set up correctly, we can overload and define our own tables, but this is time consuming for a simple exercise

            if (encodingtable.Length < 2 || encodingtable.Length > 64)
                return ""; //could throw an exception, just depends on how the library is consumed

            int count = 32; //max buffer for base 2 and int.maxvalue
            char[] buffer = new char[count];
            int thebase = encodingtable.Length;

            do
            {
                buffer[--count] = encodingtable[value%thebase];
                value /= thebase;
            } while (value > 0);

            char[] result = new char[32 - count];
            Array.Copy(buffer,count,result,0,32-count);

            return new string(result);

        }
    }
}
