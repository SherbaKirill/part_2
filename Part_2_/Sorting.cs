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
            // NOTE: do not use LINQ
            // TODO: implement here
            throw new NotImplementedException();
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
            // NOTE: do not use LINQ
            // TODO: implement here
            throw new NotImplementedException();
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
            // NOTE: do not use LINQ
            // TODO: implement here
            throw new NotImplementedException();
        }
    }
}
