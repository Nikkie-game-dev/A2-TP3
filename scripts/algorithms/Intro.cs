// 16/11/2025 - a2-tp3

using System;
using Godot;

namespace a2tp3.scripts.algorithms;

// f(n) = O(n log(n)) as worst case
public class Intro<T> : ISortable<T> where T : IComparable, new()
{
    private const int SizeLimit = 16; // by research

    public static void Sort(ref T[] array, bool isIncremental)
    {
        var depthLimit = 2 * (int)Mathf.Log(array.Length);

        IntroSort(array, depthLimit, isIncremental, 0, array.Length);
    }

    private static void LemutoPart(T[] array, bool isIncremental, out int pivotPos, in int start, in int end)
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

    private static void IntroSort(T[] array, int depthLimit, bool isIncremental, in int start, in int end)
    {
        if (array.Length < SizeLimit)
        {
            Insertion<T>.Sort(ref array, isIncremental);
        }
        else if (depthLimit == 0)
        {
            Heap<T>.Sort(ref array, isIncremental);
        }
        else
        {
            LemutoPart(array, isIncremental, out int pivotPos, start, end);

            IntroSort(array, depthLimit - 1, isIncremental, start, pivotPos - 1);
            IntroSort(array, depthLimit - 1, isIncremental, pivotPos + 1, end);
        }
    }
}