using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace a2tp3.scripts;

public enum Order
{
    Decreasing,
    Increasing
}

public static class SortingAlgorithms<T> where T : IComparable, IEnumerable<T>
{
    
    public static void Bitonic(T[] array, Order order)
    {
        CheckEmptyOrNull(array);
        var rcos = new Rco<T>[array.Length / 2];
        
        for (int i = 0, j = 0; i < rcos.Length; ++i)
        {
            rcos[i].X = array[j];
            rcos[i].Y = array[j + i];
            j += 2;
        }

        while (!Rco<T>.IsOrdered(rcos, order))
        {
            Parallel.ForEach(rcos, rco => rco.Sort(order));
            Rco<T>.Join(rcos);
        }
        
        Rco<T>.Extract(rcos, array);
    }

    private static void CheckEmptyOrNull(T[] array)
    {
        if (array == null || array.Length == 0) throw new EmptyArray();
    }
    
}