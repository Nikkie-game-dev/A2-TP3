// 16/11/2025 - a2-tp3

using System;
using Godot;

namespace a2tp3.scripts.algorithms;

public class Intro<T> : ISortable<T> where T : IComparable, new()
{
    private const int SizeLimit = 16; // by research
    public static void Sort(ref T[] array, bool isIncremental)
    {
        var depthLimit = 2 * (int) Mathf.Log(array.Length);

        IntroSort(array, depthLimit, isIncremental);
    }

    private static void IntroSort(T[] array, int depthLimit, bool isIncremental)
    {
        /*if (array.Length < SizeLimit)
        {
            Insertion<T>.Sort(ref array, isIncremental);
        }
        else if (depthLimit == 0)
        {
            Heap<T>.Sort(ref array, isIncremental);
        }
        else
        {
            Quick<T>.Sort();
        }*/
    }
}