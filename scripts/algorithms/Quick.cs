// 17/10/2025 - a2-tp3

using System;

namespace a2tp3.scripts.algorithms;
// f(n) = O(n^2) as worst case
public class Quick<T> : ISortable<T> where T : IComparable, new()
{
    public static void Sort(ref T[] array, bool isIncremental)
    {
        Sort(ref array, isIncremental, 0, array.Length - 1);
    }

    private static void Sort(ref T[] array, bool isIncremental, int start, int end)
    {
        if (start >= end) return;
        
        LemutoPart(array, isIncremental, out var pivotPos, start, end);
        
        Sort(ref array, isIncremental, start, pivotPos - 1);
        Sort(ref array, isIncremental, pivotPos + 1, end);
    }

    private static void LemutoPart(T[] array, bool isIncremental, out int pivotPos,in int start, in int end)
    {
        var j = start - 1;
        for (var i = start; i < end; i++)
        {
            if (ISortable<T>.IsOrdered(array[end], array[i], isIncremental)) continue;

            j++;
            ISortable<T>.Swap(array, i, j);
        }

        ISortable<T>.Swap(array, end, j + 1);

        pivotPos = j + 1;
    }
}