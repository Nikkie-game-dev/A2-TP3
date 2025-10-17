// 17/10/2025 - a2-tp3

using System;

namespace a2tp3.scripts.algorithms;

// Because it's a double linear loop: O(n^2)
public class Bubble<T> : ISortable<T> where T : IComparable, new()
{
    public void Sort(ref T[] array, bool isIncremental)
    {
        bool hasChanged;

        if (isIncremental)
        {
            do
            {
                hasChanged = false;

                for (var j = 0; j < array.Length - 1; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) >= 0) continue;

                    ISortable<T>.Swap(array, j, j + 1);
                    hasChanged = true;
                }
            } while (hasChanged);
        }
        else
        {
            do
            {
                hasChanged = false;

                for (var j = 0; j < array.Length - 1; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) <= 0) continue;

                    ISortable<T>.Swap(array, j, j + 1);
                    hasChanged = true;
                }
            } while (hasChanged);
        }
    }
}