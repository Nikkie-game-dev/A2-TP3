// 12/10/2025 - a2-tp3

using System;
using System.Linq;
using Godot;

namespace a2tp3.scripts.algorithms;

// f(n) = O(log(n)) as worst case
public class Bitonic<T> : ISortable<T> where T : IComparable, new()
{
    public static void Sort(ref T[] array, bool isIncremental)
    {
        var k = MathF.Log2(array.Length);

        if (!Mathf.IsEqualApprox(k - (int)k, 0f))
        {
            for (var i = 0; i < Mathf.Pow(2, (int)k + 1); i++)
            {
                array = array.Append(new T()).ToArray();
            }
        }

        BitonicSort(ref array, 0, array.Length, isIncremental);
    }

    private static void BitonicSort(ref T[] array, int start, int end, bool isIncremental)
    {
        var mid = end / 2;

        if (mid <= 1) return;
        
        BitonicSort(ref array, start, mid, isIncremental);
        BitonicSort(ref array, start + mid, end, !isIncremental);

        Merge(ref array, start, end, isIncremental);
    }

    private static void Merge(ref T[] array, int start, int end, bool isIncremental)
    {
        if (end - start <= 1) return;
        var mid = end / 2;

        CheckAndSwap(ref array, start, end, isIncremental);

        Merge(ref array, start, mid, isIncremental);
        Merge(ref array, start + mid, end, isIncremental);
    }

    private static void CheckAndSwap(ref T[] array, int start, int end, bool isIncremental)
    {
        for (int i = start, j = end; i < end; i++)
        {
            switch (isIncremental)
            {
                case true when array[i].CompareTo(array[j]) < 0:
                case false when array[i].CompareTo(array[j]) > 0:
                    (array[i], array[j]) = (array[j], array[i]);
                    break;
            }
        }
    }
}