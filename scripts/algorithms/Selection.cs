using System;

namespace a2tp3.scripts.algorithms;

// Because it's a double linear loop: O(n^2)
public class Selection<T> : ISortable<T> where T : IComparable, new()
{
    public static void Sort(ref T[] array, bool isIncremental)
    {
        if (isIncremental)
        {
            for (var i = 0; i < array.Length; i++)
            {
                var smallestPos = FindSmallestPos(array, i);
                ISortable<T>.Swap(array, i, smallestPos);
            }
        }
        else
        {
            for (var i = 0; i < array.Length; i++)
            {
                var biggestPos = FindBiggestPos(array, i);
                ISortable<T>.Swap(array, i, biggestPos);
            }
        }
    }
    private static int FindSmallestPos(T[] array, int start)
    {
        var smallest = start;

        for (var i = smallest; i < array.Length; i++)
        {
            if (array[i].CompareTo(array[smallest]) > 0)
            {
                smallest = i;
            }
        }

        return smallest;
    }
    
    private static int FindBiggestPos(T[] array, int start)
    {
        var biggest = start;

        for (var i = biggest; i < array.Length; i++)
        {
            if (array[i].CompareTo(array[biggest]) < 0)
            {
                biggest = i;
            }
        }

        return biggest;
    }
}