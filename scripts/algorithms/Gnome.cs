// 16/11/2025 - a2-tp3

using System;

namespace a2tp3.scripts.algorithms;

// f(n) = O(n^2) as worst case
public class Gnome<T> : ISortable<T> where T : IComparable, new()
{
    public static void Sort(ref T[] array, bool isIncremental)
    {
        var i = 1;
        while (i < array.Length)
        {
            if (i < 1 || ISortable<T>.IsOrdered(array[i - 1], array[i], isIncremental))
            {
                i++;
            }
            else
            {
                ISortable<T>.Swap(array, i, i - 1);
                i--;
            }
        }
    }
}