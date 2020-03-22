using System;

namespace Part_2
{
    public static class Sorting
    {
        public static T[] Order<T>(T[] collection)
            where T : IComparable<T>, IComparable
        {
            Array.Sort(collection);
            return collection;
        }

        public static T[] DescendingOrder<T>(T[] collection)
            where T : IComparable<T>, IComparable
        {
            Array.Sort(collection);
            Array.Reverse(collection);
            return collection;
        }

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
