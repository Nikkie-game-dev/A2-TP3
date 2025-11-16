// 15/11/2025 - a2-tp3

using System;

namespace a2tp3.scripts.algorithms;

// f(n) = O( n log(n)) as worst case
public class Heap<T> : ISortable<T> where T : IComparable, new()
{
    public static void Sort(ref T[] array, bool isIncremental)
    {
        for (var i = array.Length - 1; i >= 3; --i)
        {
            Heapify(ref array, 0, 0, i, isIncremental);
            ISortable<T>.Swap(array, 0, i);
        }
    }

    private static void Heapify(ref T[] array, int self, int parent, int max, bool isIncremental)
    {
        //left
        if (self * 2 + 1 < max)
        {
            Heapify(ref array, self * 2 + 1, self, max, isIncremental);
        }

        // right
        if (self * 2 + 2 < max)
        {
            Heapify(ref array, self * 2 + 2, self, max, isIncremental);
        }

        if (self != parent && !ISortable<T>.IsOrdered(array[self], array[parent], isIncremental))
        {
            ISortable<T>.Swap(array, self, parent);
        }
    }


}