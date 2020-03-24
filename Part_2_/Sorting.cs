using System;

namespace Part_2
{
    public static class Sorting
    {
        /// <summary>
        /// Order.
        /// Example: [3, 1, 4] => [1, 3, 4] 
        /// </summary>
        /// <typeparam name="T">Data type</typeparam>
        /// <param name="collection">Collection to sort</param>
        /// <returns>Ordered collection</returns>
        public static T[] Order<T>(T[] collection)
            where T : IComparable<T>, IComparable
        {
            Array.Sort(collection);
            return collection;
        }
        /// <summary>
        /// Order by descending.
        /// Example: [3, 1, 4] => [4, 3, 1] 
        /// </summary>
        /// <typeparam name="T">Data type</typeparam>
        /// <param name="collection">Collection to sort</param>
        /// <returns>Ordered collection</returns>
        public static T[] DescendingOrder<T>(T[] collection)
            where T : IComparable<T>, IComparable
        {
            Array.Sort(collection);
            Array.Reverse(collection);
            return collection;
        }
        /// <summary>
        /// Find unique collection elements.
        /// Example: [3, 1, 1, 4, 3, 3, 1, 4] => [3, 1, 4] 
        /// </summary>
        /// <typeparam name="T">Data type</typeparam>
        /// <param name="collection">Collection to sort</param>
        /// <returns>Ordered collection</returns>
        public static T[] Unique<T>(T[] collection)
        {
            T[] result = new T[0];
            foreach (T element in collection)
                if (Array.IndexOf(result, element) == -1)
                {
                    Array.Resize(ref result, result.Length + 1);
                    result.SetValue(element, result.Length - 1);                    
                }
            return result;
        }
    }
}
