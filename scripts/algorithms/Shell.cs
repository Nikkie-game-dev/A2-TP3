// 07/11/2025 - a2-tp3

using System;

namespace a2tp3.scripts.algorithms;

public class Shell<T> : ISortable<T> where T : IComparable, new()
{
    public void Sort(ref T[] array, bool isIncremental)
    {
        var k = 0;
        var gap = array.Length / (int)MathF.Pow(2, k); // original shell's gap

        while (gap > 1)
        {
            k++;
            gap = array.Length / (int)MathF.Pow(2, k);
            
            for (var i = 0; i < array.Length && i + gap < array.Length; i++)
            {
                var isBigger = array[i].CompareTo(array[i + gap]) < 0;
                if ((isBigger && isIncremental) ||
                    (!isBigger && !isIncremental))
                {
                    ISortable<T>.Swap(array, i, i + gap);
                }
            }

            gap /= 2;
        }

        for (var i = 1; i < array.Length; i++)
        {
            var n = i;
            while (n > 0 &&
                   ((array[n].CompareTo(array[n - 1]) > 0 && isIncremental) ||
                    (array[n].CompareTo(array[n - 1]) < 0 && !isIncremental)))
            {
                ISortable<T>.Swap(array, n, n - 1);
                n--;
            }
        }
    }
}