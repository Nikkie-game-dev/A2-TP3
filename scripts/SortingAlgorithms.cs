using System;
using System.Linq;
using Godot;

namespace a2tp3.scripts;

public enum Order
{
    Decreasing,
    Increasing
}

public class SortingAlgorithms<T>()
    where T : IComparable, new()
{
    public void DoBitonic(ref T[] array, Order order)
    {
        CheckEmptyOrNull(array);
        
        var k = MathF.Log2(array.Length);
        if (!Mathf.IsEqualApprox(k - (int)k, 0f))
        {
            // add padding with inf 
            for (int i = 0; i < Mathf.Pow(2, (int) k + 1); i++)
            {
                array = array.Append(new T()).ToArray();
            }
        }

        var bitonic = new Bitonic<T>();
        bitonic.Sort(ref array, order == Order.Increasing);
    }

    private static void CheckEmptyOrNull(T[] list)
    {
        if (list == null || list.Length == 0) throw new EmptyArray();
    }
    
}