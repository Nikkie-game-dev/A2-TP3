// 17/10/2025 - a2-tp3

using System;

namespace a2tp3.scripts.algorithms;

// Because it's a double linear loop: O(n^2)
public class Cocktail<T> : ISortable<T> where T : IComparable, new()
{
    public void Sort(ref T[] array, bool isIncremental)
    {
        bool hasChanged;

        if (isIncremental)
        {
            do
            {
                hasChanged = false;

                for (var i = 0; i < array.Length - 1; i++)
                {
                    if (array[i].CompareTo(array[i + 1]) >= 0) continue;

                    ISortable<T>.Swap(array, i, i + 1);
                    hasChanged = true;
                }

                for (var i = array.Length - 1; i > 0; --i)
                {
                    if (array[i - 1].CompareTo(array[i]) >= 0) continue;

                    ISortable<T>.Swap(array, i - 1, i);
                    hasChanged = true;
                }
            } while (hasChanged);
        }
        else
        {
            do
            {
                hasChanged = false;

                for (var i = 0; i < array.Length - 1; i++)
                {
                    if (array[i].CompareTo(array[i + 1]) <= 0) continue;

                    ISortable<T>.Swap(array, i, i + 1);
                    hasChanged = true;
                }

                for (var i = array.Length - 1; i > 0; --i)
                {
                    if (array[i - 1].CompareTo(array[i]) <= 0) continue;

                    ISortable<T>.Swap(array, i - 1, i);
                    hasChanged = true;
                }
            } while (hasChanged);
        }
    }
}