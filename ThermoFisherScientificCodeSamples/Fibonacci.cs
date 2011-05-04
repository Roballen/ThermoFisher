using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThermoFisherScientificCodeSamples
{
    public class Fibonacci
    {
        public static int[] _fibsequence = new int[3]{0,1,1};
        
        public static int[] GetFibonacci(int max)
        {
            while (_fibsequence[_fibsequence.Length - 1] < max && _fibsequence[_fibsequence.Length - 1] + _fibsequence[_fibsequence.Length - 2] < int.MaxValue && (_fibsequence[_fibsequence.Length - 1] + _fibsequence[_fibsequence.Length - 2]) > 0)
            {
                Array.Resize(ref _fibsequence, _fibsequence.Length + 1);
                _fibsequence[_fibsequence.Length - 1] = _fibsequence[_fibsequence.Length - 2] + _fibsequence[_fibsequence.Length - 3];
            }

            return GetNumbersFromSequence(max);
        }

        private static int[] GetNumbersFromSequence(int max)
        {
            int[] resultset;
            int idx = Array.BinarySearch(_fibsequence, max);
            if (idx >= 0)
            {
                if (_fibsequence[idx+1] == max) //handle the one, behaves different when the sequence is already cached and is hard to hit this block unless unit test is ran individually
                    idx++;
                resultset = new int[idx + 1];
                Array.Copy(_fibsequence, resultset, idx + 1);
            }
            else
            {
                resultset = new int[~idx];
                Array.Copy(_fibsequence, resultset, (~idx));
            }
            return resultset;
        }
    }
}
