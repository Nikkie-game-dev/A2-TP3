// 07/11/2025 - a2-tp3

using System;

namespace a2tp3.scripts.algorithms;

// f(n) = O(n^2) as worst case

public class Insertion<T> : ISortable<T> where T : IComparable, new()
{
    public static void Sort(ref T[] array, bool isIncremental)
    {
        if (isIncremental)
        {
            for (var i = 1; i < array.Length; i++)
            {
                var j = i - 1;
                for (; j >= 0 && array[j + 1].CompareTo(array[j]) > 0; --j)
                {
                    ISortable<T>.Swap(array, j + 1, j);
                }
            }
        }
        else
        {
            for (var i = 0; i < array.Length; i++)
            {
                var j = i - 1;
                for (; j >= 0 && array[j + 1].CompareTo(array[j]) < 0; --j)
                {
                    ISortable<T>.Swap(array, j + 1, j);
                }
            }
        }
    }
}