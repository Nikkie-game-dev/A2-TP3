// 07/11/2025 - a2-tp3

using System;
using Godot;

namespace a2tp3.scripts.algorithms;

public class Bogo<T> : ISortable<T> where T : IComparable, new()
{
    public void Sort(ref T[] array, bool isIncremental)
    {
        for (var i = 0; i < array.Length; i++)
        {
            ISortable<T>.Swap(array, i,GD.RandRange(0, array.Length - 1));
        }
    }
}