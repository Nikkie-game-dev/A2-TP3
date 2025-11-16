// 17/10/2025 - a2-tp3

using System;
using System.Collections.Generic;

namespace a2tp3.scripts.algorithms;

public class Quick<T> : ISortable<T> where T : IComparable, new()
{
    public static void Sort(ref T[] array, bool isIncremental)
    {
        var pivotPosition = array.Length - 1;
        Sort(ref array, isIncremental, pivotPosition);
    }

    private static void Sort(ref T[] array, bool isIncremental, int pivot)
    {
        if (array.Length <= 1) return;

        var rightSide = new List<T>();
        var leftSide = new List<T>();


        if (isIncremental)
        {
            foreach (var element in array)
            {
                if (array[pivot].CompareTo(element) >= 0 )
                {
                    rightSide.Add(element);
                }
                else
                {
                    leftSide.Add(element);
                }
            }
        }
        else
        {
            foreach (var element in array)
            {
                if (array[pivot].CompareTo(element) < 0 )
                {
                    rightSide.Add(element);
                }
                else
                {
                    leftSide.Add(element);
                }
            }
        }

        var rs = rightSide.ToArray();
        var ls = leftSide.ToArray();
        
        Sort(ref rs, isIncremental, pivot == 0 ? rs.Length - 1 : 0);
        Sort(ref ls, isIncremental, pivot == 0 ? ls.Length - 1 : 0);

        Merge(ref array, rightSide, leftSide);
    }

    private static void Merge(ref T[] array, List<T> rightSide, List<T> leftSide)
    {
        for (var i = 0; i < leftSide.Count; i++)
        {
            array[i] = leftSide[i];
        }

        for (var i = 0; i < rightSide.Count; i++)
        {
            array[i + leftSide.Count] = rightSide[i];
        }
    }
}