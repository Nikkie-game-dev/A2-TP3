// 15/11/2025 - a2-tp3

using System;

namespace a2tp3.scripts.algorithms;

// f(n) = O(n log(n)) as worst case
public class Merge<T> : ISortable<T> where T : IComparable, new()
{
    public static void Sort(ref T[] array, bool isIncremental)
    {
        Divide(array, out array, isIncremental);
    }

    private static void Divide(in T[] array, out T[] sorted, bool isIncremental)
    {
        var arrayLengthHalf = array.Length / 2;
        var left = new T[arrayLengthHalf];
        var right = new T[arrayLengthHalf];

        for (var i = 0; i < left.Length; i++)
        {
            left[i] = array[i];
        }

        for (var i = 0; i < right.Length; i++)
        {
            right[i] = array[i + arrayLengthHalf];
        }

        if (array.Length > 2)
        {
            Divide(left, out left, isIncremental);
            Divide(right, out right, isIncremental);
        }

        Conquer(left, right, out sorted, isIncremental);
    }

    private static void Conquer(in T[] left, in T[] right, out T[] merged, bool isIncremental)
    {
        merged = new T[left.Length + right.Length];
        var leftCount = 0;
        var rightCount = 0;
        for (var i = 0; i < merged.Length;)
        {
            if (ISortable<T>.IsOrdered(left[leftCount], right[rightCount], isIncremental))
            {
                merged[i] = left[leftCount];
                leftCount++;
            }
            else
            {
                merged[i] = right[rightCount];
                rightCount++;
            }

            i++;

            if (leftCount >= left.Length && rightCount < right.Length)
            {
                for (var j = i; j < merged.Length; j++)
                {
                    merged[j] = right[rightCount];
                    rightCount++;
                }

                break;
            }

            if (rightCount >= right.Length && leftCount < left.Length)
            {
                for (var j = i; j < merged.Length; j++)
                {
                    merged[j] = left[leftCount];
                    leftCount++;
                }

                break;
            }
        }
    }
}