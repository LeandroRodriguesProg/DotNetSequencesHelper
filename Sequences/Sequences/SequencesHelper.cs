using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequences
{
    public static class SequencesHelper
    {
        /// <summary>
        /// Sorts and retrieve one list with the higher sequencial numbers with size equals to the nElements parameter 
        /// </summary>
        /// <param name="values">The list of values</param>
        /// <param name="nElements">The number of elements to retrieve</param>
        /// <returns>A list of elements or null if there are no match</returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public static List<int> SortAndGetListWithBiggestSequence(List<int> values, int nElements)
        {
            if (values == null)
                throw new ArgumentNullException("The values should be not nullable");
            if (nElements <= 0)
                throw new ArgumentOutOfRangeException("The number of elements should be greather than 0");
            List<int> sortedValues = values.Distinct().OrderByDescending(x => x).ToList();
            int pos = 0;
            while ((pos + nElements - 1) < sortedValues.Count)
            {
                if (sortedValues[pos] - sortedValues[pos + nElements - 1] + 1 == nElements)
                    return sortedValues.GetRange(pos, nElements);
                pos++;
            }
            return null;

        }
        /// <summary>
        /// Sorts and check if all the values of the sorted list are sequential
        /// </summary>
        /// <param name="values">The list of values</param>
        /// <returns>True if the values are in sequence, False otherwise. Note that if you provide a empty list it will return False </returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static bool SortAndCheckAllValuesAreSequential(List<int> values)
        {
            if (values == null)
                throw new ArgumentNullException("The values should be not nullable");
            if (values.Count == 0)
                return false;
            List<int> sortedValues = values.Distinct().OrderByDescending(x => x).ToList();

            for (int i = 1; i < values.Count; i++)
            {
                if (values[i] != values[i - 1] + 1)
                    return false;
            }
            return true;
        }
    }
}
