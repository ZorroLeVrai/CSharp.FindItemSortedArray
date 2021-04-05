using System;

namespace FindItemSortedArray
{
    /// <summary>
    /// The aim of this class is to find an element in a sorted array
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class ItemFinder<T> where T : IComparable
    {
        //sorted array
        private T[] _sortedData;

        /// <summary>
        /// constructor taking the sorted array
        /// </summary>
        /// <param name="sortedArray"></param>
        internal ItemFinder(T[] sortedArray)
        {
            _sortedData = sortedArray;
        }

        /// <summary>
        /// Try to find item in the sorted array
        /// </summary>
        /// <param name="item">item to find</param>
        /// <returns>a value tuple (isFound, position)
        /// isFound: true if the item is found, false otherwise
        /// position: index of the item found. If not found returns 0
        /// </returns>
        internal (bool, int) FindItem(T item)
        {
            var isFound = false;
            var position = -1;

            if (null == _sortedData || _sortedData.Length == 0)
                return (isFound, position);

            return FindItemInRange(0, _sortedData.Length - 1);

            (bool, int) FindItemInRange(int minIndex, int maxIndex)
            {
                switch(maxIndex - minIndex)
                {
                    case 0:
                        if (item.Equals(_sortedData[minIndex]))
                            return (true, minIndex);
                        return (false, -1);
                    case 1:
                        if (item.Equals(_sortedData[minIndex]))
                            return (true, minIndex);
                        if (item.Equals(_sortedData[maxIndex]))
                            return (true, maxIndex);
                        return (false, -1);
                    default:
                        var newIndex = (minIndex + maxIndex) / 2;
                        var compareResult = item.CompareTo(_sortedData[newIndex]);
                        if (compareResult == 0)
                            return (true, newIndex);
                        if (compareResult < 0)
                            return FindItemInRange(minIndex, newIndex - 1);

                        return FindItemInRange(newIndex + 1, maxIndex);
                }
            }
        }
    }
}
