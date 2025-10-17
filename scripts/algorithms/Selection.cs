using System;

namespace a2tp3.scripts.algorithms;

public class Selection<T> : ISortable<T> where T : IComparable, new()
{
    public void Sort(ref T[] array, bool isIncremental)
    {
        if (isIncremental)
        {
            for (var i = 0; i < array.Length; i++)
            {
                var smallestPos = FindSmallestPos(array, i);

                (array[i], array[smallestPos]) = (array[smallestPos], array[i]);
            }
        }
        else
        {
            for (var i = 0; i < array.Length; i++)
            {
                var biggestPos = FindBiggestPos(array, i);

                (array[i], array[biggestPos]) = (array[biggestPos], array[i]);
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
        var smallest = start;

        for (var i = smallest; i < array.Length; i++)
        {
            if (array[i].CompareTo(array[smallest]) < 0)
            {
                smallest = i;
            }
        }

        return smallest;
    }
}