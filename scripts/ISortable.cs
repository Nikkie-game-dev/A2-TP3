
using System;

namespace a2tp3.scripts;

public interface ISortable <T> where T : IComparable
{
    public void Sort(ref T[] array, bool isIncremental);

    public static bool IsOrdered(T[] array, bool isIncremental)
    {
        if (isIncremental)
        {
            for (var i = 0; i < array.Length - 1; i++)
            {
                if (array[i].CompareTo(array[i + 1]) > 0) return false;
            }

        }
        else
        {
            for (var i = 0; i < array.Length - 1; i++)
            {
                if (array[i].CompareTo(array[i + 1]) <= 0) return false;
            }
        }

        return true;
    }
}