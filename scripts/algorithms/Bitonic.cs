// 12/10/2025 - a2-tp3

using System;
using System.Linq;
using Godot;

namespace a2tp3.scripts.algorithms;

public class Bitonic<T> : ISortable<T> where T : IComparable, new()
{

    public Bitonic(ref T[] array)
    {
        var k = MathF.Log2(array.Length);
        
        if (Mathf.IsEqualApprox(k - (int)k, 0f)) return;
        
        // add padding with inf 
        for (int i = 0; i < Mathf.Pow(2, (int)k + 1); i++)
        {
            array = array.Append(new T()).ToArray();
        }
    }
    
    public void Sort(ref T[] array, bool isIncremental)
    {
        var groupSize = array.Length / 2;
        Divide(array, groupSize, out var g1, out var g2);

        if (groupSize > 1)
        {
            Sort(ref g1, isIncremental);
            Sort(ref g2, !isIncremental);
        }
        
        CheckAndSwap(g1, g2, isIncremental);
        array = Merge(g1, g2);

    }

    private static void Divide(T[] array, int halfSize, out T[] g1, out T[] g2)
    {
        g1 = new T[halfSize];
        g2 = new T[halfSize];


        for (var i = 0; i < halfSize; i++)
        {
            g1[i] = array[i];
        }

        for (var i = 0; i < halfSize; i++)
        {
            g2[i] = array[i + halfSize];
        }
    }

    private static T[] Merge(T[] g1, T[] g2)
    {
        var array = new T[g1.Length + g2.Length];

        for (var i = 0; i < g1.Length; i++)
        {
            array[i] = g1[i];
        }

        for (var i = 0; i < g2.Length; i++)
        {
            array[i + g1.Length] = g2[i];
        }

        return array;
    }

    private static void CheckAndSwap(T[] g1, T[] g2, bool isIncremental)
    {
        for (var i = 0; i < g1.Length; i++)
        {
            switch (isIncremental)
            {
                case true when g1[i].CompareTo(g2[i]) < 0:
                    (g1[i], g2[i]) = (g2[i], g1[i]);
                    break;
                case false when g1[i].CompareTo(g2[i]) > 0:
                    (g2[i], g1[i]) = (g1[i], g2[i]);
                    break;
            }
        }
    }
}