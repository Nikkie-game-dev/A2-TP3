// 07/11/2025 - a2-tp3

using System;
using Godot;

namespace a2tp3.scripts.algorithms;
// f(n) = O(n!) as worst case
public class Bogo<T> : ISortable<T> where T : IComparable, new()
{
    public static void Sort(ref T[] array, bool isIncremental)
    {
        //while (IsOrdered(array, isIncremental))
        {
            for (var i = 0; i < array.Length; i++)
            {
                ISortable<T>.Swap(array, i, GD.RandRange(0, array.Length - 1));
            }
        }
    }

    private bool IsOrdered(in T[] array, bool isIncremental)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            if ((isIncremental && array[i].CompareTo(array[i + 1]) < 0) || (!isIncremental && array[i].CompareTo(array[i + 1]) > 0))
            {
                return false;
            }
        }

        return true;
    }
}